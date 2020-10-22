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
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            cbKategori.Items.Add("Humor");
            cbFrekvens.Items.Add("100");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNyPodd_Click(object sender, EventArgs e)
        {
            string category = this.cbKategori.GetItemText(this.cbKategori.SelectedItem);
            

            string updateIntervalString = this.cbFrekvens.GetItemText(this.cbFrekvens.SelectedItem);
            
            int updateInterval = Convert.ToInt32(updateIntervalString);

            //int updateInterval;
            //Int32.TryParse(cbFrekvens.SelectedValue.ToString(), out updateInterval);
            //int updateInterval = Convert.ToInt32(cbFrekvens.SelectedValue.GetHashCode());
            podcastController.CreatePodcastObject(txtPoddNamn.Text, txtUrl.Text, category, updateInterval);
        }
    }
}
