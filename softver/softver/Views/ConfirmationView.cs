using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace softver.Views
{
    public partial class ConfirmationView : Form
    {
        public Boolean result = false;

        public ConfirmationView()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            result = true;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            result = false;
            this.Close();
        }
    }
}
