using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.ServiceModel.Syndication;

namespace BL.Controllers
{
    class CategoryController
    {
        private ICategoryRepository<Category> categoryRepository;

        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }

        public void CreateCategory(string title)
        {
            Category category = new Category(title);
            categoryRepository.Create(category);
        }

        public void DeleteCategory(string title)
        {
            int index = categoryRepository.GetIndex(title);
            categoryRepository.Delete(index);
        }

        public List<Category> RetriveAllCategories()
        {
            return categoryRepository.GetAll();
        }
    }
}
