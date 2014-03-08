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
using Model;

public partial class admin_top : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            if (!IsPostBack)
            {
                LoadPersonInfo(Session["username"].ToString());
            }
        }
    }


    private void LoadPersonInfo(string username)
    {
        Users u = new Users();
        UsersManage umg = new UsersManage();
        u = umg.Getuser(username);
        if (u.TrueName.ToString() != "")
        {
            truename.Text = u.TrueName;
        }
        if (u.UserType.ToString() != "")
        {
            Role.Text = u.UserType;
        }
    }
}
