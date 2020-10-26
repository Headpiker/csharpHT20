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
    }
}
