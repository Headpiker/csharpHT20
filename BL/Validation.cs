using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    class Validation
    {

        public static bool IsUrlValid(string url)
        {
            if (url.StartsWith("https://"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
