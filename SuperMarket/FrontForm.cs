using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class FrontForm : Form
    {
        public FrontForm()
        {
            InitializeComponent();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 5;
            ProgressBar_imtiaz.Value = startpoint;
            if (ProgressBar_imtiaz.Value == 100)
            {
                ProgressBar_imtiaz.Value = 0;
                timer1.Stop();
                Form1 form = new Form1();
                this.Hide();
                form.Show();
            }
        }

        private void FrontForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
