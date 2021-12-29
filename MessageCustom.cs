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
    public partial class MessageCustom : Form
    {
        /// <summary>
        /// Конструктор класса MessageCustom (он не нужен, но пусть будет) 
        /// </summary>
        public MessageCustom()
        {
            InitializeComponent();
        }

        private String reminder; // тут будет наше напоминание 
        private int indexRewriteReminder; // индекс перезаписываемого времени напоминания

        /// <summary>
        ////ДАнные get/set требуются нам для чтения и записи компонента reminder 
        ///Поле reminder было сделано private по соображениям безопасности
        ///из учета дальнейшего масштабирования программной системы
        /// </summary>
        public string Reminder {set => reminder = value; }
        public int IndexRewriteReminder { set => indexRewriteReminder = value; }

        public MessageCustom(string nameSobit, string timeSobit, bool what)
        {
            InitializeComponent();
            if (what == true)
            {
                this.Text = "Напоминание о завершении события";
                label2.Text = nameSobit;
                label3.Text = timeSobit;
                label4.Text = "Удалить событие?";
                button1.Text = "Да";
                button2.Text = "Нет";
                timer1.Enabled = true;
                button3.Visible = false;
            }
            else 
            {
                this.Text = "Напонимание о событии";
                label2.Text = nameSobit;
                label3.Text = timeSobit;
                button1.Visible = false;
                button2.Text = "ОК";
                button3.Visible = true;
                timer1.Enabled = true;
            }
        }


        public MessageCustom(string nameSobit, string timeSobit)
        {
            InitializeComponent();
            this.Text = nameSobit;
            label1.Text = timeSobit;
            button1.Text = "Прочесть";
            button1.Width = 80;
            button2.Text = "Отмена";

            button3.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (button1.Visible && button2.Text != "Отмена")
            {
                if (this.Owner is MainForm owner)
                {
                    owner.addUnreadMessage("Напоминание о завершении события");
                    owner.addUnreadMessage(label2.Text);
                    owner.addUnreadMessage(label3.Text);
                    owner.addUnreadMessage(reminder);
                }
            }
            else
            {
                if (this.Owner is MainForm owner)
                {
                    owner.addUnreadMessage("Напоминание о событии");
                    owner.addUnreadMessage(label2.Text);
                    owner.addUnreadMessage(label3.Text);
                    owner.addUnreadMessage(reminder);
                }
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Отмена") 
            {
                Close();
            }
            if (button2.Text == "OK")
            {
                Close();
            }
            if (button2.Text == "Нет")
            {
                Close();
            }
        }

        public int count;

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Да") 
            {
                if (this.Owner is MainForm owner)
                {
                    owner.deleteInMes(count);
                }
                Close();
            }

            if (button1.Text == "Прочесть")
            {
                if (this.Owner is MainForm owner)
                {
                    owner.openWindowMessage();
                }
                Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Parse(reminder);
            int min = dt.Minute;
            int hour = dt.Hour;
            int day = dt.Day;
            int month = dt.Month;
            int year = dt.Year;

            min += 10;

            if (min > 60)
            {
                hour++;
                min = min - 60;
                if (hour > 24)
                {
                    day++;
                    hour = hour - 12;
                    int day_1 = 30;
                    if (month % 2 == 0)
                    {
                        day_1 = 31;
                    }
                    if (day > day_1)
                    {
                        month++;
                        day = day - day_1;
                        if (month >= 12)
                        {
                            year++;
                            month = 1;
                        }
                    }
                }
            }

            string STR = $"{day}.{month}.{year} {hour}:{min}:00";
            
            checkingForTransfer(STR, label3.Text);

        }

        public bool checkingForTransfer(string time1, string time2)
        {
            DateTime dateTimeEvent = DateTime.Parse(time2);
            DateTime dateTimeReminder = DateTime.Parse(time1);

            if (DateTime.Compare(dateTimeEvent, dateTimeReminder) < 0)
            {
                MessageBox.Show(
                    "Невозможно отложить данное событие",
                    "ОШИБКА!!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
                return true;
            }
            else
            {
                if (this.Owner is MainForm owner)
                {
                    owner.rewriteReminder(indexRewriteReminder + 1, time1);
                    owner.rewriteBDEvent("DB.txt");
                }
                Close();
                return false;
            }
        }
    }
}
