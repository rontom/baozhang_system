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

public partial class dataimport_dataimport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 1; i <= Convert.ToInt32(TextBox1.Text.ToString()); i++)
        {
            for (int j = 1; j <= Convert.ToInt32(TextBox2.Text.ToString()); j++)
            {
                string roomname;
                if (j < 10)
                {
                    roomname = i.ToString() + "0" + j.ToString();
                }
                else
                {
                    roomname = i.ToString() + j.ToString();
                }

                roommanage rmg = new roommanage();
                rmg.AddRoom(roomname, 27, "");
            }
        }
    }
}
