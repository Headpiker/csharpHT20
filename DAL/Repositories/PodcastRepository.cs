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
            podcastList = getPodcasts();
        }

        public void save()
        {
            dataManager.Serialize(podcastList);
        }

        public void createPodcast(Podcast podcast)
        {
            podcastList.Add(podcast);
            save();
        }

        public List<Podcast> getPodcasts()
        {
            List<Podcast> podcasts = new List<Podcast>();
            podcasts = dataManager.Deserialize();
            return podcasts;
        }

    }

}
