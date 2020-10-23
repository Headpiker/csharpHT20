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
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            categoryController = new CategoryController();
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

            //podcastController.test();

            //Min ursprungliga kod:
            
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

        }
        private void displayPodcasts()
        {
            lvPodcasts.Items.Clear();
            
            foreach (var item in podcastController.GetAllPodcasts())
            {
                if(item != null)
                {
                    ListViewItem newList = new ListViewItem("Antal"); //Hårdkodat just nu
                    newList.SubItems.Add(item.Title);
                    newList.SubItems.Add(item.UpdateInterval.ToString());
                    newList.SubItems.Add(item.Category);
                    lvPodcasts.Items.Add(newList);
                }
            }
        }
        private void displayCategories()
        {
            clbKategorier.Items.Clear();
            cbKategori.Items.Clear();

            foreach (var item in categoryController.GetAllCategories())
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
