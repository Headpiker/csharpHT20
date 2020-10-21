using System;
using DAL.Repositories;
using Models;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BL
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
            Podcast podcast = null;
            if(url == "anrop till valideringsklassen här?") 
            { 
                podcast = new Podcast 
                {
                    Title = title,
                    Url = url,
                    Category = category,
                    UpdateInterval = updateInterval,
                    Episodes = getEpisodes(url)
                };
            }
            podcastRepository.createPodcast(podcast);
        }


        public List<Episode> getEpisodes(string url)
        {
            XmlReader rssReader = XmlReader.Create(url);
            SyndicationFeed rssFeed = SyndicationFeed.Load(rssReader);
            List<Episode> episodes = new List<Episode>();

            foreach (var item in rssFeed.Items)
            {
                Episode episode = new Episode();
                episode.Title = item.Title.Text;
                episode.Description = item.Summary.Text;
                episodes.Add(episode);
            }

            return episodes;
        }

    }
}
