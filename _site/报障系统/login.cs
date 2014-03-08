using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using System.Net;
using DALProfile;
using Model;
using BLL;
using System.Configuration;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Diagnostics;


namespace 报障系统
{
    public partial class login : Form
    {
        private static loginstate loginstate1 = new loginstate();
        private  string connectionstring = ConfigurationManager.AppSettings["connectionString"].ToString().Trim();
        //private  int localpoint = Convert.ToInt32(ConfigurationManager.AppSettings["localpoint"].ToString().Trim());
        private  string serverip = ConfigurationManager.AppSettings["serverip"].ToString().Trim();
        private  int remotepoint = Convert.ToInt32(ConfigurationManager.AppSettings["point"].ToString().Trim());




        public login()
        {
            if (AllowOneAppRun())
            {
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("同一时间只允许登陆一个客户端", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Environment.Exit(0);
            }
            
            
        }



        private bool AllowOneAppRun()
        {
            // get the name of our process
            string proc = Process.GetCurrentProcess().ProcessName;
            // get the list of all processes by that name
            Process[] processes = Process.GetProcessesByName(proc);
            // if there is more than one process
            if (processes.Length > 1)
            {
                //MessageBox.Show("Application is already running");
                return false;
            }
            else
            {
                return true;
            }

        }


        /// <summary>
        /// 发送登录信息
        /// </summary>
        private string[] SendLoginInfor()
        {
            Encryption ECRY = new Encryption();
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe1 = new IPEndPoint(IPAddress.Parse(serverip), remotepoint);
            try
            {
                socket.Connect(ipe1);
                if (socket.Connected)
                {
                    Users U = new Users();
                    U.UserName = textBox1.Text.ToString().Trim();
                    U.Password = ECRY.Encrypto(textBox2.Text.ToString().Trim());
                    MemoryStream stream = new MemoryStream();
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, U);
                    stream.Flush();
                    byte[] userpw = stream.ToArray();
                    socket.Send(userpw);
                    string recivestring = "";
                    byte[] byterec = new byte[256];
                    socket.Receive(byterec);
                    recivestring = Encoding.Default.GetString(byterec).ToString().Trim();
                    string[] returnstring = recivestring.Split('|');
                    return returnstring;

                }
                else
                {
                    return null;

                }
            }
            catch
            {
                return null;
            }


        }

        protected string GetIP()   //获取本地IP   
        {
            IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            return ipAddr.ToString();
        }

        //private void ListenHaveNewFault()
        //{
        //    IPEndPoint iep = new IPEndPoint(IPAddress.Parse(GetIP()), 8562);
        //    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    byte[] byteMessage = new byte[1024];

        //    //this.label1.Text = iep.ToString();

        //    socket.Bind(iep);

        //    while (true)
        //    {

        //        try
        //        {
        //            socket.Listen(1);

        //            Socket newSocket = socket.Accept();
        //            newSocket.Receive(byteMessage);
        //            if (Encoding.Default.GetString(byteMessage).ToString().Length > 0)
        //            {
        //                MessageBox.Show("sdadasda");
        //            }
                  
        //        }

        //        catch (SocketException ex)
        //        {
        //            throw ex;
        //        }

