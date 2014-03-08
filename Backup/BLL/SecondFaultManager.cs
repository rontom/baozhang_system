using System;
using System.Collections.Generic;
using System.Text;
using DALProfile;
using Model;
using System.Data;
using System.Data.SqlClient;
using Wuqi.Webdiyer;
using System.Collections;

namespace BLL
{
    public class SecondFaultManager
    {
        SecondFault sf = new SecondFault();
        public void Add(string GuZhangContent, string name, string phone, string Address, string FuZeRen, int DongID, string DoLiuCheng, bool IsDo, string BeiZhu, bool isdel, int GuZhangFirstID, string reciver, DateTime recivedate, string menth)
        {
            GuZhangSecond gs = new GuZhangSecond();
            gs.GuZhangContent = GuZhangContent;
            gs.Address = Address;
            gs.FuZeRen=FuZeRen;
            gs.DongID = DongID;
            gs.DoLiuCheng = DoLiuCheng;
            gs.IsDo = IsDo;
            gs.Result_descript = BeiZhu;
            gs.Isdel = isdel;
            gs.GuZhangFirstID = GuZhangFirstID;
            gs.Name = name;
            gs.Phone = phone;
            gs.Recevier = reciver;
            gs.ReceivedDate = recivedate;
            gs.Menth = menth;
            sf.Add(gs);
        }



        /// <summary>
        /// 电话报障记录添加，其中包括当场处理的故障
        /// </summary>
        /// <param name="GuZhangContent">故障内容</param>
        /// <param name="name">报障人的姓名</param>
        /// <param name="phone">联系电话</param>
        /// <param name="Address">地址</param>
        /// <param name="FuZeRen">故障当前负责人</param>
        /// <param name="DongID">故障属于哪一栋的</param>
        /// <param name="DoLiuCheng">处理流程</param>
        /// <param name="IsDo">是否被处理</param>
        /// <param name="BeiZhu">故障备注</param>
        /// <param name="isdel">是否被删除</param>
        /// <param name="reciver">故障登记者即接电话的人</param>
        /// <param name="recivedate">报障日期</param>
        /// <param name="menth">报障方式</param>
        /// <param name="doresult">处理结果</param>
        /// <param name="forwarddescript">转发说明</param>
        public void Add(string GuZhangContent, string name, string phone, string Address, string FuZeRen, int DongID, string DoLiuCheng, bool IsDo, string BeiZhu, bool isdel,  string reciver, DateTime recivedate, string menth,string doresult,string forwarddescript,DateTime dt,string dopeople)
        {
            GuZhangSecond gs = new GuZhangSecond();
            gs.GuZhangContent = GuZhangContent;
            gs.Address = Address;
            gs.FuZeRen = FuZeRen;
            gs.DongID = DongID;
            gs.DoLiuCheng = DoLiuCheng;
            gs.IsDo = IsDo;
            gs.BeiZhu = BeiZhu;
            gs.Isdel = isdel;
            gs.Name = name;
            gs.Phone = phone;
            gs.Recevier = reciver;
            gs.ReceivedDate = recivedate;
            gs.Menth = menth;
            gs.Result_descript = doresult;
            gs.Forward_description = forwarddescript;
            gs.DoDate = dt;
            gs.Dopeoples = dopeople;
            sf.Add1(gs);
        }


        public void Add(string GuZhangContent, string name, string phone, string Address, string FuZeRen, int DongID, string DoLiuCheng, bool IsDo, string BeiZhu, bool isdel, string reciver, DateTime recivedate, string menth, string doresult, string forwarddescript)
        {
            GuZhangSecond gs = new GuZhangSecond();
            gs.GuZhangContent = GuZhangContent;
            gs.Address = Address;
            gs.FuZeRen = FuZeRen;
            gs.DongID = DongID;
            gs.DoLiuCheng = DoLiuCheng;
            gs.IsDo = IsDo;
            gs.BeiZhu = BeiZhu;
            gs.Isdel = isdel;
            gs.Name = name;
            gs.Phone = phone;
            gs.Recevier = reciver;
            gs.ReceivedDate = recivedate;
            gs.Menth = menth;
            gs.Result_descript = doresult;
            gs.Forward_description = forwarddescript;
            sf.Addhavedone(gs);
        }


