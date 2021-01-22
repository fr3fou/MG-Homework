using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygon_12V_23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		private void button1_Click(object sender, EventArgs e)
		{
			int vertexCount = int.Parse(textBox1.Text);
			double circRadius = double.Parse(textBox2.Text);
			double v = 0;
			try
			{
				if (vertexCount < 3 || circRadius < 1)
				{
					throw new Exception("Грешка.");
				}
				v = circRadius * 2 * Math.Sin(Math.PI / vertexCount);
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); return; }

			label4.Text = "Периметър = " + (v * vertexCount).ToString("#.##");
			label5.Text = "Лице = " + (0.25 * v * v * vertexCount * (Math.Cos(Math.PI / vertexCount) / Math.Sin(Math.PI / vertexCount))).ToString("#.##");
		}

		private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
