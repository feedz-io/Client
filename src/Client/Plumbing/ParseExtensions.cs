using System;

namespace Feedz.Client.Plumbing
{
    public static class ParseExtensions
    {
        public static int? ToInt(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;
            
            if (int.TryParse(str, out var result))
                return result;
            return null;
        }
        
        public static bool? ToBool(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;
            
            if (bool.TryParse(str, out var result))
                return result;
            return null;
        }
        
        public static Guid? ToGuid(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;
            
            if (Guid.TryParse(str, out var result))
                return result;
            return null;
        }
    }
}