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
using System.Xml.Serialization;





namespace Курсовая
{
    public partial class Heroes : Form
    {

        public Heroes()
        {
            InitializeComponent();

        }

        public bool flagEdit = false;
        FileStream fs;
        XmlSerializer xs;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public static List<Player> listP = new List<Player>();
        public List<Hero> listH;
        public static List<string> ScenarioList = new List<string>();

        /*
        private void Непутю() //метод для перекрашивания ячеек. Создан для помощи ползователю, который забыл добавить игрокам героев
         {
             var backColor = dataGridView1.RowsDefaultCellStyle.BackColor;
             var bk = Color.Pink;
             if (checkBox1.Checked) 
             {
                  for (int y = 0; y < dataGridView1.RowCount; y++)
                     // Изменить цвет фона.
                        if ((int)dataGridView1["HeroC", y].Value == 0)
                        dataGridView1.Rows[y].DefaultCellStyle.BackColor = Color.LightPink;
             }
             else
                 for (int y = 0; y < dataGridView1.RowCount; y++) 
                      // Восстановить цвет фона. 
                  if ((int)dataGridView1["HeroC", y].Value == 0)
                         dataGridView1.Rows[y].DefaultCellStyle.BackColor = backColor;
         }
         */


        private void Heroes_Load(object sender, EventArgs e)
        {

            //обозначим переменную для перекрашиваем "недоделанных" героев

            string[] scArr = new string[] { "Высокомерие", "Герои Меча, но не Магии", "Все за одного","Зима Титана",
                "Аппеляция","Близнецы","Великая Гонка","Боевая перчатка","Возраждение Феникса","Резерв","Сказание о двух землях","Ущелье драконов",
                "Наводнение","Рыцарь тьмы","Поиски Грааля","Феи!"};
            ScenarioList.AddRange(scArr);
            ((DataGridViewComboBoxColumn)dataGridView1.Columns["Scenario"]).DataSource = ScenarioList;

            label6.Text = '\u2264'.ToString() + " P " + '\u2264'.ToString();
            if (File.Exists("Игроки.xml"))
            {
                // Восстановим из файла сериализованный граф объектов.
                fs = new FileStream("Игроки.xml", FileMode.Open);
                xs = new XmlSerializer(typeof(List<Player>));
                listP = (List<Player>)xs.Deserialize(fs);
                fs.Close();
            }
            else
            { listH = new List<Hero>();

                listH.Add(new Hero("Тан", 5, 6, 7, 8, 9));
                listH.Add(new Hero("Рашка", 1, 3, 9, 4, 5));

                listP.Add(new Player("Высокомерие", "Tiffany_black", "Зелёный", "499", "Конь (2 Уровень)", "1/4/5", listH));
                fs = new FileStream("Игроки.xml", FileMode.Create);
                XmlSerializer xs = new XmlSerializer(typeof(List<Player>));
                xs.Serialize(fs, listP);
                fs.Close();
            }
            playerBindingSource.DataSource = listP;
        }




        bool show = false;
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell == null
               || dataGridView1.CurrentCell.RowIndex < 0 // Заголовок столбца
               || dataGridView1.CurrentCell.RowIndex == dataGridView1.RowCount)

