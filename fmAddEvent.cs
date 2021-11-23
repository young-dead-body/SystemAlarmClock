using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemAlarmClock
{
    public partial class fmAddEvent : Form
    {

        /// <summary>
        /// Конструктор класса fmAddEvent
        /// </summary>
        public fmAddEvent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Сохранить событие"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            String reminder = "";
            DateTime eventDateTime;
            String reminderDateTime;
            String FileName = "DB.txt";

            if (richTextBox1.Text == "" || dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("Ошибка ввода данных", "Ошибка!!!", MessageBoxButtons.OK);
            }
            else 
            {
                reminder = richTextBox1.Text;
                eventDateTime = dateTimePicker1.Value;
                int d = (int)eventDateTime.Day;
                int m = (int)eventDateTime.Month;
                int cd = comboBox2.SelectedIndex;
                int ch = comboBox1.SelectedIndex;
                cd++;
                ch++;
                if (d - cd < 0)
                {
                    d = d + (d - cd);
                    m--;
                }
                else
                {
                    d = d - cd;
                }
                int h = (int)eventDateTime.Hour;
                if (h - ch < 0)
                {
                    h = 24 + (h - ch);
                    d--;
                }
                else
                {
                    h = h - ch;
                }
                reminderDateTime = $"{d}.{m}." +
                    $"{eventDateTime.Year} {h}:{eventDateTime.Minute}";
                if (this.Owner is MainForm owner)
                {
                    owner.recordList(reminder);
                    owner.recordList(eventDateTime);
                    owner.recordList(reminderDateTime);
                    owner.rewriteBDEvent(FileName);
                }

                Close();
            }

        }

        /// <summary>
        /// Если пользователь выбрал часы до события
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buSave.Visible = true;

        }

        /// <summary>
        /// Если пользователь выбрал дни до события
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            buSave.Visible = true;
        }

        /// <summary>
        /// Пользователь выбрал дату события
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.Controls.Add(panel2);
            panel2.Visible = true;
            this.Height = 380;
        }
    }
}
