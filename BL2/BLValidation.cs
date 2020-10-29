using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class Validation
    {
        public static bool IsUrlValid(string url)
        {
            return url.StartsWith("https://") || url.StartsWith("http://") ? true : false;
        }

        public static bool UrlContainsRSS (string url)
        {
            return url.Contains("rss") ? true : false;
        }

        public static bool IsFieldNullOrEmpty (string emptyField)
        {
            return String.IsNullOrEmpty(emptyField) ? true : false;
        }

        public static bool IsFieldNullOrWhitespace(string emptyWhitespace)
        {
            return String.IsNullOrWhiteSpace(emptyWhitespace) ? true : false;
        }        
        
        
    }
}
