using System;
using System.Collections.Generic;
using System.Text;
using DALProfile;
using Model;
using System.Data.SqlClient;
using System.Data;
using Wuqi.Webdiyer;

namespace BLL
{
    public static class SystemlogManager
    {
        private static SystemlogOpera SystemlogOpera1 = new SystemlogOpera();
        private static Getloginfor Getloginfor1 = new Getloginfor();

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="username"></param>
        public static void Addnewslog(string username)
        {
            systemlog slg = new systemlog();
            slg.Ip = Getloginfor1.GetUserIP();
            slg.Date = Getloginfor1.GetSystemDateTime();
            slg.Url = Getloginfor1.GetUrl();
            slg.Username = username;
            SystemlogOpera1.Addlog(slg);
        }



        /// <summary>
        /// 获取全部的日志文件
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="AspNetPager1"></param>
        /// <returns></returns>
        public static DataTable GetLog(int flag, AspNetPager AspNetPager1)
        {
            string tab = "systemlog,Users";
            string fild = "id,ip,date,url,TrueName";
            string ord = "date";
            string where = "systemlog.username=Users.UserName";
            return SystemlogOpera1.GetAllSystemLog(flag, tab, fild, ord, AspNetPager1, true, where);

        }


        /// <summary>
        /// 获取某个时间短的日志
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="AspNetPager1"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static DataTable GetSysLogsBetweenTimes(int flag, AspNetPager AspNetPager1, DateTime starttime, DateTime endtime)
        {
            string tab = "systemlog,Users";
            string fild = "id,ip,date,url,TrueName";
            string ord = "date";
            string where = "systemlog.username=Users.UserName and systemlog.date between '"+starttime+"' and '"+endtime+"'";
            return SystemlogOpera1.GetAllSystemLog(flag, tab, fild, ord, AspNetPager1, true, where);
        }


        /// <summary>
        /// 删除系统日志
        /// </summary>
        /// <param name="logid"></param>
        public static void DelLogById(int logid)
        {
            SystemlogOpera1.DelLogById(logid);
        }


        /// <summary>
        /// 删除某个时间段的系统日志
        /// </summary>
        /// <param name="username"></param>
        /// <param name="begindate"></param>
        /// <param name="endtime"></param>
        public static void DelLogBetweenTwoDate(string username, DateTime begindate, DateTime endtime)
        {
            SystemlogOpera1.DelLogBetweenTwoDate(username, begindate, endtime);
        }
    }
}
