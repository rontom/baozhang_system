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
using dotnetCHARTING;
using System.Data.SqlClient;

public partial class admin_Report : System.Web.UI.Page
{
    private SecondFaultManager sfm = new SecondFaultManager();

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
                    BindUser();
                    GetYearFromBuildToNow();

                }
            }
        }
    }




    /// <summary>
    /// 绑定从网络中心创建到现在的年份
    /// </summary>
    private void GetYearFromBuildToNow()
    {
        int nowyear = DateTime.Now.Year;
        for (int i = nowyear; i >= 2003;i-- )
        {
            ListItem li = new ListItem();
            li.Text = i.ToString() + "年";
            li.Value = i.ToString();
            yearintabone.Items.Add(li);
            yearintabtwo.Items.Add(li);
            yearintab3.Items.Add(li);
           
        }
        yearintabone.Items.Insert(0, new ListItem("=选择年份=", ""));
        yearintabtwo.Items.Insert(0, new ListItem("=选择年份=", ""));
        yearintab3.Items.Insert(0, new ListItem("=选择年份=", ""));
    }

    private void DrawingPerYearMenth()
    {
        Charting c = new Charting();
        c.Title = yearintabone.SelectedItem.Text.ToString().Trim() + "报障方式统计图";
        c.XTitle = "月份";
        c.YTitle = "故障数";
        c.PicHight = 370;
        c.PicWidth = 700;
        c.SeriesName = "故障总数";
        c.PhaysicalImagePath = "pictemp";
        c.FileName = "dada";
        c.Type =SeriesType.Cylinder;
        c.Use3D = true;
        c.DataSource = GetDatasources();
        c.CreateStatisticPic(this.Chart1);
        Chart1.Type = ChartType.Pies;
        //Chart1.Series.DefaultElement.ShowValue = true;
    }

    private void DrawingPerYearDong()
    {
        Charting c = new Charting();
        c.Title =yearintabtwo.SelectedItem.Text.ToString().Trim() + "故障分布图";
        c.XTitle = "位置";
        c.YTitle = "故障数";
        c.PicHight = 370;
        c.PicWidth = 770;
        c.SeriesName = "故障总数";
        c.PhaysicalImagePath = "pictemp";
        c.FileName = "dongpic";
        c.Type = SeriesType.Column;
        c.Use3D = false;
        c.DataSource =GetDatasourcesEveryDong();
        c.CreateStatisticPic(this.Chart2);
        Chart2.Type = ChartType.Combo;
        //Chart1.Series.DefaultElement.ShowValue = true;
    }





    private void DrawingPerYearPeople()
    {
        Charting c = new Charting();
        c.Title =yearintab3.SelectedItem.Text.ToString().Trim()+xueqi.SelectedItem.Text + "故障处理图";
        c.XTitle = "姓名";
        c.YTitle = "处理故障数";
        c.PicHight = 370;
        c.PicWidth = 770;
        c.SeriesName = "故障总数";
        c.PhaysicalImagePath = "pictemp";
        c.FileName = "peopledofault";
        c.Type = SeriesType.Column;
        c.Use3D = false;
        c.DataSource =GetDatasourcesEveryPeople();
        c.CreateStatisticPic(this.Chart3);
       // Chart3.Type = ChartType.Combo;
        //Chart1.Series.DefaultElement.ShowValue = true;
    }



    private SeriesCollection GetDatasources()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
            return null;
        }
        else
        {
            SeriesCollection SC = new SeriesCollection();
            DataTable dt = new DataTable();
            dt = sfm.GetFalutMenthByYear(Convert.ToInt32(yearintabone.SelectedValue));
            Series s = new Series();
            s.Name = "年度报障总数";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Element e = new Element();
                e.Name = dt.Rows[i]["方式"].ToString();
                e.YValue = Convert.ToDouble(dt.Rows[i]["总数"].ToString());
                s.Elements.Add(e);
            }
            SC.Add(s);
            return SC;
        }
    }


    private SeriesCollection GetDatasourcesEveryDong()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
            return null;
        }
        else
        {
            SeriesCollection SC = new SeriesCollection();
            DataTable dt = new DataTable();
            dt = sfm.GetFaultDongByYear(Convert.ToInt32(yearintabtwo.SelectedValue));
            Series s = new Series();
            s.Name = "总数";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Element e = new Element();
                e.Name = dt.Rows[i]["建筑"].ToString();
                e.YValue = Convert.ToDouble(dt.Rows[i]["总数"].ToString());
                s.Elements.Add(e);
            }
            SC.Add(s);
            return SC;
        }
    }


    private SeriesCollection GetDatasourcesEveryPeople()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
            return null;
        }
        else
        {
            SeriesCollection SC = new SeriesCollection();
            DataTable dt = new DataTable();
            dt = sfm.GetPerPeopleYearFaultCount(Convert.ToInt32(yearintab3.SelectedValue),usertype.SelectedValue,Convert.ToInt32(xueqi.SelectedValue));
            Series s = new Series();
            s.Name = "总数";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Element e = new Element();
                e.Name = dt.Rows[i]["姓名"].ToString();
                e.YValue = Convert.ToDouble(dt.Rows[i]["数量"].ToString());
                s.Elements.Add(e);
            }
            SC.Add(s);
            return SC;
        }
    }



    private void DrawingChartEveryPeopleperYear()
    {
        Charting c = new Charting();
        c.Title = yearuntab4.SelectedItem.Text.ToString().Trim() + "个人处理故障汇总";
        c.XTitle = "月份";
        c.YTitle = "故障数";
        c.PicHight = 370;
        c.PicWidth = 700;
        c.SeriesName = "故障总数";
        c.PhaysicalImagePath = "pictembnps";
        c.FileName = "dassdass";
        c.Type = SeriesType.Column;
        c.Use3D = false;
        c.DataSource =GetDatasourcesbyerverpeopleperyear();
        c.CreateStatisticPic(this.Chart4);
    }


    private void BindUser()
    {
        UsersManage umg=new UsersManage();
        AllUser.DataSource = umg.getalluser();
        AllUser.DataTextField = "TrueName";
        AllUser.DataValueField = "UserName";
        AllUser.DataBind();
        AllUser.Items.Insert(0, new ListItem("==选择用户==", ""));
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        DrawingPerYearMenth();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DrawingPerYearDong();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DrawingPerYearPeople();
    }

    protected void AllUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (AllUser.SelectedValue.ToString().Trim() == "")
        {
            yearuntab4.Enabled = false;
            yearuntab4.Items.Insert(0, new ListItem("==选择年份==", ""));
        }
        else
        {
            yearuntab4.Items.Clear();
            BinUserTimeDuring(AllUser.SelectedValue.ToString());
            yearuntab4.Enabled = true;
        }
    }



    /// <summary>
    /// 绑定用户在网络中心的时间段
    /// </summary>
    /// <param name="username"></param>
    private void BinUserTimeDuring(string username)
    {
        UsersManage umg = new UsersManage();
        int starttime = Convert.ToInt32(umg.GetUserAddTime(username));
        int endtime = Convert.ToInt32(DateTime.Now.Year.ToString());
        for (int i = starttime; i <= endtime; i++)
        {
            ListItem li = new ListItem();
            li.Text = i.ToString() + "年";
            li.Value = i.ToString();
            yearuntab4.Items.Add(li);
        }
        yearuntab4.Items.Insert(0, new ListItem("==选择年份==", ""));
    }

    private SeriesCollection GetDatasourcesbyerverpeopleperyear()
    {
        SecondFaultManager sfmg = new SecondFaultManager();
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
            return null;
        }
        else
        {
            SeriesCollection SC = new SeriesCollection();
            DataTable dt = new DataTable();
            dt = sfmg.GetCountFaultByYearByPeopel(Convert.ToInt32(yearuntab4.SelectedValue.ToString()),AllUser.SelectedValue.ToString());
            Series s = new Series();
            s.Name = "年故障数合计";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Element e = new Element();
                e.Name = dt.Rows[i]["月份"].ToString();
                e.YValue = Convert.ToDouble(dt.Rows[i]["数量"].ToString());
                s.Elements.Add(e);
            }
            SC.Add(s);
            return SC;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        DrawingChartEveryPeopleperYear();
        //ScriptManager.RegisterStartupScript(UpdatePanel4,this.GetType())
        //Response.Write("asdad");
    }
    //protected void Button4_Click1(object sender, EventArgs e)
    //{

    //}
}
