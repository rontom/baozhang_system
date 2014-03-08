using System;
using System.Collections.Generic;
using System.Text;
using Wuqi.Webdiyer;
using System.Data;
using DALProfile;

namespace BLL
{
    public class roommanage
    {
        private RommOpera rop = new RommOpera();
        public DataTable GetAllRoomByBuildid(int flag, AspNetPager AspNetPager1, int buildid)
        {
            return rop.GetRoomByBuild(flag, "[room],Dong", "room.*,Dong.DongName", "roomid", AspNetPager1, false, "buildname=" + buildid + " and Dong.DongID=room.buildname");
        }


        public void AddRoom(string rooid, int build, string intro)
        {
            rop.AddRoom(rooid, build, intro);
        }



        public void DelRoom(int id)
        {
            rop.DelRoom(id);
        }



        public DataTable GetRoomByBuild(int buildid)
        {
            return rop.GetRoomByBuild(buildid);
        }
    }
}
