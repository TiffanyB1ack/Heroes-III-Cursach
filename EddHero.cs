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
    public partial class EddHero : Form
    {
        public EddHero()
        {
            InitializeComponent();
        }
        public int f, s, max;
        public bool flagEdit = false;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile(@"Герои\" + comboBox2.Text + ".gif");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Справочник_Героев sg = new Справочник_Героев();
            sg.s = comboBox2.Text;
            sg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
            Hero hr = Heroes.listP[f].Heros[s];
            bool have = false;
            for (int j = 0; j < max; j++)
            {
                Hero hr1 = Heroes.listP[f].Heros[j];
                if (comboBox2.Text == hr1.Name && comboBox2.Text!= hr.Name)
                    have = true;
            }
            if (have == false)
            {
                hr.Name = comboBox2.Text;
                hr.Ataka = numericUpDown5.Value;
                hr.Zashita = numericUpDown6.Value;
                hr.SilaMagii = numericUpDown7.Value;
                hr.Znania = numericUpDown8.Value;
                hr.Level = numericUpDown9.Value;
                flagEdit = true;
                Close();
            }
            else MessageBox.Show("Герои Игрока не могут повторяться!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void EddHero_Load(object sender, EventArgs e)
        {
            Text += Heroes.listP[f].NickName;
            Hero hr = Heroes.listP[f].Heros[s];
            string str = @"Фаилы\"+ Heroes.listP[f].Color + ".bmp";
            BackgroundImage = Image.FromFile(str);

            comboBox2.Text = hr.Name;
            pictureBox2.BackgroundImage = Image.FromFile(@"Герои\" + comboBox2.Text + ".gif");
            numericUpDown5.Value = hr.Ataka;
            numericUpDown6.Value = hr.Zashita;
            numericUpDown7.Value = hr.SilaMagii;
            numericUpDown8.Value = hr.Znania;
            numericUpDown9.Value = hr.Level;
        }
    }
}
