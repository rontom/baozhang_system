using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;

namespace 报障系统
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// 判断输入的配置参数是否正确，如果不正确提示用户，如果正确保存配置的参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (serverip.Text.ToString().Trim() == "")
            {
                MessageBox.Show("数据库用户名不能为空", "警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (point.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("数据库密码不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (serverip.Text.ToString().Trim() == "" || IsCorrenctIP(serverip.Text.ToString().Trim()) == false)
                    {
                        MessageBox.Show("数据库IP为空或格式不正确", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                     
                    else
                    {
                            try
                            {
                                XmlDocument doc = new XmlDocument();
                                string filestr = Application.ExecutablePath + ".config";
                                doc.Load(filestr);
                                XmlNodeList nodes = doc.GetElementsByTagName("add");
                                for (int i = 0; i < nodes.Count; i++)
                                {
                                    XmlAttribute att = nodes[i].Attributes["key"];
                                    if (att.Value == "serverip")
                                    {
                                        att = nodes[i].Attributes["value"];
                                        att.Value =serverip.Text.ToString().Trim();
                                    }
                                    if (att.Value == "localpoint")
                                    {
                                        att = nodes[i].Attributes["value"];
                                        att.Value = localpint.Text.ToString().Trim();
                                    }
                                    else if (att.Value == "point")
                                    {
                                        att = nodes[i].Attributes["value"];
                                        att.Value = point.Text.ToString().Trim();
                                    }

                                    else if (att.Value == "sendpoint")
                                    {
                                        att = nodes[i].Attributes["value"];
                                        att.Value =sendpointin.Text.ToString().Trim();
                                    }
                                }
                                doc.Save(filestr);
                                MessageBox.Show("配置成功", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                this.Dispose();
                            }
                            catch
                            {
                                MessageBox.Show("配置失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    
                }
            }
            //string Xvalue = this.textBox1.Text.ToString().Trim();
            //XmlDocument doc = new XmlDocument();
            //string filestr = Application.ExecutablePath + ".config";
            //doc.Load(filestr);
            //XmlNodeList nodes = doc.GetElementsByTagName("add");
            //for (int i = 0; i < nodes.Count; i++)
            //{
            //    XmlAttribute att = nodes[i].Attributes["key"];
            //    if (att.Value == "ConnectionString")
            //    {
            //        att = nodes[i].Attributes["value"];
            //        att.Value = this.WebIP.Text.ToString().Trim();
            //        break;
            //    }
            //}
            //doc.Save(filestr);
            //this.label5.Text = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            //label5.Text = filestr;
            //XmlNode node = doc.SelectSingleNode(@"//add[@key='databaseip']");
            //XmlElement ele = (XmlElement)node;
            //ele.SetAttribute("value", Xvalue);
            //doc.Save(Application.ExecutablePath + ".config");
        

        /// <summary>
        /// 根据正则表达式判断输入的是否为ip地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool IsCorrenctIP(string ip)
        {
            string pattrn = @"(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])";
            if (System.Text.RegularExpressions.Regex.IsMatch(ip, pattrn))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}