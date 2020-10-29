using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            categoryList = GetAll();
        }

        public int GetIndex(string title)
        {
            return GetAll().FindIndex(e => e.Title.Equals(title));
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

        public List<Category> GetAll()
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

        public void Rename(int index, string newTitle) //Ändrar kategorins titel
        {
            Category category = categoryList.ElementAt(index);
            category.Title = newTitle;
            Save();
        }

        public List<Podcast> Filter(List<string> categoriesToFilterBy)
        {
            PodcastRepository podcastRepository = new PodcastRepository();
            List<Podcast> allPodcasts = podcastRepository.GetAll();
            List<Podcast> filteredPodcasts = new List<Podcast>();
            foreach (string category in categoriesToFilterBy) /*Går genom alla kategorier som är "checkade" och lägger till
                                                               *alla podcasts av de kategorierna i den nya listan*/
            {
                filteredPodcasts.AddRange(allPodcasts.Where(x => x.Category.Contains(category)));
            }
            return filteredPodcasts;
        }
    }
}
