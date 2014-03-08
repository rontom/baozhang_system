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

public partial class admin_yanzheng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //输出验证码
        //string num = ValidateNumber.CreateValidateNumber(4);

        ////将验证码中的数字存入session
        //Session["rand"] = num;
        //ValidateNumber.CreateValidateGraphic(this, num);

        
    }
}
