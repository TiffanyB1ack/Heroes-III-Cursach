using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Курсовая
{
   
        
    public partial class Сreature : Form
    {
       

        public Сreature()
        {
            InitializeComponent();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

           
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

           
           int nodeCount = treeView1.SelectedNode.GetNodeCount(true);
           var srcEncoding = Encoding.GetEncoding(1251);
           textBox1.AutoSize = false;
           

            if (nodeCount == 21) {
                FileStream Castls = new FileStream(@"Фаилы\Все замки.txt", FileMode.Open);
                StreamReader srC = new StreamReader(Castls, srcEncoding);
                string str= @"Фаилы\" + treeView1.SelectedNode.Name + ".jpg";
                pictureBox2.Visible = true;
                pictureBox2.Image = Image.FromFile(str);
                textBox1.Visible = true;
                pictureBox4.Visible = true;
                linkLabel1.Visible = false;


                textBox1.Text = "";
                while ((!srC.EndOfStream)&&(textBox1.Text == ""))
                { string line = srC.ReadLine();
                    int o = line.IndexOf(treeView1.SelectedNode.Name);
                    if (o >= 0) 
                    {
                        line = line.Replace(treeView1.SelectedNode.Name + " :","");
                        textBox1.Text = line;

                    }
                }
                srC.Close();
                
                


            }
            else if (nodeCount == 0)
            {
                linkLabel1.Visible = true;
                linkLabel1.Text = treeView1.SelectedNode.Text;
                pictureBox2.Visible = false;
                string str = @"Существа\" + treeView1.SelectedNode.Name + ".gif";
                pictureBox1.Image = Image.FromFile(str);
                textBox1.Visible = false;
                FileStream Creachers = new FileStream(@"Фаилы\Значения.txt", FileMode.Open);
                StreamReader srCr = new StreamReader(Creachers, srcEncoding);
                pictureBox4.Visible = false;
                l1.Text = "0";
            
                while ((!srCr.EndOfStream)&&(l1.Text == "0")) 
                 
                {
                    string line = srCr.ReadLine();
                    
                    int o = line.IndexOf(treeView1.SelectedNode.Name);
                    if (o >= 0) {
                        line = line.Replace(treeView1.SelectedNode.Name+ ":", "");
                        string[] znak = line.Split(',');
                        l1.Text = znak[0];
                        l2.Text = znak[1];
                        l4.Text = znak[2];
                        l5.Text = znak[3];
                        l7.Text = znak[4];
                        l3.Text = znak[5];
                        l6.Text = znak[6];
                        textBox2.Text = "Способности:"+znak[7];
                    }
                   
                }
                srCr.Close();



            }
            else
            {
                linkLabel1.Visible = false;
                string str = @"Фаилы\" + treeView1.SelectedNode.Parent.Name + ".jpg";
                pictureBox2.Visible = true;
                pictureBox2.Image = Image.FromFile(str);
                textBox1.Visible = true;
                pictureBox4.Visible = true;
                
            }
        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }
    }
}

