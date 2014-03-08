using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UserQueue
    {
        private string username;//用户名

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private int queueid;//队列id;

        public int Queueid
        {
            get { return queueid; }
            set { queueid = value; }
        }
    }
}
