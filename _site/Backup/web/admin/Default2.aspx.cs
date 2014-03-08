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

public partial class admin_Default2 : System.Web.UI.Page
{
    BuildManager b = new BuildManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.DropDownList1.Attributes.Add("onchange", "CheckUserName()");

        DropDownList1.DataSource = b.GetAllBuild();
        DropDownList1.DataTextField = "DongName";
        DropDownList1.DataValueField = "DongID";
        DropDownList1.DataBind();
    }

   
}