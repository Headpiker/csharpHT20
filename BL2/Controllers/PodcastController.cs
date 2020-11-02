using Models;
using System.Collections.Generic;
using DAL.Repositories;

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
        public async void CreatePodcastObject(string title, string url, string category, int updateInterval)
        {
            List<Episode> episodes = await episodeRepository.GetEpisodesFromRSS(url);
            Podcast podcast = new Podcast(title, url, category, updateInterval, episodes);
            podcastRepository.Create(podcast);
        }

        public List<Podcast> GetAllPodcasts()
        {
            return podcastRepository.GetAll();
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

        public async void UpdatePodcastObject(string title, string url, string category, int updateInterval, int index)
        {
            List<Episode> episodes = await episodeRepository.GetEpisodesFromRSS(url);
            Podcast podcast = new Podcast(title, url, category, updateInterval, episodes);
            podcastRepository.Update(index, podcast);
        }

        public async void UpdateEpisodes()
        {
            List<Podcast> podcasts = GetAllPodcasts();
            foreach (var item in podcasts)
            {
                if (item.NeedsUpdate)
                {
                    item.Update();
                    string podcastUrl = item.Url;
                    List<Episode> episodes = await episodeRepository.GetEpisodesFromRSS(podcastUrl);
                    item.Episodes = episodes;
                }
            }
            podcastRepository.Save(podcasts);
        }
    }
}
