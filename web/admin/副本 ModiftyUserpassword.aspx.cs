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

public partial class admin_ModiftyUserpassword : System.Web.UI.Page
{
    private static UsersManage UsersManage1 = new UsersManage();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = Request.QueryString["username"];
        string oldpassword1 = Function.PasswordMD5(oldpassword.Text.ToString().Trim());
        string newpassword1 = Function.PasswordMD5(newpassword.Text.ToString().Trim());
        string result = UsersManage1.ModiftyPassword(username,newpassword1);
        if ( result== "修改成功")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('密码修改成功');history.go(-2)</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('原密码不正确')</script>");
            this.oldpassword.Text = "";
            this.newpassword.Text = "";
            this.check.Text = "";
        }
        //else
        //{
        //    RegisterClientScriptBlock("提示", "<script>alert('发生未知的错误')</script>");
        //}
    }
}
