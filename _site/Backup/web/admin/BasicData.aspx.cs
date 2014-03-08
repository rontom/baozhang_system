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
using System.Text;

public partial class admin_BasicData : System.Web.UI.Page
{
    UsersManage UsersManage1 = new UsersManage();
    BuildManager BuildManager1 = new BuildManager();
    roommanage rmg = new roommanage();
    queuemanager qmg = new queuemanager();
    CommonguzhangManager cmg = new CommonguzhangManager();
    private static int flag ;
    private static int flag1;
    private static int flagroom ;
    private static int flagcommonfault;
    private static string BuildAction = "";
    private static int Buildid;
    private static int ModiftyQueueid;
    private static int ModiftyPhonebookid;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.DropDownList2.Attributes.Add("onchange", "showdis()");
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
                flag = 0;
                flag1 = 0;
                flagcommonfault = 0;
                flagroom = 0;
                SystemlogManager.Addnewslog(Session["username"].ToString());
                if (!IsPostBack)
                {
                    //flag = 0;
                    Bind();
                    Bind2();
                    GetAllBuild();
                    BindPrintQueue();
                    BindCommonFault();
                    BindAllUser();
                    BindPhoneBook();
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string Username=TextBox1.Text.ToString().Trim();
        string password=Function.PasswordMD5(TextBox2.Text.ToString().Trim());
        string Truename=TextBox4.Text.ToString().Trim();
        string sex=DropDownList1.SelectedItem.ToString().Trim();
        string usertype=DropDownList2.SelectedValue.ToString().Trim();
        string yuanxi="";
        string zhuanye="";
        string phone = TextBox5.Text.ToString().Trim();
        string beizhu = TextBox9.Text.ToString().Trim();
        DateTime dt = DateTime.Now;
        if (DropDownList2.SelectedValue.ToString() == "学生")
        {
            yuanxi = TextBox7.Text.ToString().Trim();
            zhuanye = TextBox8.Text.ToString().Trim();
        }
        try
        {
            UsersManage1.Addusers(Username, password, dt, Truename, sex, usertype, yuanxi, zhuanye, phone, beizhu);
            ClientScript.RegisterStartupScript(this.GetType(),"提示", "<script>alert('用户添加成功，谢谢使用！')</script>");
            add.Visible = false;
            list.Visible = true;
            Bind();
        }
        catch
        {
            Console.Write("页面出错");
        }
    }


