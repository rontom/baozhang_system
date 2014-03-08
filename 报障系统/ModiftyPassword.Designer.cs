namespace 报障系统
{
    partial class modiftypassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.oldpassword = new System.Windows.Forms.TextBox();
            this.newpassword = new System.Windows.Forms.TextBox();
            this.checkpassword = new System.Windows.Forms.TextBox();
            this.modifty = new System.Windows.Forms.Button();
            this.closepassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "旧密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "新密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认密码：";
            // 
            // oldpassword
            // 
            this.oldpassword.Location = new System.Drawing.Point(98, 20);
            this.oldpassword.Name = "oldpassword";
            this.oldpassword.PasswordChar = '*';
            this.oldpassword.Size = new System.Drawing.Size(150, 21);
            this.oldpassword.TabIndex = 3;
            // 
            // newpassword
            // 
            this.newpassword.Location = new System.Drawing.Point(98, 55);
            this.newpassword.Name = "newpassword";
            this.newpassword.PasswordChar = '*';
            this.newpassword.Size = new System.Drawing.Size(150, 21);
            this.newpassword.TabIndex = 4;
            // 
            // checkpassword
            // 
            this.checkpassword.Location = new System.Drawing.Point(98, 95);
            this.checkpassword.Name = "checkpassword";
            this.checkpassword.PasswordChar = '*';
            this.checkpassword.Size = new System.Drawing.Size(150, 21);
            this.checkpassword.TabIndex = 5;
            // 
            // modifty
            // 
            this.modifty.Location = new System.Drawing.Point(98, 142);
            this.modifty.Name = "modifty";
            this.modifty.Size = new System.Drawing.Size(75, 23);
            this.modifty.TabIndex = 6;
            this.modifty.Text = "确认修改";
            this.modifty.UseVisualStyleBackColor = true;
            this.modifty.Click += new System.EventHandler(this.modifty_Click);
            // 
            // closepassword
            // 
            this.closepassword.Location = new System.Drawing.Point(175, 142);
            this.closepassword.Name = "closepassword";
            this.closepassword.Size = new System.Drawing.Size(75, 23);
            this.closepassword.TabIndex = 7;
            this.closepassword.Text = "关闭";
            this.closepassword.UseVisualStyleBackColor = true;
            this.closepassword.Click += new System.EventHandler(this.closepassword_Click);
            // 
            // modiftypassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 197);
            this.Controls.Add(this.closepassword);
            this.Controls.Add(this.modifty);
            this.Controls.Add(this.checkpassword);
            this.Controls.Add(this.newpassword);
            this.Controls.Add(this.oldpassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "modiftypassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.修改密码_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox oldpassword;
        private System.Windows.Forms.TextBox newpassword;
        private System.Windows.Forms.TextBox checkpassword;
        private System.Windows.Forms.Button modifty;
        private System.Windows.Forms.Button closepassword;
    }
}