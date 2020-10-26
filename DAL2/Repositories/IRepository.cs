using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
      //  List<T> GetList();
        void Save();
        void Delete(int index);
        int GetIndex(string title);
        List<T> GetAll();
    }

}
