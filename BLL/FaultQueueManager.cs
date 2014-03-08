using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DALProfile;
using Wuqi.Webdiyer;

namespace BLL
{
    public class FaultQueueManager
    {
        FaultQueueOpera fqo = new FaultQueueOpera();
        public void PutIntoPrint_Queue(int SeconFaultId, int queueid,string owner)
        {
            fqo.PutIntoPrint_Queue(SeconFaultId, queueid,owner);
        }


        public DataTable GetAllPrintByqueueid(int flag, AspNetPager AspNetPager1, int queueid)
        {
            string tab = "dbo.GuZhangSecond,dbo.FaultQueue";
            string filed = "dbo.FaultQueue.faultid,dbo.GuZhangSecond.name,dbo.GuZhangSecond.GuZhangContent,dbo.GuZhangSecond.Address,dbo.GuZhangSecond.phone,dbo.GuZhangSecond.ReceivedDate";
            string where = "dbo.FaultQueue.queueid=" + queueid + " and dbo.FaultQueue.faultid=dbo.GuZhangSecond.GuZhangSecondID";
            string fld = "dbo.FaultQueue.Priority";
            
            return fqo.GetprintQueue(flag,tab,filed,fld,AspNetPager1,false,where);
        }



        /// <summary>
        /// 把故障从打印队列移出
        /// </summary>
        /// <param name="faultid"></param>
        public void MoveoutfromQueue(int faultid)
        {
            fqo.MoveoutfromQueue(faultid);
        }


        /// <summary>
        /// 清空打印队列
        /// </summary>
        /// <param name="queueid"></param>
        public void ClearPrintQueueByQueueId(int queueid)
        {
            fqo.ClearPrintQueueByQueueId(queueid);
        }



        /// <summary>
        /// 判断故障是否在打印队列中
        /// </summary>
        /// <param name="faultid"></param>
        /// <returns></returns>
        public bool CheckIsInprint(int faultid)
        {
            return fqo.CheckIsInprint(faultid);
        }
    }
}
