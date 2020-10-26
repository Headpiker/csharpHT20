using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace BL
{
    public class Validation
    {
        public static bool IsUrlValid(string url)
        {
            return url.StartsWith("https://") || url.StartsWith("http://") ? true : false;
        }

        public static bool IsDuplicate(string newContent, string[] content) 
        {
            //Jämför inputs och kollar om det är samma, oavsett om det är små eller stora tecken
            return content.Any((i) => String.Equals(i, newContent, StringComparison.OrdinalIgnoreCase)); 
        }
        
        public static bool IsFileExisting (string filePath)
        {
            return File.Exists(filePath);
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
