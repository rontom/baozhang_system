using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class WebReportLog
    {
        private int id;//自动编号

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime logintime;//登录时间

      

        public DateTime Logintime
        {
            get { return logintime; }
            set { logintime = value; }
        }
        private string loginip;//登录IP地址

        public string Loginip
        {
            get { return loginip; }
            set { loginip = value; }
        }
        private string username;//登录使用的用户名

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private bool result;//登录结果

        public bool Result
        {
            get { return result; }
            set { result = value; }
        }
        private string url;//访问的url地址

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
    }
}
