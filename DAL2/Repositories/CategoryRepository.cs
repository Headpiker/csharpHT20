using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository<Category>
    {
        DataManager dataManager;
        List<Category> categoryList;

        public CategoryRepository()
        {
            categoryList = new List<Category>();
            dataManager = new DataManager();
            categoryList = GetList();
        }

        public int GetIndex(string title)
        {
            return GetList().FindIndex(e => e.Title.Equals(title));
        }

        public void Create(Category category)
        {
            categoryList.Add(category);
            Save();
        }

        public void Delete (int index)
        {
            categoryList.RemoveAt(index);
            Save();
        }

        public List<Category> GetList()
        {
            List<Category> categoryList = new List<Category>();
            try
            {
                categoryList = dataManager.DeserializeCategory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Kunde inte hämta kategorier");
            }
            return categoryList;
        }

        public void Save()
        {
            dataManager.SerializeCategory(categoryList);
        }

        public void Update(int index, Category category)
        {
            if (index >= 0)
            {
                categoryList[index] = category;
            }
            Save();
        }

        public List<Category> GetAll()
        {
            List<Category> categorys = new List<Category>();
            categorys = dataManager.DeserializeCategory();
            return categorys;
        }
    }
}
