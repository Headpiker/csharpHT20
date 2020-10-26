using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    public class DataManager
    {
        public void SerializePodcast(List<Podcast> podcasts)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(podcasts.GetType());
                using (FileStream Outfile = new FileStream("Podcasts.xml", FileMode.Create, FileAccess.Write))
                {
                    xmlSerializer.Serialize(Outfile, podcasts);
                }
            }
            catch (Exception)
            {
                throw new SerializerException("Podcasts.xml", "Didn't work");
            }
        }

        public List<Podcast> DeserializePodcast()
        {
            try
            {

                List<Podcast> podcastsToBeReturned;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Podcast>));
                using (FileStream inFile = new FileStream("Podcasts.xml", FileMode.Open, FileAccess.Read))
                {
                    podcastsToBeReturned = (List<Podcast>)xmlSerializer.Deserialize(inFile);
                }
                return podcastsToBeReturned;

            }
            catch (Exception)
            {
                throw new SerializerException("Podcasts.xml", "Didn't work..");
            }
        }

        public void SerializeCategory(List<Category> categories)
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

        public List<Category> DeserializeCategory()
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
