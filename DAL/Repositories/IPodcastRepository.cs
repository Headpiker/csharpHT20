using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL.Repositories
{
    public interface IPodcastRepository<T> : IRepository<T> where T : Podcast
    {
        
        void Save();

        //Kommenterat bort denna då deserialize inte fungerar..
        //List<T> GetList();


    }
}
