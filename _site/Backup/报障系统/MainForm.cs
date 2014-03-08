using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Model;
using System.Configuration;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using DALProfile;
using BLL;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace 报障系统
{
    public partial class MainForm : Form
    {
        private bool _isClosed;
        private string username = "";
        private int newsmesscount = 0;
        private int chatport;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCATION = 0x0002;
        private static string  weburl = ConfigurationManager.AppSettings["url"].ToString(); 
        private static string connectionstring = ConfigurationManager.AppSettings["connectionString"].ToString();
        Encryption ecry = new Encryption();
        //TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, 12547));


        //private void StartListen()
        //{
        //    listener.Start();
        //    while (true)
        //    {

        //    }
        //}

        //private Point point;
        public MainForm()
        {
            InitializeComponent();
            Initializenotifyicon();
        }

        protected string GetIP()   //获取本地IP   
        {
            IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            return ipAddr.ToString();
        }


        private void Listenisonline()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(GetIP()), 12547);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //newmessage newmessage1 = new newmessage();
            byte[] byteMessage = new byte[128];

            //this.label1.Text = iep.ToString();

            socket.Bind(iep);
            int bytes = 0;
            while (true)
            {

                try
                {
                    socket.Listen(1);

                    Socket newSocket = socket.Accept();
                    bytes = newSocket.Receive(byteMessage, byteMessage.Length, 0);
                    //MessageBox.Show(bytes.ToString());
                    string que = Encoding.Default.GetString(byteMessage);
                    if (que.Length > 0)
                    {
                        newSocket.Send(Encoding.ASCII.GetBytes("dads"));
                        newSocket.Close();
                        
                    }

                }


                catch (SocketException ex)
                {
                    throw ex;
                   
                }
             
            }
        }


        /// <summary>
        /// 监听是否有新的消息发布
        /// </summary>
        private void ListenHaveNewsNotice()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(GetIP()), 12564);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //newmessage newmessage1 = new newmessage();
            byte[] byteMessage = new byte[128];

            //this.label1.Text = iep.ToString();

            socket.Bind(iep);
            int bytes = 0;
            while (true)
            {

                try
                {
                    socket.Listen(1);

                    Socket newSocket = socket.Accept();
                    bytes = newSocket.Receive(byteMessage, byteMessage.Length, 0);
                    //MessageBox.Show(bytes.ToString());
                    string que = Encoding.Default.GetString(byteMessage);
                    if (que.Length > 0)
                    {
                        newSocket.Send(Encoding.ASCII.GetBytes("dads"));
                        newSocket.Close();

                    }

                }


                catch (SocketException ex)
                {
                    throw ex;

                }

            }
        }


       
        private void ListenHaveNewFault()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(GetIP()), 8562);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //newmessage newmessage1 = new newmessage();
            byte[] byteMessage = new byte[1024];

            //this.label1.Text = iep.ToString();

            socket.Bind(iep);
            int bytes = 0;
            while (true)
            {

                try
                {
                    socket.Listen(1);

                    Socket newSocket = socket.Accept();
                    bytes = newSocket.Receive(byteMessage, byteMessage.Length, 0);
                    //MessageBox.Show(bytes.ToString());
                    MemoryStream stream = new MemoryStream(byteMessage);
                    IFormatter formatter = new BinaryFormatter();
                    newmessage newmessage1 = (newmessage)formatter.Deserialize(stream);
                    newsmesscount++;
                    //if (bytes > 0)
                    //{
                    //    showtips();
                    //    bytes = 0;
                    //}
                    //MessageBox.Show)
                    //if (newmessage1.Kind.ToString().Trim().Length > 0)
                    //{
                    //    showtips();
                    //}
                    //if (newmessage1 != null)
                    //{
                    //    showtips();
                    //    //break;

                    //}
                    //tps.TopMost = true;
                    //MessageBox.Show(newmessage1.Messagecontent);
                    //if (Encoding.Default.GetString(byteMessage).ToString().Trim() == "yes")
                    //{
                    //    MessageBox.Show("有新的短信到达", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("暂无新的短信到达", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}

                }
                

                catch (SocketException ex)
                {
                    throw ex;
                }
                //break;
                //showtips();
                //MessageBox.Show(newsmesscount.ToString());
                //}showtips();
            }
        }


        private void UpdateuserChartport()
        {
            SqlConnection con = DBHelper.getConnection(ecry.Decrypto(connectionstring));
            string sql = "update Users set chartPort=@chartPort where UserName=@UserName";
            SqlParameter[] Parameter = new SqlParameter[]
            {
                new SqlParameter("@chartPort",chatport),
                new SqlParameter("@UserName",username)
            };
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(Parameter);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }

        private void GetUserFace()
        {
            
            SqlConnection con = DBHelper.getConnection(ecry.Decrypto(connectionstring));
            string sql = "select face from Users where UserName=@UserName";
            con.Open();
            SqlParameter[] Parameter = new SqlParameter[]
            {
                new SqlParameter("@UserName",username)
            };
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(Parameter);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read()&&!rd.IsDBNull(0))
            {
                
                byte[] pic = (byte[])rd["face"];
                MemoryStream stra = new MemoryStream(pic);
                pictureBox6.Image = Image.FromStream(stra);
                //pictureBox6.SizeMode
            }
        }


        public MainForm(loginstate lgs)
        {
            InitializeComponent();
            Initializenotifyicon();
            //rolelab.Text="["+
            //label1.Text = lgs.Realname;
            username = lgs.Username;
            label1.Text = lgs.Realname;
            rolelab.Text = "[" + lgs.Usertype + "]";
            baisicinfolab.Text = "未分类" + lgs.Firstfalu.ToString() + "条，已分类" + lgs.Myselffault.ToString() + "条";
            //GetUserFace();
            //ListenHaveNewFault();
            
        }

        private void Initializenotifyicon()
        {
            //设置系统托盘的各个属性
            notifyIcon1 = new NotifyIcon();
            notifyIcon1.Icon = new Icon("langing.ico");
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
            //Application.Exit();
            System.Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            //UsersManage umg = new UsersManage();
            //point = this.Location;
            GetUserFace();
            //listener.ExclusiveAddressUse = true;
            //listener.Start();

            sbFriends.AddGroup("教师和管理员列表");
            sbFriends.AddGroup("学生团队列表");
            sbFriends.Groups[0].Tag = "0";
            sbFriends.Groups[1].Tag = "1";
            
            
            
            try
            {
                Thread mythread = new Thread(new ThreadStart(ListenHaveNewFault));
                //ListenHaveNewFault();
                mythread.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                Thread mythread1 = new Thread(new ThreadStart(Listenisonline));
                //ListenHaveNewFault();
                mythread1.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                Thread mythread2 = new Thread(new ThreadStart(ListenHaveNewChat));
                //ListenHaveNewFault();
                mythread2.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            UpdateuserChartport();
            //umg.UpdateChatport(chatport, "xlm");
            //MessageBox.Show(chatport.ToString());

           


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            toolTip1.Active = false;
            this.Visible = false;
            //notifyIcon1.Visible = true;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCATION, 0);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            toolTip1.Active = true;
            this.Visible = true;
            //notifyIcon1.Visible = true;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            notifyIcon1.Visible = true;
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            //pictureBox4
            toolTip1.Active = true;
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            changeface cf = new changeface(username);
            cf.Show();
            
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (CheckIsOnline(username))
            {
                System.Diagnostics.Process.Start(weburl + "?username=" + username);
            }
            else
            {
                if (MessageBox.Show("由于未知原因您的客户端已经掉线，是否重新登录", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ReLogin rlg = new ReLogin(username);
                    rlg.ShowDialog();
                }
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            //Tips tp = new Tips();
            //tp.Show();
        }



        /// <summary>
        /// 在进入客户端之前检测用户是否掉线，如果不在线提示重新登录
        /// </summary>
        private bool CheckIsOnline(string username1)
        {

            try
            {
                SqlConnection.ClearAllPools();
                SqlConnection con = DBHelper.getConnection(ecry.Decrypto(ConfigurationManager.AppSettings["connectionString"].ToString()));

                con.Open();


                string sql = "select Status from Users where UserName=@UserName";
                SqlParameter[] Parameter = new SqlParameter[]
            {
                new SqlParameter("@UserName",username1)
            };
                try
                {

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddRange(Parameter);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "在线")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return false;
                }
            }
            catch (Exception dx)
            {
                MessageBox.Show(dx.Message);
                return false;
            }
        }

        private void showtips()
        {
            Tips tp = new Tips();
            tp.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (newsmesscount > 0)
            {
                showtips();
                newsmesscount = 0;
            }
            
        }

        private void pictureBox11_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Active = true;
        }

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Active = true;
        }



        /// <summary>
        /// 选取一个随机端口
        /// </summary>
        /// <returns></returns>
        private int  GetPortForChat()
        {
            Random rd = new Random();
            return rd.Next(1087, 9999);
        }


        private void ListenHaveNewChat()
        {
            chatport = GetPortForChat();
           
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(GetIP()),chatport);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
             byte[] byteMessage = new byte[1024];
             try
             {
                 socket.Bind(iep);
                
             }
             catch
             {
                 MessageBox.Show("聊天端口已经被占用，请重新启动程序", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }


             
             int bytes = 0;
             while (true)
             {

                 try
                 {
                     socket.Listen(20);

                     Socket newSocket = socket.Accept();
                     bytes = newSocket.Receive(byteMessage, byteMessage.Length, 0);
                     //MessageBox.Show(bytes.ToString());
                     MemoryStream stream = new MemoryStream(byteMessage);
                     IFormatter formatter = new BinaryFormatter();
                     Chat newmessage1 = (Chat)formatter.Deserialize(stream);
                 }


                 catch (SocketException ex)
                 {
                     throw ex;
                 }
             }
            
            
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if (this.panel7.Visible == true)
            {
                this.panel7.Visible = false;
            }
            else
            {
                this.panel7.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (this.panel7.Visible == true)
            {
                this.panel7.Visible = false;
            }
            else
            {
                this.panel7.Visible = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.panel7.Visible = false;
            if (MessageBox.Show("您确定要退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.notifyIcon1.Visible = false;
                System.Environment.Exit(0);
                //Application.Exit();
                
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.panel7.Visible = false;
            modiftypassword pwd = new modiftypassword(username);
            pwd.ShowDialog();
            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.panel7.Visible = false;
            ModiftyPersonInfor perinfo = new ModiftyPersonInfor(username);
            perinfo.ShowDialog();
        }
        

       
    }
}