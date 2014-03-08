<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <style type="text/css">
    body 
{
	padding:0px;
	margin:0px;
	font-size:12px;
}
.content
{
	width:100%;
	height:auto;
	margin-top:0px;
}
.bg
{
	width: 1002px;
	height: 600px;
	margin-top:0px;
	margin-left:auto;
	margin-right:auto;
}
.inf
{
	margin-top:260px;
	margin-left:250px;
	margin-right:auto;
	width:380px;
	height:190px;
	border:0px solid black;
	float:left;
}
.username
{
	width:100%;
	height:30px;
	margin-top:30px;
}
.title
{
	width: 60px;
	text-align: left;
	margin-left: 80px;
	height: 100%;
	vertical-align: bottom;
	line-height:2em;
}
.inp
{
	margin-left:150px;
	width:120px;
	text-align:left;
}
.username1 { width:130px; background:#FFFFFF url("/article/upimages/ico_username.gif") 2px 2px no-repeat; padding-left:18px;BORDER-RIGHT: #E7AD01 1px solid; BORDER-TOP: #E7AD01 1px solid; FONT-SIZE: 13px; BORDER-LEFT: #E7AD01 1px solid; COLOR: #000000; BORDER-BOTTOM: #E7AD01 1px solid; HEIGHT: 20px }

.buttontex
{
	letter-spacing:10px;
	padding-top:5px;
}
    </style>
    <script src="js/JScript.js" type="text/javascript"></script>
</head>
<body onload="checkParent();">
    <form id="form1" runat="server">
    <div class="content" style="margin-left:auto; margin-right:auto;">
    <div class="bg" style="background-image: url(images/c02f_Innovtion_login.jpg);">
    <div class="inf">
        <table style="height:80%; margin-top:200px; width:100%; vertical-align: middle; text-align: right; margin-top:20px;" cellpadding="0" cellspacing="0">
            <tr style="height:15px;">
                <td style="width: 150px; height: 15px;" >
                    用户名：</td>
                <td style="text-align:left; height: 15px;">
                    <asp:TextBox ID="Username" runat="server"></asp:TextBox></td>
            </tr>
            <tr style="height:15px;">
                <td style="width: 150px;">
                    密 &nbsp;&nbsp; 码：</td>
                <td style="text-align:left;">
                    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox></td>

            </tr>
            <tr style="height:15px;">
                <td style="width: 150px;">
                    验证吗：</td>
                <td style="text-align:left; ">
                    <asp:TextBox ID="check" runat="server" Width="72px"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" /></td>
            </tr>
            <tr style="height:15px;">
                <td style="width: 150px; height: 15px;">
                    角 &nbsp;&nbsp; 色：</td>
                <td style="text-align:left; height: 15px;">
                    <asp:DropDownList ID="role" runat="server">
                        <asp:ListItem>管理员</asp:ListItem>
                        <asp:ListItem>学生助理</asp:ListItem>
                        <asp:ListItem>收费用户</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr style="height:20px;">
            <td style="width: 150px;">
                   </td>
                <td  style="text-align:left; height: 20px;">
                    <asp:Button ID="Button1" runat="server" Text="确定" CssClass="buttontex" Width="57px" />&nbsp;&nbsp;&nbsp;
                    &nbsp;<asp:Button ID="Button2" runat="server" Text="重置" CssClass="buttontex" Width="61px" /></td>
            </tr>
        </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>