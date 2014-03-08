<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server" >
    <title>无标题页</title>
    <script src="js/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">
    function checkinput()
    {
       if($.trim($("#username").val()))
       {
          alert('用户名必填');
          return false;
       }
        if($.trim($("#password").val()))
       {
          alert('密码必填');
          return false;
       }
    }
    </script>
</head>
<body style="margin:0px; padding:0px; font-size:12px; height:100%;">
    <form id="form1" runat="server">
        <table  style="height:100%; width:100%; position:absolute;">
            <tr>
                <td valign="middle" align="center">
                    <table style="width:400px; font-size:12px;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 81px; text-align:right; padding-right:13px; height: 34px;">
                                用户名</td>
                            <td style="height: 34px; width: 178px;">
                                <asp:TextBox ID="username" runat="server" Width="175px"></asp:TextBox></td>
                            <td style="width: 130px; color:Red;">
                                (必填)</td>
                        </tr>
                         <tr>
                            <td style="width: 81px; text-align:right; padding-right:13px; height: 34px;">
                                密码</td>
                            <td style="height: 34px; width: 178px;">
                                <asp:TextBox ID="password" runat="server" Width="175px"></asp:TextBox></td>
                            <td style="width: 130px; color:Red;">
                                (必填)</td>
                        </tr>
                        
                         <tr>
                            <td style="width: 81px; text-align:right; padding-right:13px; height: 34px;">
                                </td>
                            <td style="height: 34px; width: 178px;">
                                <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" OnClientClick="return checkinput()" /></td>
                            <td style="width: 130px"></td>
                        </tr>
             
                    </table>
                
                </td>
            </tr>
           
        </table>
    </form>
</body>
</html>
