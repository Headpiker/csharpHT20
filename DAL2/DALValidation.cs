using System.IO;

namespace DAL2
{
    class DALValidation
    {
        public static bool IsFileExisting(string filePath) //Validering för om filen existerar
        {
            return File.Exists(filePath);
        }
    }
}
