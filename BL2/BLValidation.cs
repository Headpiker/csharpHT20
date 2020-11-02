using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class Validation
    {
        public static bool IsUrlValid(string url) //Validering för URL som matas in börjar på rätt sätt
        {
            return url.StartsWith("https://") || url.StartsWith("http://") ? true : false;
        }

        public static bool UrlContainsRSS (string url) //Validering för om den URL som matas in innehåller rss i länken
        {
            return url.Contains("rss") ? true : false;
        }

        public static bool IsFieldNullOrEmpty (string emptyField) //Validering för någon form av inmatning, kollar om fältet innehåller null eller är tomt
        {
            return String.IsNullOrEmpty(emptyField) ? true : false;
        }

        public static bool IsFieldNullOrWhitespace(string emptyWhitespace) //Validering för någon form av inmatning, kollar om fältet innehåller null eller bara whitespace
        {
            return String.IsNullOrWhiteSpace(emptyWhitespace) ? true : false;
        }        
        
        
    }
}
