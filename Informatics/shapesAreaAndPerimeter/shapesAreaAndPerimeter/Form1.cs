using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace shapesAreaAndPerimeter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {            
        }

        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            label4.Text = "P = 0";
            label5.Text = "S = 0";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = false;
            clear();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            clear();
        }
        public static bool canTriangleExist(double a, double b, double c)
        {
            return (a + b > c && a + c > b && b + c > a);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double p = 0;
            double s = 0;
            double halfOfP;
            double a;
            double b;
            double c;
            try
            {
                if (radioButton1.Checked)
                {
                    a = double.Parse(textBox1.Text);
                    b = double.Parse(textBox2.Text);
                    p = (a + b) * 2;
                    s = a * b;
                }
                else if (radioButton2.Checked)
                {
                    a = double.Parse(textBox1.Text);
                    p = a * 4;
                    s = a * a;
                }
                else
                {
                    a = double.Parse(textBox1.Text);
                    b = double.Parse(textBox2.Text);
                    c = double.Parse(textBox3.Text);
                    p = a + b + c;
                    halfOfP = p / 2;
                    if (canTriangleExist(a,b,c))
                    {
                        s = Math.Sqrt(halfOfP * (halfOfP - a) * (halfOfP * b) * (halfOfP * c));                        
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Value/s entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                p = 0;
                s = 0;
            }
            finally
            {
                label4.Text = "P = " + p.ToString("#.00"); 
                label5.Text = "S = " + s.ToString("#.00");
            }                      
        }
    }
}
