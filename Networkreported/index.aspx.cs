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

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserParamManager upmg=new UserParamManager();
        if (username.Text.ToString().Trim() == "" || password.Text.ToString().Trim() == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('用户名或密码必填')</script>");
        }
        else
        {
            if (upmg.login(username.Text.ToString().Trim(), password.Text.ToString().Trim()))
            {
                Session["username"] = username.Text.ToString().Trim();
                WebReportLogManager.AddNesWebReportLog(username.Text.ToString().Trim(), true);
                Response.Redirect("main.aspx");
               
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户名或密码错误')</script>");
                password.Text = "";
                WebReportLogManager.AddNesWebReportLog(username.Text.ToString().Trim(), false);
            }
        }


    }
}
