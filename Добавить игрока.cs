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
    public partial class Добавить_игрока : Form
    {
        public Добавить_игрока()
        {
            InitializeComponent();
        }

        private void Добавить_игрока_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = Heroes.ScenarioList;
            comboBox2.DataSource = bindingSource1;
        }
        public bool flagEdit = false;
        private void button1_Click(object sender, EventArgs e)
        {   
            string str = comboBox2.Text;
            if (str != String.Empty &&!Heroes.ScenarioList.Contains(str))
{
                Heroes.ScenarioList.Add(str);
                bindingSource1.ResetBindings(false);
                comboBox2.Text = str;

            }
            if (textBox1.Text == "Никнейм игрока")
            {
                MessageBox.Show("Вы забыли написать Никнейм");
                return;
            }
            if ((textBox2.Text == "Количество очков")||(textBox2.Text == String.Empty))
            {
                MessageBox.Show("Вы забыли указать количество набранных очков");
                return;
            }

            string txt = "";
            foreach (var item in groupBox1.Controls)
            { if (item is RadioButton)
                { RadioButton rb = (RadioButton)item;
                    if (rb.Checked)
                    { txt = rb.Text;
                        break;
                    }
                }
            }
            if (txt == String.Empty)
            {
                MessageBox.Show("Вы забыли указать уровень сложности");
                return;
            }
            if (comboBox1.Text == String.Empty)
            {
                MessageBox.Show("Вы забыли указать цвет флага");
                return;
            }
            if (comboBox2.Text == String.Empty)
            {
                MessageBox.Show("Вы забыли указать название сценария");
                return;
            }
            string time = numericUpDown2.Value.ToString() + "/" + numericUpDown3.Value.ToString() + "/" + numericUpDown4.Value.ToString();
            List <Hero> listH = new List<Hero> ();
            Heroes.listP.Add(new Player(comboBox2.Text, textBox1.Text, comboBox1.Text, textBox2.Text, txt , time, listH)) ;
            textBox1.Focus();
            flagEdit = true;
            MessageBox.Show("Игрок добавлен" +";\n\nДобавьте следующий или закройте окно");
            textBox1.Text = "";
            foreach(var item in groupBox1.Controls)
            if (item is RadioButton)
                { RadioButton rb = (RadioButton)item;
                    if (rb.Checked)
                        rb.Checked = false;
                }
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 1;
            numericUpDown4.Value = 1;
            textBox2.Text = "";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int a;
            int.TryParse(textBox2.Text, out a);
            if (textBox2.Text != "Количество очков") if (a > 500) { MessageBox.Show("Максимально количество очков - 500"); textBox2.Text = ""; }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {  
            label2.Text = "";
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar))) { e.Handled = true;
                label2.Text = "В этом поле не должно быть букв";
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Heroes.ScenarioList.Remove(comboBox1.Text);
                bindingSource1.ResetBindings(false);
                if (Heroes.ScenarioList.Count > 0) comboBox1.Text =
                 "" + Heroes.ScenarioList[0];
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddHeroes_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
