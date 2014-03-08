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
using BLL;

public partial class loginbyclient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Request.QueryString["username"].ToString().Trim();
        UsersManage UsersManage1 = new UsersManage();
        string LastLoginIP = "";
        //if (HttpContext.Current.Request.UserHostAddress != null)
        //{
        //    LastLoginIP = HttpContext.Current.Request.UserHostAddress;
        //}
        //else
        //{
        //    LastLoginIP = "";
        //}


        //Response.Write(LastLoginIP);
        if (UsersManage1.CheckUserIsOnline(username))
        {
            Session["username"] = username;
            Response.Redirect("admin/index.aspx");
        }
        else
        {
            Response.Write("<script>alert('非法用户，本页即将关闭');window.close();</script>");

        }
        //string user_IP = "";
        //string ip = Page.Request.UserHostAddress.ToString().Trim();
        ////if (context.Request.ServerVariables["HTTP_VIA"] != null) //判定是否有代理 
        ////{
        ////    user_IP = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        ////}
        ////else
        ////{
        ////    user_IP = context.Request.ServerVariables["REMOTE_ADDR"].ToString();
        ////} 

        //string username = Request.QueryString["username"].ToString().Trim();
        //SqlConnection conn = DBHelper.getConnection();

        //SqlCommand cmd = new SqlCommand("usp_CheckUserOnline", conn);
        //cmd.CommandType = CommandType.StoredProcedure;
        //SqlParameter username1 = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
        //SqlParameter ipaddress = cmd.Parameters.Add("@IPAddress", SqlDbType.VarChar, 50);
        //SqlParameter result = cmd.Parameters.Add("@ReturnBit", SqlDbType.Bit, 2);
        //username1.Direction = ParameterDirection.Input;
        //ipaddress.Direction = ParameterDirection.Input;
        //result.Direction = ParameterDirection.Output;
        //username1.Value = username;
        //ipaddress.Value = ip;
        //conn.Open();
        //try
        //{
            
        //    cmd.ExecuteNonQuery();
        //    Response.Write(result.Value.ToString());
        //    Response.Write(username);
        //    Response.Write(ip);
        //    //if (Convert.ToBoolean(result.Value))
        //    //{
        //    //    Response.Redirect("admin/main.aspx");
        //    //}
        //    //else
        //    //{
        //    //    Response.Write("<script>alert('非法用户，本页即将关闭');window.close();</script>");
        //    //}
        //    //conn.Close();
        //}
        //catch (Exception ex)
        //{
        //    conn.Close();
        //    throw ex;
            
        //}
       
    }
   
}
