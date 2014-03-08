using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int port = int.Parse(comboBox1.Text);
            string str = textBox8.Text;
            string sN = textBox9.Text.ToString().Trim();
            //textBox4
            //打开端口
            label5.Text = "初始化端口";
            string ret = axSzhtoSms1.YhOpenModem(port, str, sN);
            
            if (ret.IndexOf("-1")>0) 
            {
                label5.Text = "端口失败";
                button3.Enabled = false;
                button2.Enabled = false;
            }
             else
             {
                 textBox4.Text = ret;
                 label5.Text = "端口成功";
                 button3.Enabled = true;
                 button2.Enabled = true;
                 button5.Enabled = true;
                 button6.Enabled = true;
             }
  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string SiD = textBox2.Text;
            string del = "";
            label5.Text = "正在接收短信！";
            if (axSzhtoSms1.smsStatus != "" ) return;
            axSzhtoSms1.YhReadSms(SiD, del);
            String sCon = "";
            if (int.Parse(SiD) > 0)
            {   //指定的单条短信
                sCon = axSzhtoSms1.RsId + "\r\n";
                sCon = sCon + "短信中心:" + axSzhtoSms1.RsCenterNo + "\r\n";
                sCon = sCon + "对方电话:" + axSzhtoSms1.RsTel + "\r\n";
                sCon = sCon + "来信日期:" + axSzhtoSms1.RsDate + "\r\n";
                sCon = sCon + "短信内容:" + axSzhtoSms1.RsCon + "\r\n";
                sCon = sCon + "========================\r\n";
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
                    sCon = "";
                    for (int i = 0; i < Ri.Length; i++)
                    {
                        sCon = sCon + "序    号:"+ Ri[i] + "\r\n";
                        sCon = sCon + "短信中心:" + RC[i] + "\r\n";
                        sCon = sCon + "对方电话:" + RT[i] + "\r\n";
                        sCon = sCon + "来信日期:" + RD[i] + "\r\n";
                        sCon = sCon + "短信内容:" + RCon[i] + "\r\n";
                        sCon = sCon + "========================\r\n";
                    }
                }
            }
            textBox1.Text = sCon;
            label5.Text = "接收完成";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sCen =textBox4.Text;
            string sCon =textBox5.Text ;
            string sTel ="";
            if (axSzhtoSms1.smsStatus != "") return;
          
            int sBit = 0;  // 7为指定发7BIT短信，8指定发8Bit短信,0为自动判别,1为发至SP号,9发为送工业用16进制短信
            if (checkBox2.Checked) sBit = 9;
            if (checkBox3.Checked) sBit = 1;
            label5.Text = "正在发送短信...";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                sTel =System.Convert.ToString( listBox1.Items[i]);
                textBox7.Text = textBox7.Text +"状态："+ axSzhtoSms1.YhSendSms(sCen,sTel,sCon,sBit) +" ["+sTel+ "]\r\n";
            }
            label5.Text = "发送短信结束";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked )
                axSzhtoSms1.SmsFlash = true;
            else
                axSzhtoSms1.SmsFlash = false; 
        }

        private void axSzhtoSms1_NewSms(object sender, AxSzhto.__SzhtoSms_NewSmsEvent e)
        {
            if (e.sId != "")
            {
                string[] Ri = e.sId.Split('');
                string[] RC = e.sCenterNo.Split('');
                string[] RT = e.sTel.Split('');
                string[] RD = e.sDate.Split('');
                string[] RCon = e.sCon.Split('');
                string sCon = "";
                for (int i = 0; i < Ri.Length; i++)
                {
                    sCon = sCon + "序    号:" + Ri[i] + "\r\n";
                    sCon = sCon + "短信中心:" + RC[i] + "\r\n";
                    sCon = sCon + "对方电话:" + RT[i] + "\r\n";
                    sCon = sCon + "来信日期:" + RD[i] + "\r\n";
                    sCon = sCon + "短信内容:" + RCon[i] + "\r\n";
                    sCon = sCon + "========================\r\n";
                }

                textBox1.Text = textBox1.Text + sCon + "\r\n";
            }
//            string sCen = textBox4.Text;
//            string sTel = "13713855661";
//            string sCon = "自动转发:"+e.sCon;
//            int sBit = 0;  // 7为指定发7BIT短信，8指定发8Bit短信,0为自动判别
          //  label5.Text = "正在转发短信...";
          //  label5.Text = axSzhtoSms1.YhSendSms(ref sCen, ref sTel, ref  sCon, ref sBit);
          //  label5.Text=  "转发完成";
        }

        private void axSzhtoSms1_NewRing(object sender, AxSzhto.__SzhtoSms_NewRingEvent e)
        {
            textBox1.Text = textBox1.Text + "{{{{{{{{{{{{{{{{\r\n电话："+e.iTel+"时间："+e.iDate + "\r\n}}}}}}}}}}}}}}}\r\n";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string []Port = axSzhtoSms1.YhGetComPort().Split(',');
            for (int i=0;i<Port.Length;i++)
                comboBox1.Items.Add ( Port[i]);
            comboBox1.Text = Port[0];
        }

        private void axSzhtoSms1_SmsReport(object sender, AxSzhto.__SzhtoSms_SmsReportEvent e)
        {
            textBox1.Text = textBox1.Text + "**************************\r\n编    号:" + e.smsID + "\r\n发达电话:" + e.sTel + "\r\n发送日期:" + e.toCenterDate + "\r\n收到日期：" + e.toUserDate + "\r\n状态：" + e.iLog + "\r\n**************************\r\n";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label9.Text = "发送短信字符数：" +System.Convert.ToString(textBox5.TextLength);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (axSzhtoSms1.smsStatus != "") return;
            string SiD = textBox2.Text;
            label5.Text = "开始删除";
            label5.Text = axSzhtoSms1.YhDelSms(SiD);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string At = textBox10.Text;
            if (axSzhtoSms1.smsStatus != "") return;
            label5.Text = "开始测试AT";
            textBox1.Text = axSzhtoSms1.YhATCommand(At );
            label5.Text = "结束测试AT";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "") listBox1.Items.Add(textBox3.Text);
            textBox3.Text = "";
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textBox3.Text != "") listBox1.Items.Add(textBox3.Text);
                textBox3.Text = "";
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.Items.Count  >0 ) listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button7_Click(object sender, EventArgs e)
        {

             
            string A = textBox5.Text; 
            string C = "";
            byte [] b = System.Text.Encoding.GetEncoding("EUC-KR").GetBytes(A) ;
            foreach (byte aa in b)
                C += string.Format("{0:x2}", aa);
            textBox5.Text = C.ToUpper();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label5.Text = "开始拔号";
             string Tel = textBox11.Text;
             label5.Text = "通话结果:" + axSzhtoSms1.VoiceInterface(ref Tel);
        }

        private void button9_Click(object sender, EventArgs e)
        {

            textBox1.Text = textBox1.Text +"\r\n手机信号:"+ axSzhtoSms1.SignalQuality();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "\r\n短信数量:" + axSzhtoSms1.GetSmsNum();

        }
        

    }
}