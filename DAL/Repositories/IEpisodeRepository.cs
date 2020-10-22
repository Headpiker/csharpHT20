using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface IEpisodeRepository<T> : IRepository<T> where T : Episode
    {
    }
}
