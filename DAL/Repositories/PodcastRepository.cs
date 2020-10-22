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
            //podcastList = GetList();
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

        //Kommenterat bort denna då deserialize inte fungerar..
        //public List<Podcast> GetList()
        //{
        //    List<Podcast> podcasts = new List<Podcast>();
        //    podcasts = dataManager.DeserializePodcast();
        //    return podcasts;
        //}

    }

}
