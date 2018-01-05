namespace Gprinter_Zxh
{
    partial class Form3
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Bar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_Back = new System.Windows.Forms.CheckBox();
            this.nudBack = new System.Windows.Forms.NumericUpDown();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLF = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBack)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(880, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 489);
            this.panel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_Bar);
            this.groupBox3.Location = new System.Drawing.Point(236, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 148);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "卷标内容设计指令";
            // 
            // btn_Bar
            // 
            this.btn_Bar.Location = new System.Drawing.Point(32, 45);
            this.btn_Bar.Name = "btn_Bar";
            this.btn_Bar.Size = new System.Drawing.Size(117, 63);
            this.btn_Bar.TabIndex = 0;
            this.btn_Bar.Text = "BAR测试";
            this.btn_Bar.UseVisualStyleBackColor = true;
            this.btn_Bar.Click += new System.EventHandler(this.btn_Box_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_Back);
            this.groupBox2.Controls.Add(this.nudBack);
            this.groupBox2.Controls.Add(this.btnBack);
            this.groupBox2.Controls.Add(this.btnLF);
            this.groupBox2.Location = new System.Drawing.Point(236, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "打印指令";
            // 
            // cb_Back
            // 
            this.cb_Back.AutoSize = true;
            this.cb_Back.Location = new System.Drawing.Point(167, 43);
            this.cb_Back.Name = "cb_Back";
            this.cb_Back.Size = new System.Drawing.Size(22, 21);
            this.cb_Back.TabIndex = 6;
            this.cb_Back.UseVisualStyleBackColor = true;
            // 
            // nudBack
            // 
            this.nudBack.Location = new System.Drawing.Point(290, 41);
            this.nudBack.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudBack.Name = "nudBack";
            this.nudBack.Size = new System.Drawing.Size(92, 28);
            this.nudBack.TabIndex = 7;
            this.nudBack.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(195, 34);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(89, 37);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "退纸";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnLF
            // 
            this.btnLF.Location = new System.Drawing.Point(18, 34);
            this.btnLF.Name = "btnLF";
            this.btnLF.Size = new System.Drawing.Size(102, 37);
            this.btnLF.TabIndex = 5;
            this.btnLF.Text = "走纸";
            this.btnLF.UseVisualStyleBackColor = true;
            this.btnLF.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_test);
            this.groupBox1.Location = new System.Drawing.Point(17, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "常规指令";
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(32, 27);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(128, 59);
            this.btn_test.TabIndex = 5;
            this.btn_test.Text = "标签测试页";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 603);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form3";
            this.Text = "标签打印页面";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBack)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLF;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.NumericUpDown nudBack;
        private System.Windows.Forms.CheckBox cb_Back;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Bar;
    }
}