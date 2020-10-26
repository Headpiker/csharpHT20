using System;
using System.Collections.Generic;
using System.Linq;
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
            podcastList = GetList();
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

        public void Delete(int index)
        {
            podcastList.RemoveAt(index);
            Save();
        }

        public List<Podcast> GetList()
        {
            List<Podcast> podcastList = new List<Podcast>();
            try
            {
                podcastList = dataManager.DeserializePodcast();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Kunde inte hämta podcasts");
            }
            return podcastList;
        }
    }

}
