using System.IO;
using System.Windows.Forms;

namespace DAL2
{
    class DALValidation
    {
        public static bool IsFileExisting(string filePath)
        {
            bool isExisting = File.Exists(filePath);
            if (isExisting)
            {
                MessageBox.Show("Hittar inte filen!");
            }
            return isExisting;
        }
    }
}
