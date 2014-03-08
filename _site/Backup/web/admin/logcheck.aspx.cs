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

public partial class admin_logcheck : System.Web.UI.Page
{
    private int flag = 0;
    private int flag1 = 0;
    private int flagbindmenth = 0;
    private UsersManage umg = new UsersManage();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            if (umg.Getuser(Session["username"].ToString()).UserType != "超级管理员")
            {
                Function.IsPermissions(false);
            }
            else
            {
                if (!IsPostBack)
                {
                    Bind();
                    BindUser();
                    BindWebLogs();
                }
            }
        }
    }


    private void Bind()
    {
        Systemlog.DataSource = SystemlogManager.GetLog(flag, AspNetPager1);
        Systemlog.DataKeyNames = new string[] { "id" };
        Systemlog.DataBind();
    }

    private void BindUser()
    {
        Userdrop.DataSource = umg.getalluser();
        Userdrop.DataTextField = "TrueName";
        Userdrop.DataValueField = "UserName";
        Userdrop.DataBind();
        Userdrop.Items.Insert(0, new ListItem("--不限--", "*"));
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        flag = 1;
        switch (flagbindmenth)
        {
            case 0: Bind(); break;
            case 1: BindSysLogBetweenTimes(); break;
        }
        //Bind();
    }


    
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < Systemlog.Rows.Count; i++)
            {
                CheckBox che = (CheckBox)Systemlog.Rows[i].FindControl("CheckBox1");
                if (che.Checked)
                {
                    SystemlogManager.DelLogById(Convert.ToInt32(Systemlog.DataKeys[i].Value.ToString()));
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功')</script>");
            flag = 0;
            Bind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            SystemlogManager.DelLogBetweenTwoDate(Userdrop.SelectedValue.ToString().Trim(), Convert.ToDateTime(starttime.Text.ToString().Trim()), Convert.ToDateTime(endtime.Text.ToString().Trim()));
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('日志已成功删除')</script>");
            flag = 0;
            Bind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    private void BindWebLogs()
    {
        weblogslist.DataSource = WebReportLogManager.GetAllWebReportLogs(flag1,AspNetPager2);
        weblogslist.DataKeyNames = new string[] { "id" };
        weblogslist.DataBind();
    }
    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        flag1 = 1;
        switch (flagbindmenth)
        {
            case 0: BindWebLogs(); break;
            case 1: BindWebRepoetLogsBetweenTimes(); break;
        }
        //BindWebLogs();
        TabWebControl1.SelectedTabIndex = 1;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < weblogslist.Rows.Count; i++)
            {
                CheckBox che = (CheckBox)weblogslist.Rows[i].FindControl("CheckBox3");
                if (che.Checked)
                {
                    WebReportLogManager.DelWebReportLogsById(Convert.ToInt32(weblogslist.DataKeys[i].Value.ToString()));
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功')</script>");
            flag1 = 0;
            BindWebLogs();
            TabWebControl1.SelectedTabIndex = 1;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DateTime starttime = Convert.ToDateTime(weblogstart.Text.ToString().Trim());
        DateTime endtime = Convert.ToDateTime(weblogend.Text.ToString().Trim()).AddDays(1);
        try
        {
            WebReportLogManager.DelWebLogsBetweenDate(starttime, endtime);
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功')</script>");
            flag1 = 0;
            BindWebLogs();
            TabWebControl1.SelectedTabIndex = 1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        flag1 = 0;
        flagbindmenth = 1;
        AspNetPager2.CurrentPageIndex = 0;
        BindWebRepoetLogsBetweenTimes();
        TabWebControl1.SelectedTabIndex = 1;
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        flag = 0;
        flagbindmenth = 1;
        AspNetPager1.CurrentPageIndex = 0;
        BindSysLogBetweenTimes();
        
    }


    /// <summary>
    /// 绑定某段时间的系统日志
    /// </summary>
    private void BindSysLogBetweenTimes()
    {
        DateTime starttime1 = Convert.ToDateTime(starttime.Text.ToString().Trim());
        DateTime endtime1 = Convert.ToDateTime(endtime.Text.ToString().Trim()).AddDays(1);
        Systemlog.DataSource = SystemlogManager.GetSysLogsBetweenTimes(flag, AspNetPager1, starttime1, endtime1);
        Systemlog.DataKeyNames = new string[] { "id" };
        Systemlog.DataBind();
    }


    /// <summary>
    /// 绑定某段时间的网络报障日志
    /// </summary>
    private void BindWebRepoetLogsBetweenTimes()
    {
        DateTime starttime = Convert.ToDateTime(weblogstart.Text.ToString().Trim());
        DateTime endtime = Convert.ToDateTime(weblogend.Text.ToString().Trim()).AddDays(1);
        weblogslist.DataSource = WebReportLogManager.GetWebReportLogsBetweenTimes(flag1, AspNetPager2, starttime, endtime);
        weblogslist.DataKeyNames = new string[] { "id" };
        weblogslist.DataBind();
    }
}
