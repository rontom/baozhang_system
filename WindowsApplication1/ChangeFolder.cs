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
    public partial class ChangeFolder : Form
    {
        public ChangeFolder()
        {
            InitializeComponent();
        }

        private void ChangeFolder_Load(object sender, EventArgs e)
        {
            FolderPath.Text = ConfigurationManager.AppSettings["folderPath"].ToString().Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            FolderPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否更改数据库文件的保存位置？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
                {
                //    Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //    cfg.AppSettings.Settings["folderPath"].Value = FolderPath.Text.ToString();
                //    cfg.Save();
                    XmlDocument doc = new XmlDocument();
                    string filestr = Application.ExecutablePath + ".config";
                    doc.Load(filestr);
                    XmlNodeList nodes = doc.GetElementsByTagName("add");
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        XmlAttribute att = nodes[i].Attributes["key"];
                        if (att.Value == "folderPath")
                        {
                            att = nodes[i].Attributes["value"];
                            att.Value = FolderPath.Text.ToString();
                        }
                    }
                    doc.Save(filestr);
                    MessageBox.Show("修改成功，需重启后才能生效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ConfigurationManager.RefreshSection("appSettings");
                    this.Close();
                     
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}