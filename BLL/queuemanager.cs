using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DALProfile;
using Model;

namespace BLL
{
    public class queuemanager
    {
        private static queueopera quo = new queueopera();


        public DataTable GetAllQueue()
        {
            return quo.GetAllQueue();
        }


        public void AddPrintQueue(string name, DateTime dt,string usernames)
        {
            quo.AddPrintQueue(name, dt,usernames);
        }

        public void DelPrintQueue(int id)
        {
            quo.DelPrintQueue(id);
        }

        public DataTable GetAllQueue(string username)
        {
            return quo.GetAllQueue(username);
        }


        /// <summary>
        /// 获取一个打印队列实体
        /// </summary>
        /// <param name="queueid">队列编号</param>
        /// <returns></returns>
        public queue GetAPrintQueue(int queueid)
        {
            return quo.GetAPrintQueue(queueid);
        }



        /// <summary>
        /// 修改队列
        /// </summary>
        /// <param name="queueid">队列编号</param>
        /// <param name="queuename">队列名</param>
        /// <param name="users">队列所属的用户</param>
        public void UpdatePrintqueue(int queueid, string queuename, string users)
        {
            quo.UpdatePrintqueue(queueid, queuename, users);
        }
    }
}
