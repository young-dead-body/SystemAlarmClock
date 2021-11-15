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
        public fmRewriteEvent()
        {
            InitializeComponent();
        }

        public void rewritableRecords(string str) 
        {
            richTextBox1.Text = str;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
                this.Controls.Add(panel2);
                panel2.Visible = true;
                this.Height = 410;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buSave.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            buSave.Visible = true;
        }

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
                    h = h + (h - ch);
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
                    owner.rewriteEvent(reminder, eventDateTime, reminderDateTime);
                }

                Close();
            }
        }
    }
}
