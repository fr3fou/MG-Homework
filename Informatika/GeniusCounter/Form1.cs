using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeniusCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Properties.Settings.Default.counter++;
                Properties.Settings.Default.lastTimeSaid = DateTime.Now;
                Properties.Settings.Default.Save();
                label1.Text = Properties.Settings.Default.counter.ToString();
                label2.Text = "Last time said: " + Properties.Settings.Default.lastTimeSaid;
            }
            else if (e.Control && e.KeyCode == Keys.Delete)
            {
                Properties.Settings.Default.counter = 0;
                Properties.Settings.Default.lastTimeSaid = DateTime.Now;
                Properties.Settings.Default.Save();
                label1.Text = Properties.Settings.Default.counter.ToString();
                label2.Text = "Last time said: " + "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = Properties.Settings.Default.counter.ToString();
            label2.Text = "Last time said: " + Properties.Settings.Default.lastTimeSaid;
        }
    }
}
