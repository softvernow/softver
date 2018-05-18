using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace softver.Views
{
    public partial class AboutView : Form
    {
        private String PRODUCT_VERSION = new Version(FileVersionInfo.GetVersionInfo(Assembly.GetCallingAssembly().Location).ProductVersion).ToString();

        public AboutView()
        {
            InitializeComponent();
        }

        private void AboutView_Load(object sender, EventArgs e)
        {
            lblversion.Text = "Version: " + PRODUCT_VERSION;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var si = new ProcessStartInfo(linkLabel1.Text);
            Process.Start(si);
        }
    }
}
