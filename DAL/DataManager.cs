using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    public class DataManager
    {
        public void Serialize(List<Podcast> podcasts)
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
                throw new SerializerException("Persons.xml", "Didn't work");
            }
        }

        public List<Podcast> Deserialize()
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
                throw new SerializerException("Podcast.xml", "Didn't work..");
            }
        }
    }
}
