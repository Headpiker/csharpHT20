using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL.Repositories
{
    public interface IPodcastRepository<T> : IRepository<T> where T : Podcast
    {
        void Create(T podcast);
        void Save();
        //List<T> GetList();


    }
}
