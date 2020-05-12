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
    public partial class HeroesCount : Form
    {
        public HeroesCount()
        {
            InitializeComponent();
        }
        
        public int P; // номер текущего игрока в таблице DatagreedView
        

        private void HeroesCount_Load(object sender, EventArgs e)
        {
            Text += Heroes.listP[P].NickName;
            linkLabel1.Text += "\n" + Heroes.listP[P].NickName;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            
            string str = @"Фаилы\" + Heroes.listP[P].Color + ".bmp";
            BackgroundImage = Image.FromFile(str);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

           
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {   if (dataGridView1.Rows[j].Cells["NameH"].Value != String.Empty)
                {
                    Image i = Image.FromFile(@"Герои\" + dataGridView1.Rows[j].Cells["NameH"].Value + ".gif");
                    dataGridView1.Rows[j].Cells["Иконка"].Value = i;
                }
            }
            


        }


        private void button4_Click(object sender, EventArgs e)
        {
            bool f = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                for (int j = i; j < dataGridView1.Rows.Count; j++)
                    if ((dataGridView1.Rows[i].Cells["NameH"].Value == dataGridView1.Rows[j].Cells["NameH"].Value)&& i!=j )
                    {
                        MessageBox.Show("Не может быть двух одинаковых героев. Удалите одного из них");
                        f = true;
                    }
                    
           if (f == false) Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int i = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(i);
            dataGridView1.Refresh();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            EddHero eddHero = new EddHero();
            eddHero.f = P; // Текущий номер факультета
            eddHero.s = dataGridView1.CurrentRow.Index; // Текущий номер студента
            eddHero.max = dataGridView1.Rows.Count;
            eddHero.ShowDialog();
            if (eddHero.flagEdit)
                heroBindingSource.ResetCurrentItem();

        }

      

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Ataka" ||
            dataGridView1.Columns[e.ColumnIndex].Name == "Zashita" || dataGridView1.Columns[e.ColumnIndex].Name == "SilaMagii" ||
            dataGridView1.Columns[e.ColumnIndex].Name == "Znania" || dataGridView1.Columns[e.ColumnIndex].Name == "Level") ;
               
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Новое значение:
            string valueNew = e.FormattedValue.ToString().Trim();
            // Имя столбца (e.ColumnIndex - индекс столбца со старым значением).
            string nameColumn = dataGridView1.Columns[e.ColumnIndex].Name;
            decimal vInt;
            if (nameColumn == "Ataka" && valueNew != ""
            && (!decimal.TryParse(valueNew, out vInt) || vInt < 0))
{
                MessageBox.Show(" Атака должена быть положительным числом");
                e.Cancel = true; // Новое значение не принято.
            }
            else if (nameColumn == "Zashita" && valueNew != ""
            && (!decimal.TryParse(valueNew, out vInt) || vInt < 0))
            {
                MessageBox.Show("Защита должена быть положительным числом");
                e.Cancel = true; // Новое значение не принято.
            }
            else if (nameColumn == "SilaMagii" && valueNew != ""
          && (!decimal.TryParse(valueNew, out vInt) || vInt < 0))
            {
                MessageBox.Show("Сила Магии должена быть положительным числом");
                e.Cancel = true; // Новое значение не принято.
            }
            else if (nameColumn == "Znania" && valueNew != ""
           && (!decimal.TryParse(valueNew, out vInt) || vInt < 0))
            {
                MessageBox.Show("Знания должены быть положительным числом");
                e.Cancel = true; // Новое значение не принято.
            }
            else if (nameColumn == "Level" && valueNew != ""
         && (!decimal.TryParse(valueNew, out vInt) || vInt < 0))
            {
                MessageBox.Show("Уровень должен быть положительным числом");
                e.Cancel = true; // Новое значение не принято.
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            AddHeroes addForm = new AddHeroes();
            addForm.f = P; // Текущий номер факультета
            addForm.max = dataGridView1.Rows.Count;
            addForm.ShowDialog();
            if (addForm.flagEdit) heroBindingSource.ResetBindings(false);

            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                    if (dataGridView1.Rows[j].Cells["NameH"].Value != String.Empty)
                    {
                        Image i = Image.FromFile(@"Герои\" + dataGridView1.Rows[j].Cells["NameH"].Value + ".gif");
                        dataGridView1.Rows[j].Cells["Иконка"].Value = i;
                    }
            }


            
        }

        private void HeroesCount_FormClosing(object sender, FormClosingEventArgs e)
        {
            int i = 0;
            i = dataGridView1.Rows.Count;
            if (i > 8) 
            { MessageBox.Show("Героев не может быть больше восьми штук! Удалите лишних! А то я закроюсь и удалю все ваши данные!!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; }
            
        }
    }
}
