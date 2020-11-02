
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using DAL.Repositories;
using System.Windows.Forms;

namespace BL.Controllers
{
    public class CategoryController
    {
        private ICategoryRepository<Category> categoryRepository;
        PodcastRepository podcastRepository = new PodcastRepository();

        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }

        public void CreateCategoryObject(string title)
        {
            try {
                Category category = new Category(title);
                categoryRepository.Create(category);
            }
            catch (Exception ex) { MessageBox.Show("Något gick fel, pröva igen!" + "\n" + ex.Message); }

        }

        public void DeleteCategory(string title) //Raderar kategori med tillhörande podcasts
        {
            try
            {
                int index = categoryRepository.GetIndex(title);
                categoryRepository.Delete(index);
                podcastRepository.DeleteOfCategory(title);
            }
            catch (Exception ex) { MessageBox.Show("Något gick fel, pröva igen!" + "\n" + ex.Message); }

        }

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetAll();
        }

        public void RenameCategory(string title, string newTitle)
        {
            try
            {
                int index = categoryRepository.GetIndex(title);
                categoryRepository.Rename(index, newTitle);
                podcastRepository.RenameCategoryOfPodcast(title, newTitle); //Anrop för att uppdatera kategori på podcasts
            }
            catch (Exception ex) { MessageBox.Show("Något gick fel, pröva igen!" + "\n" + ex.Message); }

        }

        /*Tar en lista av strings dvs de valda kategoriernas titlar som parameter som skickas med som parameter
         * till Filter metoden i categoryRepository. Metoden returnerar en lista med de podcasts som man filtrerat utifrån.*/
        public List<Podcast> FilterPodcasts(List<string> categories) 
        {
            List<Podcast> filteredPodcasts = categoryRepository.Filter(categories);
            return filteredPodcasts;
        }
    }
}
