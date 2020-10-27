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

        public void Rename(int index, string newTitle, List<Podcast> podcastsOfCategory)
        {
            Category category = categoryList.ElementAt(index);
            category.Title = newTitle;
            PodcastRepository podcastRepository = new PodcastRepository();
            foreach (Podcast podcast in podcastsOfCategory)
            {
                podcast.Category = newTitle;
               // MessageBox.Show(podcast.Category.ToString());
            }

            //var items = from item in xmlDoc.Descendants("item")
            //            where item.Element("itemID").Value == itemID
            //            select item;

            //foreach (XElement itemElement in items)
            //{
            //    itemElement.SetElementValue("name", "Lord of the Rings Figures");
            //}
            Save();
            podcastRepository.Save();
        }
    }
}
