
namespace SystemAlarmClock
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buCreateEvent = new System.Windows.Forms.Button();
            this.buDeleteEvent = new System.Windows.Forms.Button();
            this.buEditEvents = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buClose
            // 
            this.buClose.BackColor = System.Drawing.SystemColors.ControlText;
            this.buClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buClose.ForeColor = System.Drawing.Color.LightGray;
            this.buClose.Location = new System.Drawing.Point(546, 386);
            this.buClose.Margin = new System.Windows.Forms.Padding(4);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(89, 32);
            this.buClose.TabIndex = 36;
            this.buClose.Text = "Выход";
            this.buClose.UseVisualStyleBackColor = false;
            this.buClose.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(16, 35);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(364, 382);
            this.listBox1.TabIndex = 39;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // buCreateEvent
            // 
            this.buCreateEvent.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buCreateEvent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buCreateEvent.Location = new System.Drawing.Point(389, 35);
            this.buCreateEvent.Name = "buCreateEvent";
            this.buCreateEvent.Size = new System.Drawing.Size(249, 49);
            this.buCreateEvent.TabIndex = 40;
            this.buCreateEvent.Text = "Добавить событие";
            this.buCreateEvent.UseVisualStyleBackColor = false;
            this.buCreateEvent.Click += new System.EventHandler(this.buCreateEvent_Click);
            // 
            // buDeleteEvent
            // 
            this.buDeleteEvent.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buDeleteEvent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buDeleteEvent.Location = new System.Drawing.Point(389, 94);
            this.buDeleteEvent.Name = "buDeleteEvent";
            this.buDeleteEvent.Size = new System.Drawing.Size(121, 47);
            this.buDeleteEvent.TabIndex = 41;
            this.buDeleteEvent.Text = "Удалить событие";
            this.buDeleteEvent.UseVisualStyleBackColor = false;
            this.buDeleteEvent.Visible = false;
            this.buDeleteEvent.Click += new System.EventHandler(this.button2_Click);
            // 
            // buEditEvents
            // 
            this.buEditEvents.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buEditEvents.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buEditEvents.Location = new System.Drawing.Point(514, 94);
            this.buEditEvents.Name = "buEditEvents";
            this.buEditEvents.Size = new System.Drawing.Size(124, 47);
            this.buEditEvents.TabIndex = 42;
            this.buEditEvents.Text = "Редактировать событие";
            this.buEditEvents.UseVisualStyleBackColor = false;
            this.buEditEvents.Visible = false;
            this.buEditEvents.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 43;
            this.label1.Text = "Список событий";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.OrangeRed;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Image = global::SystemAlarmClock.Properties.Resources._1904660_email_envelope_letter_mail_message_post_send_122510;
            this.button1.Location = new System.Drawing.Point(599, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 30);
            this.button1.TabIndex = 44;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 15000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(650, 436);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buEditEvents);
            this.Controls.Add(this.buDeleteEvent);
            this.Controls.Add(this.buCreateEvent);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Системный будильник";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buCreateEvent;
        private System.Windows.Forms.Button buDeleteEvent;
        private System.Windows.Forms.Button buEditEvents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer2;
    }
}

