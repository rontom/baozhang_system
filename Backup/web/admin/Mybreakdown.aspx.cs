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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using dotnetCHARTING;

public partial class admin_Mybreakdown : System.Web.UI.Page
{
    SecondFaultManager sfm = new SecondFaultManager();
    UsersManage UsersManage1 = new UsersManage();
    queuemanager qmg = new queuemanager();
    FaultQueueManager fqm = new FaultQueueManager();
    private int flag = 0;
    private int printqueueflag = 0;
    private int havedoneflag = 0;

    private int Recycle_BinFlag = 0;
    private static string forTYpe;  //转发类型，包括批量转发和单个转发
    private static int singerForwardid = 0;
    //private static string PostiontoBind = "";
    //private static string connstr = "server=222.17.232.216;database=GuZhangMag;uid=sa;pwd=20080912@admin";
    protected void Page_Load(object sender, EventArgs e)
    {

        //this.Button2.Attributes.Add("onclick", "FaultForward()");
        //printQueue.Attributes.Add("onchange", "return chekprintqueue()");
        //BatchDelInRecycle_Bin.Attributes.Add("onclick", "CheckPowerIsAllow('BatchDelInRecycle_Bin')");
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {

            if (!IsPostBack)
            {
                SystemlogManager.Addnewslog(Session["username"].ToString());
                //printQueue.Attributes.Add("onchange", "return putintoprintqueuecheck()");
                BindUndoFault();
                BindPrintQueue();
                //BindPrintqueueinqueue();
                BindprintList();
                BindHaveDoneFault();
                BindMyRecycle_Bin();
                BinUserTimeDuring(Session["username"].ToString());
            }
        }
    }


