using BL.Controllers;
using Microsoft.VisualBasic;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            lvPodcastProperties();

        }

        private void lvPodcastProperties()
        {
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
            ClearTxtNameAndUrl();
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
                    string numberOfEpisodes = item.Episodes.Count().ToString();
                    ListViewItem newList = new ListViewItem(item.Title);
                    newList.SubItems.Add(numberOfEpisodes);                      //Antal är hårdkodat just nu
                    newList.SubItems.Add(item.UpdateInterval.ToString());
                    newList.SubItems.Add(item.Category);
                    lvPodcasts.Items.Add(newList);
                }
            }
            foreach (ListViewItem items in lvPodcasts.Items)
            {

                if ((items.Index % 2) == 0)
                {
                    items.BackColor = Color.FromArgb(240, 240, 240);
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
            try
            {
                cbKategori.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                
            }
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
                tbValdKategori.Clear();
            }
        }

        private void btnTaBortPodd_Click(object sender, EventArgs e)
        {
            if (lvPodcasts.SelectedItems.Count == 1)
            {
                string title = lvPodcasts.SelectedItems[0].Text;
            
                DialogResult result = MessageBox.Show("Vill du ta bort podcasten '" + title + "'?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    podcastController.DeletePodcast(title);
                    displayPodcasts();
                    lbAvsnitt.Items.Clear();
                    ClearTxtNameAndUrl();
                }
            }
        }

        private void btnUppdateraPodd_Click(object sender, EventArgs e)
        {
            if (lvPodcasts.SelectedItems.Count == 1)
            {
                string title = lvPodcasts.SelectedItems[0].Text;
                int index = podcastController.GetIndexByTitle(title);
                Console.WriteLine("Titel från lvPodcast: " + title);

                string category = this.cbKategori.GetItemText(this.cbKategori.SelectedItem);
                string updateIntervalString = this.cbFrekvens.GetItemText(this.cbFrekvens.SelectedItem);
                int updateInterval = Convert.ToInt32(updateIntervalString);

                podcastController.UpdatePodcastObject(txtPoddNamn.Text.ToString(), txtUrl.Text.ToString(), category, updateInterval, index);
                displayPodcasts();
                ClearTxtNameAndUrl();

            }
            else
            {
                Console.WriteLine("Vänligen välj en podcast att uppdatera");
            }
        }

        private void ClearTxtNameAndUrl()
        {
            txtUrl.Clear();
            txtPoddNamn.Clear();
        }

        private void lvPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbAvsnitt.Items.Clear();
            
            if (lvPodcasts.SelectedItems.Count == 1)
            {
                string title = lvPodcasts.SelectedItems[0].Text;
                string updateInterval = lvPodcasts.Items[lvPodcasts.SelectedIndices[0]].SubItems[2].Text;
                string category = lvPodcasts.Items[lvPodcasts.SelectedIndices[0]].SubItems[3].Text;
                string url = podcastController.GetUrlByTitle(title);
                txtUrl.Text = url;
                label6.Text = title;
                txtPoddNamn.Text = title;
                cbFrekvens.SelectedItem = updateInterval;
                cbKategori.SelectedItem = category;

                foreach (var item in podcastController.GetAllPodcasts())
                {
                    if (item.Title.Equals(title))
                    {
                        int numberEpisode = 1;
                        foreach (var item2 in item.Episodes)
                        {
                            lbAvsnitt.Items.Add("Avsnitt " + numberEpisode + ": " + item2.Title);
                            numberEpisode++;
                        }
                    }
                }
                episodeController.GetEpisodes(title);
                rtbAvsnittInfo.Clear();
            }
        }

        private void clbKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbKategorier.SelectedItems.Count == 1) 
            { 
                string category = clbKategorier.SelectedItem.ToString();
                tbValdKategori.Text = category;
            }
        }

        private void lbAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAvsnitt.SelectedItems.Count == 1)
            {
                string podcast = label6.Text;
                string episode = lbAvsnitt.SelectedItem.ToString();
                string episodeTitle = episode.Substring(11);

                foreach (var item in podcastController.GetAllPodcasts())
                {
                    foreach (var aEpisode in item.Episodes)
                    {
                        if (aEpisode.Title.Equals(episodeTitle) && item.Title.Equals(podcast))
                        {
                            rtbAvsnittInfo.Text = episode + "\n\nBeskrivning:\n" + aEpisode.Description;
                        }
                    }
                }
            }
        }
    }
}
