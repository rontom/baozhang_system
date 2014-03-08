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

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Request.QueryString["username"].ToString();
        string password = Request.QueryString["password"].ToString();
        if (username == "admin" && password == "admin")
        {
            Response.Redirect("test1.aspx");
        }
        
    }
}
