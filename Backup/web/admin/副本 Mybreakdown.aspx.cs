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

public partial class admin_Mybreakdown : System.Web.UI.Page
{
    private static SecondFaultManager sfm = new SecondFaultManager();
    private static UsersManage UsersManage1 = new UsersManage();
    private static queuemanager qmg = new queuemanager();
    private static FaultQueueManager fqm = new FaultQueueManager();
    private int flag = 0;
    private static string forTYpe;  //转发类型，包括批量转发和单个转发
    private static int singerForwardid;
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.Button2.Attributes.Add("onclick", "FaultForward()");
        //printQueue.Attributes.Add("onchange", "return chekprintqueue()");
        if (!IsPostBack)
        {
            //BindUndoFault();
            //BindPrintQueue();
        }
    }



    private void BindPrintQueue()
    {
        printQueue.DataSource = qmg.GetAllQueue();
        printQueue.DataTextField = "queuename";
        printQueue.DataValueField = "id";
        printQueue.DataBind();
        printQueue.Items.Insert(0, new ListItem("移动到打印队列....", ""));
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
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ForwardFaultBind("batch");

    }

    private void BindUser()
    {

        useres.DataTextField = "TrueName";
        useres.DataValueField = "UserName";
        useres.DataSource = UsersManage1.getalluser();
        useres.DataBind();
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
                sfm.ForwardFault(singerForwardid,useres.SelectedValue.ToString().Trim());
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
                CheckBox che=(CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (che.Checked)
                {
                    int id = int.Parse(GridView1.DataKeys[i].Value.ToString());
                    sfm.ForwardFault(id, useres.SelectedValue.ToString().Trim());
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('故障已成功转发')</script>");
            listinfor.Visible = true;
            Forward.Visible = false;
            BindUndoFault();
        }
    }
  
    //protected void printQueue_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (Session["username"] == null)
    //    {
    //        Function.CheckIstimeout();
    //    }
    //    else
    //    {
    //        if (printQueue.SelectedValue.ToString().Trim() != "")
    //        {
    //            for (int i = 0; i < GridView1.Rows.Count; i++)
    //            {
    //                CheckBox che = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
    //                if (che.Checked)
    //                {
    //                    fqm.PutIntoPrint_Queue(Convert.ToInt32(GridView1.DataKeys[i].Value.ToString()), Convert.ToInt32(printQueue.SelectedValue.ToString()), Session["username"].ToString());
    //                }
    //            }
    //            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>PutintoPrintQue('sucess')</script>");
    //        }
    //    }

    //    //Response.Write("adsad");
    //}
    
}
