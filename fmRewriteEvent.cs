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
    public partial class fmRewriteEvent : Form
    {
        /// <summary>
        /// Конструктор класса fmRewriteEvent
        /// </summary>
        public fmRewriteEvent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// перезапись СОБЫТИЯ
        /// </summary>
        /// <param name="str"></param>
        /// <param name="str1"></param>
        public void rewritableRecords(string str, string str1) 
        {
            richTextBox1.Text = str;
            dateTimePicker1.Value = DateTime.Parse(str1);

        }

        /// <summary>
        /// нажатие на время события
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.Controls.Add(panel2);
            panel2.Visible = true;
            this.Height = 420;
        }

        /// <summary>
        /// выбор часов для напоминания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buSave.Visible = true;
        }

        /// <summary>
        /// выбор дней для напоминания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            buSave.Visible = true;
        }

        /// <summary>
        /// нажатие на кнопку "Сохранить событие"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buSave_Click(object sender, EventArgs e)
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
                reminderDateTime = countingReminderTime(eventDateTime.ToString(),
                                                        comboBox2.SelectedIndex + 1,
                                                        comboBox1.SelectedIndex + 1);
                if (this.Owner is MainForm owner)
                {
                    owner.rewriteEvent(reminder, eventDateTime, reminderDateTime);
                }

                Close();
            }
        }

        public string countingReminderTime(String date1, int day, int hour)
        {
            DateTime eventDateTime = DateTime.Parse(date1);
            int d = (int)eventDateTime.Day;
            int m = (int)eventDateTime.Month;
            int year = (int)eventDateTime.Year;
            int cd = day;
            int ch = hour;
            if (d - cd < 0)
            {
                m--;
                if (m == 0)
                {
                    m = 12;
                    year--;
                }
                d = getDays(m) + (d - cd);
            }
            else
            {
                d = d - cd;
                if (d == 0)
                {
                    m--;
                    if (m == 0)
                    {
                        m = 12;
                        year--;
                    }
                    d = getDays(m);
                }
            }

            int h = (int)eventDateTime.Hour;
            if (h - ch < 0)
            {
                h = 24 + (h - ch);
                d--;
                if (d == 0)
                {
                    d = 30;
                }
            }
            else
            {
                h = h - ch;
            }
            String reminderDateTime = $"{d}.{m}." + $"{year} {h}:{eventDateTime.Minute}";
            return reminderDateTime;
        }

        public int getDays(int month)
        {
            int days = 30;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    days = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    days = 30;
                    break;
                case 2:
                    days = 27;
                    break;

            }
            return days;
        }
    }
}
