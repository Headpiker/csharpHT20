using BL.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Grupp9
{
    public partial class Form1 : Form
    {
        PodcastController podcastController;
        CategoryController categoryController;
        EpisodeController episodeController;
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            categoryController = new CategoryController();
            episodeController = new EpisodeController();
            displayCategories();
            displayUpdateInterval();
            displayPodcasts();

            lvPodcasts.FullRowSelect = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNyPodd_Click(object sender, EventArgs e)
        {            
            string category = this.cbKategori.GetItemText(this.cbKategori.SelectedItem);
            string updateIntervalString = this.cbFrekvens.GetItemText(this.cbFrekvens.SelectedItem);
            int updateInterval = Convert.ToInt32(updateIntervalString);
            podcastController.CreatePodcastObject(txtPoddNamn.Text.ToString(), txtUrl.Text.ToString(), category, updateInterval);
            displayPodcasts();
        }

        private void btnNyKategori_Click(object sender, EventArgs e)
        {
            categoryController.CreateCategoryObject(tbValdKategori.Text);
            displayCategories();
            tbValdKategori.Clear();
        }
        private void displayPodcasts()
        {
            lvPodcasts.Items.Clear();
            
            foreach (var item in podcastController.GetAllPodcasts())
            {
                if(item != null)
                {
                    ListViewItem newList = new ListViewItem(item.Title); 
                    newList.SubItems.Add("Antal");                      //Antal är hårdkodat just nu
                    newList.SubItems.Add(item.UpdateInterval.ToString());
                    newList.SubItems.Add(item.Category);
                    lvPodcasts.Items.Add(newList);
                }
            }
        }
        private void displayCategories()
        {
            lbKategorier.Items.Clear();
            cbKategori.Items.Clear();

            foreach (var item in categoryController.GetAllCategories())
            {
                if (item != null)
                {
                    lbKategorier.Items.Add(item.Title);
                    cbKategori.Items.Add(item.Title);  
                }
            }
            cbKategori.SelectedIndex = 0;
        }
        private void displayUpdateInterval()
        {
            cbFrekvens.Items.Add("100");
            cbFrekvens.Items.Add("500");
            cbFrekvens.Items.Add("600");
            cbFrekvens.SelectedIndex = 0;
        }

        private void lvPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbAvsnitt.Items.Clear();
            if (lvPodcasts.SelectedItems.Count == 1)
            {
                string title = lvPodcasts.SelectedItems[0].Text;
                label6.Text = title;

                foreach (var item in podcastController.GetAllPodcasts())
                {
                    if (item.Title.Equals(title))
                    {
                        foreach (var item2 in item.Episodes)
                        {
                            lbAvsnitt.Items.Add(item2.Title);
                        }
                    }
                }
            }
        }

        private void btnTaBortPodd_Click(object sender, EventArgs e)
        {
            if (lvPodcasts.SelectedItems.Count == 1) 
            { 
                string title = lvPodcasts.SelectedItems[0].Text;

                DialogResult result = MessageBox.Show("Vill du ta bort podcasten " + title + "?", "Warning", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes) 
                { 
                    podcastController.DeletePodcast(title);
                    displayPodcasts();
                    lbAvsnitt.Items.Clear();
                }
            }
        }

        private void btnTaBortKategori_Click(object sender, EventArgs e)
        {
            if (lbKategorier.SelectedItems.Count == 1)
            {
                string category = lbKategorier.SelectedItem.ToString();

                DialogResult result = MessageBox.Show("Vill du ta bort kategorin " + category + " och alla tillhörande podcasts?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    categoryController.DeleteCategory(category);
                    displayCategories();
                    tbValdKategori.Clear();
                }
            }

            

        }

        private void clbKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
