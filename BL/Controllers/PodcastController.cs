using System;
using DAL.Repositories;
using Models;
using System.Threading.Tasks;
using System.Xml;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.ServiceModel.Syndication;

namespace BL.Controllers
{
    public class PodcastController
    {
        private IPodcastRepository<Podcast> podcastRepository;

        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
        }

        public void test()
        {
            XmlReader rssReader = XmlReader.Create("https://www.svt.se/nyheter/rss.xml");

            SyndicationFeed rssFeed = SyndicationFeed.Load(rssReader);

            string podcastTitle = rssFeed.Title.Text;
            string podcastDescription = rssFeed.Description.Text;

            Console.WriteLine(podcastTitle);
            Console.WriteLine(podcastDescription);
        }
        public void CreatePodcastObject(string title, string url, string category, int updateInterval)
        {
            //Console.WriteLine(url);
            //    XmlReader rssReader = XmlReader.Create(url);
            
                //SyndicationFeed rssFeed = SyndicationFeed.Load(rssReader);

                //string podcastTitle = rssFeed.Title.Text;
                //string podcastDescription = rssFeed.Description.Text;
                //Console.WriteLine("Podcast title: " + podcastTitle);
                //Console.WriteLine("Podcast description: " + podcastDescription);




                //Min urspringliga kod:
                //List<Episode> episodes = GetEpisodes(url);
                /*
                Podcast podcast = new Podcast(title, url, category, updateInterval);//<episodes);
                podcastRepository.Create(podcast);
                */
        }
        public List<Episode> GetEpisodes(string url)
        {
            XmlReader rssReader = XmlReader.Create(url);
            SyndicationFeed rssFeed = SyndicationFeed.Load(rssReader);
            
            string podcastTitle = rssFeed.Title.Text;
            string podcastDescription = rssFeed.Description.Text;
            Console.WriteLine("Podcast title: " + podcastTitle);
            Console.WriteLine("Podcast description: " + podcastDescription);

            List<Episode> episodes = new List<Episode>();
            foreach (SyndicationItem item in rssFeed.Items)
            {
                Episode episode = new Episode();
                episode.Title = item.Title.Text;
                episode.Description = item.Summary.Text;
                episodes.Add(episode);
                Console.WriteLine(episode.Title);
            }
            return episodes;
        }

        public List<Podcast> GetAllPodcasts()
        {
            return podcastRepository.GetList();
        }



    }
}
