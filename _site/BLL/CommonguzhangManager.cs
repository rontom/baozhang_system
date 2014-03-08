using System;
using System.Collections.Generic;
using System.Text;
using DALProfile;
using System.Data.SqlClient;
using System.Data;
using Wuqi.Webdiyer;

namespace BLL
{
    
    public class CommonguzhangManager
    {
        CommonGuzhangOpera cgm = new CommonGuzhangOpera();
        public void Add(string faultcontent)
        {
            cgm.Add(faultcontent);
        }


        public DataTable GetAllcommonFault(int flag, AspNetPager AspNetPager1)
        {
            return cgm.GetAllcommonFault(flag, "CommonGuzhang", "*", "id", AspNetPager1, false, "id is not null");
        }


        public void Del(int id)
        {
            cgm.Del(id);
        }

        public DataTable GetAllcommonFault()
        {
            return cgm.GetAllcommonFault();
        }
    }
}
