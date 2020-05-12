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
    public partial class AddHeroes : Form
    {
        public int f,max; // Номер текущего игрока.
        
        public bool flagEdit = false;
        public AddHeroes()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Справочник_Героев sg = new Справочник_Героев();
            sg.s = comboBox2.Text; 
            sg.Show();
            
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            
            if (comboBox2.Text == String.Empty)
            {
                MessageBox.Show("Вы забыли указать Имя Героя");
                return;
            }
            
            bool have = false;
            for (int j = 0; j < max; j++)
            {
                Hero hr1 = Heroes.listP[f].Heros[j];
                if (comboBox2.Text == hr1.Name)
                    have = true;
            }
            if (have == false)
            {
                Heroes.listP[f].Heros.Add(new Hero(comboBox2.Text, numericUpDown5.Value, numericUpDown6.Value, numericUpDown7.Value, numericUpDown8.Value, numericUpDown9.Value));
            flagEdit = true;
                numericUpDown5.Value = 0;
                numericUpDown6.Value = 0;
                numericUpDown7.Value = 0;
                numericUpDown8.Value = 0;
                numericUpDown9.Value = 1;
                comboBox2.Text = "";
                if (MessageBox.Show("Герой " + comboBox2.Text +
              " добавлен. \n\nДобавить следующего героя?",
               "Добавить или выйти ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.No)
            Close();
            }
            else MessageBox.Show("Герои Игрока не могут повторяться!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
            


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = @"Герои\" + comboBox2.Text + ".gif";
            pictureBox2.BackgroundImage = Image.FromFile(str);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddHeroes_Load(object sender, EventArgs e)
        {
            Text += Heroes.listP[f].NickName;
            string str = @"Фаилы\" + Heroes.listP[f].Color+".bmp";
            BackgroundImage = Image.FromFile(str) ;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
