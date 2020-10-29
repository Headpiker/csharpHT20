using BL;
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

        
        private Timer timer = new Timer();
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
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            podcastController.UpdateEpisodes();
        }

        private void btnNyPodd_Click(object sender, EventArgs e)
        {
            if (!Validation.IsFieldNullOrEmpty(txtPoddNamn.Text) || !Validation.IsFieldNullOrWhitespace(txtPoddNamn.Text))
            {
                if (Validation.IsUrlValid(txtUrl.Text))
                {                   
                        try
                        {
                            string category = this.cbKategori.GetItemText(this.cbKategori.SelectedItem);
                            string updateIntervalString = this.cbFrekvens.GetItemText(this.cbFrekvens.SelectedItem);
                            int updateInterval = Convert.ToInt32(updateIntervalString);
                            podcastController.CreatePodcastObject(txtPoddNamn.Text.ToString(), txtUrl.Text.ToString(), category, updateInterval);
                            displayPodcasts();
                            ClearTxtNameAndUrl();
                            ClearEpisodeInfo();

                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    
                }
                else { MessageBox.Show("Se till att URL är korrekt ifylld!");}
            }
            else { MessageBox.Show("Du måste skriva i ett namn!");}
            
            
            
            
        }

        private void btnNyKategori_Click(object sender, EventArgs e)
        {
            if (!Validation.IsFieldNullOrEmpty(tbValdKategori.Text) || !Validation.IsFieldNullOrWhitespace(tbValdKategori.Text))
            {
                categoryController.CreateCategoryObject(tbValdKategori.Text);
                displayCategories();
                tbValdKategori.Clear(); }

            else
            {
                MessageBox.Show("Du måste skriva in en ett kategorinamn i fältet för att kunna lägga till en ny kategori!");
            }
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
            cbFrekvens.Items.Add("1");
            cbFrekvens.Items.Add("5");
            cbFrekvens.Items.Add("10");
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
                    categoryController.RenameCategory(title, newTitel);
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

        private void btnTaBortKategori_Click(object sender, EventArgs e)
        {
            string category = tbValdKategori.Text;

            if (category != "")
            {
                //MessageBox för att låta användaren säkerställa att kategorin med tillhörande podcasts ska tas bort
                DialogResult result = MessageBox.Show("Är du säker på att du vill radera kategorin " + category + " ? \n Alla podcasts som tillhör kategorin kommer att raderas!", "Radera kategori med tiihörande podcasts", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    categoryController.DeleteCategory(category);
                    displayCategories();
                    displayPodcasts();
                    tbValdKategori.Clear();
                    ClearTxtNameAndUrl();
                    ClearEpisodeInfo();
                } 
            }
            else
            {
                MessageBox.Show("Välj en kategori för att ta bort den!");
            }
        }

        private void btnTaBortPodd_Click(object sender, EventArgs e)
        {
            if (lvPodcasts.SelectedItems.Count == 1)
            {
                string title = lvPodcasts.SelectedItems[0].Text;
            
                //MessageBox för att låta användaren säkerställa att podcasten ska tas bort
                DialogResult result = MessageBox.Show("Vill du ta bort podcasten '" + title + "'?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    podcastController.DeletePodcast(title);
                    displayPodcasts();
                    ClearTxtNameAndUrl();
                    ClearEpisodeInfo();
                }
            }
            else
            {
                MessageBox.Show("Du måste välja en podcast för att kunna ta bort den!");
            }
        }

        private void btnUppdateraPodd_Click(object sender, EventArgs e)
        {
            if (lvPodcasts.SelectedItems.Count == 1)
            {
                string title = lvPodcasts.SelectedItems[0].Text;
                int index = podcastController.GetIndexByTitle(title);

                string category = this.cbKategori.GetItemText(this.cbKategori.SelectedItem);
                string updateIntervalString = this.cbFrekvens.GetItemText(this.cbFrekvens.SelectedItem);
                int updateInterval = Convert.ToInt32(updateIntervalString);

                podcastController.UpdatePodcastObject(txtPoddNamn.Text.ToString(), txtUrl.Text.ToString(), category, updateInterval, index);
                displayPodcasts();
                ClearTxtNameAndUrl();
                ClearEpisodeInfo();

            }
            else
            {
                MessageBox.Show("Du måste välja en podcast för kunna uppdatera den!");
            }
        }

        private void ClearTxtNameAndUrl()
        {
            txtUrl.Clear();
            txtPoddNamn.Clear();
        }

        private void ClearEpisodeInfo()
        {
            rtbAvsnittInfo.Clear();
            lbAvsnitt.Items.Clear();
        }

        private void lvPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearEpisodeInfo();

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
                            lbAvsnitt.Items.Add("* " + item2.Title);
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
            if (clbKategorier.CheckedItems.Count == 1)
            {
                string category = clbKategorier.SelectedItem.ToString();
                tbValdKategori.Text = category;
                tbValdKategori.ReadOnly = true;
                btnNyKategori.Enabled = false;
                btnUppdateraKategori.Enabled = true;
                btnTaBortKategori.Enabled = true;
            }
            else
            {
                tbValdKategori.Text = "";
                tbValdKategori.ReadOnly = false;
                btnNyKategori.Enabled = true;
                btnUppdateraKategori.Enabled = false;
                btnTaBortKategori.Enabled = false;
            }
            if(clbKategorier.CheckedItems.Count >= 1)
            {
                List<string> selectedValues = clbKategorier.CheckedItems.OfType<string>().ToList();
                List<Podcast> filteredPodcasts = categoryController.FilterPodcasts(selectedValues);
                DisplayFilteredPodcasts(filteredPodcasts);
            }
            else
            {
                displayPodcasts();
            }
        }

        //Obs! "Dubbelkod", nästan exakt samma som DisplayPodcasts, ska snyggas till!
        private void DisplayFilteredPodcasts(List<Podcast> filteredPodcasts)
        {
            lvPodcasts.Items.Clear();

            foreach (var item in filteredPodcasts)
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

        private void lbAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAvsnitt.SelectedItems.Count == 1)
            {
                string podcast = label6.Text;
                string episode = lbAvsnitt.SelectedItem.ToString();
                string episodeTitle = episode.Substring(2);

                foreach (var item in podcastController.GetAllPodcasts())
                {
                    foreach (var aEpisode in item.Episodes)
                    {
                        if (aEpisode.Title.Equals(episodeTitle) && item.Title.Equals(podcast))
                        {
                            rtbAvsnittInfo.Text = "Titel:\n" + episodeTitle + "\n\nBeskrivning:\n" + aEpisode.Description;
                        }
                    }
                }
            }
        }
    }
}
