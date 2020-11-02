using DAL.Repositories;
using Models;
using System.Collections.Generic;

namespace BL.Controllers
{
    public class EpisodeController
    {

        private IEpisodeRepository<Episode> episodeRepository;

        public EpisodeController()
        {
            episodeRepository = new EpisodeRepository();
        }

        public List<Episode> GetEpisodes(string podcast)
        {
            return episodeRepository.GetEpisodesFromPodcastTitle(podcast);
        }
    }
}
