using Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Rename(int index, string newTitle, List<Podcast> podcastsOfCategory)
        {
            Category category = categoryList.ElementAt(index);
            category.Title = newTitle;
            foreach (Podcast podcast in podcastsOfCategory)
            {
                podcast.Category = newTitle;
            }
            //Podcast podcasts = from podcast in podcastsOfCategory
            //                   join cat in categoryList
            //                   on podcast.Category equals category.Title
            //                   where cat.Title = newTitle
            Save();

        }
    }
}
