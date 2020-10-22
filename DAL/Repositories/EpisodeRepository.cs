using Models;
using System;
using System.Collections.Generic;
using System.Text;

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
        //public List<Episode> GetEpisodes()
        //{
        //    List<Podcast> episodes = new List<Episode>();

        //    return episodes;
        //}
    }
}
