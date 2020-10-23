using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    class Validation
    {

        public static bool IsUrlValid(string url)
        {
            if (url.StartsWith("http://"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("URL är inte i korrekt format"); 
                return false;
            }
        }
    }
}
