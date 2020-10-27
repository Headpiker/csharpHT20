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

        public int GetIndex (string title)
        {
            return GetAll().FindIndex(a => a.Title.Equals(title));
        }

        public Podcast GetTitle(string title)
        {
            return GetAll().First(a => a.Title.Equals(title));
        }

        public List<Podcast> GetAll()
        {
            List<Podcast> podcasts = new List<Podcast>();
            podcasts = dataManager.DeserializePodcast();
            return podcasts;
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

        public void Update(int index, Podcast newPodcast)
        {
            if(index >= 0)
            {
                podcastList[index] = newPodcast;
            }
            Save();
        }

        public void UpdateEpisodes(List<Podcast> podcast)
        {
            dataManager.SerializePodcast(podcast);
        }


    }

}
