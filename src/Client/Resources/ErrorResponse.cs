using System.Collections.Generic;

namespace Feedz.Client.Resources
{
    public class ErrorResponse
    {
       
        public ErrorResponse(string message, IReadOnlyList<string>? extraInformation = null)
        {
            Message = message;
            ExtraInformation = extraInformation;
        }
        
        public string Message { get; }
        public IReadOnlyList<string>? ExtraInformation { get; }
    }
}