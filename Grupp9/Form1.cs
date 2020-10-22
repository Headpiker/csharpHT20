using BL.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupp9
{
    public partial class Form1 : Form
    {
        PodcastController podcastController;
        CategoryController categoryController;
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            categoryController = new CategoryController();
            displayCategories();
            displayUpdateInterval();
            displayPodcasts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNyPodd_Click(object sender, EventArgs e)
        {
            string category = this.cbKategori.GetItemText(this.cbKategori.SelectedItem);
            string updateIntervalString = this.cbFrekvens.GetItemText(this.cbFrekvens.SelectedItem);
            int updateInterval = Convert.ToInt32(updateIntervalString);

            podcastController.CreatePodcastObject(txtPoddNamn.Text, txtUrl.Text, category, updateInterval);

            displayPodcasts();
        }

        private void btnNyKategori_Click(object sender, EventArgs e)
        {
            categoryController.CreateCategory(tbValdKategori.Text);
            displayCategories();

        }
        private void displayPodcasts()
        {
            lvPodcasts.Items.Clear();
            foreach (var item in podcastController.RetriveAllPodcasts())
            {
                if(item != null)
                {
                    lvPodcasts.Items.Add(item.Title);
                    lvPodcasts.Items.Add(item.Category);
                }
            }
        }
        private void displayCategories()
        {
            clbKategorier.Items.Clear();
            cbKategori.Items.Clear();

            foreach (var item in categoryController.RetriveAllCategories())
            {
                if (item != null)
                {
                    clbKategorier.Items.Add(item.Title);
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
    }
}