                return;
            HeroesCount formH = new HeroesCount();
            formH.P = dataGridView1.CurrentCell.RowIndex;
            formH.heroBindingSource.DataSource = listP[formH.P].Heros;
            formH.ShowDialog();
            playerBindingSource.ResetCurrentItem();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            fs = new FileStream("Игроки.xml", FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(List<Player>));
            xs.Serialize(fs, listP);
            fs.Close();
            flagEdit = false;

        }

        private void button1_Click(object sender, EventArgs e)
        { Добавить_игрока добавить_игрока = new Добавить_игрока();
            добавить_игрока.ShowDialog();

            if (добавить_игрока.flagEdit)
            {
                playerBindingSource.ResetBindings(false);
            }
            //Непутю();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool isnull = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                if (listP[i].HeroC == 0) isnull = true;

             
             if (flagEdit == true)
                {  if (isnull == true) MessageBox.Show("Один из игроков имеет 0 героев. Удалите игрока или добавте ему героев.", "Предуплеждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult res = MessageBox.Show("Вы хотите сохранить изменения прежде чем выйти?", "Выйти?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        fs = new FileStream("Игроки.xml", FileMode.Create);
                        XmlSerializer xs = new XmlSerializer(typeof(List<Player>));
                        xs.Serialize(fs, listP);
                        fs.Close();
                    }
                
                

             }
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var backColor = dataGridView1.RowsDefaultCellStyle.BackColor;
            Изменить_игрока изменить_игрока = new Изменить_игрока();
            изменить_игрока.i = dataGridView1.CurrentRow.Index;
            изменить_игрока.ShowDialog();
            if (изменить_игрока.flagEdit)

                playerBindingSource.ResetCurrentItem();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var backColor = dataGridView1.RowsDefaultCellStyle.BackColor;
            HeroesCount formH = new HeroesCount();
            formH.P = dataGridView1.CurrentCell.RowIndex;
            formH.heroBindingSource.DataSource = listP[formH.P].Heros;
            formH.ShowDialog();
            /// if ((int)dataGridView1["HeroC", formH.P].Value == 0 && checkBox1.Checked)
            // Изменить цвет фона у должника.
            ///  dataGridView1.Rows[formH.P].DefaultCellStyle.BackColor = Color.LightPink;

            ///else
            dataGridView1.Rows[formH.P].DefaultCellStyle.BackColor = backColor;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
   
            dataGridView1.Rows.RemoveAt(i);
            dataGridView1.Refresh();
            flagEdit = true;
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            //Непутю();

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBoxScenario.Text = "";
            textBoxP1.Text = "";
            textBoxP2.Text = "";
            textBoxNickName.Text = "";
            comboBoxColor.Text = "";
            comboBoxLevel.Text = "";
            numericUpDown1.Value = -1;
        }

        private void Show_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {

                if (TestRow(i) == true)
                    dataGridView1.Rows[i].Visible = true;
                else
                {
                    dataGridView1.Rows[i].Visible = false;
                    show = true;
                }
            }
            if (numericUpDown1.Value > -1)
            {
                if (show) label1.Text = string.Format(" Список игроков отфильтрован: '{0}' {1} {2} '{3}' {4} {5} {6}", textBoxScenario.Text, textBoxP1.Text, textBoxP2.Text, textBoxNickName.Text, comboBoxColor.Text, comboBoxLevel.Text, numericUpDown1.Value.ToString());
            }
            else
                if (show) label1.Text = string.Format(" Список игроков отфильтрован: {0} {1} {2} {3} {4} {5} ", textBoxScenario.Text, textBoxP1.Text, textBoxP2.Text, textBoxNickName.Text, comboBoxColor.Text, comboBoxLevel.Text);

            if ((textBoxScenario.Text=="") && (textBoxP1.Text=="")&& (textBoxP2.Text=="")&& (textBoxNickName.Text=="")&& (comboBoxColor.Text=="" )&& (comboBoxLevel.Text =="") && (numericUpDown1.Value==-1));
            label1.Text = "Отображены все игроки";
            
            // Перенести фокус на первого отображаемого игрока, если он есть.
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)

                    if (dataGridView1.Rows[i].Visible == true)
                    {
                        // Перейти на добавленного игркока. Его индекс = i.
                        dataGridView1.CurrentCell = dataGridView1[1, i];
                        break;
                    }

        }
        private bool TestRow(int i)
        {
            Player pl = Heroes.listP[i];
            if (textBoxScenario.Text != "" && !pl.Scenario.StartsWith(textBoxScenario.Text)) { return false; }
            if (textBoxNickName.Text != "" && !pl.NickName.StartsWith(textBoxNickName.Text)) { return false; }

            int p1, p2;
            int.TryParse(textBoxP1.Text, out p1);
            int.TryParse(textBoxP2.Text, out p2);
            if (p2 == 0) p2 = 100;
            if (Convert.ToInt32(pl.Points) < p1 || Convert.ToInt32(pl.Points) > p2 && p1 != 0 && p2 != 0) { return false; }

            if (comboBoxColor.Text != "" && !pl.Color.Contains(comboBoxColor.Text)) { return false; }
            if (comboBoxLevel.Text != "" && !pl.Level.Contains(comboBoxLevel.Text)) { return false; }

            decimal c;
            decimal.TryParse(numericUpDown1.Value.ToString(), out c);
            if (Convert.ToInt32(dataGridView1.Rows[i].Cells["HeroC"].Value) != c && c != -1) return false;

            return true;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;
            int d = checkBoxSort1.Checked == true ? -1 : 1; // Порядок сортировки.
            List<Player> list = Heroes.listP;
            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Scenario":
                    list.Sort((k1, k2) => d * k1.Scenario.CompareTo(k2.Scenario));
                    break;
                case "NickName":
                    list.Sort((k1, k2) => d * k1.NickName.CompareTo(k2.NickName));

                    break;
                case "Color":
                    list.Sort((k1, k2) => d * k1.Color.CompareTo(k2.Color));
                    break;
                case "Points":
                    list.Sort((k1, k2) => d * Convert.ToInt32(k1.Points).CompareTo(Convert.ToInt32(k2.Points)));
                    break;
                case "Level":

                    list.Sort((k1, k2) => d * k1.Level.CompareTo(k2.Level));
                    break;
                case "HeroC":
                    list.Sort((k1, k2) => d * k1.HeroC.CompareTo(k2.HeroC));
                    break;
                case "Time":
                    list.Sort((k1, k2) => d * k1.Time.CompareTo(k2.Time));
                    break;
                default: // По другим столбцам сортировки не будет.
                    return;
            }
            playerBindingSource.ResetBindings(false);
            if (show) Show_Click(null, null); // Обновить фильтрацию.
            /// Непутю(); // Изменить фон у строк должников.

        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        //Двухуровневая сортировка
        private void button3_Click(object sender, EventArgs e)
        {
            List<Player> list = Heroes.listP;
            if ((comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != "") || (comboBox1.Text == comboBox2.Text)) MessageBox.Show("Для такой сортировки щёлкните по столбцу, который хотите отсортировать");
            else
            {
                int a = 0;
                if (comboBox1.Text == "Название сценария")
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 2: a = 1; break;
                        case 3: a = 2; break;
                        case 4: a = 3; break;
                        case 5: a = 4; break;
                        case 6: a = 5; break;
                        case 7: a = 6; break;
                    }
                }
                else if (comboBox1.Text == "Никнэйм игрока")
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 1: a = 7; break;
                        case 3: a = 8; break;
                        case 4: a = 9; break;
                        case 5: a = 10; break;
                        case 6: a = 11; break;
                        case 7: a = 12; break;
                    }
                }
                else if (comboBox1.Text == "Цвет флага")
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 1: a = 13; break;
                        case 2: a = 14; break;
                        case 4: a = 15; break;
                        case 5: a = 16; break;
                        case 6: a = 17; break;
                        case 7: a = 18; break;
                    }
                }
                else if (comboBox1.Text == "Уровень сложности")
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 1: a = 19; break;
                        case 2: a = 20; break;
                        case 3: a = 21; break;
                        case 5: a = 22; break;
                        case 6: a = 23; break;
                        case 7: a = 24; break;
                    }
                }
                else if (comboBox1.Text == "Кол-во очков")
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 1: a = 25; break;
                        case 2: a = 26; break;
                        case 3: a = 27; break;
                        case 4: a = 28; break;
                        case 6: a = 29; break;
                        case 7: a = 30; break;
                    }
                }
                else if (comboBox1.Text == "Кол-во героев")
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 1: a = 31; break;
                        case 2: a = 32; break;
                        case 3: a = 33; break;
                        case 4: a = 34; break;
                        case 5: a = 35; break;
                        case 7: a = 36; break;
                    }
                }
                else if (comboBox1.Text == "Время")
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 1: a = 37; break;
                        case 2: a = 38; break;
                        case 3: a = 39; break;
                        case 4: a = 40; break;
                        case 5: a = 41; break;
                        case 6: a = 42; break;
                    }
                }
                if (!checkBoxd1.Checked && !checkBoxd2.Checked)
                    switch (a)
                    {
                        case 1: list = (list.OrderBy(s => s.Scenario).ThenBy(s => s.NickName)).ToList(); break;
                        case 2: list = (list.OrderBy(s => s.Scenario).ThenBy(s => s.Color)).ToList(); break;
                        case 3: list = (list.OrderBy(s => s.Scenario).ThenBy(s => s.Level)).ToList(); break;
                        case 4: list = (list.OrderBy(s => s.Scenario).ThenBy(s => s.Points)).ToList(); break;
                        case 5: list = (list.OrderBy(s => s.Scenario).ThenBy(s => s.HeroC)).ToList(); break;
                        case 6: list = (list.OrderBy(s => s.Scenario).ThenBy(s => s.Time)).ToList(); break;
                        case 7: list = (list.OrderBy(s => s.NickName).ThenBy(s => s.Scenario)).ToList(); break;
                        case 8: list = (list.OrderBy(s => s.NickName).ThenBy(s => s.Color)).ToList(); break;
                        case 9: list = (list.OrderBy(s => s.NickName).ThenBy(s => s.Level)).ToList(); break;
                        case 10: list = (list.OrderBy(s => s.NickName).ThenBy(s => s.Points)).ToList(); break;
                        case 11: list = (list.OrderBy(s => s.NickName).ThenBy(s => s.HeroC)).ToList(); break;
                        case 12: list = (list.OrderBy(s => s.NickName).ThenBy(s => s.Time)).ToList(); break;
                        case 13: list = (list.OrderBy(s => s.Color).ThenBy(s => s.Scenario)).ToList(); break;
                        case 14: list = (list.OrderBy(s => s.Color).ThenBy(s => s.NickName)).ToList(); break;
                        case 15: list = (list.OrderBy(s => s.Color).ThenBy(s => s.Level)).ToList(); break;
                        case 16: list = (list.OrderBy(s => s.Color).ThenBy(s => s.Points)).ToList(); break;
                        case 17: list = (list.OrderBy(s => s.Color).ThenBy(s => s.HeroC)).ToList(); break;
                        case 18: list = (list.OrderBy(s => s.Color).ThenBy(s => s.Time)).ToList(); break;
                        case 19: list = (list.OrderBy(s => s.Level).ThenBy(s => s.Scenario)).ToList(); break;
                        case 20: list = (list.OrderBy(s => s.Level).ThenBy(s => s.NickName)).ToList(); break;
                        case 21: list = (list.OrderBy(s => s.Level).ThenBy(s => s.Color)).ToList(); break;
                        case 22: list = (list.OrderBy(s => s.Level).ThenBy(s => s.Points)).ToList(); break;
                        case 23: list = (list.OrderBy(s => s.Level).ThenBy(s => s.HeroC)).ToList(); break;
                        case 24: list = (list.OrderBy(s => s.Level).ThenBy(s => s.Time)).ToList(); break;
                        case 25: list = (list.OrderBy(s => s.Points).ThenBy(s => s.Scenario)).ToList(); break;
                        case 26: list = (list.OrderBy(s => s.Points).ThenBy(s => s.NickName)).ToList(); break;
                        case 27: list = (list.OrderBy(s => s.Points).ThenBy(s => s.Color)).ToList(); break;
                        case 28: list = (list.OrderBy(s => s.Points).ThenBy(s => s.Level)).ToList(); break;
                        case 29: list = (list.OrderBy(s => s.Points).ThenBy(s => s.HeroC)).ToList(); break;
                        case 30: list = (list.OrderBy(s => s.Points).ThenBy(s => s.Time)).ToList(); break;
                        case 31: list = (list.OrderBy(s => s.HeroC).ThenBy(s => s.Scenario)).ToList(); break;
                        case 32: list = (list.OrderBy(s => s.HeroC).ThenBy(s => s.NickName)).ToList(); break;
                        case 33: list = (list.OrderBy(s => s.HeroC).ThenBy(s => s.Color)).ToList(); break;
                        case 34: list = (list.OrderBy(s => s.HeroC).ThenBy(s => s.Level)).ToList(); break;
                        case 35: list = (list.OrderBy(s => s.HeroC).ThenBy(s => s.Points)).ToList(); break;
                        case 36: list = (list.OrderBy(s => s.HeroC).ThenBy(s => s.Time)).ToList(); break;
                        case 37: list = (list.OrderBy(s => s.Time).ThenBy(s => s.Scenario)).ToList(); break;
                        case 38: list = (list.OrderBy(s => s.Time).ThenBy(s => s.NickName)).ToList(); break;
                        case 39: list = (list.OrderBy(s => s.Time).ThenBy(s => s.Color)).ToList(); break;
                        case 40: list = (list.OrderBy(s => s.Time).ThenBy(s => s.Level)).ToList(); break;
                        case 41: list = (list.OrderBy(s => s.Time).ThenBy(s => s.Points)).ToList(); break;
                        case 42: list = (list.OrderBy(s => s.Time).ThenBy(s => s.HeroC)).ToList(); break;
                    }
                else if (checkBoxd1.Checked && checkBoxd2.Checked)
                    switch (a)
                    {
                        case 1: list = (list.OrderByDescending(s => s.Scenario).ThenByDescending(s => s.NickName)).ToList(); break;
                        case 2: list = (list.OrderByDescending(s => s.Scenario).ThenByDescending(s => s.Color)).ToList(); break;
                        case 3: list = (list.OrderByDescending(s => s.Scenario).ThenByDescending(s => s.Level)).ToList(); break;
                        case 4: list = (list.OrderByDescending(s => s.Scenario).ThenByDescending(s => s.Points)).ToList(); break;
                        case 5: list = (list.OrderByDescending(s => s.Scenario).ThenByDescending(s => s.HeroC)).ToList(); break;
                        case 6: list = (list.OrderByDescending(s => s.Scenario).ThenByDescending(s => s.Time)).ToList(); break;
                        case 7: list = (list.OrderByDescending(s => s.NickName).ThenByDescending(s => s.Scenario)).ToList(); break;
                        case 8: list = (list.OrderByDescending(s => s.NickName).ThenByDescending(s => s.Color)).ToList(); break;
                        case 9: list = (list.OrderByDescending(s => s.NickName).ThenByDescending(s => s.Level)).ToList(); break;
                        case 10: list = (list.OrderByDescending(s => s.NickName).ThenByDescending(s => s.Points)).ToList(); break;
                        case 11: list = (list.OrderByDescending(s => s.NickName).ThenByDescending(s => s.HeroC)).ToList(); break;
                        case 12: list = (list.OrderByDescending(s => s.NickName).ThenByDescending(s => s.Time)).ToList(); break;
                        case 13: list = (list.OrderByDescending(s => s.Color).ThenByDescending(s => s.Scenario)).ToList(); break;
                        case 14: list = (list.OrderByDescending(s => s.Color).ThenByDescending(s => s.NickName)).ToList(); break;
                        case 15: list = (list.OrderByDescending(s => s.Color).ThenByDescending(s => s.Level)).ToList(); break;
                        case 16: list = (list.OrderByDescending(s => s.Color).ThenByDescending(s => s.Points)).ToList(); break;
                        case 17: list = (list.OrderByDescending(s => s.Color).ThenByDescending(s => s.HeroC)).ToList(); break;
                        case 18: list = (list.OrderByDescending(s => s.Color).ThenByDescending(s => s.Time)).ToList(); break;
                        case 19: list = (list.OrderByDescending(s => s.Level).ThenByDescending(s => s.Scenario)).ToList(); break;
                        case 20: list = (list.OrderByDescending(s => s.Level).ThenByDescending(s => s.NickName)).ToList(); break;
                        case 21: list = (list.OrderByDescending(s => s.Level).ThenByDescending(s => s.Color)).ToList(); break;
                        case 22: list = (list.OrderByDescending(s => s.Level).ThenByDescending(s => s.Points)).ToList(); break;
                        case 23: list = (list.OrderByDescending(s => s.Level).ThenByDescending(s => s.HeroC)).ToList(); break;
                        case 24: list = (list.OrderByDescending(s => s.Level).ThenByDescending(s => s.Time)).ToList(); break;
                        case 25: list = (list.OrderByDescending(s => s.Points).ThenByDescending(s => s.Scenario)).ToList(); break;
                        case 26: list = (list.OrderByDescending(s => s.Points).ThenByDescending(s => s.NickName)).ToList(); break;
                        case 27: list = (list.OrderByDescending(s => s.Points).ThenByDescending(s => s.Color)).ToList(); break;
                        case 28: list = (list.OrderByDescending(s => s.Points).ThenByDescending(s => s.Level)).ToList(); break;
                        case 29: list = (list.OrderByDescending(s => s.Points).ThenByDescending(s => s.HeroC)).ToList(); break;
                        case 30: list = (list.OrderByDescending(s => s.Points).ThenByDescending(s => s.Time)).ToList(); break;
                        case 31: list = (list.OrderByDescending(s => s.HeroC).ThenByDescending(s => s.Scenario)).ToList(); break;
                        case 32: list = (list.OrderByDescending(s => s.HeroC).ThenByDescending(s => s.NickName)).ToList(); break;
                        case 33: list = (list.OrderByDescending(s => s.HeroC).ThenByDescending(s => s.Color)).ToList(); break;
                        case 34: list = (list.OrderByDescending(s => s.HeroC).ThenByDescending(s => s.Level)).ToList(); break;
                        case 35: list = (list.OrderByDescending(s => s.HeroC).ThenByDescending(s => s.Points)).ToList(); break;
                        case 36: list = (list.OrderByDescending(s => s.HeroC).ThenByDescending(s => s.Time)).ToList(); break;
                        case 37: list = (list.OrderByDescending(s => s.Time).ThenByDescending(s => s.Scenario)).ToList(); break;
                        case 38: list = (list.OrderByDescending(s => s.Time).ThenByDescending(s => s.NickName)).ToList(); break;
                        case 39: list = (list.OrderByDescending(s => s.Time).ThenByDescending(s => s.Color)).ToList(); break;
                        case 40: list = (list.OrderByDescending(s => s.Time).ThenByDescending(s => s.Level)).ToList(); break;
                        case 41: list = (list.OrderByDescending(s => s.Time).ThenByDescending(s => s.Points)).ToList(); break;
                        case 42: list = (list.OrderByDescending(s => s.Time).ThenByDescending(s => s.HeroC)).ToList(); break;
                    }
                else if (!checkBoxd1.Checked && checkBoxd2.Checked)
                    switch (a)
                    {
                        case 1: list = (list.OrderBy(s => s.Scenario).ThenByDescending(s => s.NickName)).ToList(); break;
                        case 2: list = (list.OrderBy(s => s.Scenario).ThenByDescending(s => s.Color)).ToList(); break;
                        case 3: list = (list.OrderBy(s => s.Scenario).ThenByDescending(s => s.Level)).ToList(); break;
                        case 4: list = (list.OrderBy(s => s.Scenario).ThenByDescending(s => s.Points)).ToList(); break;
                        case 5: list = (list.OrderBy(s => s.Scenario).ThenByDescending(s => s.HeroC)).ToList(); break;
                        case 6: list = (list.OrderBy(s => s.Scenario).ThenByDescending(s => s.Time)).ToList(); break;
                        case 7: list = (list.OrderBy(s => s.NickName).ThenByDescending(s => s.Scenario)).ToList(); break;
                        case 8: list = (list.OrderBy(s => s.NickName).ThenByDescending(s => s.Color)).ToList(); break;
                        case 9: list = (list.OrderBy(s => s.NickName).ThenByDescending(s => s.Level)).ToList(); break;
                        case 10: list = (list.OrderBy(s => s.NickName).ThenByDescending(s => s.Points)).ToList(); break;
                        case 11: list = (list.OrderBy(s => s.NickName).ThenByDescending(s => s.HeroC)).ToList(); break;
                        case 12: list = (list.OrderBy(s => s.NickName).ThenByDescending(s => s.Time)).ToList(); break;
                        case 13: list = (list.OrderBy(s => s.Color).ThenByDescending(s => s.Scenario)).ToList(); break;
                        case 14: list = (list.OrderBy(s => s.Color).ThenByDescending(s => s.NickName)).ToList(); break;
                        case 15: list = (list.OrderBy(s => s.Color).ThenByDescending(s => s.Level)).ToList(); break;
                        case 16: list = (list.OrderBy(s => s.Color).ThenByDescending(s => s.Points)).ToList(); break;
                        case 17: list = (list.OrderBy(s => s.Color).ThenByDescending(s => s.HeroC)).ToList(); break;
                        case 18: list = (list.OrderBy(s => s.Color).ThenByDescending(s => s.Time)).ToList(); break;
                        case 19: list = (list.OrderBy(s => s.Level).ThenByDescending(s => s.Scenario)).ToList(); break;
                        case 20: list = (list.OrderBy(s => s.Level).ThenByDescending(s => s.NickName)).ToList(); break;
                        case 21: list = (list.OrderBy(s => s.Level).ThenByDescending(s => s.Color)).ToList(); break;
                        case 22: list = (list.OrderBy(s => s.Level).ThenByDescending(s => s.Points)).ToList(); break;
                        case 23: list = (list.OrderBy(s => s.Level).ThenByDescending(s => s.HeroC)).ToList(); break;
                        case 24: list = (list.OrderBy(s => s.Level).ThenByDescending(s => s.Time)).ToList(); break;
                        case 25: list = (list.OrderBy(s => s.Points).ThenByDescending(s => s.Scenario)).ToList(); break;
                        case 26: list = (list.OrderBy(s => s.Points).ThenByDescending(s => s.NickName)).ToList(); break;
                        case 27: list = (list.OrderBy(s => s.Points).ThenByDescending(s => s.Color)).ToList(); break;
                        case 28: list = (list.OrderBy(s => s.Points).ThenByDescending(s => s.Level)).ToList(); break;
                        case 29: list = (list.OrderBy(s => s.Points).ThenByDescending(s => s.HeroC)).ToList(); break;
                        case 30: list = (list.OrderBy(s => s.Points).ThenByDescending(s => s.Time)).ToList(); break;
                        case 31: list = (list.OrderBy(s => s.HeroC).ThenByDescending(s => s.Scenario)).ToList(); break;
                        case 32: list = (list.OrderBy(s => s.HeroC).ThenByDescending(s => s.NickName)).ToList(); break;
                        case 33: list = (list.OrderBy(s => s.HeroC).ThenByDescending(s => s.Color)).ToList(); break;
                        case 34: list = (list.OrderBy(s => s.HeroC).ThenByDescending(s => s.Level)).ToList(); break;
                        case 35: list = (list.OrderBy(s => s.HeroC).ThenByDescending(s => s.Points)).ToList(); break;
                        case 36: list = (list.OrderBy(s => s.HeroC).ThenByDescending(s => s.Time)).ToList(); break;
                        case 37: list = (list.OrderBy(s => s.Time).ThenByDescending(s => s.Scenario)).ToList(); break;
                        case 38: list = (list.OrderBy(s => s.Time).ThenByDescending(s => s.NickName)).ToList(); break;
                        case 39: list = (list.OrderBy(s => s.Time).ThenByDescending(s => s.Color)).ToList(); break;
                        case 40: list = (list.OrderBy(s => s.Time).ThenByDescending(s => s.Level)).ToList(); break;
                        case 41: list = (list.OrderBy(s => s.Time).ThenByDescending(s => s.Points)).ToList(); break;
                        case 42: list = (list.OrderBy(s => s.Time).ThenByDescending(s => s.HeroC)).ToList(); break;
                    }
                else if (checkBoxd1.Checked && !checkBoxd2.Checked)
                    switch (a)
                    {
                        case 1: list = (list.OrderByDescending(s => s.Scenario).ThenBy(s => s.NickName)).ToList(); break;
                        case 2: list = (list.OrderByDescending(s => s.Scenario).ThenBy(s => s.Color)).ToList(); break;
                        case 3: list = (list.OrderByDescending(s => s.Scenario).ThenBy(s => s.Level)).ToList(); break;
                        case 4: list = (list.OrderByDescending(s => s.Scenario).ThenBy(s => s.Points)).ToList(); break;
                        case 5: list = (list.OrderByDescending(s => s.Scenario).ThenBy(s => s.HeroC)).ToList(); break;
                        case 6: list = (list.OrderByDescending(s => s.Scenario).ThenBy(s => s.Time)).ToList(); break;
                        case 7: list = (list.OrderByDescending(s => s.NickName).ThenBy(s => s.Scenario)).ToList(); break;
                        case 8: list = (list.OrderByDescending(s => s.NickName).ThenBy(s => s.Color)).ToList(); break;
                        case 9: list = (list.OrderByDescending(s => s.NickName).ThenBy(s => s.Level)).ToList(); break;
                        case 10: list = (list.OrderByDescending(s => s.NickName).ThenBy(s => s.Points)).ToList(); break;
                        case 11: list = (list.OrderByDescending(s => s.NickName).ThenBy(s => s.HeroC)).ToList(); break;
                        case 12: list = (list.OrderByDescending(s => s.NickName).ThenBy(s => s.Time)).ToList(); break;
                        case 13: list = (list.OrderByDescending(s => s.Color).ThenBy(s => s.Scenario)).ToList(); break;
                        case 14: list = (list.OrderByDescending(s => s.Color).ThenBy(s => s.NickName)).ToList(); break;
                        case 15: list = (list.OrderByDescending(s => s.Color).ThenBy(s => s.Level)).ToList(); break;
                        case 16: list = (list.OrderByDescending(s => s.Color).ThenBy(s => s.Points)).ToList(); break;
                        case 17: list = (list.OrderByDescending(s => s.Color).ThenBy(s => s.HeroC)).ToList(); break;
                        case 18: list = (list.OrderByDescending(s => s.Color).ThenBy(s => s.Time)).ToList(); break;
                        case 19: list = (list.OrderByDescending(s => s.Level).ThenBy(s => s.Scenario)).ToList(); break;
                        case 20: list = (list.OrderByDescending(s => s.Level).ThenBy(s => s.NickName)).ToList(); break;
                        case 21: list = (list.OrderByDescending(s => s.Level).ThenBy(s => s.Color)).ToList(); break;
                        case 22: list = (list.OrderByDescending(s => s.Level).ThenBy(s => s.Points)).ToList(); break;
                        case 23: list = (list.OrderByDescending(s => s.Level).ThenBy(s => s.HeroC)).ToList(); break;
                        case 24: list = (list.OrderByDescending(s => s.Level).ThenBy(s => s.Time)).ToList(); break;
                        case 25: list = (list.OrderByDescending(s => s.Points).ThenBy(s => s.Scenario)).ToList(); break;
                        case 26: list = (list.OrderByDescending(s => s.Points).ThenBy(s => s.NickName)).ToList(); break;
                        case 27: list = (list.OrderByDescending(s => s.Points).ThenBy(s => s.Color)).ToList(); break;
                        case 28: list = (list.OrderByDescending(s => s.Points).ThenBy(s => s.Level)).ToList(); break;
                        case 29: list = (list.OrderByDescending(s => s.Points).ThenBy(s => s.HeroC)).ToList(); break;
                        case 30: list = (list.OrderByDescending(s => s.Points).ThenBy(s => s.Time)).ToList(); break;
                        case 31: list = (list.OrderByDescending(s => s.HeroC).ThenBy(s => s.Scenario)).ToList(); break;
                        case 32: list = (list.OrderByDescending(s => s.HeroC).ThenBy(s => s.NickName)).ToList(); break;
                        case 33: list = (list.OrderByDescending(s => s.HeroC).ThenBy(s => s.Color)).ToList(); break;
                        case 34: list = (list.OrderByDescending(s => s.HeroC).ThenBy(s => s.Level)).ToList(); break;
                        case 35: list = (list.OrderByDescending(s => s.HeroC).ThenBy(s => s.Points)).ToList(); break;
                        case 36: list = (list.OrderByDescending(s => s.HeroC).ThenBy(s => s.Time)).ToList(); break;
                        case 37: list = (list.OrderByDescending(s => s.Time).ThenBy(s => s.Scenario)).ToList(); break;
                        case 38: list = (list.OrderByDescending(s => s.Time).ThenBy(s => s.NickName)).ToList(); break;
                        case 39: list = (list.OrderByDescending(s => s.Time).ThenBy(s => s.Color)).ToList(); break;
                        case 40: list = (list.OrderByDescending(s => s.Time).ThenBy(s => s.Level)).ToList(); break;
                        case 41: list = (list.OrderByDescending(s => s.Time).ThenBy(s => s.Points)).ToList(); break;
                        case 42: list = (list.OrderByDescending(s => s.Time).ThenBy(s => s.HeroC)).ToList(); break;
                    }
                Heroes.listP = list;
                playerBindingSource.DataSource = list;
            }
        }

        private void textBoxP1_TextChanged(object sender, EventArgs e)
        {

        }
    }
} 


