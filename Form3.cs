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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

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


                if (checkBox1.Checked)
                {
                    //========работает корректно========
                    int d = (int)eventDateTime.Day;
                    int m = (int)eventDateTime.Month;
                    if (d - 1 == 0)
                    {
                        d = 30 + (d - 1);
                        m--;
                    }
                    else
                    {
                        d--;
                    }
                    reminderDateTime = $"{d}.{m}.{eventDateTime.Year} " +
                                                            $"{eventDateTime.Hour}:{eventDateTime.Minute}";
                    //==================================
                }
                else
                {
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
                }


                if (this.Owner is Form1 owner)
                {
                    owner.recordList(reminder);
                    owner.recordList(eventDateTime);
                    owner.recordList(reminderDateTime);
                    owner.rewriteBDEvent(FileName);
                }

                Close();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button2.Visible = true;
                panel2.Visible = false;
                Height = 300;
            }
            else
            {
                button2.Visible = false;
                panel2.Visible = true;
                Height = 404;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Visible = true;
        }

        private void rewriteEvent() 
        {
            //if (a % 4 == 0)
            //{
            //    listBox1.ClearSelected();
            //    listBox1.Items[a] = richTextBox1.Text + importance;
            //    listBox1.Items[a + 1] = richTextBox2.Text;
            //    listBox1.Items[a + 2] = words[0];
            //    listBox1.Items[a + 3] = words[1];
            //}
            //else if (a % 4 == 1)
            //{
            //    listBox1.ClearSelected();
            //    listBox1.Items[a - 1] = richTextBox1.Text + importance;
            //    listBox1.Items[a] = richTextBox2.Text;
            //    listBox1.Items[a + 1] = words[0];
            //    listBox1.Items[a + 2] = words[1];
            //}
            //else if (a % 4 == 2)
            //{
            //    listBox1.ClearSelected();
            //    listBox1.Items[a - 2] = richTextBox1.Text + importance;
            //    listBox1.Items[a - 1] = richTextBox2.Text;
            //    listBox1.Items[a] = words[0];
            //    listBox1.Items[a + 1] = words[1];
            //}
            //button2.Visible = false;
            //button4.Visible = false;
            //button1.Enabled = true;
            //a = -1;
            //rewriteBDEvent(FileName);
        }
    }
}
