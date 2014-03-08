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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

public partial class admin_Default3 : System.Web.UI.Page
{
    //private static string connstr = "server=222.17.232.216;database=GuZhangMag;uid=sa;pwd=20080912@admin";
    private static SecondFaultManager sfm = new SecondFaultManager();
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
                SystemlogManager.Addnewslog(Session["username"].ToString());
            }
            //SqlConnection con = new SqlConnection(connstr);
            //con.Open();
            //string sql = "select * from GuZhangSecond";
            //SqlDataAdapter da = new SqlDataAdapter(sql, con);
            string faluid = Request.QueryString["a"].ToString();
            DataTable ds = new DataTable();
            ds = sfm.GetprintFault(faluid);
            //SecondFaultManager sfm = new SecondFaultManager();
            //CrystalReportViewer1.ReportSource = sfm.GetAllSeconFaultBynull();
            ReportDocument doc = new ReportDocument();
            doc.Load(Server.MapPath("../CrystalReport/FauluTable.rpt"));
            doc.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = doc;
        }
        //con.Close();
    }
}
