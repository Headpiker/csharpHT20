using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Xml.Serialization;
using System.IO;

namespace DAL
{
    class DataManagerCategory
    {
        public void Serialize(List<Category> categories)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(categories.GetType());
                using (FileStream outFile = new FileStream("Categories.xml", FileMode.Create, FileAccess.Write))
                {
                    xmlSerializer.Serialize(outFile, categories);
                } 
            }
            catch (Exception)
            {
                throw new SerializerException("Categories.xml", "Could not serialize!");
            }
        }

        public List<Category> Deserialize()
        {
            try
            {
                List<Category> categoryListToBeReturned;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Category>));
                using (FileStream inFile = new FileStream("Categories.xml", FileMode.Open, FileAccess.Read))
                {
                    categoryListToBeReturned = (List<Category>)xmlSerializer.Deserialize(inFile);
                }
                return categoryListToBeReturned;
            }
            catch (Exception)
            {
                throw new SerializerException("Categories.xml", "Could not deserialize!");
            }
        }
    }
}
