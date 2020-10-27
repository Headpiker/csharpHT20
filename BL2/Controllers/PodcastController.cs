using System;
using Models;
using System.Threading.Tasks;
using System.Xml;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.ServiceModel.Syndication;
using DAL.Repositories;
using System.Dynamic;
using System.Windows.Forms;

namespace BL.Controllers
{
    public class PodcastController
    {
        private IPodcastRepository<Podcast> podcastRepository;
        private EpisodeRepository episodeRepository;

        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
            episodeRepository = new EpisodeRepository();
        }
        public void CreatePodcastObject(string title, string url, string category, int updateInterval)
        {
            if (Validation.IsUrlValid(url)) 
            {
                List<Episode> episodes = episodeRepository.GetEpisodesFromRSS(url);
                Podcast podcast = new Podcast(title, url, category, updateInterval, episodes);
                podcastRepository.Create(podcast);
            }
        }

        public List<Podcast> GetAllPodcasts()
        {
            return podcastRepository.GetList();
        }

        public void DeletePodcast(string title)
        {
            int index = podcastRepository.GetIndex(title);
            podcastRepository.Delete(index);
        }

        public int GetIndexByTitle(string title)
        {
            int index = podcastRepository.GetIndex(title);
            return index;
        }

        public string GetUrlByTitle(string title)
        {
            Podcast podcast = podcastRepository.GetTitle(title);
            string url = podcast.Url;
            return url;
        }

        public void UpdatePodcastObject(string title, string url, string category, int updateInterval, int index)
        {
            if (Validation.IsUrlValid(url))
            {
                List<Episode> episodes = episodeRepository.GetEpisodesFromRSS(url);
                Podcast podcast = new Podcast(title, url, category, updateInterval, episodes);
                podcastRepository.Update(index, podcast);
            }
        }

        public void UpdateEpisodes()
        {
            List<Podcast> podcasts = GetAllPodcasts();
            foreach (var item in podcasts)
            {
                string podcastUrl = item.Url;
                List<Episode> episodes = episodeRepository.GetEpisodesFromRSS(podcastUrl);
                item.Episodes = episodes;
            }
            podcastRepository.UpdateEpisodes(podcasts);
        }

    }
}
