using System;
using System.Collections.Generic;
using System.Text;
using DALProfile;
using Wuqi.Webdiyer;
using System.Data;
using Model;
using System.Web;

namespace BLL
{
    public class Unclassified_FaultManager
    {
        private static Unclassified_Fault ucf = new Unclassified_Fault();
        public DataTable  getallUnclassified_FaultManagerAll(int flag,AspNetPager AspNetPager1)
        {
            return ucf.GetUnclassified_Fault(flag, "GuZhangFirst", "*", "GuZhangFirstID", AspNetPager1, true, "IsTyped=0 and isdel=0");
        }

        public void Addnewfault(string con, string dt, string tel)
        {
            //if (ucf.AddnewFault(tel, dt, con, false) > 0)
            //{
            //    //return "短信已成功存入数据库！";
            //    return ucf.AddnewFault(tel, dt, con, false).ToString();
            //}
            //else
            //{
            //    //return "数据库出错";
            //    return ucf.AddnewFault(tel, dt, con, false).ToString();
            //}
            ucf.AddnewFault(tel, dt, con, false);

        }


        /// <summary>
        /// 通过网络报障
        /// </summary>
        /// <param name="con">故障内容</param>
        /// <param name="dt">报障日期</param>
        /// <param name="tel">手机联系电话</param>
        /// <param name="telephone">座机联系电话</param>
        public void Addnewfault(string con, string dt, string tel,string telephone)
        {
           
            ucf.AddnewFault(tel,dt,con,false,telephone);

        }

        public GuZhangFirst GetGuZhangFirstbyid(int id)
        {
            return ucf.GetGuZhangFirstbyId(id);
        }


        public void PutFaultIntoRecycle_Bin(int GuZhangFirstID, string deluser)
        {
            try
            {
                ucf.PutFaultIntoRecycle_Bin(GuZhangFirstID, deluser);
                //HttpContext.Current.Response.Write("<script>alert('你已成功放入回收站了')</script>");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 标识故障是否已经被分类
        /// </summary>
        /// <param name="GuZhangFirstID"></param>
        /// <param name="isdong"></param>
        public void SetFaultHaveclassification(int GuZhangFirstID, bool isdong)
        {
            ucf.SetFaultHaveclassification(GuZhangFirstID, isdong);
        }


        /// <summary>
        /// 判断故障是否被处理，防止故障的发生
        /// </summary>
        /// <param name="GuZhangFirstID">故障编号</param>
        /// <returns></returns>
        public bool CheckIsDoing(int GuZhangFirstID)
        {
            return ucf.CheckIsDoing(GuZhangFirstID);
        }

        public DataTable GetdelFault(int flag, AspNetPager AspNetPager1)
        {
            return ucf.GetDelFault(flag, "GuZhangFirst,Users", "GuZhangFirstID,PhoneNumber,telephone,MessageContent,ReceivedDate,menth,TrueName", "ReceivedDate", AspNetPager1, true, "GuZhangFirst.isdel=1 and GuZhangFirst.deluser=Users.UserName");

        }


        /// <summary>
        /// 还原删除的短信
        /// </summary>
        /// <param name="faultid"></param>
        public void RevertFault(int faultid)
        {
            ucf.RevertFault(faultid);
        }

        /// <summary>
        /// 超级管理员批量删除短信
        /// </summary>
        /// <param name="faultid"></param>
        public void DelFaultByAdministrator(int faultid)
        {
            ucf.DelFaultByAdministrator(faultid);
        }

        /// <summary>
        /// 清空已删除短信
        /// </summary>
        public void EmptyFaultByAdministrator()
        {
            ucf.EmptyFaultByAdministrator();
        }

        /// <summary>
        /// 更改最新短信
        /// </summary>
        public void SetFaultToBeOld()
        {
            ucf.SetFaultToBeOld();
        }



        /// <summary>
        /// 把故障标识为已经分类
        /// </summary>
        /// <param name="id">故障标号</param>
        public void SetFaultHaveClassiced(int id)
        {
            ucf.SetFaultHaveClassiced(id);
        }
    }
}