        //    }
        //}



       

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString().Trim() == "")
            {
                MessageBox.Show("用户名必填，请输入正确的用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (textBox2.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("密码必填请输入正确的密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    button1.Enabled = false;
                    Encryption ecry = new Encryption();
                    string hostname;
                    System.Net.IPHostEntry localhost;
                    System.Net.IPAddress localaddr;

                    hostname = System.Net.Dns.GetHostName();
                    localhost = System.Net.Dns.GetHostByName(hostname);
                    localaddr = localhost.AddressList[0]; //localaddr中就是本机ip地址 
                    loginstate lgs = new loginstate();
                    //if (connectionstring == "")
                    //{
                       
                        //string recivestring = SendLoginInfor().ToString().Trim();
                        
                        if (SendLoginInfor() == null)
                        {
                            MessageBox.Show("连接服务器失败，请与管理员联系", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            button1.Enabled = true;
                        }
                        else
                        {
                            string[] result = SendLoginInfor();
                            int lengths = SendLoginInfor().Length;
                            //MessageBox.Show(result[1], "dsad");
                            if (lengths == 2)
                            {
                                MessageBox.Show("请输入正确的用户名和密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBox2.Text = "";
                                button1.Enabled = true;
                            }

                            else
                            {
                                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                                config.AppSettings.Settings["connectionString"].Value = ecry.Encrypto(result[0].ToString());
                                config.AppSettings.Settings["url"].Value = result[1];
                                config.Save(ConfigurationSaveMode.Full);
                                ConfigurationManager.RefreshSection("appSettings");

                                XmlDocument doc = new XmlDocument();
                                string filestr = Application.ExecutablePath + ".config";
                                doc.Load(filestr);
                                XmlNodeList nodes = doc.GetElementsByTagName("add");
                                for (int i = 0; i < nodes.Count; i++)
                                {
                                    XmlAttribute att = nodes[i].Attributes["key"];
                                    if (att.Value == "connectionString")
                                    {
                                        att = nodes[i].Attributes["value"];
                                        att.Value = ecry.Encrypto(result[0].ToString());
                                        //MessageBox.Show(result[0]);
                                    }
                                    if (att.Value == "url")
                                    {
                                        att = nodes[i].Attributes["value"];
                                        att.Value = result[1];
                                    }
                                }
                                doc.Save(filestr);
                                //Properties.Settings.Default.Reload();
                                //doc
                                connectionstring = result[0];
                                //MessageBox.Show(connectionstring);
                                //MessageBox.Show(ConfigurationManager.AppSettings["connectionString"].ToString().Trim());
                                loginbyclient(textBox1.Text.ToString().Trim(), textBox2.Text.ToString().Trim(), localaddr.ToString(), connectionstring);
                               
                            }
                        }

                    //}
                    //else
                    //{
                    //    MessageBox.Show(connectionstring,"xlm");
                    //     loginbyclient(textBox1.Text.ToString().Trim(), textBox2.Text.ToString().Trim(), localaddr.ToString(),ecry.Decrypto(connectionstring));
                        
                    //}
                    
                }
            }
        }



        public void loginbyclient(string username1, string password1, string ip1, string connectionstring1)
        {
            Encryption ecry = new Encryption();
            using (SqlConnection conn = DBHelper.getConnection(connectionstring1))
            {
                SqlCommand cmd = new SqlCommand("usp_CheckLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter username = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
                SqlParameter password = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                SqlParameter loginip = cmd.Parameters.Add("@IPAddress", SqlDbType.VarChar, 50);
                SqlParameter loginstate = cmd.Parameters.Add("@ReturnBit", SqlDbType.Bit, 2);
                SqlParameter realname = cmd.Parameters.Add("@ReturnMsg", SqlDbType.VarChar, 50);
                SqlParameter firstfalu = cmd.Parameters.Add("@GuZhangFirstCount", SqlDbType.Int, 2);
                SqlParameter myselffault = cmd.Parameters.Add("@GuZhangSecondCount", SqlDbType.Int, 2);
                SqlParameter usertype = cmd.Parameters.Add("@UserType", SqlDbType.VarChar, 50);
                username.Direction = ParameterDirection.Input;
                password.Direction = ParameterDirection.Input;
                loginip.Direction = ParameterDirection.Input;
                realname.Direction = ParameterDirection.Output;
                loginstate.Direction = ParameterDirection.Output;
                firstfalu.Direction = ParameterDirection.Output;
                myselffault.Direction = ParameterDirection.Output;
                usertype.Direction = ParameterDirection.Output;
                username.Value = username1;
                password.Value = Function.PasswordMD5(password1);
                loginip.Value = ip1;
                try
                {

                    conn.Open();
                    if (conn.State ==ConnectionState.Closed)
                    {
                        MessageBox.Show("与数据库连接失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        try
                        {
                            cmd.ExecuteNonQuery();
                            loginstate1.State = Convert.ToBoolean(loginstate.Value);
                            loginstate1.Realname = realname.Value.ToString();
                            loginstate1.Username = textBox1.Text.ToString().Trim();
                            loginstate1.Firstfalu = Convert.ToInt32(firstfalu.Value.ToString());
                            loginstate1.Myselffault = Convert.ToInt32(myselffault.Value.ToString());
                            loginstate1.Usertype = usertype.Value.ToString();
                            conn.Close();
                            if (loginstate1.State == true)
                            {
                                MainForm mf = new MainForm(loginstate1);

                                mf.Show();
                                this.Hide();

                            }
                            else
                            {
                                MessageBox.Show("请输入正确的用户名和密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBox1.Text = "";
                                textBox2.Text = "";
                                button1.Enabled = true;
                            }
                        }
                        catch(Exception dx)
                        {
                            conn.Close();
                            throw dx;
                        }
                    }
                        }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = null;
            this.textBox2.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Config cf = new Config();
            cf.Show();
        }
    }
}