        public DataTable GetAllSecondFault(int flag, AspNetPager AspNetPager1)
        {
            return sf.GetAllSecondFaultByProcrsure(flag, "GuZhangSecond,Users", "GuZhangSecondID,name,GuZhangContent,menth,DoDate,TrueName,Address,GuZhangSecond.phone,ReceivedDate,IsDo", "ReceivedDate", AspNetPager1, true, " GuZhangSecond.isdel=0 and GuZhangSecond.FuZeRen=Users.UserName");
        }


        public DataTable GetAllHaveDoneSecondFault(int flag, AspNetPager AspNetPager1)
        {
            return sf.GetAllSecondFaultByProcrsure(flag, "GuZhangSecond,Users", "GuZhangSecondID,name,GuZhangContent,menth,DoDate,TrueName,Address,GuZhangSecond.phone,ReceivedDate,IsDo", "ReceivedDate", AspNetPager1, true, " GuZhangSecond.isdel=0 and GuZhangSecond.FuZeRen=Users.UserName and IsDo=1");
        }


        public DataTable GetAllUnDoneSecondFault(int flag, AspNetPager AspNetPager1)
        {
            return sf.GetAllSecondFaultByProcrsure(flag, "GuZhangSecond,Users", "GuZhangSecondID,name,GuZhangContent,menth,DoDate,TrueName,Address,GuZhangSecond.phone,ReceivedDate,IsDo", "ReceivedDate", AspNetPager1, true, " GuZhangSecond.isdel=0 and GuZhangSecond.FuZeRen=Users.UserName and IsDo=0");
        }


        public DataTable GetAllSecondFaultByTel(int flag, AspNetPager AspNetPager1,string username,string meth)
        {
            return sf.GetAllSecondFaultByProcrsure(flag, "GuZhangSecond", "GuZhangSecondID,name,GuZhangContent,Address,phone,ReceivedDate", "ReceivedDate", AspNetPager1, true, " GuZhangSecond.isdel=0 and recevier='" + username + "' and menth='"+meth+"'");
        }


        public DataTable GetAllSecondFaultHavedone(int flag, AspNetPager AspNetPager1,string username)
        {
            return sf.GetAllSecondFaultByProcrsure(flag, "GuZhangSecond", "GuZhangSecondID,DoDate,menth,name,GuZhangContent,Address,phone,ReceivedDate", "ReceivedDate", AspNetPager1, true, " GuZhangSecond.isdel=0 and FuZeRen='" + username + "' and IsDo=1");
        }

        public DataTable GetAllSecondFaultInRecycle_Bin(int flag, AspNetPager AspNetPager1, string username)
        {
            return sf.GetAllSecondFaultByProcrsure(flag, "GuZhangSecond", "GuZhangSecondID,menth,name,GuZhangContent,Address,phone,ReceivedDate", "ReceivedDate", AspNetPager1, false, " GuZhangSecond.isdel=1 and delUser='" + username + "'");
        }


        public DataTable GetAllSecondFaultInRecycle_BinByAdministration(int flag, AspNetPager AspNetPager1)
        {
            return sf.GetAllSecondFaultByProcrsure(flag, "GuZhangSecond,[Users]", "GuZhangSecondID,TrueName,menth,name,GuZhangContent,Address,GuZhangSecond.phone,ReceivedDate", "ReceivedDate", AspNetPager1, false, " GuZhangSecond.isdel=1and GuZhangSecond.delUser=Users.UserName");
        }


        public GuZhangSecond GetASecondFault(int secondfaultid)
        {
            return sf.GetASecondFault(secondfaultid);
        }

