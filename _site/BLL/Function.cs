using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.Web;
using System.Collections;
using System.Data;

namespace BLL
{
    public static class Function
    {
        public static string CutString(string str, int length)
        {
            string newString = "";
            if (str != "")
            {
                if (str.Length > length)
                {
                    newString = str.Substring(0, length) + "...";
                }
                else
                {
                    newString = str;
                }
            }
            return newString;
        }

        public static string PasswordMD5(string password)
        {
            string c = "";
            if (password.ToString().Trim() != "")
            {
                c = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
                return FormsAuthentication.HashPasswordForStoringInConfigFile(c.ToString().Trim(), "sha1");
            }
            else
            {
                return null;
            }
        }

        public static void CheckIstimeout()
        {
            HttpContext.Current.Response.Write("<script>alert('登录超时，本页面即将关闭');window.location='../timeout.aspx';</script>");
        }

        public static void loginimeout()
        {
            HttpContext.Current.Response.Write("<script>alert('登录超时，请重新登录');window.location='../timeout.aspx';</script>");
        }


        public static string FormatBool(bool t, string tart,string tarf)
        {
            if (t==true)
            {
                return "<font style='color:blue'>"+tart+"</font>";
            }
            else
            {
                return "<font style='color:red'>"+tarf+"</font>";
            }
        }



        public static string FormatBool(bool t,string filed)
        {
            if (t == true)
            {
                return "<font style='color:black'>" + filed + "</font>";
            }
            else
            {
                return "<font style='color:red'>" + filed + "</font>";
            }
        }

        public static string FormatFaultQueue(string content, DateTime fromDate, DateTime Todate)
        {
            TimeSpan ts = Todate - fromDate;
            double ddays = ts.TotalDays;
            if (ddays < 2)
            {
                return "<font style='color:#2d1212'>" + content + "</font>";
            }
            if(ddays>=2&&ddays<4)
            {
                return "<font style='color:#2a48fa'>" + content + "</font>";
            }
            if (ddays >= 4)
            {
                return "<font style='color:#f53151'>" + content + "</font>";
            }
            else
            {
                return null;
            }
        }


        public static string FormatFaultQueue(string content, DateTime fromDate, DateTime Todate,bool isdo)
        {
            TimeSpan ts = Todate - fromDate;
            double ddays = ts.TotalDays;
            if (isdo)
            {
                return "<font style='color:#000000'>" + content + "</font>";
            }
            else
            {
                if (ddays < 2)
                {
                    return "<font style='color:#c0c0c0'>" + content + "</font>";
                }
                if (ddays >= 2 && ddays < 4)
                {
                    return "<font style='color:#2a48fa'>" + content + "</font>";
                }
                if (ddays >= 4)
                {
                    return "<font style='color:#f53151'>" + content + "</font>";
                }
                else
                {
                    return null;
                }
            }
        }


        public static string FormatFaultMenth(string menth)
        {
            if (menth == "电话")
            {
                return "<img src='../images/life_nide_03.png' alt='电话'>";
            }
            if (menth == "短信")
            {
                return "<img src='../images/icon57.jpg' alt='短信'>";
            }

            if (menth == "网络")
            {
                return "<img src='../images/Internet_Explorer.jpg' alt='网络'>";
            }
            else
            {
                return null;
            }
        }

        public static string formateempty(string inner, string emptywar)
        {
            if (inner.ToString().Trim() == "")
            {
                return emptywar;
            }
            else
            {
                return inner;
            }
        }



        /// <summary>
        /// 判断首选和副选
        /// </summary>
        /// <param name="FirstSelect"></param>
        /// <param name="LastSelect"></param>
        /// <returns></returns>
        public static string CheckOnePhone(string FirstSelect, string LastSelect)
        {
            if (FirstSelect.ToString().Trim() == "")
            {
                return LastSelect;
            }
            else
            {
                return FirstSelect;
            }
        }

        /// <summary>
        /// 判断用户是否有足够权限访问
        /// </summary>
        /// <param name="isallow"></param>
        public static void IsPermissions(bool isallow)
        {
            if (!isallow)
            {
                HttpContext.Current.Response.Write("<script>alert('您没有足够的权限访问本页面');window.location='Perssion.aspx'</script>");
            }
        }



        /// <summary>
        /// 截取短信分割符
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static char[] splitstring(string s)
        {
            ArrayList al = new ArrayList();
            int i = 0;
            do
            {

                al.Add(s[i]);
                i = i + 2;
            } while (i < s.Length);

            char[] tt = (char[])al.ToArray(typeof(char));
            return tt;
        }



        /// <summary>
        /// 替代超长短信中的乱码
        /// </summary>
        /// <param name="re"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string ReplaceGarbled(string re)
        {

            if (re.Length > 70)
            {
                string rep = re.Substring(0, 3);
                string NormalString = re.Replace(rep, "");
                return NormalString;
            }
            else
            {
                return re;
            }
            
        }


       


    }
}
