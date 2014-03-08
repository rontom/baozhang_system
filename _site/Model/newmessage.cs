using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    [Serializable]
    public class newmessage
    {
        private string kind;

        public string Kind
        {
            get { return kind; }
            set { kind = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string messagecontent;

        public string Messagecontent
        {
            get { return messagecontent; }
            set { messagecontent = value; }
        }
        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
