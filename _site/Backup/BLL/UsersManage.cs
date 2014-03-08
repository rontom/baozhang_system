using System;
using System.Collections.Generic;
using System.Text;
using DALProfile;
using System.Data;
using Wuqi.Webdiyer;
using Model;
using System.Web;

namespace BLL
{
    public class UsersManage
    {
        UserOpera upo = new UserOpera();
        public DataTable getalluser()
        {
            return upo.GetAlluser();
        }


        /// <summary>
        /// 获取除某个用户以外的所有用户
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataTable getalluser(string username)
        {
            return upo.GetAlluser(username);
        }


        /// <summary>
        /// 获取某个电话簿中人的电话号码
        /// </summary>
        /// <param name="phonebookid">电话簿id</param>
        /// <returns></returns>
        public DataTable getalluser(int phonebookid)
        {
            return upo.GetAlluser(phonebookid);
        }



        /// <summary>
        /// 获取除学生用户以外的所有用户
        /// </summary>
        /// <param name="usertype">用户类型</param>
        /// <returns></returns>
        public DataTable GetAlluserTeacher(string usertype)
        {
            return upo.GetAlluserTeacher(usertype);
        }

        public DataTable Getalluserbyprcedure(int flag, AspNetPager AspNetPager1)
        {
            return upo.GetAlluser(flag, "Users", "UserName,TrueName,UserType,phone", "UserName", AspNetPager1, false, " UserName is not null");
        }

        public void Addusers(string username, string password,DateTime dt, string truename, string sex, string usertype, string yuanxi, string zhuanye, string phone, string beizhu)
        {
            try
            {
                Users Users1 = new Users();
                Users1.UserName = username;
                Users1.Password = password;
                Users1.TrueName = truename;
                Users1.Sex = sex;
                Users1.AddTime = dt;
                Users1.UserType = usertype;
                Users1.Yuanxi = yuanxi;
                Users1.Zhuanye = zhuanye;
                Users1.Phone = phone;
                Users1.Beizhu = beizhu;
                upo.addUser(Users1);
            }
            catch
            {
                Console.WriteLine("操作异常");
            }
            
        }

        /// <summary>
        /// 根据用户名删除指定的用户
        /// </summary>
        /// <param name="username"></param>
        public void DelUser(string username)
        {
            upo.DelUser(username);
        }



        /// <summary>
        /// 根据用户名获取用户信息，返回值是一个对象
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Users Getuser(string username)
        {
            return upo.GetAuser(username);
        }


        public void UpdateUser(string username, string truename, string sex, string usertype, string yuanxi, string zhuanye, string phone, string beizhu)
        {
            Users u = new Users();
            u.UserName = username;
            u.TrueName = truename;
            u.Sex = sex;
            u.UserType = usertype;
            u.Yuanxi = yuanxi;
            u.Zhuanye = zhuanye;
            u.Phone = phone;
            u.Beizhu = beizhu;
            upo.updateuser(u);
        }



        /// <summary>
        /// 修改用户的登录密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldpassword"></param>
        /// <param name="newpassword"></param>
        public string ModiftyPassword(string username, string newpassword)
        {
            return upo.ModiftyPassword(username,newpassword);
        }



        /// <summary>
        /// 修改用户密码传入用户名，旧密码，和新密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldpassword"></param>
        /// <param name="newpassword"></param>
        /// <returns></returns>
        public string ModiftyPassword(string username,string oldpassword, string newpassword)
        {
            return upo.ModiftyPassword(username,oldpassword, newpassword);
        }


        public bool CheckUserIsOnline(string Username)
        {
            Getloginfor glg=new Getloginfor();
            string LastLoginIP=glg.GetUserIP().ToString().Trim();
           
            if (upo.CheckUserIsOline(Username, LastLoginIP).Rows.Count > 0 && upo.CheckUserIsOline(Username, LastLoginIP).Rows[0][0].ToString().Trim() != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string CheckUserRole(string username)
        {
            return upo.GetAuser(username).UserType.ToString();
        }

        /// <summary>
        /// 修改用户头像
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="p"></param>
        public void ModiftyFace(string userid, byte[] p)
        {
            upo.ModiftyFace(userid, p);
        }

        public int CheckExist(string username, string password)
        {
            return upo.CheckExist(username, password);
        }


       /// <summary>
       /// 不在某个打印队列中的用户
       /// </summary>
       /// <param name="queueid">队列编号</param>
       /// <returns></returns>
        public DataTable UsersNotinQueue(int queueid)
        {
            return upo.UsersNotinQueue(queueid);
        }


        /// <summary>
        /// 某个打印队列中的所有用户
        /// </summary>
        /// <param name="queueid">打印队列编号</param>
        /// <returns></returns>
        public DataTable UsersInQueue(int queueid)
        {
            return upo.UsersInQueue(queueid);
        }


        /// <summary>
        /// 不在某个电话组中的其他用户
        /// </summary>
        /// <param name="queueid"></param>
        /// <returns></returns>
        public DataTable UsersNotInPhoneBook(int phonebookid)
        {
            return upo.UsersNotInPhoneBook(phonebookid);
        }


        /// <summary>
        /// 某个电话簿组中的用户
        /// </summary>
        /// <param name="phonebookid"></param>
        /// <returns></returns>
        public DataTable UsersInPhoneBook(int phonebookid)
        {
            return upo.UsersInPhoneBook(phonebookid);
        }


        /// <summary>
        /// 获取某种用户类型中的所有用户
        /// </summary>
        /// <param name="usertype">用户类型</param>
        /// <returns></returns>
        public DataTable GetAllUserByType(string usertype)
        {
            return upo.GetAllUserByType(usertype);
        }


        /// <summary>
        /// 用户加入网络中心的时间
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetUserAddTime(string username)
        {
            return upo.GetUserAddTime(username);
        }



        /// <summary>
        /// 更新聊天端口
        /// </summary>
        /// <param name="port"></param>
        /// <param name="username"></param>
        public void UpdateChatport(int port, string username)
        {
            upo.UpdateChatport(port, username);
        }
    }
}
