// ***************************************************************
//  Form1   version:  1.0   ? date: 09/11/2007
//  -------------------------------------------------------------
//  在托盘建立程序图标并也许隐藏运行程序支持热键在隐藏和显示间切换
//  (热键Ctrl+F12)
//  -------------------------------------------------------------
//  Copyright (C) 2007 - All Rights Reserved
// ***************************************************************
//  zmj
// ***************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Management;
using System.Configuration;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using agsXMPP;
using Model;
using System.Data.SqlClient;
using DALProfile;

namespace 报障系统
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public partial class Form1 : System.Windows.Forms.Form
    {
        private int Hotkey1;
        private bool _isClosed;
        TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, 2222));    //2222端口


        private string username; //传过来的用户名用做从客户端登录C/S模式的系统
        private string realnane;//保存用户的真实姓名
        

          
        //private System.Windows.Forms.NotifyIcon notifyIcon1;
        //private QQClient.QQ.QQBuddy.Components.AutoDockManage autoDockManage1;
        //private MenuStrip menuStrip1;
        //private ToolStripMenuItem 菜单ToolStripMenuItem;
        //private ToolStripMenuItem 退出ToolStripMenuItem;
        //private System.ComponentModel.IContainer components;

        public Form1()
        {
           
        }

        public Form1(loginstate lgs)
        {
            // Windows 窗体设计器支持所必需的
            //InitializeComponent1();
            InitializeComponent();
            //初始化托盘程序的各个要素
            Initializenotifyicon();
            this.username = lgs.Username.ToString();
            this.realnane =lgs.Realname.ToString();
            this.label1.Text = username+"欢迎使用本系统";
            listener.Start();  //开始侦听端口

            //Thread acceptThread = new Thread(new ThreadStart(AcceptWorkThread));

            //acceptThread.Start();  //接受客户端请求        
        }


        //private void AcceptWorkThread()
        //{

        //    Socket socket = listener.AcceptSocket();

        //    byte[] buffer = new byte[1024];

        //    while (true)
        //    {

        //        int receiveCount = socket.Receive(buffer);

        //        if (receiveCount > 0)
        //        {

        //            string recString = Encoding.UTF8.GetString(buffer, 0, receiveCount);  //解码

        //            //ShowMsg(recString);

        //        }

        //        else
        //        {

        //            socket.Close();

        //            break;

        //        }

        //    }

        //}



        ///// <summary>
        ///// 清理所有正在使用的资源。
        ///// </summary>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (components != null)
        //        {
        //            components.Dispose();
        //        }
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        //private void InitializeComponent1()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        //    this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
        //    this.autoDockManage1 = new QQClient.QQ.QQBuddy.Components.AutoDockManage(this.components);
        //    this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        //    this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        //    this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        //    this.menuStrip1.SuspendLayout();
        //    this.SuspendLayout();
        //    // 
        //    // notifyIcon1
        //    // 
        //    this.notifyIcon1.Text = "notifyIcon1";
        //    this.notifyIcon1.Visible = true;
        //    // 
        //    // autoDockManage1
        //    // 
        //    this.autoDockManage1.DockForm = this;
        //    // 
        //    // menuStrip1
        //    // 
        //    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        //    this.菜单ToolStripMenuItem});
        //    this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        //    this.menuStrip1.Name = "menuStrip1";
        //    this.menuStrip1.Size = new System.Drawing.Size(202, 24);
        //    this.menuStrip1.TabIndex = 0;
        //    this.menuStrip1.Text = "menuStrip1";
        //    // 
        //    // 菜单ToolStripMenuItem
        //    // 
        //    this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        //    this.退出ToolStripMenuItem});
        //    this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
        //    this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
        //    this.菜单ToolStripMenuItem.Text = "菜单";
        //    // 
        //    // 退出ToolStripMenuItem
        //    // 
        //    this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
        //    this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        //    this.退出ToolStripMenuItem.Text = "退出";
        //    this.退出ToolStripMenuItem.Click += new System.EventHandler(this.ExitSelect);
        //    // 
        //    // Form1
        //    // 
        //    this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
        //    this.ClientSize = new System.Drawing.Size(202, 443);
        //    this.Controls.Add(this.menuStrip1);
        //    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        //    this.MainMenuStrip = this.menuStrip1;
        //    this.Name = "Form1";
        //    this.Text = "报障系统";
        //    this.TopMost = true;
        //    this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
        //    this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
        //    this.Load += new System.EventHandler(this.Form1_Load);
        //    this.menuStrip1.ResumeLayout(false);
        //    this.menuStrip1.PerformLayout();
        //    this.ResumeLayout(false);
        //    this.PerformLayout();

        //}
        #endregion
        ///// <summary>
        ///// 应用程序的主入口点。
        ///// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.Run(new Form1());
        //}
        private void Initializenotifyicon()
        {
            //设置系统托盘的各个属性
            notifyIcon1 = new NotifyIcon();
            notifyIcon1.Icon = new Icon("App.ico");
            notifyIcon1.Text = "报障系统";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += new System.EventHandler(this._Click);
            //定义一个MenuItem数组，并把此数组同时赋值给ContextMenu对象
            MenuItem[] mnuItems = new MenuItem[3];
            mnuItems[0] = new MenuItem();
            mnuItems[0].Text = "隐藏运行(Crtl+F12)";
            mnuItems[0].Click += new EventHandler(this.showmessage);

            mnuItems[1] = new MenuItem("-");

            mnuItems[2] = new MenuItem();
            mnuItems[2].Text = "退出系统";
            mnuItems[2].DefaultItem = true;
            mnuItems[2].Click += new System.EventHandler(this.ExitSelect);

            notifyIcon1.ContextMenu = new ContextMenu(mnuItems);
        }
        public void _Click(object sender, EventArgs e)
        {
            this.Show();
            this.Visible = true;

        }
        public void showmessage(object sender, System.EventArgs e)
        {
            //　         MessageBox.Show ( "隐藏运行(Crtl+F12)" ) ;					
            this.Hide();
            notifyIcon1.Visible = false;
        }
        public void ExitSelect(object sender, System.EventArgs e)
        {
            //隐藏托盘程序中的图标
            notifyIcon1.Visible = false;
            _isClosed = true;
            //this.Close();
            Application.Exit();
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.TopMost = false;
            //skinEngine1.SkinFile = Application.StartupPath + @"\MacOS.ssk";

            notifyIcon1.Visible = false;
            Hotkey hotkey;
            hotkey = new Hotkey(this.Handle);
            //定义快键(Ctrl + F1)
            Hotkey1 = hotkey.RegisterHotkey(System.Windows.Forms.Keys.F12, Hotkey.KeyFlags.MOD_CONTROL);
            hotkey.OnHotkey += new HotkeyEventHandler(OnHotkey);
        }
        //添加快键调用函数(显示/隐藏窗口):
        public void OnHotkey(int HotkeyID)
        {
            if (HotkeyID == Hotkey1)
            {
                if (this.Visible == true || notifyIcon1.Visible == true)
                {
                    this.Visible = false;
                    notifyIcon1.Visible = false;
                }
                else
                {
                    this.Visible = true;
                    notifyIcon1.Visible = true;
                }
            }
            else
            {
                this.Visible = false;
            }
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (_isClosed)
            {
                e.Cancel = false;
                //				this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon1.Visible = true;
            }
            //			this.ShowInTaskbar = false;
        }

        private void Form1_SizeChanged(object sender, System.EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Hide();
                this.notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FaultCheck falu = new FaultCheck();
            //falu.Show();
            //this.panel2.Visible = false;
            //this.panel3.Visible = false;
            //this.panel3.Visible = false;
            //this.panel2.Visible = false;
            
        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    System.Diagnostics.Process.Start("www.sina.com"); 
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    System.Diagnostics.Process.Start("www.yahoo.com"); 
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    System.Diagnostics.Process.Start("www.google.com"); 
        //}

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Show();
                this.ShowDialog();
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //string admin = "admin";
            //string url = ConfigurationSettings.AppSettings["WebIp"].ToString();
            System.Diagnostics.Process.Start("http://210.37.1.139/loginbyclient.aspx?username=" +username);
            //FaultCheck flc = new FaultCheck();
            //flc.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "当前日期："+DateTime.Now.ToString();
        }

        public string macaddress()
        {
            string strings = "";
            ManagementClass mc;
            ManagementObjectCollection moc;
            mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    strings = mo["MacAddress"].ToString();
                }
            }
            return strings;
        }

        private void 苹果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"\MacOS.ssk";
        }

        private void vistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"\vista1.ssk";
        }

        private void 默认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = null;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modiftypassword modipwd = new modiftypassword();
            modipwd.Show();
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = DBHelper.getConnection();
            
        }



        
        

       
        


    }
}
