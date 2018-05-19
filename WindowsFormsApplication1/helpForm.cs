using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loopTester
{
    public partial class helpForm : Form
    {
        public helpForm()
        {
            InitializeComponent();
            label1.Text = "Version: " + Application.ProductVersion + "\nby:" + Application.CompanyName;            
            label1.SetBounds(Width/2-label1.Width/2, label1.Top, label1.Width, label1.Height);
        }
        Random loco = new System.Random(1);
        public int randoom
        {
            set;
            get;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void but_LoadChangeLog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("changelog.txt");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
