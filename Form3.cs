using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;





namespace Курсовая
{   

    public partial class Musika : Form

    {
        public class MediaPlayer : System.Windows.Media { }
        private SoundPlayer sp;

       
       

        public Musika()
        {
            InitializeComponent();
            sp = new SoundPlayer();
            
    }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            
         }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {

            
            if (listBox1.Text != string.Empty) {
                sp.SoundLocation = @"Music\" + listBox1.Text + ".wav";
                sp.Load();
                sp.Play();
                sp.PlayLooping();
                Close();
            }
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sp.Stop();
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            
            
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            Process cmd = new Process();


            cmd.StartInfo = new ProcessStartInfo(@"cmd.exe");
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine("setvol " + trackBar1.Value.ToString());
            label3.Visible = true;
            label3.Text = "Громкость: " + trackBar1.Value.ToString() + "%" ;
        }

        private void Musika_Load(object sender, EventArgs e)
        {

        }
    }
}
