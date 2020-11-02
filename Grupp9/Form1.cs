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
            displayCategories();
            displayUpdateInterval();
            displayPodcasts(podcastController.GetAllPodcasts());
            EnabledButtonsAtStart();

            lvPodcasts.FullRowSelect = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void EnabledButtonsAtStart()
        {
            btnNyPodd.Enabled = true;
            btnNyKategori.Enabled = true;
            btnUppdateraPodd.Enabled = false;
            btnUppdateraKategori.Enabled = false;
            btnTaBortPodd.Enabled = false;
            btnTaBortKategori.Enabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            podcastController.UpdateEpisodes();
        }

        private void btnNyPodd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation.IsFieldNullOrEmpty(txtPoddNamn.Text) || !Validation.IsFieldNullOrWhitespace(txtPoddNamn.Text))
                {
                    if (Validation.IsUrlValid(txtUrl.Text))
                    {

                        string category = this.cbKategori.GetItemText(this.cbKategori.SelectedItem);
                        string updateIntervalString = this.cbFrekvens.GetItemText(this.cbFrekvens.SelectedItem);
                        int updateInterval = Convert.ToInt32(updateIntervalString);
                        podcastController.CreatePodcastObject(txtPoddNamn.Text.ToString(), txtUrl.Text.ToString(), category, updateInterval);
                        Delay();
                        ClearTxtNameAndUrl();
                        ClearEpisodeInfo();
                    }
                    else { MessageBox.Show("Se till att URL är korrekt ifylld!"); }
                }
                else { MessageBox.Show("Du måste skriva i ett namn!"); }
            }
            catch (Exception ex) { MessageBox.Show("Något gick fel, pröva igen!" + "\n" + ex.Message); }
        }

        async Task Delay()
        {
            await Task.Delay(300);
            displayPodcasts(podcastController.GetAllPodcasts());
        }

        private void btnNyKategori_Click(object sender, EventArgs e)
        {            
            try
            {
                
                if (!Validation.IsFieldNullOrEmpty(tbValdKategori.Text) || !Validation.IsFieldNullOrWhitespace(tbValdKategori.Text))
                {
                    categoryController.CreateCategoryObject(tbValdKategori.Text);
                    displayCategories();
                    tbValdKategori.Clear();
                }

                else
                {
                    MessageBox.Show("Du måste skriva in något i fältet!");
                }
            }
            catch (FormatException ex) { MessageBox.Show("Se till att du skrev in allt korrekt! " + "\n" + ex.Message);}
            catch (Exception ex) { MessageBox.Show("Något gick fel, pröva igen!" + "\n" + ex.Message); }
        }

        /*Metod för att visa podcasts i ListView, tar en parameter List<Podcast> för att specifisera vilken samling av
         * podcasts som ska visas dvs filtrerade eller alla */
        private void displayPodcasts(List<Podcast> podcastsToDisplay) 
        {
            try
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
                foreach (ListViewItem items in lvPodcasts.Items)
                {

                    if ((items.Index % 2) == 0)
                    {
                        items.BackColor = Color.FromArgb(240, 240, 240);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Något gick fel, pröva igen!" + "\n" + ex.Message); }
        }

        private void displayCategories()
        {
            try
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
            catch (ArgumentOutOfRangeException ex) { MessageBox.Show("Den valda kategorin gick inte att ta bort! " + "\n" + ex.Message);}
            catch (Exception ex) { MessageBox.Show("Något gick fel, pröva igen!" + "\n" + ex.Message); }
        }
        private void displayUpdateInterval()
        {
            cbFrekvens.Items.Add("5");
            cbFrekvens.Items.Add("10");
            cbFrekvens.Items.Add("30");
            cbFrekvens.SelectedIndex = 0;
        }

        private void btnUppdateraKategori_Click(object sender, EventArgs e)
        {
            try
            {
                string title = tbValdKategori.Text.ToString();

                string newTitel = Interaction.InputBox("Skriv in ett nytt namn på kategorin " + title + " för att byta namn.", "Uppdatera kategori", "", 500, 300);
                if (newTitel != "")
                {
                    categoryController.RenameCategory(title, newTitel);
                    displayCategories();
                    displayPodcasts(podcastController.GetAllPodcasts());
                    tbValdKategori.Text = "";
                }
                else
                {
                    MessageBox.Show("Vänligen skriv in en ny titel för att uppdatera kategorin!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Något gick fel, pröva igen!" + "\n" + ex.Message); }
        }

        private void btnTaBortKategori_Click(object sender, EventArgs e)
        {
            try
            {
                string category = tbValdKategori.Text;

                //MessageBox för att låta användaren säkerställa att kategorin med tillhörande podcasts ska tas bort
                DialogResult result = MessageBox.Show("Är du säker på att du vill radera kategorin " + category + " ? \n Alla podcasts som tillhör kategorin kommer att raderas!", "Radera kategori med tiihörande podcasts", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    categoryController.DeleteCategory(category);
                    displayCategories();
                    displayPodcasts(podcastController.GetAllPodcasts());
                    tbValdKategori.Clear();
                    ClearTxtNameAndUrl();
                    ClearEpisodeInfo();
                }
            }
            catch (Exception ex) { MessageBox.Show("Något gick fel, pröva igen!" + "\n" + ex.Message); }
        }

        private void btnTaBortPodd_Click(object sender, EventArgs e)
        {
            try
            {
                string title = lvPodcasts.SelectedItems[0].Text;

                //MessageBox för att låta användaren säkerställa att podcasten ska tas bort
                DialogResult result = MessageBox.Show("Vill du ta bort podcasten '" + title + "'?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    podcastController.DeletePodcast(title);
                    displayPodcasts(podcastController.GetAllPodcasts());
                    ClearTxtNameAndUrl();
                    ClearEpisodeInfo();
                }
            }
            catch (Exception ex) { MessageBox.Show("Något gick fel, pröva igen!" + "\n" + ex.Message);}
        }

        private void btnUppdateraPodd_Click(object sender, EventArgs e)
        {
            
            try
            {
                string title = lvPodcasts.SelectedItems[0].Text;
                int index = podcastController.GetIndexByTitle(title);
                if (title != null)
                {
                    string category = this.cbKategori.GetItemText(this.cbKategori.SelectedItem);
                    string updateIntervalString = this.cbFrekvens.GetItemText(this.cbFrekvens.SelectedItem);
                    int updateInterval = Convert.ToInt32(updateIntervalString);

                    podcastController.UpdatePodcastObject(txtPoddNamn.Text.ToString(), txtUrl.Text.ToString(), category, updateInterval, index);
                    Delay();
                    ClearTxtNameAndUrl();
                    ClearEpisodeInfo();
                }
            }
            catch (Exception ex) { MessageBox.Show("Du har inte valt någon kategori!" + "\n" + ex.Message );}
            
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
            try
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
            catch (ArgumentOutOfRangeException ex) { MessageBox.Show("Se till att du har valt rätt podcast!" + "\n" + ex.Message);}
            catch (Exception ex) { MessageBox.Show("Något gick fel, pröva igen!" + "\n" + ex.Message); }
        }

        private void clbKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                    btnNyKategori.Enabled = true;
                    btnUppdateraKategori.Enabled = false;
                    btnTaBortKategori.Enabled = false;
                }
                /*Är en eller fler kategorier valda filtreras podcasts efter de kategorierna, är mer än en podcast vald tillåts
                 * inte användaren att uppdatera eller ta bort kategori.*/
                if (clbKategorier.CheckedItems.Count >= 1)
                {
                    List<string> selectedValues = clbKategorier.CheckedItems.OfType<string>().ToList();
                    List<Podcast> filteredPodcasts = categoryController.FilterPodcasts(selectedValues);
                    displayPodcasts(filteredPodcasts);
                    ClearEpisodeInfo();
                    ClearTxtNameAndUrl();
                }
                else
                {
                    displayPodcasts(podcastController.GetAllPodcasts());
                }
            }
            catch (Exception ex) { MessageBox.Show("Något gick fel, pröva igen!" + "\n" + ex.Message); }
        }

        //Visar beskrivning av valt avsnitt
        private void lbAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { MessageBox.Show("Något gick fel, pröva igen!" + "\n" + ex.Message); }
        }
    }
}
