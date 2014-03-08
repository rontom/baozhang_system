using System;
using System.Collections.Generic;
using System.Text;
using DALProfile;
using System.Web;
using System.Data;
using Wuqi.Webdiyer;
using Model;

namespace BLL
{
    public class BuildManager
    {
        BuildOpera bop = new BuildOpera();


        /// <summary>
        /// 添加楼房
        /// </summary>
        /// <param name="buildname"></param>
        /// <param name="anothername"></param>
        public void add(string buildname, string anothername)
        {
            try
            {
                bop.AddBuild(buildname, anothername);
                //HttpContext.Current.Response.Write("<script>alert('添加成功'); history.go(-2);</script>");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 利用sql语句获取楼房信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetBuild()
        {
            return bop.getall();
        }


        public DataTable GetBuild(int flag, AspNetPager AspNetPager1)
        {
            return bop.GetAllBuild(flag, "Dong", "*", "DongID", AspNetPager1, false, "DongID is not null");
        }


        public DataTable GetAllBuild()
        {
            return bop.GetAllBuild();
        }


        public void Update(string buildname,string anothername,int id)
        {
            Dong d = new Dong();
            d.DongID = id;
            d.DongName = buildname;
            d.Anothername = anothername;
            bop.Update(d);
        }


        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id"></param>
        public void Del(int id)
        {
            bop.Del(id);
        }


        public Dong GetAbuild(int id)
        {
            return bop.GetABulid(id);
        }
    }
}
