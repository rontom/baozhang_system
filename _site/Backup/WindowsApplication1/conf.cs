using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;

namespace WindowsApplication1
{
    public partial class conf : Form
    {
        public conf()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString().Trim() == "")
            {
                MessageBox.Show("���ݿ�IP����Ϊ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox2.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("���ݿ�������Ϊ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (textBox3.Text.ToString().Trim() == "")
                    {
                        MessageBox.Show("�û�������Ϊ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        if (IsCorrenctIPput(textBox1.Text.ToString().Trim(), @"(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])") == false)
                        {
                            MessageBox.Show("���ݿ�IP��ַ����ȷ", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {

                            if (IsCorrenctIPput(textBox11.Text.ToString().Trim(), @"^\d+(\.\d)?$") == false)
                            {
                                MessageBox.Show("ͨѶ�˿ں�ֻ��Ϊ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                        if (att.Value == "connectionString")
                                        {
                                            att = nodes[i].Attributes["value"];
                                            att.Value = "server=" + textBox1.Text.ToString().Trim() + ";database=" + textBox2.Text.ToString().Trim() + ";uid=" + textBox3.Text.ToString().Trim() + ";pwd=" + textBox4.Text.ToString().Trim();
                                        }
                                        if (att.Value == "server")
                                        {
                                            att = nodes[i].Attributes["value"];
                                            att.Value = textBox1.Text.ToString().Trim();
                                        }
                                        if (att.Value == "database")
                                        {
                                            att = nodes[i].Attributes["value"];
                                            att.Value = textBox2.Text.ToString().Trim();
                                        }
                                        if (att.Value == "uid")
                                        {
                                            att = nodes[i].Attributes["value"];
                                            att.Value = textBox3.Text.ToString().Trim();
                                        }
                                        if (att.Value == "pwd")
                                        {
                                            att = nodes[i].Attributes["value"];
                                            att.Value = textBox4.Text.ToString().Trim();
                                        }

                                        else if (att.Value == "serverip")
                                        {
                                            att = nodes[i].Attributes["value"];
                                            att.Value = textBox10.Text.ToString().Trim();
                                        }
                                        else if (att.Value == "listenpoint")
                                        {
                                            att = nodes[i].Attributes["value"];
                                            att.Value = textBox11.Text.ToString().Trim();
                                        }

                                        else if (att.Value == "offtime")
                                        {
                                            att = nodes[i].Attributes["value"];
                                            att.Value = textBox9.Text.ToString().Trim();
                                        }
                                    }
                                    doc.Save(filestr);
                                    MessageBox.Show("���óɹ�,��������Ч", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                    //this.Dispose();
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                }
            }
        }



        public bool IsCorrenctIPput(string ip, string pattrn)
        {
            //string pattrn = @"(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])";
            if (System.Text.RegularExpressions.Regex.IsMatch(ip, pattrn))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private void conf_Load(object sender, EventArgs e)
        {
            //string connectionstring=ConfigurationManager.AppSettings["connectionString"].ToString();
            textBox1.Text = ConfigurationManager.AppSettings["server"].ToString();
            textBox2.Text = ConfigurationManager.AppSettings["database"].ToString();
            textBox3.Text = ConfigurationManager.AppSettings["uid"].ToString();
            textBox4.Text = ConfigurationManager.AppSettings["pwd"].ToString();
            textBox6.Text = ConfigurationManager.AppSettings["Sn"].ToString();
            textBox7.Text = ConfigurationManager.AppSettings["str"].ToString();
            textBox8.Text = ConfigurationManager.AppSettings["Ctle"].ToString();
            textBox5.Text = ConfigurationManager.AppSettings["Messagerecivetime"].ToString();
            textBox9.Text = ConfigurationManager.AppSettings["offtime"].ToString();
            textBox10.Text = ConfigurationManager.AppSettings["serverip"].ToString();
            textBox11.Text = ConfigurationManager.AppSettings["listenpoint"].ToString();
            Domain_Name.Text = ConfigurationManager.AppSettings["webdomain"].ToString();
            list_separator.Text = ConfigurationManager.AppSettings["list_separator"].ToString();
            recivelimte.Text = ConfigurationManager.AppSettings["everyrecivetime"].ToString();
            warmingmessage.Text = ConfigurationManager.AppSettings["warmingmessage"].ToString();
            filterphone.Text = ConfigurationManager.AppSettings["filternum"].ToString();
            mysqldatabaseip.Text = ConfigurationManager.AppSettings["mysqldatabaseip"].ToString();
            mysqldatabase.Text = ConfigurationManager.AppSettings["mysqldabasename"].ToString();
            mysqlusername.Text = ConfigurationManager.AppSettings["mysqldatabaseusername"].ToString();
            mysqlpassword.Text = ConfigurationManager.AppSettings["mysqldatabasepassword"].ToString();
            sourcessql.Text = ConfigurationManager.AppSettings["renamefile"].ToString();
            port.Text = ConfigurationManager.AppSettings["port"].ToString();
            importtimes.Text = ConfigurationManager.AppSettings["importtimes"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Domain_Name.Text.ToString().Trim() == "")
            {
                MessageBox.Show("IP��ַ����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        if (att.Value == "webdomain")
                        {
                            att = nodes[i].Attributes["value"];
                            att.Value = Domain_Name.Text.ToString().Trim();
                        }
                    }
                    doc.Save(filestr);
                    MessageBox.Show("Web���óɹ����������������Ч", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.ToString().Trim() == "")
            {
                MessageBox.Show("ע���벻��Ϊ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox8.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("���ĺ��벻��Ϊ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {


                    if (IsCorrenctIPput(textBox5.Text.ToString().Trim(), @"^\d+(\.\d)?$") == false)
                    {
                        MessageBox.Show("���Ž���ʱ����ֻ��Ϊ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        if (recivelimte.Text.ToString().Trim().Length == 0)
                        {
                            MessageBox.Show("�û�ÿ��������Ʊ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (IsCorrenctIPput(recivelimte.Text.ToString().Trim(), @"^\d+(\.\d)?$") == false)
                            {
                                MessageBox.Show("�û�ÿ��������Ʊ���Ϊ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if (warmingmessage.Text.ToString().Trim().Length == 0)
                                {
                                    MessageBox.Show("���ž������", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                            if (att.Value == "list_separator")
                                            {
                                                att = nodes[i].Attributes["value"];
                                                att.Value = list_separator.Text.ToString().Trim();
                                            }
                                            if (att.Value == "everyrecivetime")
                                            {
                                                att = nodes[i].Attributes["value"];
                                                att.Value = recivelimte.Text.ToString().Trim();
                                            }
                                            if (att.Value == "warmingmessage")
                                            {
                                                att = nodes[i].Attributes["value"];
                                                att.Value = warmingmessage.Text.ToString().Trim();
                                            }
                                            if (att.Value == "Messagerecivetime")
                                            {
                                                att = nodes[i].Attributes["value"];
                                                att.Value = textBox5.Text.ToString().Trim();
                                            }
                                            else if (att.Value == "Sn")
                                            {
                                                att = nodes[i].Attributes["value"];
                                                att.Value = textBox6.Text.ToString().Trim();
                                            }
                                            else if (att.Value == "str")
                                            {
                                                att = nodes[i].Attributes["value"];
                                                att.Value = textBox7.Text.ToString().Trim();
                                            }
                                            else if (att.Value == "Ctle")
                                            {
                                                att = nodes[i].Attributes["value"];
                                                att.Value = textBox8.Text.ToString().Trim();
                                            }
                                            else if (att.Value == "filternum")
                                            {
                                                att = nodes[i].Attributes["value"];
                                                att.Value = filterphone.Text.ToString().Trim();
                                            }

                                        }
                                        doc.Save(filestr);
                                        MessageBox.Show("����è���óɹ����������������Ч", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }



                                }

                            }
                        }
                    }
                }
            }
        }

        private void changeFolder_Click(object sender, EventArgs e)
        {
            ChangeFolder cf = new ChangeFolder();
            cf.Show();
            cf.TopMost = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ConfigurationManager.AppSettings["folderPath"].ToString());
        }


        private void button8_Click(object sender, EventArgs e)
        {
            if (mysqldatabaseip.Text.ToString().Trim() == "")
            {
                MessageBox.Show("���ݿ��IP��ַ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (IsCorrenctIPput(mysqldatabaseip.Text.ToString().Trim(), @"(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])") == false && mysqldatabaseip.Text.ToString() != "localhost")
                {
                    MessageBox.Show("���ݿ��IP��ַ��ʽ����ȷ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (mysqldatabase.Text.ToString().Trim() == "")
                    {
                        MessageBox.Show("���ݿ�������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (mysqlusername.Text.ToString().Trim() == "")
                        {
                            MessageBox.Show("�û�������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {

                            if (importtimes.Text.ToString().Trim() == "")
                            {
                                MessageBox.Show("������дһ��ʱ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if (!Checkimporttimeislegal(importtimes.Text.ToString().Trim()))
                                {
                                    MessageBox.Show("����ʱ���ʽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    if (sourcessql.Text.ToString().Trim() == "")
                                    {
                                        MessageBox.Show("�������ļ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        if (port.Text.ToString().Trim() == "")
                                        {
                                            MessageBox.Show("�˿ںű���", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                                    if (att.Value == "mysqldatabaseip")
                                                    {
                                                        att = nodes[i].Attributes["value"];
                                                        att.Value = mysqldatabaseip.Text.ToString().Trim();
                                                    }
                                                    if (att.Value == "mysqldabasename")
                                                    {
                                                        att = nodes[i].Attributes["value"];
                                                        att.Value = mysqldatabase.Text.ToString().Trim();
                                                    }
                                                    if (att.Value == "mysqldatabaseusername")
                                                    {
                                                        att = nodes[i].Attributes["value"];
                                                        att.Value = mysqlusername.Text.ToString().Trim();
                                                    }
                                                    if (att.Value == "mysqldatabasepassword")
                                                    {
                                                        att = nodes[i].Attributes["value"];
                                                        att.Value = mysqlpassword.Text.ToString().Trim();
                                                    }

                                                    else if (att.Value == "importtimes")
                                                    {
                                                        att = nodes[i].Attributes["value"];
                                                        att.Value = importtimes.Text.ToString().Trim();
                                                    }
                                                    else if (att.Value == "mysqlconnectionstring")
                                                    {
                                                        att = nodes[i].Attributes["value"];
                                                        att.Value = "Database=" + mysqldatabase.Text.ToString().Trim() + ";Data Source=" + mysqldatabaseip.Text.ToString().Trim() + ";User Id=" +mysqlusername.Text.ToString() + ";Password=" + mysqlpassword.Text.ToString().Trim();

                                                    }
                                                    else if (att.Value == "port")
                                                    {
                                                        att = nodes[i].Attributes["value"];
                                                        att.Value = port.Text.ToString().Trim();
                                                    }

                                                    else if (att.Value == "renamefile")
                                                    {
                                                        att = nodes[i].Attributes["value"];
                                                        att.Value = sourcessql.Text.ToString().Trim();
                                                    }

                                                }
                                                doc.Save(filestr);
                                                MessageBox.Show("���óɹ�,�����������Ч", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// ��֤ʱ����Ƿ�Ϸ�
        /// </summary>
        /// <param name="timestring"></param>
        private bool Checkimporttimeislegal(string timestring)
        {
            string[] times = timestring.Split(' ');
            bool result = true;
            for (int i = 0; i < times.Length; i++)
            {
                if (!IsCorrenctIPput(times[i], @"^(([0-1][0-9])|(2[0-3])|([0-9])):(([0-5][0-9])|([0-9]))$"))
                {
                    result = false;
                    break;
                }

            }
            return result;
        }
    }
}