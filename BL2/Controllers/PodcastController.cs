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

        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
        }
        public void CreatePodcastObject(string title, string url, string category, int updateInterval)
        {
                List<Episode> episodes = GetEpisodes(url);
                Podcast podcast = new Podcast(title, url, category, updateInterval, episodes);
                podcastRepository.Create(podcast);   
        }
        public List<Episode> GetEpisodes(string url)
        {
            XmlReader rssReader = XmlReader.Create(url);
            SyndicationFeed rssFeed = SyndicationFeed.Load(rssReader);

            List<Episode> episodes = new List<Episode>();
            foreach (SyndicationItem item in rssFeed.Items)
            {
                Episode episode = new Episode();
                episode.Title = item.Title.Text;
                episode.Description = item.Summary.Text;
                episodes.Add(episode);
            }
            return episodes;
        }

        public List<Podcast> GetAllPodcasts()
        {
            return podcastRepository.GetList();
        }



    }
}
