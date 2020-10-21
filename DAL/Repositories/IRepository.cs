using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        void save();
        void createPodcast(T podcast);


    }
    
}
