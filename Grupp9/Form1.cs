using BL.Controllers;
using Microsoft.VisualBasic;
using Models;
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
                if (item != null)
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


        private void btnUppdateraKategori_Click(object sender, EventArgs e)
        {
            string title = tbValdKategori.Text.ToString();

            if (title != "")
            {
                string newTitel = Interaction.InputBox("Skriv in ett nytt namn på kategorin " + title + " för att byta namn.", "Uppdatera kategori", "", 500, 300);
                if (newTitel != "")
                {
                    List<Podcast> podcasts = podcastController.GetAllPodcasts();
                    categoryController.RenameCategory(title, newTitel, podcasts);
                    displayCategories();
                    displayPodcasts();
                    tbValdKategori.Text = "";
                }
                else
                {
                    MessageBox.Show("Vänligen skriv in en ny titel för att uppdatera kategorin!");
                }
            }
            else
            {
                MessageBox.Show("Välj en kategori för att uppdatera den!");
            }
        }

        private void clbKategorier_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!clbKategorier.GetItemChecked(e.Index))
            {
                string vald = clbKategorier.SelectedItem.ToString();
                tbValdKategori.Text = vald;
            }
            else
            {
                tbValdKategori.Text = "";
            }

        }

        private void btnTaBortKategori_Click(object sender, EventArgs e)
        {
            string category = tbValdKategori.Text;
            DialogResult result = MessageBox.Show("Är du säker på att du vill radera kategorin " + category + " ? \n Alla podcasts som tillhör kategorin kommer att raderas!", "Radera kategori med tiihörande podcasts", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                categoryController.DeleteCategory(category);
                displayCategories();
                displayPodcasts();
                tbValdKategori.Text = "";
            }
        }

            private void btnTaBortPodd_Click(object sender, EventArgs e)
            {
                if (lvPodcasts.SelectedItems.Count == 1)
                {
                    string title = lvPodcasts.SelectedItems[0].Text;

                    DialogResult result = MessageBox.Show("Vill du ta bort podcasten " + title + "?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        podcastController.DeletePodcast(title);
                        displayPodcasts();
                        lbAvsnitt.Items.Clear();
                    }
                }
            }


            private void btnUppdateraPodd_Click(object sender, EventArgs e)
            {
                if (lvPodcasts.SelectedItems.Count == 1)
                {
                    string title = lvPodcasts.SelectedItems[0].Text;
                    int index = podcastController.UpdatePodcast(title);


                    string category = this.cbKategori.GetItemText(this.cbKategori.SelectedItem);
                    string updateIntervalString = this.cbFrekvens.GetItemText(this.cbFrekvens.SelectedItem);
                    int updateInterval = Convert.ToInt32(updateIntervalString);
                    podcastController.UpdatePodcastObject(txtPoddNamn.Text.ToString(), txtUrl.Text.ToString(), category, updateInterval, index);
                    displayPodcasts();
                }


            }
        }
    }
