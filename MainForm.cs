using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemAlarmClock
{
	public partial class MainForm : Form
	{
		String str = ""; // строка для хранения информации о событии
		String str1 = ""; // строка для хранения данных о времени события
		string FileName = "DB.txt"; // наименование файла с базой данных
		int a = -1; // номер строки на которую нажал пользователь 

		/// <summary>
		/// конструктор класса MainForm
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Обработчик события открытия формы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			timer1.Enabled = true; // включение таймера
			StreamReader reader = new StreamReader(FileName); // открытие файла с базой данных
			// и считывание информации из него
			while (!reader.EndOfStream)
			{
				listBox1.Items.Add(reader.ReadLine());
			}
			reader.Close(); // ОБЯЗАТЕЛЬНОЕ ЗАКРЫТИЕ ФАЙЛА
		}
		
		/// <summary>
		/// Обработчик события нажания на кнопку "Добавить событие"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buCreateEvent_Click(object sender, EventArgs e)
		{
			fmAddEvent form2 = new fmAddEvent();
			form2.Owner = this;
			form2.Show();
		}

		/// <summary>
		/// Обработчик события нажания на кнопку "Удалить событие"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show($"Вы уверены, что хотели бы удалить событие: '{str}'?", "Подтвердите удаление",
				MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				deleteEvent(a);
				rewriteBDEvent(FileName);
			}
		}

		/// <summary>
		/// Обработчик события нажания на кнопку "Выход"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Обработчик события нажания на кнопку "Редактировать событие"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button4_Click(object sender, EventArgs e)
		{
			fmRewriteEvent form3 = new fmRewriteEvent();
			form3.Owner = this;
			form3.Show();
			form3.rewritableRecords(str, str1);
		}

		/// <summary>
		/// Обработчик события нажания на событие в списке событий
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (a != -1)
			{
				listBox1.ClearSelected();
				a = -1;
				buDeleteEvent.Visible = false;
				buEditEvents.Visible = false;
			}
			else
			{
				a = listBox1.SelectedIndex;
				if (a % 3 == 0) // нажатие на инфу о событии
				{
					listBox1.ClearSelected();
					listBox1.SetSelected(a, true);
					str = listBox1.Items[a].ToString();
					listBox1.SetSelected(a + 1, true);
					str1 = listBox1.Items[a+1].ToString();
					listBox1.SetSelected(a + 2, true);
				}
				if (a % 3 == 1) // нажатие на время события
				{
					listBox1.ClearSelected();
					listBox1.SetSelected(a - 1, true);
					str = listBox1.Items[a-1].ToString();
					listBox1.SetSelected(a, true);
					str1 = listBox1.Items[a].ToString();
					listBox1.SetSelected(a + 1, true);
				}
				if (a % 3 == 2) // нажатие на время напоминания
				{
					listBox1.ClearSelected();
					listBox1.SetSelected(a - 2, true);
					str = listBox1.Items[a-2].ToString();
					listBox1.SetSelected(a - 1, true);
					str1 = listBox1.Items[a-1].ToString();
					listBox1.SetSelected(a, true);
				}

				buDeleteEvent.Visible = true;
				buEditEvents.Visible = true;
			}
		}

		/// <summary>
		/// ВАРИАНТ СОБЫТИЯ "ПРОВЕРКА ПРИБЛИЖЕНИЯ СОБЫТИЯ"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime systemTime = DateTime.Now;
            eventReminder(systemTime);
            deletionReminder(systemTime);
        }

		/// <summary>
		/// ВАРИАНТ СОБЫТИЯ "НАПОМИНАНИЕ О СОБЫТИИ"
		/// </summary>
		/// <param name="systemTime"></param>
        private void eventReminder(DateTime systemTime)
        {
            for (int i = 0; i < (listBox1.Items.Count + 1) / 3; i++)
            {
                DateTime date = DateTime.Parse(Convert.ToString(listBox1.Items[2 + i * 3])); // это время до события
                if (date.Year == systemTime.Year)
                    if (date.Month == systemTime.Month)
                        if (date.Day == systemTime.Day)
                            if (date.Hour == systemTime.Hour)
                                if (date.Minute == systemTime.Minute)
                                {
									SoundPlayer sp = new SoundPlayer("F:\\JOB\\7 семак\\Системное ПО\\КУРСАЧ\\SystemAlarmClock\\Resourses\\sound.wav");
									sp.Play();
									MessageBox.Show("Скоро придет время события: \n " +
										$"{Convert.ToString(listBox1.Items[0 + i * 3])}\n" +
										$"{Convert.ToString(listBox1.Items[1 + i * 3])}", 
										"Напоминание о приближении события");									
								}
            }
        }

		/// <summary>
		/// ВАРИНАТ СОБЫТИЯ "НАПОМИНАНЕИ О ЗАВЕРШЕНИИ СОБЫТИЯ"
		/// </summary>
		/// <param name="systemTime"></param>
        private void deletionReminder(DateTime systemTime)
        {
            for (int i = 0; i < (listBox1.Items.Count + 1) / 3; i++)
            {
				DateTime date1 = DateTime.Parse(Convert.ToString(listBox1.Items[1 + i * 3])); // это время события
                if (date1.Year <= systemTime.Year)
                    if (date1.Month <= systemTime.Month)
                        if (date1.Day <= systemTime.Day)
                            if (date1.Day == systemTime.Day)
                            {
                                if (date1.Hour <= systemTime.Hour)
                                    if (date1.Hour == systemTime.Hour)
                                    {
                                        if (date1.Minute <= systemTime.Minute)
                                        {
                                            deletingEvent(i);
                                        }
                                    }
                                    else
                                    {
                                        deletingEvent(i);
                                    }
                            }
                            else
                            {
                                deletingEvent(i);
                            }
            }
        }

		/// <summary>
		/// ВЫВОД СООБЩЕНИЯ О ЗАВЕРШЕНИИ СОБЫТИЯ
		/// </summary>
		/// <param name="i"></param>
        private void deletingEvent(int i)
        {
            if (MessageBox.Show($"Вот и пришло завершение события \n " +
							$"Название события: {Convert.ToString(listBox1.Items[0 + i * 3])} \n"+
							$"Время события: {Convert.ToString(listBox1.Items[1 + i * 3])}", 
							"Напоминание о завершении события", 
							MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				deleteEvent(2 + i * 3);
				rewriteBDEvent(FileName);
			}
        }

		/// <summary>
		/// ЗАПИСЬ СТРОКИ В СПИСОК 
		/// </summary>
		/// <param name="str"></param>
		public void recordList(string str)
		{
			listBox1.Items.Add(str);
		}

		/// <summary>
		/// ЗАПИСЬ ДАТЫ В СПИСОК
		/// </summary>
		/// <param name="dt"></param>
		public void recordList(DateTime dt)
		{
			listBox1.Items.Add(dt);
		}

		/// <summary>
		/// ПЕРЕЗАПИСЬ БАЗЫ ДАННЫХ
		/// </summary>
		/// <param name="FileName"></param>
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

		/// <summary>
		/// УДАЛЕНИЕ СОБЫТИЯ
		/// </summary>
		/// <param name="count"></param>
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
			buDeleteEvent.Visible = false;
			buEditEvents.Visible = false;
			a = -1;
		}

		/// <summary>
		/// РЕДАКТИРОВАНИЕ СОБЫТИЯ
		/// </summary>
		/// <param name="str1"></param>
		/// <param name="dateTime1"></param>
		/// <param name="str2"></param>
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
			buDeleteEvent.Visible = false;
			buEditEvents.Visible = false;
			buCreateEvent.Enabled = true;
			a = -1;
			rewriteBDEvent(FileName);
		}
    }
}

