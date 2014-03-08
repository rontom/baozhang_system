using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    [Serializable]
    public class SMS
    {
        private string number;//短信发送号码

        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        private string scon;//短信内容

        public string Scon
        {
            get { return scon; }
            set { scon = value; }
        }
    }
}
