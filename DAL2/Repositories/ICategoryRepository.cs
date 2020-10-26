using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface ICategoryRepository<T> : IRepository<T> where T : Category
    {
        int GetIndex(string title);
        void Update(int index, Category category);
        void Rename(int index, string newTitle, List<Podcast> podcasts);
    }
}
