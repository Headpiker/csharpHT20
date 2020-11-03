using System;

namespace BL2
{
    public class URLException : Exception
    {
        public URLException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
