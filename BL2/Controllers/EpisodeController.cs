using DAL.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace BL.Controllers
{
    public class EpisodeController
    {

        private IEpisodeRepository<Episode> episodeRepository;

        public EpisodeController()
        {
            episodeRepository = new EpisodeRepository();
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
    }
}
