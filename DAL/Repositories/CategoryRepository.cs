﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository<Category>
    {
        DataManagerCategory dataManager;
        List<Category> categoryList;

        public CategoryRepository()
        {
            categoryList = new List<Category>();
            dataManager = new DataManagerCategory();
            categoryList = GetAll();
        }

        public int GetIndex(string title)
        {
            return GetAll().FindIndex(e => e.Title.Equals(title));
        }

        public void Create(Category category)
        {
            categoryList.Add(category);
            SaveChanges();
        }

        public void Delete (int index)
        {
            categoryList.RemoveAt(index);
            SaveChanges();
        }

        public List<Category> GetAll()
        {
            List<Category> categoryListToBeReturned = new List<Category>();
            try
            {
                categoryListToBeReturned = dataManager.Deserialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Kunde inte hämta kategorier");
            }
            return categoryListToBeReturned;
        }

        public void SaveChanges()
        {
            dataManager.Serialize(categoryList);
        }

        public void Update(int index, Category category)
        {
            if (index >= 0)
            {
                categoryList[index] = category;
            }
            SaveChanges();
        }
    }
}
