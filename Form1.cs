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
		string FileName = "DB.txt";
		public Form1()
		{
			InitializeComponent();
		}

		int a = -1;

		private void button3_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Form3 form3 = new Form3();
			form3.Owner = this;
			form3.Show();
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

				button2.Visible = true;
				button4.Visible = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form2 form2 = new Form2();
			form2.Owner = this;
			form2.Show();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{

			DateTime systemTime = DateTime.Now;
			for (int i = 0; i < (listBox1.Items.Count + 1) / 3; i++)
			{
				DateTime date = DateTime.Parse(Convert.ToString(listBox1.Items[1 + i * 3])); // это время до события
				if (date.Year <= systemTime.Year)
					if (date.Month <= systemTime.Month)
						if (date.Day <= systemTime.Day)
							if (date.Day == systemTime.Day)
							{
								if (date.Hour <= systemTime.Hour)
									if (date.Hour == systemTime.Hour)
									{
										if (date.Minute <= systemTime.Minute)
										{
											MessageBox.Show($"Вот и пришло завершение события \n " +
												$"{Convert.ToString(listBox1.Items[1 + i * 3])}", "ВОУ ВОУ");
											deleteEvent(2 + i * 3);
											rewriteBDEvent(FileName);
										}
									}
									else 
									{
										MessageBox.Show($"Вот и пришло завершение события \n " +
												$"{Convert.ToString(listBox1.Items[1 + i * 3])}", "ВОУ ВОУ");
										deleteEvent(2 + i * 3);
										rewriteBDEvent(FileName);
									}
							}
							else 
							{
								MessageBox.Show($"Вот и пришло завершение события \n " +
											$"{Convert.ToString(listBox1.Items[1 + i * 3])}", "ВОУ ВОУ");
								deleteEvent(2 + i * 3);
								rewriteBDEvent(FileName);
							}
			}


			for (int i = 0; i < (listBox1.Items.Count + 1) / 3; i++)
			{
				DateTime date = DateTime.Parse(Convert.ToString(listBox1.Items[2 + i * 3])); // это время события
				if (date.Year == systemTime.Year)
					if (date.Month == systemTime.Month)
						if (date.Day == systemTime.Day)
							if (date.Hour == systemTime.Hour)
								if (date.Minute == systemTime.Minute)
								{
									MessageBox.Show("Скоро придет время события \n " +
										$"{Convert.ToString(listBox1.Items[1 + i * 3])}", "ВОУ ВОУ");
								}
			}


		}
		private void Form1_Load(object sender, EventArgs e)
		{
			timer1.Enabled = true;
			StreamReader reader = new StreamReader(FileName);
			while (!reader.EndOfStream)
			{
				listBox1.Items.Add(reader.ReadLine());
			}
			reader.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			deleteEvent(a);
			rewriteBDEvent(FileName);
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

		public void deleteEvent(int count)
		{
			if (count % 3 == 0)
			{
				listBox1.ClearSelected();
				listBox1.Items.RemoveAt(count);
				listBox1.Items.RemoveAt(count);
				listBox1.Items.RemoveAt(count);
			}
			if (count % 3 == 1)
			{
				listBox1.ClearSelected();
				listBox1.Items.RemoveAt(count - 1);
				listBox1.Items.RemoveAt(count - 1);
				listBox1.Items.RemoveAt(count - 1);
			}
			if (count % 3 == 2)
			{
				listBox1.ClearSelected();
				listBox1.Items.RemoveAt(count - 2);
				listBox1.Items.RemoveAt(count - 2);
				listBox1.Items.RemoveAt(count - 2);
			}
			button2.Visible = false;
			button4.Visible = false;
			a = -1;
		}

		public void rewriteEvent(String str1, DateTime dateTime1, String str2)
		{
			if (a % 3 == 0)
			{
				listBox1.ClearSelected();
				listBox1.Items[a] = str1;
				listBox1.Items[a + 1] = dateTime1;
				listBox1.Items[a + 2] = str2;
			}
			else if (a % 3 == 1)
			{
				listBox1.ClearSelected();
				listBox1.Items[a - 1] = str1;
				listBox1.Items[a] = dateTime1;
				listBox1.Items[a + 1] = str2;
			}
			else if (a % 3 == 2)
			{
				listBox1.ClearSelected();
				listBox1.Items[a - 2] = str1;
				listBox1.Items[a - 1] = dateTime1;
				listBox1.Items[a] = str2;
			}
			button2.Visible = false;
			button4.Visible = false;
			button1.Enabled = true;
			a = -1;
			rewriteBDEvent(FileName);
		}

	}
}

