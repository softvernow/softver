using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace softver.View
{
    public partial class FlipPageView : Form
    {
        private int counter;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public Boolean RESULT = true;


        public FlipPageView(String page, int counter)
        {
            InitializeComponent();

            this.counter = counter;
            circularProgressBar2.Text = counter.ToString();
            label1.Text = page;
        }

        private void FlipPageView_Load(object sender, EventArgs e)
        {
            InitTimer();

           // this.WindowState = FormWindowState.Minimized;
        }


        public void InitTimer()
        {
            //if (timer.Enabled)
            //    timer.Stop();

            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Interval = 1000;
            timer.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                this.Close();
            }


            circularProgressBar2.Text = counter.ToString();

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            RESULT = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RESULT = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
