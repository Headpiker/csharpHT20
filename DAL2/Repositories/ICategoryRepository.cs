using Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface ICategoryRepository<T> : IRepository<T> where T : Category
    {
        void Rename(int index, string newTitle);
        List<Podcast> Filter(List<string> lista);
    }
}
