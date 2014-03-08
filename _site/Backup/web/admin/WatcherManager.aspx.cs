using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;

public partial class admin_WatcherManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindAllUser();
    }


    private void BindAllUser()
    {
        UsersManage umg = new UsersManage();
        allusers.DataSource = umg.GetAlluserTeacher("学生");
        allusers.DataTextField = "TrueName";
        allusers.DataValueField = "UserName";
        allusers.DataBind();
    }
   
}
