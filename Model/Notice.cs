using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Notice
    {
        private int id;//编号，由数据库自动生成

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string fromuser;//消息的发送者

        public string Fromuser
        {
            get { return fromuser; }
            set { fromuser = value; }
        }
        private string touser;//消息的接受者

        public string Touser
        {
            get { return touser; }
            set { touser = value; }
        }
        private string noticecontent;//通知内容

        public string Noticecontent
        {
            get { return noticecontent; }
            set { noticecontent = value; }
        }
        private DateTime sendtime;//消息发布的时间

        public DateTime Sendtime
        {
            get { return sendtime; }
            set { sendtime = value; }
        }
        private string menth;//消息发布的方式，一般分为短信方式和网络方式

        public string Menth
        {
            get { return menth; }
            set { menth = value; }
        }
        private int validity;//消息的有效期限

        public int Validity
        {
            get { return validity; }
            set { validity = value; }
        }
    }
}
