namespace Calender
{
    partial class FrmMain
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
            this.dtpkDate = new System.Windows.Forms.DateTimePicker();
            this.btnToday = new System.Windows.Forms.Button();
            this.cbNotify = new System.Windows.Forms.CheckBox();
            this.nmNotify = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPrivious = new System.Windows.Forms.Button();
            this.btnMonday = new System.Windows.Forms.Button();
            this.btnTuesday = new System.Windows.Forms.Button();
            this.btnWednesday = new System.Windows.Forms.Button();
            this.btnThursday = new System.Windows.Forms.Button();
            this.btnFriday = new System.Windows.Forms.Button();
            this.btnSaturDay = new System.Windows.Forms.Button();
            this.btnSunday = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmNotify)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nmNotify);
            this.panel1.Controls.Add(this.cbNotify);
            this.panel1.Controls.Add(this.btnToday);
            this.panel1.Controls.Add(this.dtpkDate);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 24);
            this.panel1.TabIndex = 0;
            // 
            // dtpkDate
            // 
            this.dtpkDate.Location = new System.Drawing.Point(236, 1);
            this.dtpkDate.Name = "dtpkDate";
            this.dtpkDate.Size = new System.Drawing.Size(200, 20);
            this.dtpkDate.TabIndex = 0;
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(442, -1);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(75, 23);
            this.btnToday.TabIndex = 1;
            this.btnToday.Text = "Hôm nay";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbNotify
            // 
            this.cbNotify.AutoSize = true;
            this.cbNotify.Location = new System.Drawing.Point(4, 4);
            this.cbNotify.Name = "cbNotify";
            this.cbNotify.Size = new System.Drawing.Size(78, 17);
            this.cbNotify.TabIndex = 2;
            this.cbNotify.Text = "Thông báo";
            this.cbNotify.UseVisualStyleBackColor = true;
            // 
            // nmNotify
            // 
            this.nmNotify.Location = new System.Drawing.Point(80, 3);
            this.nmNotify.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.nmNotify.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmNotify.Name = "nmNotify";
            this.nmNotify.Size = new System.Drawing.Size(47, 20);
            this.nmNotify.TabIndex = 3;
            this.nmNotify.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 326);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNext);
            this.panel3.Controls.Add(this.btnSunday);
            this.panel3.Controls.Add(this.btnSaturDay);
            this.panel3.Controls.Add(this.btnFriday);
            this.panel3.Controls.Add(this.btnThursday);
            this.panel3.Controls.Add(this.btnWednesday);
            this.panel3.Controls.Add(this.btnTuesday);
            this.panel3.Controls.Add(this.btnMonday);
            this.panel3.Controls.Add(this.btnPrivious);
            this.panel3.Location = new System.Drawing.Point(4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(730, 47);
            this.panel3.TabIndex = 0;
            // 
            // btnPrivious
            // 
            this.btnPrivious.Location = new System.Drawing.Point(3, 3);
            this.btnPrivious.Name = "btnPrivious";
            this.btnPrivious.Size = new System.Drawing.Size(75, 40);
            this.btnPrivious.TabIndex = 0;
            this.btnPrivious.Text = "Tháng trước";
            this.btnPrivious.UseVisualStyleBackColor = true;
            // 
            // btnMonday
            // 
            this.btnMonday.Location = new System.Drawing.Point(84, 3);
            this.btnMonday.Name = "btnMonday";
            this.btnMonday.Size = new System.Drawing.Size(75, 40);
            this.btnMonday.TabIndex = 1;
            this.btnMonday.Text = "Thứ 2";
            this.btnMonday.UseVisualStyleBackColor = true;
            // 
            // btnTuesday
            // 
            this.btnTuesday.Location = new System.Drawing.Point(165, 3);
            this.btnTuesday.Name = "btnTuesday";
            this.btnTuesday.Size = new System.Drawing.Size(75, 40);
            this.btnTuesday.TabIndex = 2;
            this.btnTuesday.Text = "Thứ 3";
            this.btnTuesday.UseVisualStyleBackColor = true;
            // 
            // btnWednesday
            // 
            this.btnWednesday.Location = new System.Drawing.Point(246, 3);
            this.btnWednesday.Name = "btnWednesday";
            this.btnWednesday.Size = new System.Drawing.Size(75, 40);
            this.btnWednesday.TabIndex = 3;
            this.btnWednesday.Text = "Thứ 4";
            this.btnWednesday.UseVisualStyleBackColor = true;
            // 
            // btnThursday
            // 
            this.btnThursday.Location = new System.Drawing.Point(327, 3);
            this.btnThursday.Name = "btnThursday";
            this.btnThursday.Size = new System.Drawing.Size(75, 40);
            this.btnThursday.TabIndex = 4;
            this.btnThursday.Text = "Thứ 5";
            this.btnThursday.UseVisualStyleBackColor = true;
            // 
            // btnFriday
            // 
            this.btnFriday.Location = new System.Drawing.Point(408, 3);
            this.btnFriday.Name = "btnFriday";
            this.btnFriday.Size = new System.Drawing.Size(75, 40);
            this.btnFriday.TabIndex = 5;
            this.btnFriday.Text = "Thứ 6";
            this.btnFriday.UseVisualStyleBackColor = true;
            // 
            // btnSaturDay
            // 
            this.btnSaturDay.Location = new System.Drawing.Point(489, 3);
            this.btnSaturDay.Name = "btnSaturDay";
            this.btnSaturDay.Size = new System.Drawing.Size(75, 40);
            this.btnSaturDay.TabIndex = 6;
            this.btnSaturDay.Text = "Thứ 7";
            this.btnSaturDay.UseVisualStyleBackColor = true;
            // 
            // btnSunday
            // 
            this.btnSunday.Location = new System.Drawing.Point(570, 3);
            this.btnSunday.Name = "btnSunday";
            this.btnSunday.Size = new System.Drawing.Size(75, 40);
            this.btnSunday.TabIndex = 7;
            this.btnSunday.Text = "Chủ nhật";
            this.btnSunday.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(651, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 40);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Tháng sau";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(88, 56);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(561, 267);
            this.panel4.TabIndex = 1;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 379);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMain";
            this.Text = "Calender - TVT";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmNotify)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.DateTimePicker dtpkDate;
        private System.Windows.Forms.NumericUpDown nmNotify;
        private System.Windows.Forms.CheckBox cbNotify;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSunday;
        private System.Windows.Forms.Button btnSaturDay;
        private System.Windows.Forms.Button btnFriday;
        private System.Windows.Forms.Button btnThursday;
        private System.Windows.Forms.Button btnWednesday;
        private System.Windows.Forms.Button btnTuesday;
        private System.Windows.Forms.Button btnMonday;
        private System.Windows.Forms.Button btnPrivious;
    }
}

