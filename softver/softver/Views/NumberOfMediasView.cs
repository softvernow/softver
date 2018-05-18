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
    public partial class NumberOfMediasView : Form
    {
        public int RESULT = 0;

        public NumberOfMediasView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (maskedTextBox1.Text.Length == 0)
                RESULT = 0;
            else
                RESULT = Convert.ToInt16(maskedTextBox1.Text);
            this.Close();
        }
    }
}
