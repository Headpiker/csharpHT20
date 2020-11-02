using BL;
using BL.Controllers;
using Microsoft.VisualBasic;
using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupp9
{
    public partial class Form1 : Form
    {
        PodcastController podcastController;
        CategoryController categoryController;
        EpisodeController episodeController;        

        
        private Timer timer = new Timer(); //Timer för uppdateringsfrekvensen

        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            categoryController = new CategoryController();
            episodeController = new EpisodeController();
            DisplayCategories();
            DisplayUpdateInterval();
            DisplayPodcasts(podcastController.GetAllPodcasts());
            EnabledButtonsForPodcast();
            EnabledButtonsForCategory();

            lvPodcasts.FullRowSelect = true;

            //Startar timer och anger att timern ska köra varje sekund. 
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void EnabledButtonsForPodcast()
        {
            btnNyPodd.Enabled = true;
            btnUppdateraPodd.Enabled = false;
            btnTaBortPodd.Enabled = false;
        }

        private void EnabledButtonsForCategory()
        {
            btnNyKategori.Enabled = true;
            btnUppdateraKategori.Enabled = false;
            btnTaBortKategori.Enabled = false;
        }

        //Detta event anropas varje sekund
        private void Timer_Tick(object sender, EventArgs e)
        {
            //UpdateEspisode() kollar om avsnitt för podcasts behöver uppdateras utifrån dess uppdateringsfrekvens
            podcastController.UpdateEpisodes();
        }

        private void btnNyPodd_Click(object sender, EventArgs e)
        {
            if (!Validation.IsFieldNullOrEmpty(cbKategori.Text.ToString()) && !Validation.IsFieldNullOrEmpty(txtPoddNamn.Text))
            {
                if (Validation.IsUrlValid(txtUrl.Text) && !Validation.UrlExsists(txtUrl.Text))
                {
                    if (!Validation.IsPodcastDuplicate(txtPoddNamn.Text))
                    {
                        string category = this.cbKategori.GetItemText(this.cbKategori.SelectedItem);
                        string updateIntervalString = this.cbFrekvens.GetItemText(this.cbFrekvens.SelectedItem);
                        int updateInterval = Convert.ToInt32(updateIntervalString);
                        podcastController.CreatePodcastObject(txtPoddNamn.Text.ToString(), txtUrl.Text.ToString(), category, updateInterval);
                        _ = Delay();
                        ClearTxtNameAndUrl();
                        ClearEpisodeInfo();
                    }
                }
            }
        }

        //Delay gör att programmet avvaktar inläsningen av alla podcasts för att avsnitten ska hinna hämtas innan podcasten visas.
        async Task Delay()
        {
            await Task.Delay(300);
            DisplayPodcasts(podcastController.GetAllPodcasts());

            //Startar om applikationen
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Application.Exit();
        }

        private void btnNyKategori_Click(object sender, EventArgs e)
        { 
            if (!Validation.IsFieldNullOrEmpty(tbValdKategori.Text) && !Validation.IsCategoryDuplicate(tbValdKategori.Text))
            {
                categoryController.CreateCategoryObject(tbValdKategori.Text);
                DisplayCategories();
                tbValdKategori.Clear();
            }
        }

        /*Metod för att visa podcasts i ListView, tar en parameter List<Podcast> för att specifisera vilken samling av
         * podcasts som ska visas dvs filtrerade eller alla */
        private void DisplayPodcasts(List<Podcast> podcastsToDisplay) 
        {
            lvPodcasts.Items.Clear();

            foreach (var item in podcastsToDisplay)
            {
                if (item != null)
                {
                    string numberOfEpisodes = item.Episodes.Count().ToString();
                    ListViewItem newList = new ListViewItem(item.Title);
                    newList.SubItems.Add(numberOfEpisodes);
                    newList.SubItems.Add(item.UpdateInterval.ToString());
                    newList.SubItems.Add(item.Category);
                    lvPodcasts.Items.Add(newList);
                }
            }
            // Sätter bakgrundsfärg grå för varannan rad i lvPodcast.
            foreach (ListViewItem items in lvPodcasts.Items)
            {
                if ((items.Index % 2) == 0)
                {
                    items.BackColor = Color.FromArgb(240, 240, 240);
                }
            }
        }

        private void DisplayCategories()
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
        }

        private void DisplayUpdateInterval()
        {
            cbFrekvens.Items.Add("5");
            cbFrekvens.Items.Add("10");
            cbFrekvens.Items.Add("30");
            cbFrekvens.SelectedIndex = 0;
        }

        private void btnUppdateraKategori_Click(object sender, EventArgs e)
        {
            string title = tbValdKategori.Text.ToString();
            string newTitel = Interaction.InputBox("Skriv in ett nytt namn på kategorin " + title + " för att byta namn.", "Uppdatera kategori", "", 500, 300);
  
            if (!Validation.IsFieldNullOrEmpty(newTitel))
            {
                if (!Validation.IsCategoryDuplicate(newTitel))
                {
                    categoryController.RenameCategory(title, newTitel);
                    DisplayCategories();
                    DisplayPodcasts(podcastController.GetAllPodcasts());
                    tbValdKategori.Clear();

                    //Startar om applikationen
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Application.Exit();
                }
            }
        }

        private void btnTaBortKategori_Click(object sender, EventArgs e)
        {
            string category = tbValdKategori.Text;
            //MessageBox för att låta användaren säkerställa att kategorin med tillhörande podcasts ska tas bort
            DialogResult result = MessageBox.Show("Är du säker på att du vill radera kategorin " + category + " ? \n Alla podcasts som tillhör kategorin kommer att raderas!", "Radera kategori med tiihörande podcasts", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                categoryController.DeleteCategory(category);
                DisplayCategories();
                EnabledButtonsForPodcast();
                DisplayPodcasts(podcastController.GetAllPodcasts());
                tbValdKategori.Clear();
                ClearTxtNameAndUrl();
                ClearEpisodeInfo();

                //Startar om applikationen
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
        }

        private void btnTaBortPodd_Click(object sender, EventArgs e)
        {
            string title = lvPodcasts.SelectedItems[0].Text;

            //MessageBox för att låta användaren säkerställa att podcasten ska tas bort
            DialogResult result = MessageBox.Show("Vill du ta bort podcasten '" + title + "'?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                podcastController.DeletePodcast(title);
                DisplayPodcasts(podcastController.GetAllPodcasts());
                ClearTxtNameAndUrl();
                ClearEpisodeInfo();
                EnabledButtonsForPodcast();
            }
        }

        private void btnUppdateraPodd_Click(object sender, EventArgs e)
        {
            string title = lvPodcasts.SelectedItems[0].Text;
            int index = podcastController.GetIndexByTitle(title);
            if (!Validation.IsFieldNullOrEmpty(title))
            {
                string category = this.cbKategori.GetItemText(this.cbKategori.SelectedItem);
                string updateIntervalString = this.cbFrekvens.GetItemText(this.cbFrekvens.SelectedItem);
                int updateInterval = Convert.ToInt32(updateIntervalString);

                podcastController.UpdatePodcastObject(txtPoddNamn.Text.ToString(), txtUrl.Text.ToString(), category, updateInterval, index);
                _ = Delay();
                ClearTxtNameAndUrl();
                ClearEpisodeInfo();
                EnabledButtonsForPodcast();
            }
        }

        private void ClearTxtNameAndUrl()
        {
            txtUrl.Clear();
            txtPoddNamn.Clear();
            lblTitle.Text = "Podcast #:";
        }

        private void ClearEpisodeInfo()
        {
            rtbAvsnittInfo.Clear();
            lbAvsnitt.Items.Clear();
        }

        private void lvPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearEpisodeInfo();
            //Om en podcast är vald hämtas information om podcasten och fylls i respektive textfält/combobox.
            if (lvPodcasts.SelectedItems.Count == 1)
            {
                string title = lvPodcasts.SelectedItems[0].Text;
                string updateInterval = lvPodcasts.Items[lvPodcasts.SelectedIndices[0]].SubItems[2].Text;
                string category = lvPodcasts.Items[lvPodcasts.SelectedIndices[0]].SubItems[3].Text;
                string url = podcastController.GetUrlByTitle(title);
                txtUrl.Text = url;
                lblTitle.Text = title;
                txtPoddNamn.Text = title;
                cbFrekvens.SelectedItem = updateInterval;
                cbKategori.SelectedItem = category;
                btnTaBortPodd.Enabled = true;
                btnUppdateraPodd.Enabled = true;
                btnNyPodd.Enabled = false;

                foreach (var item in podcastController.GetAllPodcasts())
                {
                    if (item.Title.Equals(title))
                    {
                        int numberEpisode = 1;
                        foreach (var item2 in item.Episodes) //Hämtar antal avsnitt för vald podcast
                        {
                            lbAvsnitt.Items.Add("* " + item2.Title);
                            numberEpisode++;
                        }
                    }
                }
                episodeController.GetEpisodes(title); //Hämtar avsnitten för vald podcast
                rtbAvsnittInfo.Clear();
            }
            else
            {
                ClearEpisodeInfo();
                ClearTxtNameAndUrl();
                btnNyPodd.Enabled = true;
                btnTaBortPodd.Enabled = false;
                btnUppdateraPodd.Enabled = false;
            }
        }

        private void clbKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbKategorier.CheckedItems.Count == 1) //Är en kategori vald tillåts användaren att uppdatera/ta bort den kategorin
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
                EnabledButtonsForCategory();
            }
            /*Är en eller fler kategorier valda filtreras podcasts efter de kategorierna, är mer än en podcast vald tillåts
             * inte användaren att uppdatera eller ta bort kategori.*/
            if (clbKategorier.CheckedItems.Count >= 1)
            {
                List<string> selectedValues = clbKategorier.CheckedItems.OfType<string>().ToList();
                List<Podcast> filteredPodcasts = categoryController.FilterPodcasts(selectedValues);
                DisplayPodcasts(filteredPodcasts);
                ClearEpisodeInfo();
                ClearTxtNameAndUrl();
            }
            else
            {
                DisplayPodcasts(podcastController.GetAllPodcasts());
            }
        }

        //Visar beskrivning av valt avsnitt
        private void lbAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAvsnitt.SelectedItems.Count == 1)
            {
                string podcast = lblTitle.Text;
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
