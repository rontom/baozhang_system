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

public partial class admin_TelBreakdown : System.Web.UI.Page
{
    CommonguzhangManager cgm = new CommonguzhangManager();
    BuildManager bmg = new BuildManager();
    roommanage rmg = new roommanage();
    UsersManage umg = new UsersManage();
    SecondFaultManager sfm = new SecondFaultManager();
    Unclassified_FaultManager ufm = new Unclassified_FaultManager();
    private static int flag = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {

            if (!IsPostBack)
            {
                //this.form1.Attributes.Add("onload", "GetAllbuild()");
                //this.builddrop.Attributes.Add("onchange", "Builddropchange()");
                //this.roomdrop.Attributes.Add("onchange", "Roomdropchange()");
                this.commonfaultdrop.Attributes.Add("onchange", "showcustomfault()");
                this.customfaultinput.Attributes.Add("onclick", "clearcustomfault()");
                this.userdrop.Attributes.Add("onchange", "showforwarddescript()");
                this.CheckBox1.Attributes.Add("onclick", "showdoresult()");
                BindCommonFault();
                BindBuild();
                BindUser();
                BindTelFaultByYouself();
            }
        }
    }



    private void BindTelFaultByYouself()
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            telfalutgrid.DataSource = sfm.GetAllSecondFaultByTel(flag, AspNetPager1, Session["username"].ToString(), "电话");
            telfalutgrid.DataBind();
        }
    }
    private void BindCommonFault()
    {
        commonfaultdrop.DataSource = cgm.GetAllcommonFault();
        
        commonfaultdrop.DataTextField = "guzhangcontent";
        commonfaultdrop.DataValueField = "id";
        commonfaultdrop.DataBind();
        commonfaultdrop.Items.Add(new ListItem("自定义", "自定义"));
    }


    private void BindBuild()
    {
        //builddrop.DataSource = bmg.GetAllBuild();
        //builddrop.DataTextField = "DongName";
        //builddrop.DataValueField = "DongID";
        //builddrop.DataBind();
        faultare.DataSource = bmg.GetAllBuild();
        faultare.DataTextField = "DongName";
        faultare.DataValueField = "DongID";
        faultare.DataBind();
        //builddrop.Items.Add(new ListItem("自定义", ""));
        //builddrop.Items.Insert(0, new ListItem("---选择---", "---选择---"));
    }


    private void BindUser()
    {
        userdrop.DataSource = umg.getalluser();
        userdrop.DataTextField = "TrueName";
        userdrop.DataValueField = "UserName";
        userdrop.DataBind();
        userdrop.Items.Insert(0, new ListItem("--不转发--", ""));
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            //if ((bool)Session["IsSubmit"] == false)
            //{
                string username = nameinput.Text.ToString().Trim();
                string phone = phoneinput.Text.ToString().Trim();
                string commfault = "";
                if (commonfaultdrop.SelectedValue.ToString().Trim() == "自定义")
                {
                    commfault = customfaultinput.Text.ToString().Trim();
                }
                else
                {
                    commfault = commonfaultdrop.SelectedItem.Text.ToString().Trim();
                }
                string address = addressimput.Text.ToString().Trim();
                string fuze = "";
                string doliu = "";
                string forward_description ="";
                string result_descript ="";
                DateTime dodt = new DateTime();
                if (userdrop.SelectedValue.ToString().Trim() == "")
                {
                    fuze = Session["username"].ToString().Trim();
                    doliu = umg.Getuser(Session["username"].ToString().Trim()).TrueName;
                }
                else
                {
                    fuze = userdrop.SelectedValue.ToString().Trim();
                    doliu = umg.Getuser(Session["username"].ToString().Trim()).TrueName + "--->" + userdrop.SelectedItem.Text.ToString().Trim();
                    forward_description = forwarddescipt.Text.ToString().Trim();
                }
                bool isdo = false;
                string dopeople = umg.Getuser(Session["username"].ToString().Trim()).TrueName;
                if (CheckBox1.Checked)
                {
                    result_descript = forwarddescipt.Text.ToString().Trim();
                    dodt = DateTime.Now;
                    isdo = true;
                }
                int dongid = 0;
                if (guzhangarea.Text.ToString().Trim() != "")
                {
                    dongid = Convert.ToInt32(guzhangarea.Text.ToString().Trim());
                }
              
                string beizhu ="";
                
            
                bool isdel = false;
                try
                {
                    if (isdo)
                    {
                        sfm.Add(commfault, username, phone, address, fuze, dongid, doliu, isdo, beizhu, isdel, Session["username"].ToString(), DateTime.Now, "电话", result_descript, forward_description, dodt,dopeople);
                    }
                    else
                    {
                        sfm.Add(commfault, username, phone, address, fuze, dongid, doliu, isdo, beizhu, isdel, Session["username"].ToString(), DateTime.Now, "电话", result_descript, forward_description);
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('记录已经成功添加')</script>");
                    nameinput.Text = "";
                    phoneinput.Text = "";
                    commonfaultdrop.SelectedIndex = 0;
                    customfaultinput.Text = "";
                    addressimput.Text = "";
                    //beizhiinput.Text = "";
                    userdrop.SelectedIndex = 0;
                    faultare.SelectedIndex = 0;
                    TabWebControl1.SelectedTabIndex = 1;
                    BindTelFaultByYouself();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

       
       
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        flag = 1;
        BindTelFaultByYouself();
        TabWebControl1.SelectedTabIndex = 1;
    }
}
