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
using System.Data.SqlClient;
using DALProfile;
using BLL;
using Model;

public partial class admin_NewsestBreakdown : System.Web.UI.Page
{
    private static Unclassified_FaultManager Unclassified_FaultManager1 = new Unclassified_FaultManager();
    private static SecondFaultManager SecondFaultManager1 = new SecondFaultManager();
    private static UsersManage umg = new UsersManage();
    private static int flag;
    private static int flag1;
    private static int flagdel;
    private static int secondfaultid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            SystemlogManager.Addnewslog(Session["username"].ToString());
            flag = 0;
            flag1 = 0;
            flagdel = 0;
            if (!IsPostBack)
            {
                bind();
                BindSecondFault();
                BindDelFault();
                BindPrintQueue();
            }
        }
    }


    private void bind()
    {
        GridView1.DataSource = Unclassified_FaultManager1.getallUnclassified_FaultManagerAll(flag, AspNetPager1);
        GridView1.DataKeyNames = new string[] { "GuZhangFirstID" };
        GridView1.DataBind();
    }


    private void BindDelFault()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            string role = umg.CheckUserRole(Session["username"].ToString());
            if (role != "超级管理员")
            {
                CompletelyDel.Enabled = false;
                Empty.Enabled = false;
                CompletelyDel.Visible = false;
                Empty.Visible = false;
            }
            delfaultlist.DataSource = Unclassified_FaultManager1.GetdelFault(flagdel, AspNetPager3);
            delfaultlist.DataKeyNames = new string[] { "GuZhangFirstID" };
            delfaultlist.DataBind();
        }
    }

    private void BindSecondFault()
    {
        GridView2.DataSource = SecondFaultManager1.GetAllSecondFault(flag1, AspNetPager2);
        GridView2.DataKeyNames = new string[] { "GuZhangSecondID" };
        GridView2.DataBind();
        //for (int i = 0; i < GridView2.Rows.Count; i++)
        //{
        //    Label lab = (Label)GridView2.Rows[i].FindControl("Label1");
        //    if (lab.Text == "已处理")
        //    {
        //        LinkButton lik = (LinkButton)GridView2.Rows[i].FindControl("LinkButton1");
        //        lik.Enabled = false;
        //    }
        //}
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            Unclassified_FaultManager1.PutFaultIntoRecycle_Bin(Convert.ToInt32(((ImageButton)sender).CommandArgument), Session["username"].ToString());
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('选中项已成功放入回收站')</script>", false);
            bind();
            BindDelFault();
            TabWebControl1.SelectedTabIndex = 0;
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        flag = 1;
        bind();
        TabWebControl1.SelectedTabIndex = 0;
    }
    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        flag1 = 1;
        if (RadioButtonList1.SelectedValue == "全部")
        {
            BindSecondFault();
        }
        if (RadioButtonList1.SelectedValue == "已处理")
        {
            BindHaveDoneSecondFault();
        }
        if (RadioButtonList1.SelectedValue == "未处理")
        {
            BindUnDoneSecondFault();
        }
        TabWebControl1.SelectedTabIndex = 1;
    }
    protected void AspNetPager3_PageChanged(object sender, EventArgs e)
    {
        flagdel = 1;
        BindDelFault();
        TabWebControl1.SelectedTabIndex = 2;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < delfaultlist.Rows.Count; i++)
        {
            CheckBox che = (CheckBox)delfaultlist.Rows[i].FindControl("CheckBox2");
            if (che.Checked)
            {
                try
                {
                    Unclassified_FaultManager1.RevertFault(Convert.ToInt32(delfaultlist.DataKeys[i].Value.ToString()));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('选中项已成功还原')</script>");
        flag = 0;
        flagdel = 0;
        bind();
        BindDelFault();
        TabWebControl1.SelectedTabIndex = 2;
    }
    protected void CompletelyDel_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < delfaultlist.Rows.Count; i++)
        {
            CheckBox che = (CheckBox)delfaultlist.Rows[i].FindControl("CheckBox2");
            if (che.Checked)
            {
                Unclassified_FaultManager1.DelFaultByAdministrator(Convert.ToInt32(delfaultlist.DataKeys[i].Value.ToString()));
            }
        }
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已成功删除')</script>");
        flagdel = 0;
        BindDelFault();
        TabWebControl1.SelectedTabIndex = 2;
    }
    protected void Empty_Click(object sender, EventArgs e)
    {
        try
        {
            Unclassified_FaultManager1.EmptyFaultByAdministrator();
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已成功清空！')</script>");
            flagdel = 0;
            BindDelFault();
            TabWebControl1.SelectedTabIndex = 2;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            try
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    CheckBox che = (CheckBox)GridView1.Rows[i].FindControl("CheckBox3");
                    if (che.Checked)
                    {
                        Unclassified_FaultManager1.PutFaultIntoRecycle_Bin(Convert.ToInt32(GridView1.DataKeys[i].Value.ToString()), Session["username"].ToString());

                    }
                }

                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('选中项成功放入了回收站')</script>");
                flag = 0;
                flagdel = 0;
                BindDelFault();
                bind();
                TabWebControl1.SelectedTabIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        secondfaultlist.Visible = false;
        havedo.Visible = true;
        TabWebControl1.SelectedTabIndex = 1;
        secondfaultid = Convert.ToInt32(((LinkButton)sender).CommandArgument);
        this.finishdate.Text = DateTime.Now.Date.ToShortDateString();
       GetFaultPostion();
        BindUsers();
    }


    private void GetFaultPostion()
    {
        GuZhangSecond gzs = SecondFaultManager1.GetASecondFault(secondfaultid);
        Literal1.Text = gzs.Address;
        Literal2.Text = gzs.GuZhangContent;
        Literal3.Text = gzs.Phone.ToString();
        //return gzs.Address.ToString();
    }


    private void BindUsers()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            listall.DataSource = umg.getalluser(Session["username"].ToString());
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
            string dopeoples = hidendopeoples.Text.ToString() ;

           // Response.Write(dopeople);
            if (dopeoples.ToString().Trim() != "")
            {
                dopeoples = umg.Getuser(Session["username"].ToString()).TrueName + "、" + dopeoples.Substring(0, (dopeoples.Length - 1));
            }
            else
            {
                dopeoples = umg.Getuser(Session["username"].ToString()).TrueName;
            }
            //Response.Write(dopeoples);
            SecondFaultManager1.FaultConfirm(secondfaultid, beizhu.Text.ToString().Trim(), DateTime.Parse(finishdate.Text.ToString().Trim()), dopeople, dopeoples);
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('故障已成功完成，恭喜！')</script>");
             secondfaultlist.Visible = true;
            havedo.Visible = false;
            //BindUndoFault();
            //BindHaveDoneFault();
            BindSecondFault();
            TabWebControl1.SelectedTabIndex = 1;
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        FaultQueueManager fqm=new FaultQueueManager();
        for (int i = 0; i <GridView2.Rows.Count; i++)
        {
        //if (e.Row[.RowType == DataControlRowType.DataRow)
        //{

            Label lab = (Label)GridView2.Rows[i].FindControl("Label1");
            Label lab2=(Label)GridView2.Rows[i].FindControl("isinprint");
            LinkButton lik = (LinkButton)GridView2.Rows[i].FindControl("LinkButton1");
            if (lab != null)
            {

                if (lik != null)
                {
                    //Response.Write(lab.Text+",");
                    if (lab.Text =="<font style='color:blue'>已处理</font>")
                    {
                        //lab.Enabled = false;
                        lik.Enabled = false;
                        //Response.Write("yes");
                    }
                    //Response.Write(lab.Enabled);
                }
            }

            if (lab2 != null)
            {
                if (fqm.CheckIsInprint(Convert.ToInt32(GridView2.DataKeys[i].Value.ToString())))
                {
                    lab2.Text = "已在";
                    //lab2.ForeColor = "Red";
                    lab2.ForeColor = System.Drawing.Color.Red;

                }
                else
                {
                    lab2.Text = "未在";
                }
            }
        //}
    }
    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        
        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>history.go(-2);</script>");

        TabWebControl1.SelectedTabIndex = 2;
        
    }
    protected void Button3_Click2(object sender, EventArgs e)
    {
        secondfaultlist.Visible = true;
        havedo.Visible = false;
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
            queuemanager qmg = new queuemanager();
            DataTable dt = qmg.GetAllQueue(Session["username"].ToString().Trim());
            printQueue.DataSource = dt;
            printQueue.DataTextField = "queuename";
            printQueue.DataValueField = "id";
            printQueue.DataBind();
            printQueue.Items.Insert(0, new ListItem("移动到打印队列....", ""));
           
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
            FaultQueueManager fqm = new FaultQueueManager();
            if (printQueue.SelectedValue.ToString().Trim() != "")
            {
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    CheckBox che = (CheckBox)GridView2.Rows[i].FindControl("CheckBox5");
                    System.Web.UI.WebControls.Label lb = (System.Web.UI.WebControls.Label)GridView2.Rows[i].FindControl("isinprint");
                    if (che.Checked && lb.Text == "未在")
                    {
                        fqm.PutIntoPrint_Queue(Convert.ToInt32(GridView2.DataKeys[i].Value.ToString()), Convert.ToInt32(printQueue.SelectedValue.ToString()), Session["username"].ToString());
                    }
                    //Response.Write(lb.Text);
                }



                ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('选中的故障已经成功放入打印队列')</script>");
                //ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>PutintoPrintQue()</script>",true);
                //RegisterStartupScript("提示", "<script>alert('选中的故障已经成功放入打印队列')</script>");
                //RegisterStartupScript("提示", "<script>PutintoPrintQue()</script>");
                BindSecondFault();
                //BindUndoFault();
                //BindprintList();
                printQueue.SelectedIndex = 0;
                TabWebControl1.SelectedTabIndex = 1;
            }
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string kind = RadioButtonList1.SelectedValue.ToString();
        if (kind == "全部")
        {
            BindSecondFault();
        }
        if (kind == "已处理")
        {
            BindHaveDoneSecondFault();
        }
        if (kind == "未处理")
        {
            BindUnDoneSecondFault();
        }
        TabWebControl1.SelectedTabIndex = 1;
    }


    private void BindHaveDoneSecondFault()
    {
        GridView2.DataSource = SecondFaultManager1.GetAllHaveDoneSecondFault(flag1, AspNetPager2);
        GridView2.DataKeyNames = new string[] { "GuZhangSecondID" };
        GridView2.DataBind();
        
    }


    private void BindUnDoneSecondFault()
    {
        GridView2.DataSource = SecondFaultManager1.GetAllUnDoneSecondFault(flag1, AspNetPager2);
        GridView2.DataKeyNames = new string[] { "GuZhangSecondID" };
        GridView2.DataBind();

    }
}
