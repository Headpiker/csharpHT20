using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface ICategoryRepository<T> : IRepository<T> where T : Category
    {
        int GetIndex(string title);
        void Delete(int index);
        List<Category> GetAll();
        void SaveChanges();
        void Update(int index, Category category);
    }
}
