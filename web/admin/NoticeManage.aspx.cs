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
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Text;

public partial class admin_NoticeManage : System.Web.UI.Page
{
    private UsersManage UsersManage1 = new UsersManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        //this.SMSContent.Attributes.Add("onpropertychange", "checklen(this)");
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
                SystemlogManager.Addnewslog(Session["username"].ToString());
                if (!IsPostBack)
                {
                    BindConf();
                    BindPhonebook();
                }
            }
        }
    }

    private void BindUser()
    {
        UsersManage umg = new UsersManage();
        CheckBoxList1.DataSource = umg.getalluser();
        CheckBoxList1.DataTextField = "TrueName";
        CheckBoxList1.DataValueField = "UserName";
        CheckBoxList1.DataBind();

    }


    private void BindPhonebook()
    {
        PhoneBookManager pbm=new PhoneBookManager();
        phonebooklist.DataSource = pbm.GetPhoneBook();
        phonebooklist.DataTextField = "telbook";
        phonebooklist.DataValueField = "id";
        phonebooklist.DataBind();
        ListItem li = new ListItem();
        li.Value = "";
        li.Text = "自定义";
        phonebooklist.Items.Add(li);
    }

    private void BindConf()
    {
        SMSConfigManager ssm = new SMSConfigManager();
        SendSMS sms = new SendSMS();
        sms = ssm.GetSMSconfig(Server.MapPath("../xml/SendSMS.xml"));
        serverip.Text = sms.Ip;
        port.Text = sms.Port;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SMSConfigManager ssm = new SMSConfigManager();
        try
        {
            ssm.ModiftySMSConf(Server.MapPath("../xml/SendSMS.xml"), serverip.Text.ToString(), port.Text.ToString());
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功')</script>");
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
            UsersManage umg = new UsersManage();
            int sucess = 0;
            int faild = 0;
            SMS sms = new SMS();
            SendSMS ssm = GetSMSConf();
            sms.Number = "";
            string recivers = "";
            string recivername = "";
            if (phonebooklist.SelectedValue.ToString() != "")
            {
                DataTable dt = umg.getalluser(Convert.ToInt32(phonebooklist.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count == 1)
                    {
                        sms.Number = dt.Rows[0]["phone"].ToString();
                        recivers = dt.Rows[0]["TrueName"].ToString().Trim();
                        recivername += dt.Rows[0]["UserName"].ToString().Trim();
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            sms.Number += dt.Rows[i]["phone"].ToString().Trim() + "|";
                            recivers += dt.Rows[i]["TrueName"].ToString().Trim() + "、";
                            recivername += dt.Rows[i]["UserName"].ToString().Trim() + "+";
                        }
                    }
                }

            }
            else
            {
                if (CheckBoxList1.Items.Count == 1)
                {
                    sms.Number = umg.Getuser(CheckBoxList1.Items[0].Value.ToString().Trim()).Phone;
                }
                else
                {
                    for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                    {

                        if (CheckBoxList1.Items[i].Selected)
                        {
                            sms.Number += umg.Getuser(CheckBoxList1.Items[i].Value.ToString().Trim()).Phone + "|";
                            recivers += CheckBoxList1.Items[i].Text.ToString().Trim() + "、";
                            recivername += CheckBoxList1.Items[i].Value.ToString().Trim() + "+";
                        }
                    }
                }
            }
            if (sms.Number.ToString().Trim() != "")
            {
                sms.Scon = SMSContent.Text.ToString();
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint Ipe = new IPEndPoint(IPAddress.Parse(ssm.Ip), int.Parse(ssm.Port));
                try
                {
                    socket.Connect(Ipe);
                    if (socket.Connected)
                    {
                        MemoryStream stream = new MemoryStream();
                        IFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(stream, sms);
                        stream.Flush();
                        byte[] smsbyte = stream.ToArray();
                        socket.Send(smsbyte);
                        byte[] reciver = new byte[128];
                        socket.Receive(reciver);
                        string reciverstring = Encoding.Default.GetString(reciver).ToString().Trim();
                        if (Convert.ToBoolean(reciverstring))
                        {
                            sucess++;
                        }
                        else
                        {
                            faild++;
                        }
                    }
                    if (sucess > 0)
                    {

                        NoticesManager nmg = new NoticesManager();
                        nmg.AddNotices("", Session["username"].ToString(), recivers.Substring(0, recivers.Length - 1), SMSContent.Text.ToString(), DateTime.Now, "短信", 0, recivername.Substring(0, recivername.Length - 1));
                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, UpdatePanel2.GetType(), "", "alert('短信接发送成功')", true);
                        SMSContent.Text = "";
                        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                        {
                            CheckBoxList1.Items[i].Selected = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, UpdatePanel2.GetType(), "", "alert('短信接收者为空')", true);
            }
        }
       
        

    }


    private SendSMS GetSMSConf()
    {
        SMSConfigManager ssm = new SMSConfigManager();
        return ssm.GetSMSconfig(Server.MapPath("../xml/SendSMS.xml"));
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (UserType.SelectedValue.ToString().Trim() == "")
        {
            usertypelist.Visible = false;
        }
        else
        {
            UsersManage umg=new UsersManage();
            usertypelist.Visible = true;
            NoticeObj.DataSource = umg.GetAllUserByType( UserType.SelectedValue.ToString().Trim());
            NoticeObj.DataTextField = "TrueName";
            NoticeObj.DataValueField = "UserName";
            NoticeObj.DataBind();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string reciver="";
        string recivername="";
        if (Session["username"] == null)
        {
            Function.CheckIstimeout();
        }
        else
        {
            for(int i=0;i<NoticeObj.Items.Count;i++)
            {
                if(NoticeObj.Items[i].Selected)
                {
                    reciver+=NoticeObj.Items[i].Text.ToString().Trim()+"、";
                    recivername+=NoticeObj.Items[i].Value.ToString().Trim()+"+";
                }
            }
            try
            {
                NoticesManager nmg = new NoticesManager();
                nmg.AddNotices(NoticeTitle.Text.ToString().Trim(), Session["username"].ToString(), reciver.Substring(0, reciver.Length - 1), NoticeContent.Text.ToString().Trim(), DateTime.Now, "网络", Convert.ToInt32(Validity.Text.ToString().Trim()), recivername.Substring(0, recivername.Length - 1));
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, UpdatePanel1.GetType(), "", "alert('通知发布成功')", true);
                NoticeTitle.Text = "";
                NoticeContent.Text = "";
                UserType.SelectedIndex = 0;
                for (int i = 0; i < NoticeObj.Items.Count; i++)
                {
                    NoticeObj.Items[i].Selected = false;
                }
                Validity.Text = "";
                usertypelist.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
    protected void phonebooklist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (phonebooklist.SelectedValue == "")
        {
            BindUser();
            Customizeuser.Visible = true;
        }
        else
        {
            Customizeuser.Visible = false;
        }
    }
}
