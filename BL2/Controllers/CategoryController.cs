
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using DAL.Repositories;

namespace BL.Controllers
{
    public class CategoryController
    {
        private ICategoryRepository<Category> categoryRepository;

        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }

        public void CreateCategoryObject(string title)
        {
            Category category = new Category(title);
            categoryRepository.Create(category);
        }

        public void DeleteCategory(string title)
        {
            int index = categoryRepository.GetIndex(title);
            categoryRepository.Delete(index);
        }

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetList();
        }

        public void RenameCategory(string title, string newTitle, List<Podcast> podcasts)
        {
            List<Podcast> podcastsOfCategory = new List<Podcast>();
            int index = categoryRepository.GetIndex(title);
            foreach (Podcast podcast in podcasts)
            {
                if(podcast.Category == title)
                {
                    podcastsOfCategory.Add(podcast);
                }
            }
            categoryRepository.Rename(index, newTitle, podcastsOfCategory);
        }
    }
}
