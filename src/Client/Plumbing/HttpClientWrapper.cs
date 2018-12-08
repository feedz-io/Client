using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Feedz.Client.Resources;
using Feedz.Client.Resources.Integrations.Octopus;

namespace Feedz.Client.Plumbing
{
    internal interface IHttpClientWrapper : IDisposable
    {
        Task<IReadOnlyList<T>> List<T>(string path);
        Task<T> Get<T>(string path);
        Task<T> Create<T>(string path, Stream stream, string originalFilename, Dictionary<string, string> formValues);
        Task<T> Create<T>(string path, IResource resource = null);
        Task Create(string path, IResource resource = null);
        Task<T> Update<T>(string path, IResource resource);
        Task Remove(string path);
        Uri BaseAddress { get; }
    }

    internal class FeedClientWrapper : HttpClientWrapper
    {
        const string ApiKeyHeader = "Feedz-Api-Key";

        public FeedClientWrapper(Uri baseAddress, string pat)
            : this(new HttpClient() {BaseAddress = baseAddress}, pat)
        {
            OwnsClient = true;
        }

        public FeedClientWrapper(HttpClient client, string pat)
            : base()
        {
            Client = client;
            Client.DefaultRequestHeaders.Add(ApiKeyHeader, pat);
        }
    }

    internal class HttpClientWrapper : IHttpClientWrapper
    {
        protected bool OwnsClient { get; set; }
        protected HttpClient Client { get; set; }

        protected HttpClientWrapper()
        {
        }

        public HttpClientWrapper(Uri baseAddress, string pat)
            : this(new HttpClient() {BaseAddress = baseAddress}, pat)
        {
            OwnsClient = true;
        }

        public HttpClientWrapper(HttpClient client, string pat)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("PAT", pat);
            Client = client;
        }

        public Uri BaseAddress => Client.BaseAddress;

        public Task<IReadOnlyList<T>> List<T>(string path)
            => Get<IReadOnlyList<T>>(path);

        public async Task<T> Get<T>(string path)
        {
            var response = await Client.GetAsync(path);
            var body = await ProcessResponse<T>(path, response);
            return body;
        }

        public async Task<T> Create<T>(string path, Stream stream, string originalFilename, Dictionary<string, string> formValues)
        {
            using (var content = new MultipartFormDataContent())
            using (var streamContent = new StreamContent(stream))
            {
                //    var streamContent = new StreamContent(fileUploadContent.Contents);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                content.Add(streamContent, "file", originalFilename);
                foreach (var pair in formValues)
                    content.Add(new StringContent(pair.Value ?? ""), pair.Key);

                //content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                var response = await Client.PostAsync(path, content);
                var body = await ProcessResponse<T>(path, response);

                return body;
            }
        }

        public async Task<T> Create<T>(string path, IResource resource = null)
        {
            StringContent content = null;
            if (resource != null)
            {
                var json = JsonConvert.SerializeObject(resource);
                content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            var response = await Client.PostAsync(path, content);
            var body = await ProcessResponse<T>(path, response);

            return body;
        }

        public async Task Create(string path, IResource resource = null)
        {
            StringContent content = null;
            if (resource != null)
            {
                var json = JsonConvert.SerializeObject(resource);
                content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            var response = await Client.PostAsync(path, content);
            await ProcessResponse(path, response);
        }

        public async Task<T> Update<T>(string path, IResource resource)
        {
            var json = JsonConvert.SerializeObject(resource);
            var content = new StringContent(json, Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await Client.PutAsync(path, content);
            var body = await ProcessResponse<T>(path, response);

            return body;
        }

        public async Task Remove(string path)
        {
            var response = await Client.DeleteAsync(path);
            await ProcessResponse(path, response);
        }

        private static Task ProcessResponse(string path, HttpResponseMessage response)
            => ProcessResponse<object>(path, response, false);

        private static async Task<T> ProcessResponse<T>(string path, HttpResponseMessage response, bool readResponse = true)
        {
            void CheckSuccess(string content)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new FeedzHttpRequestException(response.StatusCode, "Unauthorised" + (string.IsNullOrWhiteSpace(content) ? "" : $": {content}") );
                if (response.StatusCode == HttpStatusCode.Forbidden)
                    throw new FeedzHttpRequestException(response.StatusCode, "Forbidden" + (string.IsNullOrWhiteSpace(content) ? "" : $": {content}") );
                if (response.StatusCode == HttpStatusCode.NotFound)
                    throw new FeedzHttpRequestException(response.StatusCode, "Not Found: " + path);
                if (response.StatusCode == HttpStatusCode.Conflict)
                    throw new FeedzHttpRequestException(response.StatusCode, "Conflict: " + path);
                
                if (!response.IsSuccessStatusCode)
                {
                    try
                    {
                        if(string.IsNullOrWhiteSpace(content))
                            throw new FeedzHttpRequestException(response.StatusCode, "Server Error");
                            
                        var error = JsonConvert.DeserializeObject<ErrorResponse>(content);
                        throw new FeedzHttpRequestException(response.StatusCode, error.Message);
                    }
                    catch (JsonException)
                    {
                        throw new FeedzHttpRequestException(response.StatusCode, $"Request error {response.StatusCode} to {path}{(string.IsNullOrWhiteSpace(content) ? "" : "\r\n")}{content}");
                    }
                }
            }

            var contentType = response.Content.Headers.ContentType?.MediaType;
            switch (contentType)
            {
                case "application/json":
                    var json = await response.Content.ReadAsStringAsync();
                    CheckSuccess(json);
                    return readResponse
                        ? JsonConvert.DeserializeObject<T>(json)
                        : default(T);

                case "application/octet-stream":
                    CheckSuccess("<Stream>");
                    if (typeof(T) != typeof(Stream))
                        throw new Exception("API returned file, but no file was expected");
                    return readResponse
                        ? (T) (object) await response.Content.ReadAsStreamAsync()
                        : default(T);

                default:
                    var content = await response.Content.ReadAsStringAsync();
                    CheckSuccess(content);

                    return readResponse
                        ? throw new Exception($"API returned an unknown content type '{contentType}': " + content)
                        : default(T);
            }
        }

        public void Dispose()
        {
            if (OwnsClient)
                Client?.Dispose();
        }
    }
}