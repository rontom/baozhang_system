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

public partial class admin_Mybreakdown : System.Web.UI.Page
{
    SecondFaultManager sfm = new SecondFaultManager();
    UsersManage UsersManage1 = new UsersManage();
    queuemanager qmg = new queuemanager();
    FaultQueueManager fqm = new FaultQueueManager();
    private int flag = 0;
    private static string forTYpe;  //转发类型，包括批量转发和单个转发
    private static int singerForwardid;
    //private static string PostiontoBind = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.Button2.Attributes.Add("onclick", "FaultForward()");
        //printQueue.Attributes.Add("onchange", "return chekprintqueue()");
        if (!IsPostBack)
        {
            BindUndoFault();
            BindPrintQueue();
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
                    Label lb = (Label)GridView1.Rows[i].FindControl("isonprintlab");
                    if (che.Checked && !bool.Parse(lb.Text))
                    {
                        fqm.PutIntoPrint_Queue(Convert.ToInt32(GridView1.DataKeys[i].Value.ToString()), Convert.ToInt32(printQueue.SelectedValue.ToString()), Session["username"].ToString());
                    }
                    //Response.Write(lb.Text);
                }



                ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>$('#putintoqueueresult').css('display','block');</script>");
                //ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>PutintoPrintQue()</script>",true);
                //RegisterStartupScript("提示", "<script>alert('选中的故障已经成功放入打印队列')</script>");
                //RegisterStartupScript("提示", "<script>PutintoPrintQue()</script>");
                BindUndoFault();
                printQueue.SelectedIndex = 0;
            }
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        singerForwardid = int.Parse(((LinkButton)sender).CommandArgument.ToString());
        this.havedo.Visible = true;
        this.listinfor.Visible = false;
        //ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>BindPostion()<script>");
        Literal1.Text = GetFaultPostion();
        BindUsers();
    }


    private string GetFaultPostion()
    {
        GuZhangSecond gzs = sfm.GetASecondFault(singerForwardid);
        return gzs.Address.ToString();
    }

    private void BindUsers()
    {
        CheckBoxList1.DataSource = UsersManage1.getalluser();
        CheckBoxList1.DataTextField = "TrueName";
        CheckBoxList1.DataValueField = "UserName";
        CheckBoxList1.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string dopeople = "";
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                dopeople=dopeople+"+"+CheckBoxList1.Items[i].Value.ToString();
            }
        }
        sfm.FaultConfirm(singerForwardid, beizhu.Text.ToString().Trim(), DateTime.Parse(finishdate.Text.ToString().Trim()), dopeople);
        ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('故障已成功完成，恭喜！')</script>");
        listinfor.Visible = true;
        havedo.Visible = false;
        BindUndoFault();
    }
}
