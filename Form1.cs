﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;

namespace Курсовая
{
    

        
    
    public partial class Меню : Form
    {

       
         private SoundPlayer sp;

        public Меню()
        {
            
            InitializeComponent();
            

        }
        internal static Properties.Settings set = Properties.Settings.Default;
        private void button1_Click(object sender, EventArgs e)
        {
            Сreature creature = new Сreature();

            creature.Show();


        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Heroes heroes = new Heroes();

            
            heroes.Show();
            

        }


        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void музыкаToolStripMenuItem_Click(object sender, EventArgs e)
        {   ///Архив не содержит музыку, поэтому сейчас это окно не доступно
            MessageBox.Show("Архив не содержит музыку, поэтому сейчас это окно не доступно");
            ///Musika musika  = new Musika();
            ///musika.ShowDialog();
            ///labelmusic.Text = musika.listBox1.Text;
           
        }

        private void пToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fpath = "Help.txt";
            Process proc = Process.Start("notepad.exe", fpath);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Справочник_Героев сг = new Справочник_Героев();

            сг.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа разработана и написана: \n\n Прекрасной и несравненной \n\n Фарбовской Светланой Сергеевной, группа ПИ18-4\nПочта: sfarbovskaya50@gmail.com\n\n Приложение было создано с любовью c помощью:\nMicrosoft Visual Studio\nВерсия 16.4.6");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Меню_Load(object sender, EventArgs e)
        {
            
            BackgroundImage = Image.FromFile(@"Фаилы\" + label3.Text);
            this.ClientSize = set.CSize;
            sp = new SoundPlayer(); ;
            if (labelmusic.Text != "")
            {
                sp.SoundLocation = @"Music\"
                    + labelmusic.Text
                    + ".wav";
                sp.Load();
                sp.Play();
                sp.PlayLooping();
            }
            
        }

        private void вернутьИзначальныйРазмерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void настройкиТемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorForm cf = new ColorForm();
            cf.ShowDialog();
            if (cf.L != null) { 
            BackgroundImage = Image.FromFile(@"Фаилы\" + cf.L);
            label3.Text = cf.L;
            if (cf.L == "advmap_fill.bmp")
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            else
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
             }
            

        }
    }
}
