using System.IO;

namespace DAL2
{
    class DALValidation
    {
        public static bool IsFileExisting(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
