using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Model;

namespace BLL
{
    public class Getloginfor
    {

        //public systemlog  Getloginfor(string username)
        //{
        //    systemlog slg = new systemlog();
        //    slg.Username = username;
        //    slg.Ip = GetUserIP();
        //    slg.Url = GetUrl();
        //    slg.Date = GetSystemDateTime();
        //    return slg;
        //}


        /// <summary>
        /// 获取用户访问的url地址
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            return HttpContext.Current.Request.Url.AbsoluteUri;
        }


        /// <summary>
        /// 获取用户的ip地址
        /// </summary>
        /// <returns></returns>
        public string GetUserIP()
        {
            string userIP;
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] == null)
            {
                userIP = HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                userIP =HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            return userIP;
        }


        /// <summary>
        /// 记录当前的系统时间
        /// </summary>
        public DateTime GetSystemDateTime()
        {
            return DateTime.Now;
        }
    }

   
}
