using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BL.Controllers;
using Models;

namespace BL
{
    public class Validation
    {
        public static bool IsUrlValid(string url)
        {
            bool isUrlValid = url.StartsWith("https://") || url.StartsWith("http://");
            if (!isUrlValid) 
            {
                MessageBox.Show("Se till att URL är korrekt ifylld!");
            }
            return isUrlValid;
        }

        public static bool UrlExsists(string url)
        {
            PodcastController podcastController = new PodcastController();
            List<Podcast> podcasts = podcastController.GetAllPodcasts();
            bool isDuplicate = podcasts.Exists(podcast => podcast.Url == url);

            if (isDuplicate)
            {
                MessageBox.Show("Podcasten med denna url finns redan i din lista!");
            }
            return isDuplicate;
        }

        public static bool IsFieldNullOrEmpty (string emptyField)
        {
            bool isNullOrEmptyOrWhiteSpace = String.IsNullOrEmpty(emptyField) || String.IsNullOrWhiteSpace(emptyField);
            if (isNullOrEmptyOrWhiteSpace) 
            {
                MessageBox.Show("Kontrollera att du fyllt i alla fält!");
            }
            return isNullOrEmptyOrWhiteSpace;
        }

        public static bool IsCategoryDuplicate(string newContent)
        {
            CategoryController categoryController = new CategoryController();
            List<Category> categories = categoryController.GetAllCategories();
            bool isDuplicate = categories.Exists(category => category.Title == newContent);

            if (isDuplicate)
            {
                MessageBox.Show("Kategorin " + newContent + " finns redan!");
            }
            return isDuplicate;
        }

        public static bool IsPodcastDuplicate(string newContent)
        {
            PodcastController podcastController = new PodcastController();
            List<Podcast> podcasts = podcastController.GetAllPodcasts();
            bool isDuplicate = podcasts.Exists(podcast => podcast.Title == newContent);

            if (isDuplicate)
            {
                MessageBox.Show("Podcasten " + newContent + " finns redan!");
            }
            return isDuplicate;
        }
    }
}