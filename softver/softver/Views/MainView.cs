using OpenQA.Selenium;
using softver.Models.Presenter;
using softver.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace softver.Models
{
    public partial class MainView : Form
    {

        public MainPresenter Presenter;
        private WhatsappModel whatsapp;


        public MainView()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cleaning();
        }


        /// <summary>
        /// Closes chrome and reset selections. 
        /// </summary>
        private void Cleaning()
        {
            if (whatsapp != null)
                if (whatsapp.driver != null)
                {
                    whatsapp.Close();
                    btnDownload.Enabled = false;
                    btnGroups.Enabled = false;
                    btnLoadGroups.Enabled = false;
                }
                    

        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cleaning();
        }


        /// <summary>
        /// Opens whatsapp web using google chrome. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenWhatsapp_Click(object sender, EventArgs e)
        {
            //reset buttons
            btnGroups.Enabled = false;
            btnLoadGroups.Enabled = false;
            btnDownload.Enabled = false;

            //cleans everything if any open browser. 
            Cleaning();

            //opens browser
            whatsapp = Presenter.WhatsappWeb();


            //select folder to save pictures. 
            FolderBrowserDialog sf = new FolderBrowserDialog();
            sf.Description = "Select Folder to Save Media";
            if (sf.ShowDialog() == DialogResult.OK)
                whatsapp.Open_Page(sf.SelectedPath);
            else
                whatsapp.Open_Page(null);

            btnLoadGroups.Enabled = true;

        }

        /// <summary>
        /// Loads groups to softver. using listview. 
        /// </summary>
        private void Set_Groups()
        {

            listView1.Items.Clear();
            List<String> list = whatsapp.Get_Groups();
            foreach (String group in list)
            {
                string[] strItemcoll3 = {group};
                var listViewItem = new ListViewItem(strItemcoll3);
                listView1.Items.Add(listViewItem);
            }
     
        }



        /// <summary>
        /// load all groups
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadGroups_Click(object sender, EventArgs e)
        {
            if (Is_Users_Loggedin())
            {
                Set_Groups();
                btnGroups.Enabled = true;
            }
            else
            {
                Cleaning();
                MessageBox.Show("Please Login to Whatsapp Web when Prompted!");
            }
            
        }


        /// <summary>
        /// Checks if user is logged in. 
        /// </summary>
        /// <returns></returns>
        private Boolean Is_Users_Loggedin()
        {
            ConfirmationView confirmation = new ConfirmationView();
            confirmation.ShowDialog();

            Boolean result = confirmation.result;
            confirmation.Close();

            return result;


        }

        private void MainView_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Download medias from whatsapp web. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            whatsapp.Open_All_Media();
            int number_of_medias = Get_Number_Of_Media();

            try
            {
                whatsapp.Open_And_Save_Each_Media(number_of_medias);
                DialogResult dialogResult = MessageBox.Show("Do you want download more Medias?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    whatsapp.Close();
                }

                whatsapp.Close_Media();
                btnDownload.Enabled = false;
                btnGroups.Enabled = false;
                btnLoadGroups.Enabled = false;
            }
            catch
            {

                btnDownload.Enabled = false;
                btnGroups.Enabled = false;
                btnLoadGroups.Enabled = false;
                MessageBox.Show("No Medias Found");
            }


        }


        /// <summary>
        /// Input for number of medias needed to download. 
        /// </summary>
        /// <returns></returns>
        private int Get_Number_Of_Media()
        {
            NumberOfMediasView ofMediasView = new NumberOfMediasView();
            ofMediasView.ShowDialog();
            int Result = ofMediasView.RESULT;
            ofMediasView.Close();

            return Result;
        }

        private void btnGroups_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// CLick action for every selection of a group. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_Click(object sender, EventArgs e)
        {

            try
            {
                btnDownload.Enabled = false;

                if (listView1.SelectedItems.Count > 0)
                {
                    whatsapp.Close_Media_Selection_Page();
                    String test = listView1.SelectedItems[0].Text;
                    whatsapp.Select_Group(test);
                    btnDownload.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                btnDownload.Enabled = false;
                btnGroups.Enabled = false;
                btnLoadGroups.Enabled = false;
                MessageBox.Show("Error Opening Group!, Restart Process" + ex.Message);
            }

         



           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }


        /// <summary>
        /// Open About screen. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutView view = new AboutView();
            view.ShowDialog();
            view.Close();
        }
    }
}
