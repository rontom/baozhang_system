using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class systemlog
    {
        private int _id;             //自动编号

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _ip;         //用户访问ip地址

        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        private DateTime _date;   //访问时间

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        private string _url;       //访问过的页面URL地址

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        private string _username;  //用户名

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
    }
}
