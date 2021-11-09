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
    public partial class Form2 : Form
    {


        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String reminder = "";
            DateTime eventDateTime;
            String reminderDateTime;

            if (richTextBox1.Text == "" || dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("Ошибка ввода данных", "Ошибка!!!", MessageBoxButtons.OK);
            }
            else 
            {
                reminder = richTextBox1.Text;
                eventDateTime = dateTimePicker1.Value;
                reminderDateTime = $"{eventDateTime.Day}.{eventDateTime.Month}.{eventDateTime.Year} " +
                    $"{eventDateTime.Hour}:{eventDateTime.Minute}";

                if (this.Owner is Form1 owner)
                {
                    owner.recordList(reminder);
                    owner.recordList(eventDateTime);
                    owner.recordList(reminderDateTime);
                }

                Close();
            }

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (button2.Visible)
            {
                button2.Visible = false;
                panel2.Visible = true;
                Height = 404;
            }
            else 
            {
                button2.Visible = true;
                panel2.Visible = false;
                Height = 300;
            }
        }
    }
}
