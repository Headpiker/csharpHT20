using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Validation
    {
        public static bool IsUrlValid(string url)
        {
            if (url.StartsWith("http://") || url.StartsWith("https://"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("URL har inte korrekt format");
                return false;
            }
        }
    }
}
