using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace Курсовая
{     
    public partial class Справочник_Героев : Form
    {    
        public Справочник_Героев()
        {
            InitializeComponent();
            
            
        }
        public string s;
        public void Справочник_Героев_Load(object sender, EventArgs e)
        {
 
            List<HeroesList> CSV_Struct = new List<HeroesList>();
            CSV_Struct = HeroesList.ReadFile(@"Герои\Герои3.csv");
            if (s == "")
            {
                label22.Text = "1";
                label23.Text = "2";
            }
            else
            {
                for (int k = 0; k < CSV_Struct.Count; k++) 
                { if (CSV_Struct[k].Name == s)
                    {
                        if (CSV_Struct[k].Number % 2 == 1) 
                        {
                            label22.Text = CSV_Struct[k].Number.ToString();
                            label23.Text = (CSV_Struct[k].Number + 1).ToString(); 
                        } 
                        else

                        {
                            label22.Text = (CSV_Struct[k].Number - 1).ToString();
                            label23.Text = CSV_Struct[k].Number.ToString(); }
                    }
                }
            }
            int i = Convert.ToInt32(label22.Text) - 1;
            int j = Convert.ToInt32(label23.Text) - 1;
            Name1.Text = CSV_Struct[i].Name;
            Name2.Text = CSV_Struct[j].Name;
            string str1 = @"Герои\" + Name1.Text + ".gif";
            pictureBox1.BackgroundImage = Image.FromFile(str1);
            string str2 = @"Герои\" + Name2.Text + ".gif";
            pictureBox2.BackgroundImage = Image.FromFile(str2);
            Castle1.Text = CSV_Struct[i].Castle;
            Castle2.Text = CSV_Struct[j].Castle;
            Class1.Text = CSV_Struct[i].Class;
            Class2.Text = CSV_Struct[j].Class;
            Sex1.Text = CSV_Struct[i].Sex;
            Sex2.Text = CSV_Struct[j].Sex;
            Rase1.Text = CSV_Struct[i].Race;
            Rase2.Text = CSV_Struct[j].Race;
            Can1.Text = CSV_Struct[i].Sposobnost;
            Can2.Text = CSV_Struct[j].Sposobnost;
            Navyki1.Text = CSV_Struct[i].Navyki;
            Navyki2.Text = CSV_Struct[j].Navyki;
            History1.Text = CSV_Struct[i].History;
            History2.Text = CSV_Struct[j].History;
            Ataka1.Text = CSV_Struct[i].AtakaB.ToString();
            Ataka2.Text = CSV_Struct[j].AtakaB.ToString();
            Zashita1.Text = CSV_Struct[i].ZashitaB.ToString();
            Zashita2.Text = CSV_Struct[j].ZashitaB.ToString();
            SilaMagii1.Text = CSV_Struct[i].SilaMagiiB.ToString();
            SilaMagii2.Text = CSV_Struct[j].SilaMagiiB.ToString();
            Zashita1.Text = CSV_Struct[i].ZashitaB.ToString();
            Zashita2.Text = CSV_Struct[j].ZashitaB.ToString();
        }

        private void Справочник_Героев_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int p = Convert.ToInt32(label22.Text);
            if (p < 143)
            {
                label22.Text = (Convert.ToInt32(label22.Text) + 2).ToString();
                label23.Text = (Convert.ToInt32(label23.Text) + 2).ToString();
                List<HeroesList> CSV_Struct = new List<HeroesList>();
                CSV_Struct = HeroesList.ReadFile(@"Герои\Герои3.csv");
                int i = Convert.ToInt32(label22.Text) - 1;
                int j = Convert.ToInt32(label23.Text) - 1;
                Name1.Text = CSV_Struct[i].Name;
                Name2.Text = CSV_Struct[j].Name;
                string str1 = @"Герои\" + Name1.Text + ".gif";
                pictureBox1.BackgroundImage = Image.FromFile(str1);
                string str2 = @"Герои\" + Name2.Text + ".gif";
                pictureBox2.BackgroundImage = Image.FromFile(str2);
                Castle1.Text = CSV_Struct[i].Castle;
                Castle2.Text = CSV_Struct[j].Castle;
                Class1.Text = CSV_Struct[i].Class;
                Class2.Text = CSV_Struct[j].Class;
                Sex1.Text = CSV_Struct[i].Sex;
                Sex2.Text = CSV_Struct[j].Sex;
                Rase1.Text = CSV_Struct[i].Race;
                Rase2.Text = CSV_Struct[j].Race;
                Can1.Text = CSV_Struct[i].Sposobnost;
                Can2.Text = CSV_Struct[j].Sposobnost;
                Navyki1.Text = CSV_Struct[i].Navyki;
                Navyki2.Text = CSV_Struct[j].Navyki;
                History1.Text = CSV_Struct[i].History;
                History2.Text = CSV_Struct[j].History;
                Ataka1.Text = CSV_Struct[i].AtakaB.ToString();
                Ataka2.Text = CSV_Struct[j].AtakaB.ToString();
                Zashita1.Text = CSV_Struct[i].ZashitaB.ToString();
                Zashita2.Text = CSV_Struct[j].ZashitaB.ToString();
                SilaMagii1.Text = CSV_Struct[i].SilaMagiiB.ToString();
                SilaMagii2.Text = CSV_Struct[j].SilaMagiiB.ToString();
                Zashita1.Text = CSV_Struct[i].ZashitaB.ToString();
                Zashita2.Text = CSV_Struct[j].ZashitaB.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int p = Convert.ToInt32(label22.Text);
            if (p > 1)
            {
                label22.Text = (Convert.ToInt32(label22.Text) - 2).ToString();
                label23.Text = (Convert.ToInt32(label23.Text) - 2).ToString();
                List<HeroesList> CSV_Struct = new List<HeroesList>();
                CSV_Struct = HeroesList.ReadFile(@"Герои\Герои3.csv");
                int i = Convert.ToInt32(label22.Text) - 1;
                int j = Convert.ToInt32(label23.Text) - 1;
                Name1.Text = CSV_Struct[i].Name;
                Name2.Text = CSV_Struct[j].Name;
                string str1 = @"Герои\" + Name1.Text + ".gif";
                pictureBox1.BackgroundImage = Image.FromFile(str1);
                string str2 = @"Герои\" + Name2.Text + ".gif";
                pictureBox2.BackgroundImage = Image.FromFile(str2);
                Castle1.Text = CSV_Struct[i].Castle;
                Castle2.Text = CSV_Struct[j].Castle;
                Class1.Text = CSV_Struct[i].Class;
                Class2.Text = CSV_Struct[j].Class;
                Sex1.Text = CSV_Struct[i].Sex;
                Sex2.Text = CSV_Struct[j].Sex;
                Rase1.Text = CSV_Struct[i].Race;
                Rase2.Text = CSV_Struct[j].Race;
                Can1.Text = CSV_Struct[i].Sposobnost;
                Can2.Text = CSV_Struct[j].Sposobnost;
                Navyki1.Text = CSV_Struct[i].Navyki;
                Navyki2.Text = CSV_Struct[j].Navyki;
                History1.Text = CSV_Struct[i].History;
                History2.Text = CSV_Struct[j].History;
                Ataka1.Text = CSV_Struct[i].AtakaB.ToString();
                Ataka2.Text = CSV_Struct[j].AtakaB.ToString();
                Zashita1.Text = CSV_Struct[i].ZashitaB.ToString();
                Zashita2.Text = CSV_Struct[j].ZashitaB.ToString();
                SilaMagii1.Text = CSV_Struct[i].SilaMagiiB.ToString();
                SilaMagii2.Text = CSV_Struct[j].SilaMagiiB.ToString();
                Zashita1.Text = CSV_Struct[i].ZashitaB.ToString();
                Zashita2.Text = CSV_Struct[j].ZashitaB.ToString();
            }
        }

        private void еритикToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void хозяинToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

       

       

        private void быстрыйПоискToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
