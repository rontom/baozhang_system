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
using System.Xml;

public partial class admin_ajax : System.Web.UI.Page
{
    private static SecondFaultManager sf = new SecondFaultManager();
    private static UsersManage UsersManage1 = new UsersManage();
    private static roommanage rmg = new roommanage();
    BuildManager bmg = new BuildManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        //string t = Request.QueryString["t"].ToString();
        string t = Request["t"];
        //int secondid = Convert.ToInt32(Request.QueryString["secondid"].ToString().Trim());

        switch (t)
        {
            case "secondfaultinfor":
                GetSecondFaultInfo();
                break;
            case "getAllUser":
                GetAllUseres();
                break;
            case "getsecondfaultinfor":
                GetSecondFaultinfor();
                break;
            case "getroom":
                Getroom();
                break;
            case "getBuild":
                GetBuild();
                break;




        }

        //Getroom();
        //GetBuild();






    }


    public void GetSecondFaultInfo()
    {
        //GuZhangSecond gzs = sf.GetASecondFault(id);
        int id = Convert.ToInt32(Request["aa"].ToString().Trim());
        DataTable dt = sf.GetASecondFault1(id);
        if (dt.Rows.Count > 0)
        {
            Context.Response.ContentType = "text/plain";
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<table style='width:680px; background-color:Gray;' cellpadding='0' cellspacing='1'>");
            Builder.Append("<tr><td style='height: 33px; width:120px; text-align:right; padding-right:10px;'>报障人：</td>");
            Builder.Append("<td style='height: 33px; width:220px; text-align:center;padding-left:3px; padding-right:3px;'>" + dt.Rows[0]["name"].ToString().Trim() + "</td>");
            Builder.Append("<td style='height: 33px; width:120px;text-align:right; padding-right:10px;'>联系电话：</td>");
            Builder.Append("<td style='height: 33px; width:220px; text-align:center; padding-left:3px; padding-right:3px;'>" + dt.Rows[0]["phone"].ToString().Trim() + "</td></tr>");
            Builder.Append("<tr><td style='height: 33px; width:120px; text-align:right; padding-right:10px;'>地址：</td>");
            Builder.Append("<td colspan='3' style='height: 33px; width:220px; text-align:center;padding-left:3px; padding-right:3px;'>" + dt.Rows[0]["Address"].ToString().Trim() + "</td>");
            Builder.Append("</tr>");
            Builder.Append("<tr><td style=' width:120px; padding-top:5px; padding-buttom:5px; text-align:right; padding-right:10px;'>故障内容：</td>");
            Builder.Append("<td colspan='3' style='width:560px; padding-top:10px; padding-bottom:10px; text-align:center;padding-left:3px; padding-right:3px;'>" + dt.Rows[0]["GuZhangContent"].ToString().Trim().Trim() + "</td>");
            Builder.Append("</tr>");
            Builder.Append("<tr><td style='height: 33px; width:120px; text-align:right; padding-right:10px;'>状态：</td>");
            Builder.Append("<td style='height: 33px; width:220px; text-align:center;padding-left:3px; padding-right:3px;'>" + Function.FormatBool(bool.Parse(dt.Rows[0]["IsDo"].ToString().Trim()), "已维护", "未维护") + "</td>");
            Builder.Append("<td style='height: 33px; width:120px;text-align:right; padding-right:10px;'>报障方式：</td>");
            Builder.Append("<td style='height: 33px; width:220px; text-align:center; padding-left:3px; padding-right:3px;'>" + Function.FormatFaultMenth(dt.Rows[0]["menth"].ToString().Trim()) + "</td></tr>");
            Builder.Append("<tr><td style='height: 33px; width:120px; text-align:right; padding-right:10px;'>报障日期：</td>");
            Builder.Append("<td style='height: 33px; width:220px; text-align:center;padding-left:3px; padding-right:3px;'>" + dt.Rows[0]["ReceivedDate"] + "</td>");
            Builder.Append("<td style='height: 33px; width:120px;text-align:right; padding-right:10px;'>负责人：</td>");
            Builder.Append("<td style='height: 33px; width:220px; text-align:center; padding-left:3px; padding-right:3px;'>" + dt.Rows[0]["TrueName"].ToString().Trim().Trim() + "</td></tr>");
            Builder.Append("<tr><td style=' width:120px; text-align:right; padding-right:10px;'>转发流程：</td>");
            Builder.Append("<td colspan='3' style=' width:560px;padding-top:10px; padding-bottom:10px; text-align:center;padding-left:3px; padding-right:3px;'>" + dt.Rows[0]["DoLiuCheng"].ToString().Trim() + "</td>");
            Builder.Append("</tr>");

            Builder.Append("<tr><td style='height: 33px; width:120px; text-align:right; padding-right:10px;'>处理时间：</td>");
            Builder.Append("<td  style='height: 33px; width:560px; text-align:center;padding-left:3px; padding-right:3px;'>" + Function.formateempty(dt.Rows[0]["DoDate"].ToString().Trim(),"未处理") + "</td>");
           
            Builder.Append("<td style=' width:120px;  text-align:right; padding-top:4px; padding-buttom:4px; padding-right:10px;'>处理人：</td>");
            Builder.Append("<td style=' width:560px;padding-top:10px; padding-bottom:10px; text-align:center;padding-left:3px; padding-right:3px;'>" + dt.Rows[0]["dopeoples"].ToString().Trim() + "</td>");
            Builder.Append("</tr>");


            Builder.Append("<tr><td style=' width:120px; text-align:right; padding-top:10px; padding-bottom:10px; padding-right:10px;'>处理结果：</td>");
            Builder.Append("<td colspan='3' style='width:560px;padding-top:10px; padding-bottom:10px; text-align:center;padding-left:3px; padding-right:3px;'>" + Function.formateempty(dt.Rows[0]["result_descript"].ToString().Trim(), "无") + "</td>");
            Builder.Append("</tr>");

            Builder.Append("<tr><td style=' width:120px; text-align:right; padding-top:10px; padding-bottom:10px; padding-right:10px;'>备注：</td>");
            Builder.Append("<td colspan='3' style='width:560px;padding-top:10px; padding-bottom:10px; text-align:center;padding-left:3px; padding-right:3px;'>" + Function.formateempty(dt.Rows[0]["BeiZhu"].ToString().Trim(),"无") + "</td>");
            Builder.Append("</tr>");
            Builder.Append("</tr>");
          
            Builder.Append("</table>");
            //Builder.Append(" <div style='width:90%; margin-left:auto; text-align:center; cursor:hand; margin-right:auto; margin-top:16px;'><img src='../images/return.gif' onclick='javascript:history.go(-2)'/></div>");
            Context.Response.Write(Builder);
            System.Threading.Thread.Sleep(100);
        }



    }

    private void GetAllUseres()
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml("<?xml version=\"1.0\" encoding=\"GB2312\" ?>\n<root/>");
        IList li;
        li = (IList)UsersManage1.getalluser();
        StringBuilder buffer = new StringBuilder();

        buffer.Append("<root>");
        buffer.Append("<item code=\"\" name=\"全部\" />");

        for (int i = 0; i < li.Count; i++)
        {
            Users u = (Users)li[i];

            buffer.AppendFormat("<item code=\"{0}\" name=\"{1}\" />",
             u.TrueName, u.UserName);
        }
        buffer.Append("</root>");

        doc.DocumentElement.InnerXml = buffer.ToString();

        Response.ContentType = "text/xml";
        doc.Save(Response.OutputStream);
        Response.End();
    }

    private void GetSecondFaultinfor()
    {
       // Context.Response.ContentType = "text/plain";
        //string a = Context.Request.Params["secondfaultid"];
        Context.Response.Write("adasdads"); 
    }



    private void Getroom()
    {
        Context.Response.ContentType = "text/xml";
        int buildid = Convert.ToInt32(Request["aa"].ToString().Trim());
        DataTable dt = rmg.GetRoomByBuild(buildid);
        XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
        writer.Formatting = Formatting.Indented;
        writer.Indentation = 4;
        writer.IndentChar =' ';
        writer.WriteStartDocument();
        dt.WriteXml(writer);
        //writer.Flush();
        //Context.Response.Write(writer);
        Response.End();
    }

    private void GetBuild()
    {
        Context.Response.ContentType = "text/xml";
        //int buildid = Convert.ToInt32(Request["aa"].ToString().Trim());
        DataTable dt = bmg.GetAllBuild();
        XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
        writer.Formatting = Formatting.Indented;
        writer.Indentation = 4;
        writer.IndentChar = ' ';
        writer.WriteStartDocument();
        dt.WriteXml(writer);
        //writer.Flush();
        //Context.Response.Write(writer);
        Response.End();
    }
}
