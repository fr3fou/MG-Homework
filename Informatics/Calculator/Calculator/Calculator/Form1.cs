using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        double a = 0;
        double b = 0;
        public Form1()
        {
            InitializeComponent();
        }
        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            label1.Text = "Result is: ";
        }
        public void getAandB()
        {
            a = double.Parse(textBox1.Text);
            b = double.Parse(textBox2.Text);
        }
        public static string calc(double a, double b, char action)
        {
            switch (action)
            {
                case '+':
                    return (a + b).ToString();
                case '-':
                    return (a - b).ToString();
                case '/':
                    return (b > 0) ? (a / b).ToString() : "ERROR";
                case '*':
                    return (a * b).ToString();
                case '^':
                    return (Math.Pow(a, b)).ToString();
                case '%':
                    return (a % b).ToString();
                default:
                    return "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getAandB();
            label1.Text = "Result is: " + calc(a, b, '+');
        }
        private void button2_Click(object sender, EventArgs e)
        {
            getAandB();
            label1.Text = (calc(a, b, '-') == "ERROR") ? "ERROR" : "Result is: " + calc(a, b, '-');
        }
        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            getAandB();
            label1.Text = "Result is: " + calc(a, b, '/');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getAandB();
            label1.Text = "Result is: " + calc(a, b, '*');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            getAandB();
            label1.Text = "Result is: " + calc(a, b, '^');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            getAandB();
            label1.Text = "Result is: " + calc(a, b, '%');
        }
    }
}
