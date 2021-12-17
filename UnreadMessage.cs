using System;
using System.Collections;
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
    public partial class UnreadMessage : Form
    {
        public UnreadMessage()
        {
            InitializeComponent();
        }

        public UnreadMessage(ArrayList unreadMessage)
        {
			InitializeComponent();
			foreach (var str_col in unreadMessage)
            {
                listBox1.Items.Add(str_col.ToString());
            }
        }

		int a = -1;
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
			if (a != -1)
			{
				listBox1.ClearSelected();
				a = -1;
				//button2->Visible = false;
				//button4->Visible = false;
			}
			else
			{
				a = listBox1.SelectedIndex;
				if (a % 4 == 0)
				{
					listBox1.ClearSelected();
					listBox1.SetSelected(a, true);
					listBox1.SetSelected(a + 1, true);
					listBox1.SetSelected(a + 2, true);
					listBox1.SetSelected(a + 3, true);
				}
				if (a % 4 == 1)
				{
					listBox1.ClearSelected();
					listBox1.SetSelected(a - 1, true);
					listBox1.SetSelected(a, true);
					listBox1.SetSelected(a + 1, true);
					listBox1.SetSelected(a + 2, true);
				}
				if (a % 4 == 2)
				{
					listBox1.ClearSelected();
					listBox1.SetSelected(a - 2, true);
					listBox1.SetSelected(a - 1, true);
					listBox1.SetSelected(a, true);
					listBox1.SetSelected(a + 1, true);
				}
				if (a % 4 == 3)
				{
					listBox1.ClearSelected();
					listBox1.SetSelected(a - 3, true);
					listBox1.SetSelected(a - 2, true);
					listBox1.SetSelected(a - 1, true);
					listBox1.SetSelected(a, true);
				}

				if (MessageBox.Show("Вы хотели бы удалить сообщение?", "Информация", MessageBoxButtons.YesNo) == DialogResult.Yes) 
				{
					delete();
				}
			}
		
		}

		private void delete() 
		{
			int num;
			ArrayList aL = new ArrayList();
			if (a % 4 == 0)
			{
				num = a;
				aL.Add(listBox1.Items[num + 1]);
				aL.Add(listBox1.Items[num + 2]);
				aL.Add(listBox1.Items[num + 3]);

				listBox1.ClearSelected();
				listBox1.Items.RemoveAt(a);
				listBox1.Items.RemoveAt(a);
				listBox1.Items.RemoveAt(a);
				listBox1.Items.RemoveAt(a);
			}
			if (a % 4 == 1)
			{
				num = a-1;
				aL.Add(listBox1.Items[num + 1]);
				aL.Add(listBox1.Items[num + 2]);
				aL.Add(listBox1.Items[num + 3]);

				listBox1.ClearSelected();
				listBox1.Items.RemoveAt(a-1);
				listBox1.Items.RemoveAt(a - 1);
				listBox1.Items.RemoveAt(a - 1);
				listBox1.Items.RemoveAt(a - 1);

			}
			if (a % 4 == 2)
			{
				num = a - 2;
				aL.Add(listBox1.Items[num + 1]);
				aL.Add(listBox1.Items[num + 2]);
				aL.Add(listBox1.Items[num + 3]);

				listBox1.ClearSelected();
				listBox1.Items.RemoveAt(a - 2);
				listBox1.Items.RemoveAt(a - 2); 
				listBox1.Items.RemoveAt(a - 2); 
				listBox1.Items.RemoveAt(a - 2);
			}
			if (a % 4 == 3)
			{
				num = a - 3;
				aL.Add(listBox1.Items[num + 1]);
				aL.Add(listBox1.Items[num + 2]);
				aL.Add(listBox1.Items[num + 3]);

				listBox1.ClearSelected();
				listBox1.Items.RemoveAt(a - 3);
				listBox1.Items.RemoveAt(a - 3); 
				listBox1.Items.RemoveAt(a - 3); 
				listBox1.Items.RemoveAt(a - 3);
			}
			a = -1;

			if (this.Owner is MainForm owner)
			{
				owner.passingUnreadMessagesForDelete(aL);
			}
		}

    }
}
