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
    public static string a = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            GuZhangFirst GuZhangFirst1 = new GuZhangFirst();
            GuZhangFirst1 = Unclassified_FaultManager1.GetGuZhangFirstbyid(id);
            a = GuZhangFirst1.MessageContent;
            string[] content = GuZhangFirst1.MessageContent.Split('/');
            if (content.Length == 3)
            {
                TextBox1.Text = content[0].ToString();
                TextBox2.Text = GuZhangFirst1.PhoneNumber.ToString();
                TextBox4.Text = content[1].ToString();
                TextBox3.Text = content[2].ToString();
            }
            this.DropDownList1.DataSource=umg.getalluser();
            this.DropDownList1.DataTextField="TrueName";
            this.DropDownList1.DataValueField="UserName";
            this.DropDownList1.DataBind();
        }
        //this.form1.Attributes.Add("onload", dip());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
