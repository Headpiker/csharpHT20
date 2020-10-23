using System;
using Models;
using System.Threading.Tasks;
using System.Xml;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.ServiceModel.Syndication;
using DAL.Repositories;

namespace BL.Controllers
{
    public class PodcastController
    {
        private IPodcastRepository<Podcast> podcastRepository;
        private EpisodeController episodeController;

        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
            episodeController = new EpisodeController();
        }
        public void CreatePodcastObject(string title, string url, string category, int updateInterval)
        {
            if (Validation.IsUrlValid(url)) 
            {
                List<Episode> episodes = episodeController.GetEpisodes(url);
                Podcast podcast = new Podcast(title, url, category, updateInterval, episodes);
                podcastRepository.Create(podcast);
            }
        }

        public List<Podcast> GetAllPodcasts()
        {
            return podcastRepository.GetList();
        }



    }
}
