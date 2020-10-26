using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface IPodcastRepository<T> : IRepository<T> where T : Podcast
    {
        
    }
}
