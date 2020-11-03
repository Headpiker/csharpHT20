using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BL.Controllers;
using BL2;
using Models;

namespace BL
{
    public class Validation
    {
        public static bool IsUrlValid(string url)
        {
            try
            {
                bool isUrlValid = url.StartsWith("https://") || url.StartsWith("http://");
                if (!isUrlValid)
                {
                    MessageBox.Show("Se till att URL är korrekt ifylld!");
                }
                return isUrlValid;
            }
            catch (Exception)
            {
                throw new URLException("Ogiltig url!");
            }
        }

        public static bool UrlContainsRSS(string url)
        {
            try
            {
                bool isUrlValid = url.Contains("rss") || url.Contains("feed");
                if (!isUrlValid)
                {
                   MessageBox.Show("Denna url innehåller ingen RSS, avsnitt går inte att hämta!");
                }
                return isUrlValid;
            }
            catch (Exception)
            {
                throw new URLException("Url innehöll ingen RSS!");
            }
        }

        public static bool UrlExsists(string url)
        {
            try
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
            catch (Exception)
            {
                throw new URLException("Podcasten finns redan!"); 
            }
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