using System;
using Feedz.Client.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Feedz.Client.Plumbing.Converters
{
    public class PackageJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => typeof(PackageResource).IsAssignableFrom(objectType);

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var type = jo["type"]?.Value<string>();
            switch (type)
            {
                case "NuGet":
                    return jo.ToObject<NuGetPackageResource>();
                case "Generic":
                    return jo.ToObject<GenericPackageResource>();
                case "Npm":
                    return jo.ToObject<NpmPackageResource>();
                default:
                    throw new NotSupportedException("This version of the client does not support packages of type " + type);
            }
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}