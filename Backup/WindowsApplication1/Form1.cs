using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.SqlClient;
using BLL;
using DALProfile;
using Model;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        //private static string port;
        Socket socket;
        Socket sendSMSsocket;
        Socket checkonlinesocket;
        Thread mythread;
        Thread mysendSMS;
        private string Connectionstring = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        private int listenport = Convert.ToInt32(ConfigurationManager.AppSettings["listenpoint"].ToString());
        private string servertip = ConfigurationManager.AppSettings["serverip"].ToString();
        private int recivertime = Convert.ToInt32(ConfigurationManager.AppSettings["Messagerecivetime"].ToString()) * 60 * 1000;
        private int offtime = Convert.ToInt32(ConfigurationManager.AppSettings["offtime"].ToString()) * 20 * 1000;
        private string url = ConfigurationManager.AppSettings["webdomain"].ToString();
        private string sCen = ConfigurationManager.AppSettings["Ctle"].ToString();
        //private string sNO = ConfigurationManager.AppSettings["Sn"].ToString();
        private string sCon = ConfigurationManager.AppSettings["warmingmessage"].ToString();
        private string filternum = ConfigurationManager.AppSettings["filternum"].ToString();
        private int everyrecivetime = Convert.ToInt32(ConfigurationManager.AppSettings["everyrecivetime"].ToString());
        //private Socket socket;
        //private Thread mythread;
        //private 

        Unclassified_FaultManager Unclassified_FaultManager1 = new Unclassified_FaultManager();
        private bool _isClosed;
        public Form1()
        {
            InitializeComponent();
            Initializenotifyicon();
        }


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
            //System.Environment.Exit(0);
        }



        private void button1_Click(object sender, EventArgs e)
        {

            //SqlConnection conn = new SqlConnection(Connectionstring);
            //conn.Open();
            int port = int.Parse(comboBox1.Text);
            string str = ConfigurationManager.AppSettings["str"].ToString();
            string sN = ConfigurationManager.AppSettings["Sn"].ToString();
            listBox1.Items.Add("============================================================");
            listBox1.Items.Add("[" + DateTime.Now + "]");
            listBox1.Items.Add("正在初始化端口");
            string ret = axSzhtoSms1.YhOpenModem(port, str, sN);

            if (ret.IndexOf("-1") > 0)
            {
                listBox1.Items.Add("端口初始化失败");
            }
            else
            {
                listBox1.Items.Add("端口初始化成功");
                GetModelSignalQuality();

                chekonline.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["offtime"].ToString())*1000*60;
                timer1.Interval = recivertime;
                this.chekonline.Enabled = true;
                this.timer1.Enabled = true;
                gettimernow.Enabled = true;
                this.chekonline.Enabled = true;
                try
                {
                    mythread = new Thread(new ThreadStart(BeginListen));
                    mythread.Start();
                }
                catch (Exception ex)
                {
                    throw ex;
                    //listBox1.Items.Add(ex.Message.ToString());
                }
                try
                {
                    mysendSMS = new Thread(new ThreadStart(ListenhaveSend));
                    mysendSMS.Start();

                }
                catch (SocketException ex)
                {
                    throw ex;
                }
                //BeginListen();
            }


        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conf conf1 = new conf();
            conf1.Show();
            conf1.TopMost = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Hide();
                this.notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (_isClosed)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon1.Visible = true;
            }



        }



        private void Form1_Load(object sender, EventArgs e)
        {
            string[] Port = axSzhtoSms1.YhGetComPort().Split(',');
            for (int i = 0; i < Port.Length; i++)
                comboBox1.Items.Add(Port[i]);
            comboBox1.Text = Port[0];
        }






        protected override void Dispose(bool disposing)
        {

            try
            {

                socket.Close();//释放资源 

                mythread.Abort();//中止线程 

            }

            catch { }



            if (disposing)
            {

                if (components != null)
                {

                    components.Dispose();

                }

            }

            base.Dispose(disposing);

        }






        private void BeginListen()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(servertip), listenport);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            byte[] byteMessage = new byte[4068];

            //this.label1.Text = iep.ToString();
            try
            {
                socket.Bind(iep);
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Socket监听服务启动失败，请检查系统的IP配置是否正确！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //listBox1.Items.Add(ex.Message.ToString());
                //throw ex;
            }
            while (true)
            {

                try
                {

                    socket.Listen(100);

                    Socket newSocket = socket.Accept();
                    Encryption ecry = new Encryption();
                    UsersManage umg = new UsersManage();
                    newSocket.Receive(byteMessage);
                    //IPAddress remoteclientip = IPAddress.Parse(((IPEndPoint)newSocket.RemoteEndPoint).Address.ToString());
                    IFormatter formatter = new BinaryFormatter();
                    MemoryStream stram = new MemoryStream(byteMessage);
                    Users u = (Users)formatter.Deserialize(stram);
                    string username = u.UserName;
                    string password = Function.PasswordMD5(ecry.Decrypto(u.Password));
                    //listBox1.Items.Add(username);
                    //listBox1.Items.Add(password);
                    int count = umg.CheckExist(username, password);
                    ////newSocket.Connect(remoteclientip,listenport);
                    if (count > 0)
                    {
                        newSocket.Send(Encoding.ASCII.GetBytes(Connectionstring + "|" + url + "|"));
                       
                    }
                    else
                    {
                        newSocket.Send(Encoding.ASCII.GetBytes("faild|"));
                    }

                    newSocket.Shutdown(SocketShutdown.Both);
                    newSocket.Close();
                    //listBox1.Items.Add(Encoding.Default.GetString(byteMessage));
                    //MessageBox.Show(password, "dddddf");
                }

                catch (SocketException ex)
                {

                    ////this.label1.Text += ex.ToString();
                    //throw ex;
                    //throw ex;
                    //listBox1.Items.Add(ex.Message.ToString());


                }

            }


        }



        private void ListenhaveSend()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(servertip), 16751);
            sendSMSsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            byte[] byteMessage = new byte[1024];

            //this.label1.Text = iep.ToString();
            try
            {
                sendSMSsocket.Bind(iep);
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Socket监听服务启动失败，请检查系统的IP配置是否正确！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //listBox1.Items.Add(ex.Message.ToString());
                //throw ex;
            }

            while (true)
            {

                try
                {

                    sendSMSsocket.Listen(5);

                    Socket newSocket = sendSMSsocket.Accept();
                    //Encryption ecry = new Encryption();
                    //UsersManage umg = new UsersManage();
                    newSocket.Receive(byteMessage,byteMessage.Length,0);
                    //IPAddress remoteclientip = IPAddress.Parse(((IPEndPoint)newSocket.RemoteEndPoint).Address.ToString());
                    IFormatter formatter = new BinaryFormatter();
                    MemoryStream stram = new MemoryStream(byteMessage);
                    SMS sms = (SMS)formatter.Deserialize(stram);
                    string phone = sms.Number;
                    string conntent = sms.Scon;
                    //listBox1.Items.Add(username);
                    //listBox1.Items.Add(password);
                    //int count = umg.CheckExist(username, password);
                    ////newSocket.Connect(remoteclientip,listenport);
                    if (phone.ToString().Trim()!=""&&conntent.ToString().Trim()!="")
                    {
                        string[] phones = phone.Split('|');//用分割符分割开电话号码
                        if (phones.Length == 0)
                        {
                            //if (SendSMS(conntent, phone) == "-1")
                            //{
                            //    newSocket.Send(Encoding.ASCII.GetBytes("False"));
                            //}
                            //else
                            //{
                            //    newSocket.Send(Encoding.ASCII.GetBytes("True"));
                            //}
                        }
                        else
                        {
                            for (int i = 0; i < phones.Length - 1; i++)
                            {
                                //MessageBox.Show(SendSMS(conntent, phones[i]));
                                if (SendSMS(conntent, phones[i]) == "-1")
                                {
                                    newSocket.Send(Encoding.ASCII.GetBytes("False"));
                                }
                               

                                //MessageBox.Show(phones[i].ToString());
                            }

                            newSocket.Send(Encoding.ASCII.GetBytes("True"));
                        }

                    }
                    
                }

                catch (SocketException ex)
                {

                    ////this.label1.Text += ex.ToString();
                    //throw ex;
                    //throw ex;
                    //listBox1.Items.Add(ex.Message.ToString());


                }

            }

        }


        /// <summary>
        /// 利用短信猫发送短信，返回发送结果
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="phone">号码</param>
        /// <returns></returns>
        private string SendSMS(string content, string phone)
        {
            return axSzhtoSms1.YhSendSms(sCen, phone, content,0);
        }

        /// <summary>
        /// 如果有新的消息到达通知客户端
        /// </summary>

        private void Sendinfor(string clientip, newmessage newsmessage1)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe1 = new IPEndPoint(IPAddress.Parse(clientip), 8562);
            try
            {
                socket.Connect(ipe1);
                if (socket.Connected == true)
                {
                    newmessage newmessage1 = new newmessage();
                    newmessage1 = newsmessage1;
                    MemoryStream stream = new MemoryStream();
                    IFormatter formatmatter = new BinaryFormatter();
                    formatmatter.Serialize(stream, newmessage1);
                    stream.Flush();
                    byte[] newsms = stream.ToArray();

                    socket.Send(newsms);
                }

            }
            catch (SocketException ex)
            {

                listBox1.Items.Add("============================================================");
                listBox1.Items.Add("[" + DateTime.Now + "]");
                listBox1.Items.Add("发送消息发生意外");
                listBox1.Items.Add(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 在指定的时间间隔间隔用户是否在线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chekonline_Tick(object sender, EventArgs e)
        {
            chekonline.Enabled = false;
            
            try
            {
                
                SqlConnection conn = DBHelper.getConnection();
                conn.Open();
                string sql = "select IPAddress,UserName from Users where Status='在线'";
                SqlDataAdapter ds = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                ds.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    listBox1.Items.Add("============================================================");
                    listBox1.Items.Add("[" + DateTime.Now + "]");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Socket socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        IPAddress serverIp = IPAddress.Parse(dt.Rows[i]["IPAddress"].ToString().Trim());
                        IPEndPoint iep = new IPEndPoint(serverIp, 12547);
                        try
                        {
                            socket1.Connect(iep);  //连接服务器

                            //if (socket.Connected == true)
                            //{
                                //socket1.Send(Encoding.ASCII.GetBytes("asdadadasd"));
                                //socket1.Send(Encoding.ASCII.GetBytes("isonline"));
                                
                                
                                ////socket1.Send(newsms);
                                //byte[] newsms = new byte[128];
                                //socket1.Receive(newsms);
                                //if (Encoding.Default.GetString(newsms).Length > 0)
                                //{
                            listBox1.Items.Add(dt.Rows[i]["IPAddress"].ToString().Trim() + "在线");
                            //checkonlinesocket.Close();
                                //}


                            //checkonlinesocket.Shutdown(SocketShutdown.Both);
                            //socket1.Close();
                            //}
                            
                        }
                        catch
                        {
                            try
                            {

                                string sql1 = "update Users set Status='不在线' where UserName='" + dt.Rows[i]["UserName"].ToString() + "'";
                                SqlCommand cmd = new SqlCommand(sql1, conn);
                                cmd.ExecuteNonQuery();
                                listBox1.Items.Add(dt.Rows[i]["IPAddress"].ToString().Trim() + "不在线");
                                //socket1.Shutdown(SocketShutdown.Both);
                                //socket1.Close();
                                //checkonlinesocket.Shutdown(SocketShutdown.Both);
                                //checkonlinesocket.Close();

                            }
                            catch (Exception ex1)
                            {
                                throw ex1;
                            }

                           
                        }
                        socket1.Shutdown(SocketShutdown.Both);
                        socket1.Close();
                    }
                }
                conn.Close();
                
               
            }

           
            catch (Exception ex)
            {
                //chekonline.Enabled = false;
                //MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listBox1.Items.Add(ex.Message);

            }
            chekonline.Enabled = true;
            //socket1.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int EffectiveSMScout = 0;

            Encryption ecry = new Encryption();
            SMSFirewall smsf = new SMSFirewall();
            string SiD = "0";
            string del = "是";
            if (axSzhtoSms1.smsStatus != "") return;
            axSzhtoSms1.YhReadSms(SiD, del);
            string RsTel = "";
            string Rsdate = "";
            string RsCon = "";
            
            if (int.Parse(SiD) > 0)
            {
                RsTel = axSzhtoSms1.RsTel.ToString();
                Rsdate = axSzhtoSms1.RsDate.ToString();
                RsCon = axSzhtoSms1.RsCon.ToString();
                if (smsf.FilterPhone(RsTel, filternum))
                {
                    if (CheckFaulttimes(RsTel) > everyrecivetime)
                    {
                        if (axSzhtoSms1.smsStatus != "") return;
                        listBox1.Items.Add(SendWarmingSms(sCen, RsTel, sCon, 0));

                    }
                    else
                    {
                        Unclassified_FaultManager1.Addnewfault( RsCon, Rsdate, RsTel);
                    }
                }
                else
                {
                    listBox1.Items.Add("成功过滤");
                }


            }
            else
            {  //多条码信分割
                if (axSzhtoSms1.RsId != "")
                {
                    string[] Ri = axSzhtoSms1.RsId.Split('');
                    string[] RC = axSzhtoSms1.RsCenterNo.Split('');
                    string[] RT = axSzhtoSms1.RsTel.Split('');
                    string[] RD = axSzhtoSms1.RsDate.Split('');
                    string[] RCon = axSzhtoSms1.RsCon.Split('');
                  

                    Unclassified_FaultManager1.SetFaultToBeOld();

                    for (int i = 0; i < Ri.Length; i++)
                    {

                        RsCon = RCon[i].ToString();
                        RsTel = RT[i].ToString();
                        Rsdate = RD[i].ToString();
                        if (smsf.FilterPhone(RsTel, filternum))
                        {
                            if (CheckFaulttimes(RsTel) > everyrecivetime)
                            {
                               
                                listBox1.Items.Add("============================================================");
                                listBox1.Items.Add("[" + DateTime.Now + "]");
                                listBox1.Items.Add("超出的报障信息");
                                listBox1.Items.Add("报障电话：" + RsTel.ToString());
                                listBox1.Items.Add("短信内容：" + RsCon.ToString());
                                listBox1.Items.Add("报障日期" + Rsdate.ToString());
                                listBox1.Items.Add("----------------------------------------------------------------");
                                listBox1.Items.Add(axSzhtoSms1.YhSendSms(sCen, RsTel, sCon, 0));

                            }
                            else
                            {
                                try
                                {
                                    listBox1.Items.Add("============================================================");
                                    listBox1.Items.Add("[" + DateTime.Now + "]");

                                    Unclassified_FaultManager1.Addnewfault(RsCon, Rsdate, RsTel);
                                    listBox1.Items.Add("报障电话：" + RsTel.ToString());
                                    listBox1.Items.Add("短信内容：" + RsCon.ToString());
                                    listBox1.Items.Add("报障日期" + Rsdate.ToString());
                                    listBox1.Items.Add("短信接收成功");
                                    listBox1.Items.Add("----------------------------------------------------------------");
                                    EffectiveSMScout++;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            listBox1.Items.Add("============================================================");
                            listBox1.Items.Add("[" + DateTime.Now + "]");
                            listBox1.Items.Add("成功过滤短信");
                            listBox1.Items.Add("报障电话：" + RsTel.ToString());
                            listBox1.Items.Add("短信内容：" + RsCon.ToString());
                            listBox1.Items.Add("报障日期" + Rsdate.ToString());
                        }
                    } 
                    
                    
                   
                    if (EffectiveSMScout > 0)
                    {
                        SqlConnection conn = DBHelper.getConnection(Connectionstring);
                        conn.Open();
                        string sql = "select IPAddress from Users where Status='在线'";
                        SqlDataAdapter ds = new SqlDataAdapter(sql, conn);
                        DataTable dt = new DataTable();
                        ds.Fill(dt);
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            newmessage nmg = new newmessage();
                            nmg.Kind = "短信猫温馨提示";
                            nmg.Messagecontent = "有新的故障信息，请注意查收！";
                            nmg.Date = DateTime.Now.ToString();
                            //nmg.Phone = "asdas";
                            Sendinfor(dt.Rows[j]["IPAddress"].ToString().Trim(), nmg);
                        }
                    }

                }

            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Show();
                this.ShowDialog();
            }
        }



        /// <summary>
        /// 检查用户当天报障的次数
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        private int CheckFaulttimes(string phone)
        {
            using (SqlConnection conn = DBHelper.getConnection(Connectionstring))
            {
                SqlCommand cmd = new SqlCommand("usp_RecordCountByPhone", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter phone1 = cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50);
                SqlParameter RecordCount = cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 2);
                phone1.Direction = ParameterDirection.Input;
                RecordCount.Direction = ParameterDirection.Output;
                phone1.Value = phone;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(RecordCount.Value.ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        private string SendWarmingSms(string centerphone, string Sno, string con, int kind)
        {
            return axSzhtoSms1.YhSendSms(centerphone, Sno, con, kind);
            //if()
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            chekonline.Enabled = false;
            gettimernow.Enabled = false;
            listBox1.Items.Add("============================================================");
            listBox1.Items.Add("[" + DateTime.Now + "]");
            if (axSzhtoSms1.YhCloseModem().ToString() == "1")
            {
                listBox1.Items.Add("通讯端口已经关闭");
            }
            else
            {
                listBox1.Items.Add("通讯端口关闭失败");
            }
            try
            {
                mythread.Abort();
                socket.Close();
                listBox1.Items.Add("监听端口已成功关闭.....");
            }
            catch
            {
                listBox1.Items.Add("监听端口关闭失败....");
            }
            try
            {
                sendSMSsocket.Close();
                mysendSMS.Abort();
                listBox1.Items.Add("短信发送监听端口已成功关闭.....");
            }
            catch
            {
                listBox1.Items.Add("监听端口关闭失败....");
            }
            label3.Text = "服务未启动";

        }

        /// <summary>
        /// 获取短信猫信号的强度
        /// </summary>
        /// <returns></returns>
        private void GetModelSignalQuality()
        {
            int signalquality = Convert.ToInt32(axSzhtoSms1.SignalQuality());
            label3.Text = signalquality.ToString();
            //if (signalquality == 0)
            //{
            //    label3.Text = "无信号";
            //}
            //else
            //{
            //    if (signalquality >= 20 && signalquality <= 30)
            //    {
            //        label3.Text = "很好";
            //    }
            //    else
            //    {
            //        if (signalquality >= 10 && signalquality <= 19)
            //        {
            //            label3.Text = "一般";
            //        }
            //        else
            //        {
            //            if (signalquality > 0 && signalquality <= 9)
            //            {
            //                label3.Text = "差";
            //            }
            //        }
            //    }
            //}
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Environment.Exit(System.Environment.ExitCode);
            Application.Exit();
            this.Dispose();
            this.Close();

        }

        private void gettimernow_Tick(object sender, EventArgs e)
        {
            string getdatetime = DateTime.Now.ToString("H:mm");
            //listBox1.Items.Add(getdatetime);
            //RenameFile(ConfigurationManager.AppSettings["folderPath"].ToString(), "asd.sql");
            //RestoreDate();
            //bool flag = false;
            if (getdatetime == "12:46")
            {
                listBox1.Items.Clear();
                try
                {
                    RenameFile(ConfigurationManager.AppSettings["folderPath"].ToString(), ConfigurationManager.AppSettings["renamefile"].ToString());
                    RestoreToMachine();
                    //flag = true;
                    //listBox1.Items.Add(flag.ToString());
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add(ex.Message);
                }
            }
            //ImportData(ConfigurationManager.AppSettings["importtimes"].ToString(), getdatetime);
            ImportData(ConfigurationManager.AppSettings["importtimes"].ToString(), getdatetime);
            

        }



        /// <summary>
        /// 重命名文件
        /// </summary>
        /// <param name="FilePath">.sql文件的路径</param>
        /// <param name="NewName">文件重命名的文件名</param>
        private void RenameFile(string FilePath, string NewName)
        {
            //DateTime dt=Convert.ToDateTime("yyyy-MM-dd",DateTime.Now.ToShortDateString());
            string AbsolutePath = FilePath + "\\dcradius" + DateTime.Now.ToString("yyyy-MM-dd") + ".sql";
            //string AbsolutePath2 = "D:\\dd\\dcradius_2009-08-27.sql";
            //listBox1.Items.Add(AbsolutePath1);
            //listBox1.Items.Add(AbsolutePath2);
            listBox1.Items.Add("============================================================");
            listBox1.Items.Add("[" + DateTime.Now + "]");
            if (!File.Exists(AbsolutePath))
            {
                listBox1.Items.Add(AbsolutePath + "文件不存在");
                //listBox1.Items.Add(AbsolutePath);
                //listBox1.Items.Add(AbsolutePath2);
            }
            else
            {
                listBox1.Items.Add("文件夹存在");
                listBox1.Items.Add(AbsolutePath);
                FileInfo inf = new FileInfo(AbsolutePath);
                string newspath = FilePath + "\\" + NewName;
                File.Delete(newspath);
                //inf.Delete();
                inf.MoveTo(newspath);
            }
        }


        /// <summary>
        /// 还原mysql数据库
        /// </summary>
        /// <param name="host">主机的ip地址</param>
        /// <param name="port">MySQL远程端口</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="database">还原数据库名</param>
        /// <param name="directory">源文件的路径</param>
        private void RestoreDate(string host, string port, string username, string password, string database, string directory)
        {
            try
            {
                StringBuilder sbcommand = new StringBuilder();

                //OpenFileDialog openFileDialog = new OpenFileDialog();

                //if (openFileDialog.ShowDialog() == DialogResult.OK)
                //{
                    //String directory = ConfigurationManager.AppSettings["folderPath"] + "\\asd.sql";

                    //在文件路径后面加上""避免空格出现异常
                sbcommand.AppendFormat("mysql --host={0} --default-character-set=gb2312 --port={1} --user={2} --password={3} {4}<\"{5}\"", host, port, username, password, database, directory);
                    String command = sbcommand.ToString();

                    //获取mysql.exe所在路径
                    String appDirecroty = System.Windows.Forms.Application.StartupPath + "\\";

                    //DialogResult result = MessageBox.Show("您是否真的想覆盖以前的数据库吗？那么以前的数据库数据将丢失！！！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    //if (result == DialogResult.Yes)
                    //{
                        StartCmd(appDirecroty, command);
                        //MessageBox.Show("数据库还原成功！");
                    //}
                //}

            }
            catch (Exception ex)
            {
                //MessageBox.Show("数据库还原失败！");
            }

        }






        public static void StartCmd(String workingDirectory, String command)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = workingDirectory;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(command);
            p.StandardInput.WriteLine("exit");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string host = ConfigurationManager.AppSettings["mysqldatabaseip"];
            //string host = "localhost";
            string port = ConfigurationManager.AppSettings["port"];
            string username = ConfigurationManager.AppSettings["mysqldatabaseusername"];
            string password = ConfigurationManager.AppSettings["mysqldatabasepassword"];
            string database = ConfigurationManager.AppSettings["mysqldabasename"];
            string directory = ConfigurationManager.AppSettings["folderPath"] + "\\" + ConfigurationManager.AppSettings["renamefile"];
            RestoreDate(host,port,username,password,database,directory);
        }


        private void RestoreToMachine()
        {
            string host = ConfigurationManager.AppSettings["mysqldatabaseip"];
            //string host = "localhost";
            string port = ConfigurationManager.AppSettings["port"];
            string username = ConfigurationManager.AppSettings["mysqldatabaseusername"];
            string password = ConfigurationManager.AppSettings["mysqldatabasepassword"];
            string database = ConfigurationManager.AppSettings["mysqldabasename"];
            string directory = ConfigurationManager.AppSettings["folderPath"] + "\\" + ConfigurationManager.AppSettings["renamefile"];
            RestoreDate(host, port, username, password, database, directory);
        }



        /// <summary>
        /// 在特定的时间导入数据
        /// </summary>
        /// <param name="timesring"></param>
        /// <param name="timenow"></param>
        private void ImportData(string timesring, string timenow)
        {
            bool flag = false;
            UserParamManager upg = new UserParamManager();
            string[] a = timesring.Split(' ');
            if (a.Length == 0)
            {
                if (timesring == timenow&&flag==false)
                {

                    upg.DelAll();
                    listBox1.Items.Add("UserParam表已成功清空");
                    DataTable dt = new DataTable();
                    dt = GetDataTableFromMySql();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        upg.AddUser(dt.Rows[j]["username"].ToString(), Function.PasswordMD5(dt.Rows[j]["password"].ToString()), ISO8859_GB2312(dt.Rows[j]["realname"].ToString()), ISO8859_GB2312(dt.Rows[j]["address"].ToString()), dt.Rows[j]["telephone"].ToString(), dt.Rows[j]["mobile"].ToString());
                        //listBox1.Items.Add(ISO8859_GB2312(dt.Rows[j]["address"].ToString()));
                    }
                    dt.Dispose();
                    listBox1.Items.Add("数据库已成功更新");
                    flag = true;
                }
              
            }
            else
            {
                string[] time = timesring.Split(' ');

                for (int i = 0; i < time.Length; i++)
                {

                    if (time[i] == timenow&&flag==false)
                    {

                        upg.DelAll();
                        listBox1.Items.Add("UserParam表已成功清空");
                        DataTable dt = new DataTable();
                        dt = GetDataTableFromMySql();
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            upg.AddUser(dt.Rows[j]["username"].ToString(), Function.PasswordMD5(dt.Rows[j]["password"].ToString()), ISO8859_GB2312(dt.Rows[j]["realname"].ToString()), ISO8859_GB2312(dt.Rows[j]["address"].ToString()), dt.Rows[j]["telephone"].ToString(), dt.Rows[j]["mobile"].ToString());
                            //listBox1.Items.Add(ISO8859_GB2312(dt.Rows[j]["address"].ToString()));
                        }
                        dt.Dispose();
                        listBox1.Items.Add("数据库已成功更新");
                        flag = true;
                    }

                }
            }
        }




        /// <summary>
        /// 获取MySQL数据库中的数据
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableFromMySql()
        {
            string sql = "select username,password,realname,address,telephone,mobile from userparam";
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["mysqlconnectionstring"].ToString());
            listBox1.Items.Add("============================================================");
            listBox1.Items.Add("[" + DateTime.Now + "]");
            try
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (MySqlException ex)
            {
                listBox1.Items.Add(ex.Message);
                return null;
            }
           
        }


        public string ISO8859_GB2312(string read)
        {
            //声明字符集
            System.Text.Encoding iso8859, gb2312;
            //iso8859
            iso8859 = System.Text.Encoding.GetEncoding("iso8859-1");
            //国标2312
            gb2312 = System.Text.Encoding.GetEncoding("gb2312");
            byte[] iso;
            iso = iso8859.GetBytes(read);
            //返回转换后的字符
            return gb2312.GetString(iso);
        }



        /// <summary>
        /// 两个时间相差的秒数
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        private int TimeDifference(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts = dt1-dt2;
            return ts.Seconds;
        }

    }
}