using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface ICategoryRepository<T> : IRepository<T> where T : Category
    {
        void Update(int index, Category category);
        void Rename(int index, string newTitle);
        List<Podcast> Filter(List<string> lista);
    }
}
