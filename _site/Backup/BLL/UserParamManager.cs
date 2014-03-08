using System;
using System.Collections.Generic;
using System.Text;
using DALProfile;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class UserParamManager
    {
        UserparamOpera uop = new UserparamOpera();


        /// <summary>
        /// 删除userparam表中所有的记录
        /// </summary>
        public void DelAll()
        {
            uop.DelAll();
        }



        /// <summary>
        /// 向userparam表中增加一条记录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="truename"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="mobile"></param>
        public void AddUser(string username, string password, string truename, string address, string phone, string mobile)
        {
            userparam up = new userparam();
            up.Username = username;
            up.Password = password;
            up.Truename = truename;
            up.Address = address;
            up.Phone = phone;
            up.Mobile = mobile;
            uop.AddUser(up);
        }


        /// <summary>
        /// 网络报障用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool login(string username, string password)
        {
            DataTable dt = uop.CheckHaveExist(username, Function.PasswordMD5(password));
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 获取报障人的基本信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public userparam GetUser(string username)
        {
            return uop.GetAuserByUsername(username);
        }



        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUser()
        {
            return uop.GetAllUser();
        }
    }
}
