namespace 报障系统
{
    partial class Config
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serverip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.point = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sendpointin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.localpint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(231, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "服务器IP地址：";
            // 
            // serverip
            // 
            this.serverip.Location = new System.Drawing.Point(116, 20);
            this.serverip.Name = "serverip";
            this.serverip.Size = new System.Drawing.Size(190, 21);
            this.serverip.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "通信端口号：";
            // 
            // point
            // 
            this.point.Location = new System.Drawing.Point(116, 73);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(190, 21);
            this.point.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sendpointin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.localpint);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.point);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.serverip);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(23, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 248);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本设置";
            // 
            // sendpointin
            // 
            this.sendpointin.Location = new System.Drawing.Point(116, 168);
            this.sendpointin.Name = "sendpointin";
            this.sendpointin.Size = new System.Drawing.Size(190, 21);
            this.sendpointin.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "本机发送端口：";
            // 
            // localpint
            // 
            this.localpint.Location = new System.Drawing.Point(116, 117);
            this.localpint.Name = "localpint";
            this.localpint.Size = new System.Drawing.Size(190, 21);
            this.localpint.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "本机监听端口：";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(456, 310);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox point;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox localpint;
        private System.Windows.Forms.TextBox sendpointin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}