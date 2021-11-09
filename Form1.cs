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

namespace SystemAlarmClock
{
    public partial class Form1 : Form
    {
		public Form1()
        {
            InitializeComponent();
        }

		int a = -1;
		
        private void button3_Click(object sender, EventArgs e)
        {
			Close();
        }

 

		private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
			if (a != -1)
			{
				listBox1.ClearSelected();
				a = -1;
				button2.Visible = false;
				button4.Visible = false;
			}
			else
			{
				a = listBox1.SelectedIndex;
				if (a % 3 == 0)
				{
					listBox1.ClearSelected();
					listBox1.SetSelected(a, true);
					listBox1.SetSelected(a + 1, true);
					listBox1.SetSelected(a + 2, true);
					//listBox1.SetSelected(a + 3, true);
				}
				if (a % 3 == 1)
				{
					listBox1.ClearSelected();
					listBox1.SetSelected(a - 1, true);
					listBox1.SetSelected(a, true);
					listBox1.SetSelected(a + 1, true);
					//listBox1.SetSelected(a + 2, true);
				}
				if (a % 3 == 2)
				{
					listBox1.ClearSelected();
					listBox1.SetSelected(a - 2, true);
					listBox1.SetSelected(a - 1, true);
					listBox1.SetSelected(a, true);
					//listBox1.SetSelected(a + 1, true);
				}
				//if (a % 4 == 3)
				//{
				//	listBox1.ClearSelected();
				//	listBox1.SetSelected(a - 3, true);
				//	listBox1.SetSelected(a - 2, true);
				//	listBox1.SetSelected(a - 1, true);
				//	listBox1.SetSelected(a, true);
				//}

				button2.Visible = true;
				button4.Visible = true;
			}
		}

		public void recordList(string str)
		{
			listBox1.Items.Add(str);
		}

		public void recordList(DateTime dt)
		{
			listBox1.Items.Add(dt);
		}

		public void rewriteBDEvent(String FileName)
		{
			FileStream file = new FileStream(FileName, FileMode.Create); //создаем файловый поток
			StreamWriter writer = new StreamWriter(file); //создаем «потоковый писатель» и связываем его с файловым потоком
			for (int i = 0; i < listBox1.Items.Count; i++)
			{
				writer.WriteLine(listBox1.Items[i]);
			}
			writer.Close();
		}

        private void button1_Click(object sender, EventArgs e)
        {
			Form2 form2 = new Form2();
			form2.Owner = this;
			form2.Show();
		}

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
