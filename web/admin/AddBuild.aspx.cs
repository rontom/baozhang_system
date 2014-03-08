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

public partial class admin_AddBuild : System.Web.UI.Page
{
    BuildManager BuildManager1 = new BuildManager();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void add_Click(object sender, EventArgs e)
    {
        BuildManager1.add(Buildname.Text.ToString().Trim(), anothername.Text.ToString().Trim());
        ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('添加成功');window.location='BasicData.aspx'</script>");
        

        //Response.Redirect("")
    }
}
