using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    [Serializable]
    public class Chat
    {
        private string senderpeople;

        public string Senderpeople
        {
            get { return senderpeople; }
            set { senderpeople = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private DateTime sendtime;

        public DateTime Sendtime
        {
            get { return sendtime; }
            set { sendtime = value; }
        }
    }
}
