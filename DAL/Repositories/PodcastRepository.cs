using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL.Repositories
{
    public class PodcastRepository : IPodcastRepository<Podcast>
    {
        DataManager dataManager;
        List<Podcast> podcastList;

        public PodcastRepository()
        {
            podcastList = new List<Podcast>();
            dataManager = new DataManager();
            podcastList = GetAll();
        }

        public void Save()
        {  
            dataManager.SerializePodcast(podcastList);
        }

        public void Create(Podcast podcast)
        {
            podcastList.Add(podcast);
            Save();
        }        

        public List<Podcast> GetAll()
        {
            List<Podcast> podcastListToBeReturned = new List<Podcast>();
            try
            {
                podcastListToBeReturned = dataManager.DeserializePodcast();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Kunde inte hämta podcasts");
            }
            return podcastListToBeReturned;
        }

    }

}
