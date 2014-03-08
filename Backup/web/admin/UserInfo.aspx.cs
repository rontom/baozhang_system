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

public partial class admin_UserInfo : System.Web.UI.Page
{
    private static UsersManage UsersManage1 = new UsersManage();
    public string beizhu = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string username1 = Request.QueryString["username"];
        if (!IsPostBack)
        {
            binduser(username1);
        }
    }

    private void binduser(string username1)
    {
        Users u = new Users();
        u = UsersManage1.Getuser(username1);
        username.Text = u.UserName;
        state.Text = u.Status;
        sex.Text = u.Sex;
        phone.Text = u.Phone;
        yuanxi.Text = u.Yuanxi;
        zhuanye.Text = u.Zhuanye;
        logintime.Text = u.LoginTime.ToString();
        ip.Text = u.IPAddress;
        usertype.Text = u.UserType;
        truename.Text = u.TrueName;
        //if (u.Beizhu.ToString().Trim() != "")
        //{
            beizhu = u.Beizhu;
        //}
        //else
        //{
        //    beizhu = "无";
        //}
        if (u.UserType.ToString().Trim() != "学生")
        {
            yuanxi.Text = "无";
            zhuanye.Text = "无";
        }
        
    }
}
