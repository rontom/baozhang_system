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
using Model;
using BLL;

public partial class admin_Manual_classification : System.Web.UI.Page
{
    private static Unclassified_FaultManager Unclassified_FaultManager1 = new Unclassified_FaultManager();
    private static UsersManage umg=new UsersManage();
    SecondFaultManager SecondFaultManager1 = new SecondFaultManager();
    private static BuildManager BuildManager1 = new BuildManager();
    public static string a = "";
    private static DateTime dt;
    private static string menth;
    private static string separators = ConfigurationManager.AppSettings["fengefu"].ToString().Trim();//分隔符
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["username"] == null)
            {
                Function.CheckIstimeout();
            }
            else
            {
                SystemlogManager.Addnewslog(Session["username"].ToString());
                int id = Convert.ToInt32(Request.QueryString["id"]);
                GuZhangFirst GuZhangFirst1 = new GuZhangFirst();
                GuZhangFirst1 = Unclassified_FaultManager1.GetGuZhangFirstbyid(id);
                a = GuZhangFirst1.MessageContent.ToString();
                dt = Convert.ToDateTime(GuZhangFirst1.ReceivedDate);
                menth = GuZhangFirst1.Menth;
                char[] separator = Function.splitstring(separators);
                if (GuZhangFirst1.PhoneNumber == null)
                {
                    TextBox5.Text = GuZhangFirst1.Telephone.ToString();
                }
                else
                {
                    TextBox5.Text = GuZhangFirst1.PhoneNumber.ToString();
                }
                for (int i = 0; i < separator.Length; i++)
                {
                    string[] content = GuZhangFirst1.MessageContent.Split(separator[i]);
                    if (content.Length == 3)
                    {
                        
                        TextBox4.Text = content[0].ToString();
                        TextBox1.Text = content[1].ToString();
                        TextBox2.Text = content[2].ToString();
                        break;
                    }
                }
                DropDownList1.DataSource = umg.getalluser();
                DropDownList1.DataTextField = "TrueName";
                DropDownList1.DataValueField = "UserName";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("---不转发---", ""));
                DropDownList2.DataSource = BuildManager1.GetAllBuild();
                DropDownList2.DataTextField = "DongName";
                DropDownList2.DataValueField = "DongID";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("---请选择---", ""));

            }
        }
        //this.form1.Attributes.Add("onload", dip());
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
            //Response.Write("<script>window.parent.close()</script>");
        }
        else
        {
            if (Unclassified_FaultManager1.CheckIsDoing(Convert.ToInt32(Request.QueryString["id"])))
            {
                RegisterClientScriptBlock("提示", "<script>alert('由于你的动作慢，本故障已被其它用户分好类了');window.location='NewsestBreakdown.aspx'</script>");
            }
            else
            {
                string DoLiuCheng;
                string FuZeRen = "";
                if (DropDownList1.SelectedItem.Value.ToString().Trim() != "")
                {
                    DoLiuCheng = umg.Getuser(Session["username"].ToString().Trim()).TrueName + "--->" + DropDownList1.SelectedItem.Text.ToString().Trim();
                    FuZeRen = DropDownList1.SelectedValue.ToString();
                }
                else
                {
                    DoLiuCheng = umg.Getuser(Session["username"].ToString().Trim()).TrueName;
                    FuZeRen = Session["username"].ToString();
                }
                int id = Convert.ToInt32(Request.QueryString["id"]);
                string GuZhangContent = TextBox1.Text.ToString().Trim();
                string Address = TextBox2.Text.ToString().Trim();

                int DongID = Convert.ToInt32(DropDownList2.SelectedValue.ToString());
                //string DoLiuCheng = Session["username"].ToString();
                bool IsDo = false;
                bool isdel = false;
                string BeiZhu = TextBox3.Text.ToString().Trim();
                string name = TextBox4.Text.ToString().Trim();
                string phone = TextBox5.Text.ToString().Trim();
                int GuZhangSecondID = id;
                string reciver = Session["username"].ToString();
                //string menth=
                SecondFaultManager1.Add(GuZhangContent, name, phone, Address, FuZeRen, DongID, DoLiuCheng, IsDo, BeiZhu, isdel, GuZhangSecondID, reciver, Convert.ToDateTime(dt), menth);
                Unclassified_FaultManager1.SetFaultHaveclassification(Convert.ToInt32(Request.QueryString["id"]),true);
                Unclassified_FaultManager1.SetFaultHaveClassiced(Convert.ToInt32(Request.QueryString["id"]));
                RegisterClientScriptBlock("提示", "<script>alert('分类成功！');window.location='NewsestBreakdown.aspx';</script>");
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.location='NewsestBreakdown.aspx'</script>");
    }
}
