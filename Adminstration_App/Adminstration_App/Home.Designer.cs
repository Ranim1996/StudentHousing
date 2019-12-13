namespace Adminstration_App
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mbtnLogOut = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPlaceanEvent = new System.Windows.Forms.Button();
            this.tbxPlaceanEvent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxStudentName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnChooseDate = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxAssignTask = new System.Windows.Forms.TextBox();
            this.tbxDate = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxComplains = new System.Windows.Forms.ListBox();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lbxRequestedEvent = new System.Windows.Forms.ListBox();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbxPublishAnouncement = new System.Windows.Forms.TextBox();
            this.btnPublish = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbxRecievedAnoun = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.mbtnLogOut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 542);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Adminstration_App.Properties.Resources.Profile_512;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // mbtnLogOut
            // 
            this.mbtnLogOut.BackColor = System.Drawing.Color.Teal;
            this.mbtnLogOut.Location = new System.Drawing.Point(0, 500);
            this.mbtnLogOut.Name = "mbtnLogOut";
            this.mbtnLogOut.Size = new System.Drawing.Size(118, 42);
            this.mbtnLogOut.TabIndex = 0;
            this.mbtnLogOut.Text = "LogOut";
            this.mbtnLogOut.UseSelectable = true;
            this.mbtnLogOut.Click += new System.EventHandler(this.MbtnLogOut_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(118, 0);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 3;
            this.metroTabControl1.Size = new System.Drawing.Size(667, 542);
            this.metroTabControl1.TabIndex = 1;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.panel2);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(659, 500);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Schedule";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.btnPlaceanEvent);
            this.panel2.Controls.Add(this.tbxPlaceanEvent);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tbxStudentName);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnChooseDate);
            this.panel2.Controls.Add(this.btnAssign);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbxAssignTask);
            this.panel2.Controls.Add(this.tbxDate);
            this.panel2.Controls.Add(this.monthCalendar1);
            this.panel2.Location = new System.Drawing.Point(0, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(663, 500);
            this.panel2.TabIndex = 2;
            // 
            // btnPlaceanEvent
            // 
            this.btnPlaceanEvent.Location = new System.Drawing.Point(404, 370);
            this.btnPlaceanEvent.Name = "btnPlaceanEvent";
            this.btnPlaceanEvent.Size = new System.Drawing.Size(153, 31);
            this.btnPlaceanEvent.TabIndex = 11;
            this.btnPlaceanEvent.Text = "Place an Event";
            this.btnPlaceanEvent.UseVisualStyleBackColor = true;
            this.btnPlaceanEvent.Click += new System.EventHandler(this.BtnPlaceanEvent_Click);
            // 
            // tbxPlaceanEvent
            // 
            this.tbxPlaceanEvent.Location = new System.Drawing.Point(141, 406);
            this.tbxPlaceanEvent.Name = "tbxPlaceanEvent";
            this.tbxPlaceanEvent.Size = new System.Drawing.Size(227, 22);
            this.tbxPlaceanEvent.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 406);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Event:";
            // 
            // tbxStudentName
            // 
            this.tbxStudentName.Location = new System.Drawing.Point(141, 281);
            this.tbxStudentName.Name = "tbxStudentName";
            this.tbxStudentName.Size = new System.Drawing.Size(227, 22);
            this.tbxStudentName.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Student name:";
            // 
            // btnChooseDate
            // 
            this.btnChooseDate.Location = new System.Drawing.Point(404, 96);
            this.btnChooseDate.Name = "btnChooseDate";
            this.btnChooseDate.Size = new System.Drawing.Size(153, 35);
            this.btnChooseDate.TabIndex = 6;
            this.btnChooseDate.Text = "Choose Date";
            this.btnChooseDate.UseVisualStyleBackColor = true;
            this.btnChooseDate.Click += new System.EventHandler(this.BtnChooseDate_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(404, 303);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(153, 35);
            this.btnAssign.TabIndex = 5;
            this.btnAssign.Text = "Assign Task";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.BtnAssign_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Assign Task:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selected Date:";
            // 
            // tbxAssignTask
            // 
            this.tbxAssignTask.Location = new System.Drawing.Point(141, 363);
            this.tbxAssignTask.Name = "tbxAssignTask";
            this.tbxAssignTask.Size = new System.Drawing.Size(227, 22);
            this.tbxAssignTask.TabIndex = 2;
            // 
            // tbxDate
            // 
            this.tbxDate.Location = new System.Drawing.Point(141, 326);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Size = new System.Drawing.Size(227, 22);
            this.tbxDate.TabIndex = 1;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.monthCalendar1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.monthCalendar1.Location = new System.Drawing.Point(37, 23);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.panel3);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(659, 500);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "ViewComplains";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lbxComplains);
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(663, 501);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "The recieved complains:";
            // 
            // lbxComplains
            // 
            this.lbxComplains.FormattingEnabled = true;
            this.lbxComplains.ItemHeight = 16;
            this.lbxComplains.Location = new System.Drawing.Point(30, 79);
            this.lbxComplains.Name = "lbxComplains";
            this.lbxComplains.Size = new System.Drawing.Size(518, 292);
            this.lbxComplains.TabIndex = 0;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.panel4);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(659, 500);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Requested Events";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel4.Controls.Add(this.btnReject);
            this.panel4.Controls.Add(this.btnAccept);
            this.panel4.Controls.Add(this.lbxRequestedEvent);
            this.panel4.Location = new System.Drawing.Point(-4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(667, 500);
            this.panel4.TabIndex = 2;
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(346, 413);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(137, 43);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.BtnReject_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(194, 413);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(137, 43);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // lbxRequestedEvent
            // 
            this.lbxRequestedEvent.FormattingEnabled = true;
            this.lbxRequestedEvent.ItemHeight = 16;
            this.lbxRequestedEvent.Location = new System.Drawing.Point(29, 23);
            this.lbxRequestedEvent.Name = "lbxRequestedEvent";
            this.lbxRequestedEvent.Size = new System.Drawing.Size(600, 356);
            this.lbxRequestedEvent.TabIndex = 0;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.panel5);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 10;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(659, 500);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "New Anouncements";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel5.Controls.Add(this.tbxPublishAnouncement);
            this.panel5.Controls.Add(this.btnPublish);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.lbxRecievedAnoun);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(-4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(667, 500);
            this.panel5.TabIndex = 2;
            // 
            // tbxPublishAnouncement
            // 
            this.tbxPublishAnouncement.Location = new System.Drawing.Point(351, 74);
            this.tbxPublishAnouncement.Multiline = true;
            this.tbxPublishAnouncement.Name = "tbxPublishAnouncement";
            this.tbxPublishAnouncement.Size = new System.Drawing.Size(256, 340);
            this.tbxPublishAnouncement.TabIndex = 7;
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(396, 429);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(187, 47);
            this.btnPublish.TabIndex = 6;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.BtnPublish_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(347, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Make an Anouncement:";
            // 
            // lbxRecievedAnoun
            // 
            this.lbxRecievedAnoun.FormattingEnabled = true;
            this.lbxRecievedAnoun.ItemHeight = 16;
            this.lbxRecievedAnoun.Location = new System.Drawing.Point(59, 74);
            this.lbxRecievedAnoun.Name = "lbxRecievedAnoun";
            this.lbxRecievedAnoun.Size = new System.Drawing.Size(253, 340);
            this.lbxRecievedAnoun.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Recieved anouncements:";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(785, 542);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Home";
            this.Text = "Home";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.metroTabPage4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton mbtnLogOut;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxAssignTask;
        private System.Windows.Forms.TextBox tbxDate;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnChooseDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxComplains;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListBox lbxRecievedAnoun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxStudentName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxPublishAnouncement;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Button btnPlaceanEvent;
        private System.Windows.Forms.TextBox tbxPlaceanEvent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ListBox lbxRequestedEvent;
    }
}