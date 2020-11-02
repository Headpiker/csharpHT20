using Models;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.Repositories
{
    public class EpisodeRepository : IEpisodeRepository<Episode>
    {
        DataManager dataManager;
        List<Episode> episodeList;

        public EpisodeRepository()
        {
            episodeList = new List<Episode>();
            dataManager = new DataManager();
        }

        //Hämtar alla avsnitt som finns i den url som används när man lägger till en ny podcast
        public async Task<List<Episode>> GetEpisodesFromRSS(string url)
        {
            XmlReader rssReader = XmlReader.Create(url);
            SyndicationFeed rssFeed = await Task.Run(() => SyndicationFeed.Load(rssReader));

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

        public List<Episode> GetEpisodesFromPodcastTitle(string podcastTitle)
        {
            List<Episode> episodes = new List<Episode>();

            return episodes;
        }
    }
}
