namespace Calender
{
    partial class frmDailyPlan
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
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.mnsiAddJob = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsiToDay = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlJob = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpkDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrevieusDay = new System.Windows.Forms.Button();
            this.btnNextDay = new System.Windows.Forms.Button();
            this.mnsMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsiAddJob,
            this.mnsiToDay});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(684, 24);
            this.mnsMain.TabIndex = 0;
            this.mnsMain.Text = "menuStrip1";
            // 
            // mnsiAddJob
            // 
            this.mnsiAddJob.Name = "mnsiAddJob";
            this.mnsiAddJob.Size = new System.Drawing.Size(73, 20);
            this.mnsiAddJob.Text = "Thêm việc";
            this.mnsiAddJob.Click += new System.EventHandler(this.MnsiAddJob_Click);
            // 
            // mnsiToDay
            // 
            this.mnsiToDay.Name = "mnsiToDay";
            this.mnsiToDay.Size = new System.Drawing.Size(68, 20);
            this.mnsiToDay.Text = "Hôm nay";
            this.mnsiToDay.Click += new System.EventHandler(this.MnsiToDay_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlJob);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 270);
            this.panel1.TabIndex = 1;
            // 
            // pnlJob
            // 
            this.pnlJob.Location = new System.Drawing.Point(3, 34);
            this.pnlJob.Name = "pnlJob";
            this.pnlJob.Size = new System.Drawing.Size(654, 233);
            this.pnlJob.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpkDate);
            this.panel2.Controls.Add(this.btnPrevieusDay);
            this.panel2.Controls.Add(this.btnNextDay);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 27);
            this.panel2.TabIndex = 3;
            // 
            // dtpkDate
            // 
            this.dtpkDate.Location = new System.Drawing.Point(239, 3);
            this.dtpkDate.Name = "dtpkDate";
            this.dtpkDate.Size = new System.Drawing.Size(200, 20);
            this.dtpkDate.TabIndex = 2;
            this.dtpkDate.ValueChanged += new System.EventHandler(this.DtpkDate_ValueChanged);
            // 
            // btnPrevieusDay
            // 
            this.btnPrevieusDay.Location = new System.Drawing.Point(3, 2);
            this.btnPrevieusDay.Name = "btnPrevieusDay";
            this.btnPrevieusDay.Size = new System.Drawing.Size(75, 23);
            this.btnPrevieusDay.TabIndex = 0;
            this.btnPrevieusDay.Text = "Hôm qua";
            this.btnPrevieusDay.UseVisualStyleBackColor = true;
            this.btnPrevieusDay.Click += new System.EventHandler(this.BtnPrevieusDay_Click);
            // 
            // btnNextDay
            // 
            this.btnNextDay.Location = new System.Drawing.Point(563, 3);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(75, 23);
            this.btnNextDay.TabIndex = 1;
            this.btnNextDay.Text = "Ngày mai";
            this.btnNextDay.UseVisualStyleBackColor = true;
            this.btnNextDay.Click += new System.EventHandler(this.BtnNextDay_Click);
            // 
            // frmDailyPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 309);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.Name = "frmDailyPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lịch trong ngày";
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem mnsiAddJob;
        private System.Windows.Forms.ToolStripMenuItem mnsiToDay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlJob;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpkDate;
        private System.Windows.Forms.Button btnPrevieusDay;
        private System.Windows.Forms.Button btnNextDay;
    }
}