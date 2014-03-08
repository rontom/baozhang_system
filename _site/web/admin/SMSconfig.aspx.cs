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
using System.Web.Configuration;
using System.Xml;
using BLL;

public partial class admin_SMSconfig : System.Web.UI.Page
{
    private UsersManage UsersManage1 = new UsersManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            if (UsersManage1.Getuser(Session["username"].ToString()).UserType != "超级管理员")
            {
                Function.IsPermissions(false);
            }
            else
            {
                if (!IsPostBack)
                {
                    SystemlogManager.Addnewslog(Session["username"].ToString());
                    this.TextBox1.Text = ConfigurationManager.AppSettings["fengefu"].ToString();
                }
            }
        }
    }


    /// <summary>
    /// 短信分隔符
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Write(TextBox1.Text.ToString());
        string a =TextBox1.Text.ToString().Trim();
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        AppSettingsSection app = (AppSettingsSection)config.GetSection("appSettings");
        app.Settings["fengefu"].Value =a;
        config.Save();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        UserParamManager upmg=new UserParamManager();
        GridView1.DataSource = upmg.GetAllUser();
        GridView1.DataBind();
        TabWebControl1.SelectedTabIndex = 1;

         Response.Clear();
        Response.Buffer = true;
        Response.Charset = "GB2312";
        Response.AppendHeader("Content-Disposition", "attachment;filename=FileName.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF7;
        Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。 
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
        this.GridView1.RenderControl(oHtmlTextWriter); 
        Response.Output.Write(oStringWriter.ToString());
        Response.Flush();
        Response.End();


    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i < GridView1.Columns.Count; i++)
        {
            e.Row.Cells[i].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
        }


    }
}