    /// <summary>
    /// 绑定已经处理的故障
    /// </summary>
    private void BindHaveDoneFault()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            haovedonefaultdrid.DataSource = sfm.GetAllSecondFaultHavedone(havedoneflag, AspNetPager3, Session["username"].ToString());
            haovedonefaultdrid.DataBind();
        }
    }


    /// <summary>
    /// 绑定我的回收站
    /// </summary>
    private void BindMyRecycle_Bin()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            string userrole = UsersManage1.CheckUserRole(Session["username"].ToString());
            if (userrole == "超级管理员")
            {
                BoundField bndf = new BoundField();
                bndf.HeaderText = "删除人";
                bndf.DataField = "TrueName";
                SeconFaultRecycle_Bin.Columns.Add(bndf);

                SeconFaultRecycle_Bin.DataSource = sfm.GetAllSecondFaultInRecycle_BinByAdministration(Recycle_BinFlag, AspNetPager4);
                SeconFaultRecycle_Bin.DataKeyNames = new string[] { "GuZhangSecondID" };
                SeconFaultRecycle_Bin.DataBind();
            }
            else
            {
                SeconFaultRecycle_Bin.DataSource = sfm.GetAllSecondFaultInRecycle_Bin(Recycle_BinFlag, AspNetPager4, Session["username"].ToString());
                SeconFaultRecycle_Bin.DataKeyNames = new string[] { "GuZhangSecondID" };
                SeconFaultRecycle_Bin.DataBind();
                BatchDelInRecycle_Bin.Enabled = false;
                EmptyInRecycle_Bin.Enabled = false;
            }
        }
    }


    /// <summary>
    /// 绑定打印队列
    /// </summary>
    private void BindPrintQueue()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            DataTable dt = qmg.GetAllQueue(Session["username"].ToString().Trim());
            printQueue.DataSource = dt;
            printQueue.DataTextField = "queuename";
            printQueue.DataValueField = "id";
            printQueue.DataBind();
            printQueue.Items.Insert(0, new ListItem("移动到打印队列....", ""));
            printqueinqueue.DataSource = dt;
            printqueinqueue.DataTextField = "queuename";
            printqueinqueue.DataValueField = "id";
            printqueinqueue.DataBind();
        }
    }

    /// <summary>
    /// 绑定未处理的故障
    /// </summary>
    private void BindUndoFault()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            GridView1.DataSource = sfm.GetMyFault(flag, AspNetPager1, Session["username"].ToString());
            GridView1.DataKeyNames = new string[] { "GuZhangSecondID" };
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                GridView1.EmptyDataText = "暂无任何故障";
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox che = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (che.Checked)
                {
                    sfm.PutIntoRecycle_Bin(int.Parse(GridView1.DataKeys[i].Value.ToString()), Session["username"].ToString());
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('放入回收站成功')</script>");
            BindUndoFault();
            BindMyRecycle_Bin();
            TabWebControl1.SelectedTabIndex = 0;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ForwardFaultBind("batch");

    }

    private void BindUser()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            useres.DataTextField = "TrueName";
            useres.DataValueField = "UserName";
            useres.DataSource = UsersManage1.getalluser(Session["username"].ToString());
            useres.DataBind();
        }
    }

    private void ForwardFaultBind(string type)
    {
        listinfor.Visible = false;
        Forward.Visible = true;
        BindUser();
        forTYpe = type;

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        switch (forTYpe)
        {
            case "signel":
                SignelForward();
                break;
            case "batch":
                BatchFaword();
                break;


        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        TabWebControl1.SelectedTabIndex = 0;
        singerForwardid = int.Parse(((LinkButton)sender).CommandArgument.ToString());
        ForwardFaultBind("signel");
    }



    /// <summary>
    /// 单个转发
    /// </summary>
    private void SignelForward()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            if (singerForwardid.ToString().Trim() != "")
            {
                sfm.ForwardFault(singerForwardid, useres.SelectedValue.ToString().Trim(),useres.SelectedItem.Text.ToString().Trim());
                ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('故障已成功转发')</script>");
                listinfor.Visible = true;
                Forward.Visible = false;
                BindUndoFault();
            }
        }
    }

    private void BatchFaword()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox che = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (che.Checked)
                {
                    int id = int.Parse(GridView1.DataKeys[i].Value.ToString());
                    sfm.ForwardFault(id, useres.SelectedValue.ToString().Trim(),useres.SelectedItem.Text.ToString());
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('故障已成功转发')</script>");
            listinfor.Visible = true;
            Forward.Visible = false;
            BindUndoFault();
        }
    }

    protected void printQueue_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            if (printQueue.SelectedValue.ToString().Trim() != "")
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    CheckBox che = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                    System.Web.UI.WebControls.Label lb = (System.Web.UI.WebControls.Label)GridView1.Rows[i].FindControl("isonprintlab");
                    if (che.Checked && !bool.Parse(lb.Text))
                    {
                        fqm.PutIntoPrint_Queue(Convert.ToInt32(GridView1.DataKeys[i].Value.ToString()), Convert.ToInt32(printQueue.SelectedValue.ToString()), Session["username"].ToString());
                    }
                    //Response.Write(lb.Text);
                }



                ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('选中的故障已经成功放入打印队列')</script>");
                //ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>PutintoPrintQue()</script>",true);
                //RegisterStartupScript("提示", "<script>alert('选中的故障已经成功放入打印队列')</script>");
                //RegisterStartupScript("提示", "<script>PutintoPrintQue()</script>");
                BindUndoFault();
                BindprintList();
                printQueue.SelectedIndex = 0;
            }
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TabWebControl1.SelectedTabIndex = 0;
        singerForwardid = int.Parse(((LinkButton)sender).CommandArgument.ToString());
        this.havedo.Visible = true;
        this.listinfor.Visible = false;
        //ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>BindPostion()<script>");
        this.finishdate.Text = DateTime.Now.Date.ToShortDateString();
        GuZhangSecond gzs=GetFaultPostion();
        Literal1.Text = gzs.Address;
        Literal2.Text = gzs.GuZhangContent;
        Literal3.Text = gzs.Phone.ToString();
        BindUsers();
    }


    private GuZhangSecond GetFaultPostion()
    {
        GuZhangSecond gzs = sfm.GetASecondFault(singerForwardid);
        return gzs;
    }

    private void BindUsers()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            listall.DataSource = UsersManage1.getalluser(Session["username"].ToString());
            listall.DataTextField = "TrueName";
            listall.DataValueField = "UserName";
            listall.DataBind();
        }


    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {

            string dopeople = Session["username"].ToString() + "+";
            dopeople = dopeople + hiddenstring.Text.ToString().Trim();
            dopeople = dopeople.Substring(0, dopeople.Length - 1);
            string dopeoples =hidendopeoples.Text.ToString();


            dopeoples = dopeoples.Substring(0, dopeoples.Length - 1);
            //Response.Write(dopeoples);
                sfm.FaultConfirm(singerForwardid, beizhu.Text.ToString().Trim(), DateTime.Parse(finishdate.Text.ToString().Trim()), dopeople,dopeoples);
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('故障已成功完成，恭喜！')</script>");
            listinfor.Visible = true;
            havedo.Visible = false;
            BindUndoFault();
            BindHaveDoneFault();
        }
    }



    /// <summary>
    /// 绑定打印队列
    /// </summary>
    //private void BindPrintqueueinqueue()
    //{
    //    if (Session["username"] == null)
    //    {

    //    }
    //    printqueinqueue.DataSource = qmg.GetAllQueue();
    //    printqueinqueue.DataTextField = "queuename";
    //    printqueinqueue.DataValueField = "id";
    //    printqueinqueue.DataBind();
    //}



    private void BindprintList()
    {
        if (printqueinqueue.Items.Count == 0)
        {
            printqueinqueue.Items.Insert(0, new ListItem("---暂无任何打印队列---", ""));
        }
        else
        {
            GridView2.DataSource = fqm.GetAllPrintByqueueid(printqueueflag, AspNetPager2, Convert.ToInt32(printqueinqueue.SelectedValue.ToString()));
            GridView2.DataKeyNames = new string[] { "faultid" };
            GridView2.DataBind();
        }
    }
    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        printqueueflag = 1;
        //BindPrintqueueinqueue();
        TabWebControl1.SelectedTabIndex = 3;
    }
    protected void printqueinqueue_SelectedIndexChanged(object sender, EventArgs e)
    {
        printqueueflag = 0;
        BindprintList();
        TabWebControl1.SelectedTabIndex = 3;

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        int faultid = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());
        fqm.MoveoutfromQueue(faultid);
        ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('故障已成功移出打印队列')</script>");
        BindprintList();
        BindUndoFault();
        TabWebControl1.SelectedTabIndex = 3;

    }
    protected void printfaulttablebtn_Click(object sender, EventArgs e)
    {
        //string a = "";
        //TabWebControl1.SelectedTabIndex = 3;
        //listprintqueues.Visible = false;
        //printbyCrystalReport.Visible = true;
        //ArrayList FaultList = new ArrayList();
        string fault = "";
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            CheckBox checkbox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox3");
            if (checkbox.Checked)
            {
                fault = fault + GridView2.DataKeys[i].Value.ToString() + ",";
            }
        }
        //////Int32[] va = (Int32[])FaultList.ToArray(typeof(Int32));
        fault = fault.Substring(0, fault.Length - 1);
        //ReportDocument doc = new ReportDocument();
        //doc.Load(Server.MapPath("../CrystalReport/FauluTable.rpt"));
        //doc.SetDataSource(sfm.GetprintFault(fault));
        //CrystalReportViewer1.ReportSource = doc;

        //SqlConnection con = new SqlConnection(connstr);
        //con.Open();
        //string sql = "select * from GuZhangSecond";
        //SqlDataAdapter da = new SqlDataAdapter(sql, con);

        //DataSet ds = new DataSet();
        //da.Fill(ds, "GuZhangSecond");
        ////SecondFaultManager sfm = new SecondFaultManager();
        ////CrystalReportViewer1.ReportSource = sfm.GetAllSeconFaultBynull();
        ////ReportDocument doc = new ReportDocument();
        ////doc.Load(Server.MapPath("../CrystalReport/FauluTable.rpt"));
        ////doc.SetDataSource(ds.Tables["GuZhangSecond"]);
        ////CrystalReportSource1.ReportDocument.SetDataSource(ds.Tables[""])
        //////CrystalReportViewer1.ReportSource = doc;
        //////CrystalReportViewer1.DataBind();
        //////CrystalReportSource1
        ////con.Close();

        //CrystalReportSource1.ReportDocument.Load(Server.MapPath("../CrystalReport/FauluTable.rpt"));
        //    //注意此处必需指明Dataset中的表的名称，否则会提示“您请求的报表需要更多信息.”
        //CrystalReportSource1.ReportDocument.SetDataSource(ds.Tables["GuZhangSecond"]);
        //    //{?}中的参数可以不用赋值，即使赋了值也不起作用。

        //    CrystalReportSource1.DataBind();
        //    CrystalReportViewer1.ReportSource = CrystalReportSource1;
        //    CrystalReportViewer1.DataBind();

        string url = "print.aspx?a=" + fault;
        ClientScript.RegisterStartupScript(this.GetType(), "xs", "<script>window.open('" + url + "')</script>");
        TabWebControl1.SelectedTabIndex = 3;



    }

    protected void BatchMoveoutbtn_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            CheckBox checkbox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox3");
            if (checkbox.Checked)
            {
                fqm.MoveoutfromQueue(int.Parse(GridView2.DataKeys[i].Value.ToString()));
            }
        }
        ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('选中项已成功移出打印队列')</script>");
        BindprintList();
        BindUndoFault();
        TabWebControl1.SelectedTabIndex = 3;
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        int queueid = Convert.ToInt32(printqueinqueue.SelectedValue.ToString());
        try
        {
            fqm.ClearPrintQueueByQueueId(queueid);
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('打印队列已经成功的被清空')</script>");
            BindprintList();
            BindUndoFault();
            TabWebControl1.SelectedTabIndex = 3;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void AspNetPager3_PageChanged(object sender, EventArgs e)
    {
        havedoneflag = 1;
        BindHaveDoneFault();
        TabWebControl1.SelectedTabIndex = 1;
    }
    protected void AspNetPager4_PageChanged(object sender, EventArgs e)
    {
        Recycle_BinFlag = 1;
        BindMyRecycle_Bin();
        TabWebControl1.SelectedTabIndex = 2;
    }


    private void RestoreSeconfault(int seconfaultid)
    {
        sfm.RestoreSeconfault(seconfaultid);
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        int seconfaultid = Convert.ToInt32(((ImageButton)sender).CommandArgument.ToString());
        try
        {
            RestoreSeconfault(seconfaultid);
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('选中项已成功还原到未处理的故障')</script>");
            BindUndoFault();
            BindMyRecycle_Bin();
            TabWebControl1.SelectedTabIndex = 2;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < SeconFaultRecycle_Bin.Rows.Count; i++)
            {
                CheckBox checkbox = (CheckBox)SeconFaultRecycle_Bin.Rows[i].FindControl("CheckBox5");
                if (checkbox.Checked)
                {
                    RestoreSeconfault(Convert.ToInt32(SeconFaultRecycle_Bin.DataKeys[i].Value.ToString()));
                }
            }

            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('已成功还原所选项')</script>");
            BindMyRecycle_Bin();
            BindUndoFault();
            TabWebControl1.SelectedTabIndex = 2;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void BatchDelInRecycle_Bin_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < SeconFaultRecycle_Bin.Rows.Count; i++)
            {
                CheckBox checkbox = (CheckBox)SeconFaultRecycle_Bin.Rows[i].FindControl("CheckBox5");
                if (checkbox.Checked)
                {
                    sfm.DelSeconfault(Convert.ToInt32(SeconFaultRecycle_Bin.DataKeys[i].Value.ToString()));
                }
            }

            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('选中项已经彻底删除')</script>");
            BindMyRecycle_Bin();
            TabWebControl1.SelectedTabIndex = 2;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void EmptyInRecycle_Bin_Click(object sender, EventArgs e)
    {
        try
        {
            sfm.EmptyRecycle_Bin();
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('回收站已被清空')</script>");
            BindMyRecycle_Bin();
            TabWebControl1.SelectedTabIndex = 2;
        }
        catch (Exception ex)
        {
            throw ex;
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
            CheckFaultChartByYear.Items.Add(li);
        }
        CheckFaultChartByYear.Items.Insert(0, new ListItem("==选择年份==", ""));
    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        DrawingChart();
    }



    private void DrawingChart()
    {
        Charting c = new Charting();
        c.Title = CheckFaultChartByYear.SelectedItem.Text.ToString().Trim() + "个人处理故障汇总";
        c.XTitle = "月份";
        c.YTitle = "故障数";
        c.PicHight = 370;
        c.PicWidth = 700;
        c.SeriesName = "故障总数";
        c.PhaysicalImagePath = "pictemp";
        c.FileName = "dada";
        c.Type = SeriesType.Column;
        c.Use3D =false;
        c.DataSource = GetDatasources();
        c.CreateStatisticPic(this.Chart1);
        //Chart1.Type = ChartType.Pies;

        
        //Chart1.Title = this._title;
        //Chart1.XAxis.Label.Text ="月份";
        //Chart1.YAxis.Label.Text ="处理的故障数";
        //Chart1.TempDirectory = "pictemp";
        //Chart1.Width =600;
        //Chart1.Height = 500;
        //Chart1.Type = Chart1Type.Combo;
        //Chart1.Series.Type = SeriesType.Cylinder;
        //Chart1.Series.Name ="asda";
        //Chart1.Series.Data = sfm.GetCountFaultByYearByPeopel(Convert.ToInt32(CheckFaultChartByYear.SelectedValue.ToString()), Session["username"].ToString());
        //Chart1.SeriesCollection.Add();
        //Chart1.DefaultSeries.DefaultElement.ShowValue = true;
        //Chart1.ShadingEffect = true;
        //Chart1.Use3D = false;
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
            dt = sfm.GetCountFaultByYearByPeopel(Convert.ToInt32(CheckFaultChartByYear.SelectedValue.ToString()), Session["username"].ToString());
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

}
