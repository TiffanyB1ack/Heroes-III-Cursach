using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class ColorForm : Form
    {
        public ColorForm()
        {
            InitializeComponent();
        }
        public string L;
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            label1.Visible = true; 
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            L = "Красный.bmp";
            Close();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            label3.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            L = "Синий.bmp";
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            L = "Зелёный.bmp";
            Close();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            label4.Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            L = "Оранжевый.bmp";
            Close();
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            label6.Visible = true;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            L = "advmap_fill.bmp";
            Close();
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            label7.Visible = true;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            L = "Розовый.bmp";
            Close();
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            label8.Visible = true;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            L ="Пурпурный.bmp";
            Close();
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
label9.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            L = "Бежевый.bmp";
            Close();
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            label10.Visible = true;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            label10.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            L = "Бирюзовый.bmp";
            Close();
        }
    }
}
