using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public  class NoticeUser
    {
        private string username;//用户名

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private int noticeid;//通知编号

        public int Noticeid
        {
            get { return noticeid; }
            set { noticeid = value; }
        }

        private bool isread;

        public bool Isread
        {
            get { return isread; }
            set { isread = value; }
        }
    }
}
