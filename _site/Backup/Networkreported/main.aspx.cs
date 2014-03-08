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

public partial class main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Function.loginimeout();
        }
        else
        {
            username.Text = Session["username"].ToString();
            BindUser();
        }
    }


    /// <summary>
    /// 绑定用户信息
    /// </summary>
    /// <param name="username"></param>
    private void BindUser()
    {
        UserParamManager upmg=new UserParamManager();
        userparam up = upmg.GetUser(Session["username"].ToString());
        realname.Text = up.Truename;
        telephone.Text = up.Phone;
        mobile.Text = up.Mobile;
        address.Text = up.Address;
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Unclassified_FaultManager ufmg = new Unclassified_FaultManager();
        string content = realname.Text.ToString().Trim() + "/" + gucontent.Text.ToString().Trim() + "/" + address.Text.ToString().Trim();
        DateTime dt = DateTime.Now;
        string telephone1 = telephone.Text.ToString().Trim();
        string mobile1 = mobile.Text.ToString().Trim();
        try
        {
            ufmg.Addnewfault(content, dt.ToString(), mobile1, telephone1);
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('报障成功,我们会尽快过来处理，谢谢使用！');window.close();</script>");
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}
