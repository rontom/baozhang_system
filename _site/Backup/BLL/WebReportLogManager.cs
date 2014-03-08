using System;
using System.Collections.Generic;
using System.Text;
using DALProfile;
using Model;
using Wuqi.Webdiyer;
using System.Data;

namespace BLL
{
    public static class WebReportLogManager
    {

        private static WebReportLogOpera wro = new WebReportLogOpera();
        /// <summary>
        /// 记录网络报障的日志信息
        /// </summary>
        /// <param name="logintime">登录时间</param>
        /// <param name="loginip">登录IP</param>
        /// <param name="username">登录使用的用户名</param>
        /// <param name="Url">登录使用的url地址</param>
        /// <param name="result">登录结果</param>
        public static void AddNesWebReportLog( string username, bool result)
        {
            Getloginfor gli = new Getloginfor();
            //WebReportLogOpera wro = new WebReportLogOpera();
            WebReportLog wrl = new WebReportLog();
            wrl.Logintime = gli.GetSystemDateTime();
            wrl.Loginip = gli.GetUserIP();
            wrl.Username = username;
            wrl.Url = gli.GetUrl();
            wrl.Result = result;
            wro.AddNewLog(wrl);
        }


        public static  DataTable GetAllWebReportLogs(int flag, AspNetPager AspNetPager1)
        {
            return wro.GetAllWebReportLogs(flag, "Web_Reported_impaired_log", "*", "logintime", AspNetPager1, true, "id is not null");
        }



        /// <summary>
        /// 根据id删除日志
        /// </summary>
        /// <param name="id"></param>
        public static void DelWebReportLogsById(int id)
        {
            wro.DelWebReportLogsById(id);
        }



        /// <summary>
        /// 删除某段时间的系统日志
        /// </summary>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        public static void DelWebLogsBetweenDate(DateTime starttime, DateTime endtime)
        {
            wro.DelWebLogsBetweenDate(starttime, endtime);
        }


        public static DataTable GetWebReportLogsBetweenTimes(int flag, AspNetPager AspNetPager1,DateTime starttime, DateTime endtime)
        {
            return wro.GetAllWebReportLogs(flag, "Web_Reported_impaired_log", "*", "logintime", AspNetPager1, true, "logintime between '" + starttime + "' and '" + endtime + "'");
        }
    }
}