        public DataTable GetASecondFault1(int secondfaultid)
        {
            return sf.GetASecondFault1(secondfaultid);
        }



        public DataTable GetMyFault(int flag, AspNetPager AspNetPager1,string username)
        {
            string ziduan = "a.*,MyBit = case when b.faultid is null then 'False' else 'True' end";
            string tab = " dbo.GuZhangSecond a left join  dbo.FaultQueue b on a.GuZhangSecondID = b.faultid";
            string where = "a.FuZeRen='" + username + "' and a.isdel=0 and IsDo=0";
            //return sf.GetAllSecondFaultByProcrsure(flag, "GuZhangSecond,GuZhangFirst", "GuZhangSecondID,name,GuZhangContent,Address,phone,ReceivedDate", "ReceivedDate", AspNetPager1, false, "GuZhangSecond.GuZhangSecondID=GuZhangFirst.GuZhangFirstID and GuZhangSecond.isdel=0 and IsDo=0 and FuZeRen='" + username + "'"); ;
            return sf.GetAllSecondFaultByProcrsure(flag, tab, ziduan, "ReceivedDate", AspNetPager1, false, where);
        }

        public void PutIntoRecycle_Bin(int secondfaultid, string username)
        {
            sf.PutIntoRecycle_Bin(secondfaultid, username);
        }


        public void ForwardFault(int id, string fuzeren,string fuzerenname)
        {
            sf.ForwardFault(id, fuzeren,fuzerenname);
        }



        /// <summary>
        /// 将选中项放入打印队列
        /// </summary>
        /// <param name="SeconFaultId"></param>
        /// <param name="queueid"></param>
        public void PutIntoPrint_Queue(int SeconFaultId, int queueid)
        {

        }




        /// <summary>
        /// 故障确认
        /// </summary>
        /// <param name="FaultId"></param>
        /// <param name="beizhu"></param>
        /// <param name="dt"></param>
        /// <param name="dopeople"></param>
        public void FaultConfirm(int FaultId, string beizhu, DateTime dt, string dopeople, string dopeoples)
        {
            sf.FaultConfirm(FaultId, beizhu, dt, dopeople,dopeoples);
        }



        public DataTable GetAllSeconFaultBynull()
        {
            return sf.GetAllSeconFaultBynull();
        }


        public DataTable GetprintFault(string al)
        {
            return sf.GetprintFault(al);
        }

        /// <summary>
        /// 故障还原
        /// </summary>
        /// <param name="seconfaultid"></param>
        public void RestoreSeconfault(int seconfaultid)
        {
            sf.RestoreSeconfault(seconfaultid);
        }

        /// <summary>
        /// 超级管理员删除回收站里面的故障
        /// </summary>
        /// <param name="seconfaultid"></param>
        public void DelSeconfault(int seconfaultid)
        {
            sf.DelSeconfault(seconfaultid);
        }


        /// <summary>
        /// 超级管理员清空回收站
        /// </summary>
        public void EmptyRecycle_Bin()
        {
            sf.EmptyRecycle_Bin();
        }



        /// <summary>
        /// 获取用户每年每月的故障数
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public DataTable GetCountFaultByYearByPeopel(int year, string username)
        {
            return sf.GetCountFaultByYearByPeopel(year, username);
        }


        /// <summary>
        /// 获取每种报障方式的信息
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public DataTable GetFalutMenthByYear(int year)
        {
            return sf.GetFalutMenthByYear(year);
        }



        /// <summary>
        /// 年度故障分布图
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetFaultDongByYear(int year)
        {
            return sf.GetFaultDongByYear(year);
        }


        /// <summary>
        /// 获取学期人员故障图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="usertype"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public DataTable GetPerPeopleYearFaultCount(int year, string usertype, int term)
        {
            return sf.GetPerPeopleYearFaultCount(year, usertype, term);
        }
    }
}
