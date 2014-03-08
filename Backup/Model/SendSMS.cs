using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 短信发送的配置信息类
    /// </summary>
    public class SendSMS
    {
        private string ip;  //服务器端的ip地址

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private string port; //服务器端的端口号

        public string Port
        {
            get { return port; }
            set { port = value; }
        }
    }
}