    private void Bind()
    {
        GridView1.DataSource=UsersManage1.Getalluserbyprcedure(flag,AspNetPager1);
        GridView1.DataBind();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        flag = 1;
        Bind();
        //TabWebControl1.SelectedTabIndex = 0;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //鼠标移动到每项时颜色交替效果   
            e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor='White';this.style.color='#003399'");
            e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor='#6699FF';this.style.color='#8C4510'");
        }   

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        this.list.Visible = false;
        this.add.Visible = true;
    }
    //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (DropDownList2.SelectedValue.ToString() == "学生")
    //    {
    //        this.DIV2.Visible = true;
    //    }
    //}
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string username = ((LinkButton)sender).CommandArgument.ToString();
        try
        {
            UsersManage1.DelUser(username);
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('已成功删除选中的用户')</script>");
            flag = 0;
            Bind();
        }
        catch
        {
            Console.Write("操作异常！");
        }
    }

    /// <summary>
    /// 修改按钮，隐藏list层，显示modifty层，绑定用户数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string username = ((LinkButton)sender).CommandArgument.ToString();
        list.Visible = false;
        modifty.Visible = true;
        BindOldbyusername(username);
    }


    /// <summary>
    /// 修改页面前绑定数据
    /// </summary>
    /// <param name="username"></param>
    private void BindOldbyusername(string username)
    {
        Users u = UsersManage1.Getuser(username);
        TextBox6.Text = u.UserName;
        TextBox12.Text = u.TrueName;
        DropDownList3.SelectedValue = u.Sex;
        if (u.UserType == "学生")
        {
            Div3.Visible = true;
            TextBox13.Text = u.Yuanxi;
            TextBox14.Text = u.Zhuanye;
            DropDownList4.SelectedValue = u.UserType;
        }
        DropDownList4.SelectedValue = u.UserType;
        TextBox15.Text = u.Phone;
        TextBox16.Text = u.Beizhu;
        
    }


    protected void Button4_Click(object sender, EventArgs e)
    {
        this.modifty.Visible = false;
        this.list.Visible = true;
        Bind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string username = TextBox6.Text.ToString().Trim();
        string truename = TextBox12.Text.ToString().Trim();
        string sex = DropDownList3.SelectedValue.ToString().Trim();
        string usertype = DropDownList4.SelectedValue.ToString().Trim();
        string yuanxi="";
        string zhuanye="";
        if (DropDownList4.SelectedValue.ToString().Trim() == "学生")
        {
            yuanxi = TextBox13.Text.ToString().Trim();
            zhuanye = TextBox14.Text.ToString().Trim();
        }
        string phone = TextBox15.Text.ToString().Trim();
        string beizhu = TextBox16.Text.ToString().Trim();
        try
        {
            UsersManage1.UpdateUser(username, truename, sex, usertype, yuanxi, zhuanye, phone, beizhu);
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('用户信息已成功修改！')</script>");
            this.modifty.Visible = false;
            this.list.Visible = true;
            Bind();

        }
        catch
        {
            Console.Write("操作出错");
        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        string username=((LinkButton)sender).CommandArgument.ToString();
        Response.Redirect("ModiftyUserpassword.aspx?username=" + username);
    }

    //protected void TabPage3_Load(object sender, EventArgs e)
    //{
    //    if (!IsPostBack)
    //    {
    //        Bind2();
    //    }
    //}

    private void Bind2()
    {
        GridView2.DataSource = BuildManager1.GetBuild(flag1, AspNetPager2);
        GridView2.DataBind();
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        //Response.Redirect("AddBuild.aspx");
        BuildAction = "Add";
        list1.Visible = false;
        op.Visible = false;
        add1.Visible = true;
        TabWebControl1.SelectedTabIndex = 1;
        Button5.Text = "添加";
        
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        flag1 = 0;
        if (BuildAction == "Add")
        {
            BuildManager1.add(Buildname.Text.ToString().Trim(), anothername.Text.ToString().Trim());
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('添加成功');</script>");
            //TabWebControl1;

            //Response.Redirect("BasicData.aspx");

            TabWebControl1.SelectedTabIndex = 1;
            op.Visible = true;
            list1.Visible = true;
            add1.Visible = false;
            Bind2();
            Buildname.Text = "";
            anothername.Text = "";
        }
        else if(BuildAction=="Modifty")
        {
            BuildManager1.Update(Buildname.Text.ToString().Trim(), anothername.Text.ToString().Trim(), Buildid);
            //Response.Write();
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('修改成功！');</script>");
            Bind2();
            op.Visible = true;
            list1.Visible = true;
            add1.Visible = false;
            TabWebControl1.SelectedTabIndex = 1;
        }
        

    }

    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        flag1 = 1;
        Bind2();
        TabWebControl1.SelectedTabIndex = 1;
    }

    private void BindOldBuild(int id)
    {
        Dong d = BuildManager1.GetAbuild(id);
        Buildname.Text = d.DongName;
        anothername.Text = d.Anothername;
        
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        op.Visible = false;
        list1.Visible = false;
        add1.Visible = true;
        BuildAction = "Modifty";
        TabWebControl1.SelectedTabIndex = 1;
        Button5.Text = "修改";
        Buildid = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());
        BindOldBuild(Buildid);
        
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        //TabWebControl1.SelectedTabIndex = 1;
        op.Visible = true;
        list1.Visible = true;
        add1.Visible = false;
        TabWebControl1.SelectedTabIndex = 1;
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        int id = int.Parse(((LinkButton)sender).CommandArgument.ToString());
        try
        {
            BuildManager1.Del(id);
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('删除成功')</script>");
            flag1 = 0;
            Bind2();
            TabWebControl1.SelectedTabIndex = 1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.add.Visible = false;
        this.list.Visible = true;
        Bind();
    }

    private void GetAllBuild()
    {
        DropDownList5.DataSource = BuildManager1.GetAllBuild();
        DropDownList5.DataTextField = "DongName";
        DropDownList5.DataValueField = "DongID";
        DropDownList5.DataBind();
        DropDownList5.Items.Insert(0, new ListItem("====请选择楼房====", ""));
    }


    /// <summary>
    /// 获取房间
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindRoom();
        TabWebControl1.SelectedTabIndex = 2;

    }

    private void BindRoom()
    {
        int buildid = int.Parse(DropDownList5.SelectedValue.ToString());
        roomlist.DataSource = rmg.GetAllRoomByBuildid(flagroom, AspNetPager3, buildid);
        roomlist.DataBind();
    }

    protected void AspNetPager3_PageChanged(object sender, EventArgs e)
    {
        flagroom = 1;
        BindRoom();
        TabWebControl1.SelectedTabIndex = 2;

    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        if (DropDownList5.SelectedValue.ToString().Trim() != "")
        {
            rmg.AddRoom(roomid.Text.ToString(), int.Parse(DropDownList5.SelectedValue.ToString().Trim()), roomintro.Text.ToString().Trim());
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('添加成功')</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script> $('#listroom').css('display','block');</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script> $('#addroom').css('display','none');</script>");
            
            roomid.Text = "";
            roomintro.Text = "";
            //addroom.Visible = false;
            //listroom.Visible = true;
            flagroom = 0;
            BindRoom();
            TabWebControl1.SelectedTabIndex = 2;
        }
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        int roomid1=Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());
        rmg.DelRoom(roomid1);
        ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('删除成功')</script>");
        flagroom = 0;
        BindRoom();
        TabWebControl1.SelectedTabIndex = 2;
    }

    private void BindPrintQueue()
    {
        queueinfo.DataSource = qmg.GetAllQueue();
        queueinfo.DataBind();
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        if (Button11.Text == "确认")
        {
            string printqueuename = printqueue.Text.ToString().Trim();
            DateTime dt = DateTime.Now;
            string usernames = hiddenstring.Text.ToString().Trim().Substring(0, hiddenstring.Text.ToString().Trim().Length - 1);
            //Response.Write(usernames);
            qmg.AddPrintQueue(printqueuename, dt, usernames);
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('添加成功')</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>showqueuelist();</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "DelAll()");
            BindPrintQueue();
            TabWebControl1.SelectedTabIndex = 3;
        }
        else
        {
            qmg.UpdatePrintqueue(ModiftyQueueid, printqueue.Text.ToString().Trim(), hiddenstring.Text.ToString().Trim().Substring(0, hiddenstring.Text.ToString().Trim().Length - 1));
            //qmg.AddPrintQueue(printqueuename, dt, usernames);
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('修改成功')</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>showqueuelist();</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>DelAll()</script>");
            Button11.Text = "确认";
            BindPrintQueue();
            BindAllUser();
            TabWebControl1.SelectedTabIndex = 3;
        }
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        int printid = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());
        qmg.DelPrintQueue(printid);
        ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('删除成功')</script>");
        BindPrintQueue();
        TabWebControl1.SelectedTabIndex = 3;
    }


    private void AddCommonFault()
    {
        try
        {
            cmg.Add(commonfaultinput.Text.ToString().Trim());
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功');$('#commonfaulyadd').css('display';'none');$('#commonfaulylist').css('display';'block');</script>");
            flagcommonfault = 0;
            BindCommonFault();
            TabWebControl1.SelectedTabIndex = 4;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    protected void Button14_Click(object sender, EventArgs e)
    {
        AddCommonFault();
    }


    private void BindCommonFault()
    {
        commonfaultgrd.DataSource = cmg.GetAllcommonFault(flagcommonfault, AspNetPager4);
        commonfaultgrd.DataBind();
    }
    protected void AspNetPager4_PageChanged(object sender, EventArgs e)
    {
        flagcommonfault = 1;
        BindCommonFault();
        TabWebControl1.SelectedTabIndex = 4;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        int commomfaultid = Convert.ToInt32(((ImageButton)sender).CommandArgument.ToString());
        try
        {
            cmg.Del(commomfaultid);
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功')</script>");
            flagcommonfault = 0;
            BindCommonFault();
            TabWebControl1.SelectedTabIndex = 4;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    private void BindAllUser()
    {
        listall.DataSource = UsersManage1.getalluser();
        listall.DataTextField = "TrueName";
        listall.DataValueField = "UserName";
        listall.DataBind();
        ListBox1.DataSource = UsersManage1.getalluser();
        ListBox1.DataTextField = "TrueName";
        ListBox1.DataValueField = "UserName";
        ListBox1.DataBind();
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        TabWebControl1.SelectedTabIndex = 3;
        ClientScript.RegisterStartupScript(this.GetType(),"","<script>$('#addqueue').css('display','block');$('#listqueue').css('display','none');</script>");
        int queueid = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());
        ModiftyQueueid = queueid;
        BindLeftUser(queueid);
        printqueue.Text = qmg.GetAPrintQueue(queueid).Queuename.ToString();
        BindRightUser(queueid);
        BindHiddenString();
        Button11.Text = "修改";
    }




    /// <summary>
    /// 在修改打印队列是绑定左边的listbox
    /// </summary>
    private void BindLeftUser(int queueid)
    {
        listall.DataSource = UsersManage1.UsersNotinQueue(queueid);
        listall.DataTextField = "TrueName";
        listall.DataValueField = "UserName";
        listall.DataBind();
    }


    /// <summary>
    /// 绑定某个队列中已分配的人
    /// </summary>
    /// <param name="queueid"></param>
    private void BindRightUser(int queueid)
    {
        listtarget.DataSource = UsersManage1.UsersInQueue(queueid);
        listtarget.DataTextField = "TrueName";
        listtarget.DataValueField = "UserName";
        listtarget.DataBind();
    }

    private void BindHiddenString()
    {
        string hiddestr="";
        for (int i = 0; i < listtarget.Items.Count; i++)
        {
            hiddestr = listtarget.Items[i].Value + "+";
        }
        hiddenstring.Text = hiddestr;
    }


    private void BindHiddenStringInPhoneBook()
    {
        string hiddenstr = "";
        for (int i = 0; i < ListBox2.Items.Count; i++)
        {
            hiddenstr = ListBox2.Items[i].Value + "+";
        }
        TextBox11.Text = hiddenstr;
    }


    protected void Button12_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>showqueuelist();</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>DelAll()</script>");
        Button11.Text = "确认";
        BindAllUser();
        TabWebControl1.SelectedTabIndex = 3;
    }
    protected void Button19_Click(object sender, EventArgs e)
    {
        PhoneBookManager pbm = new PhoneBookManager();
        if (Button19.Text == "确认分组")
        {
            string phonebookname = phonebooknameinput.Text.ToString().Trim();
            string usernames = TextBox11.Text.ToString().Trim().Substring(0, TextBox11.Text.ToString().Trim().Length - 1);
            try
            {
                pbm.Add(phonebookname, usernames);
                ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('添加成功')</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>disaddtelephoebook();</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>DelAllselectusers()</script>");
                BindPhoneBook();
                TabWebControl1.SelectedTabIndex = 5;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        else
        {
            pbm.UpdatePhoneBook(ModiftyPhonebookid, phonebooknameinput.Text.ToString().Trim(), TextBox11.Text.ToString().Substring(0, TextBox11.Text.ToString().Length - 1));
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('修改成功')</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>disaddtelephoebook();</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>DelAllselectusers();</script>");
            Button19.Text = "确认分组";
            BindPhoneBook();
            BindAllUser();
            TabWebControl1.SelectedTabIndex = 5;
        }
    }


    private void BindPhoneBook()
    {
        PhoneBookManager pbm=new PhoneBookManager();
        DataTable dt = pbm.GetPhoneBook();
        GridView3.DataSource = dt;
        GridView3.DataBind();
        
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();

        }
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        PhoneBookManager pbm = new PhoneBookManager();
        TabWebControl1.SelectedTabIndex = 5;
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$('#addtelephonebook').css('display','block');$('#listtelephonebook').css('display','none');</script>");
        int phonebookid = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());
        ModiftyPhonebookid = phonebookid;
        BindLeftUserInphonebook(phonebookid);
         phonebooknameinput.Text = pbm.GetAphoneBook(phonebookid).Telbook;
        BindRightUserInPhoneBook(phonebookid);
        BindHiddenStringInPhoneBook();
        Button19.Text = "修改分组";
    }



    /// <summary>
    /// 在修改某个电话簿组的时候绑定这个组中未加入的用户
    /// </summary>
    /// <param name="phonebookid">电话簿编号</param>
    private void BindLeftUserInphonebook(int phonebookid)
    {
        ListBox1.DataSource = UsersManage1.UsersNotInPhoneBook(phonebookid);
        ListBox1.DataTextField = "TrueName";
        ListBox1.DataValueField = "UserName";
        ListBox1.DataBind();
    }

    private void BindRightUserInPhoneBook(int phonebookid)
    {
        ListBox2.DataSource = UsersManage1.UsersInPhoneBook(phonebookid);
        ListBox2.DataTextField = "TrueName";
        ListBox2.DataValueField = "UserName";
        ListBox2.DataBind();
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {

    }
   
}
