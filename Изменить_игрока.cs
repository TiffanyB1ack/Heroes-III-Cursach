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
    public partial class Изменить_игрока : Form
    {
        public Изменить_игрока()
        {
            InitializeComponent();
        }

        public int i; // Номер текущего игрока в списке.
        public bool flagEdit = false; //Флаг изменений
        private void Изменить_игрока_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = Heroes.ScenarioList; // Ищем сценарий
            comboBox2.DataSource = bindingSource1; // Строим комбо-бокс
            comboBox2.Text = Heroes.listP[i].Scenario;//передаём Название сценария, Никнэйм, кол-во очков, цвет, уровень и время игры
            textBox1.Text = Heroes.listP[i].NickName; 
            textBox2.Text = Heroes.listP[i].Points;
            comboBox1.Text = Heroes.listP[i].Color;
            string txt = Heroes.listP[i].Level;
            foreach (var item in groupBox1.Controls) //ищем указанную кнопку и отмечаем её 
            {
                if (item is RadioButton)
                {
                    RadioButton rb = (RadioButton)item;
                    if (txt == rb.Text)
                    {
                        rb.Checked = true;
                        break;
                    }
                }
            }
            string time1 = Heroes.listP[i].Time;
            string[] mounth = time1.Split('/'); //разделяем время на отдельные числа
            numericUpDown2.Value = Convert.ToDecimal(mounth[0]); //присваиваем в окошки времени
            numericUpDown3.Value = Convert.ToDecimal(mounth[1]);
            numericUpDown4.Value = Convert.ToDecimal(mounth[2]);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = comboBox2.Text;
            if (str != String.Empty && !Heroes.ScenarioList.Contains(str))
{
                Heroes.ScenarioList.Add(str);
                bindingSource1.ResetBindings(false);
                comboBox2.Text = str;
            }
            if ((textBox1.Text == "Никнейм игрока")|| (textBox1.Text == String.Empty))
            {
                MessageBox.Show("Вы забыли написать Никнейм");
                return;
            }
            if ((textBox2.Text == "Количество очков") || (textBox2.Text == String.Empty))
            {
                MessageBox.Show("Вы забыли указать количество набранных очков");
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
            // Отредактировать запись Игрока
            string txt = "";
            foreach (var item in groupBox1.Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton rb = (RadioButton)item;
                    if (rb.Checked)
                    {
                        txt = rb.Text;
                        break;
                    }
                }
            }
            Heroes.listP[i].Level = txt;
            Heroes.listP[i].NickName = textBox1.Text;
            Heroes.listP[i].Scenario = comboBox2.Text;
            Heroes.listP[i].Color = comboBox1.Text;
            Heroes.listP[i].Points = textBox2.Text;
            string time = numericUpDown2.Value.ToString() + "/" + numericUpDown3.Value.ToString() + "/" + numericUpDown4.Value.ToString();
            Heroes.listP[i].Time = time;
            flagEdit = true;
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox2.Text) > 500) { MessageBox.Show("Максимально количество очков - 500"); textBox2.Text = ""; }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
