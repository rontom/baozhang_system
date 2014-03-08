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
        if (username.Text.ToString().Trim() == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户名必填')</script>");
        }
        if (password.Text.ToString().Trim() == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码必填')</script>");
        }
        else
        {

        }
    }
}
