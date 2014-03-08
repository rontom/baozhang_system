<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>网络报障</title>
    <script src="js/jquery-1.3.2.js" type="text/javascript"> </script>
    <script  type="text/javascript">
     function checkv()
    {
       if(!$.trim($("#username").val()))
       {
          alert('用户名必填');
          return false;
       }
       if(!$.trim($("#realname").val()))
       {
          alert('姓名必填');
          return false;
       }
       if(!$.trim($("#telephone").val())&&!$.trim($("#mobile").val()))
       {
          alert('电话或手机必填一个');
          return false;
       }
       
       if(!$.trim($("#address").val()))
       {
          alert('地址必填');
          return false;
       }
       if(!$.trim($("#gucontent").val()))
       {
          alert('故障内容');
          return false;
       }
       else
       {
         return confirm('您确定报此网络故障？');
       }
    }
    
    
    
    </script>
   
   
    <style type="text/css">
    .ft{ float:left;}
    </style>
    
</head>

<body style="margin:0px; padding:0px; font-size:12px;">
    <form id="form1" runat="server">
    <div>
        <table style="width:550px; margin-left:auto; margin-right:auto; margin-top:120px;">
            <tr>
                <td style="text-align:right; padding-right:10px; width:70px; height: 40px;">
                用户名：
                </td>
                
                <td style="width: 161px; height: 40px; line-height:40px;">
                    <asp:TextBox ID="username" runat="server" Width="155px" CssClass="ft" ReadOnly="True" MaxLength="50"></asp:TextBox></td>
                    <td style="width:30px; color:Red;">
                        </td>
                <td style="text-align:right; padding-right:10px; width:70px; height: 40px;">
                    姓名：</td>
                <td style="height: 40px; line-height:40px;">
                    <asp:TextBox ID="realname" runat="server" MaxLength="10"></asp:TextBox></td><td style="width:30px; color:Red;">
                        *</td>
            </tr>
            <tr>
                <td style="text-align:right; padding-right:10px; width:70px; height: 42px;">
                    联系电话：
                </td>
                
                <td style="width: 161px; height: 42px; line-height:40px;">
                    <asp:TextBox ID="telephone" runat="server" MaxLength="20"></asp:TextBox></td>
                <td style="width:30px;color:Red; height: 42px;">
                    </td>
                <td style="text-align:right; padding-right:10px; width:70px; height: 42px;">
                    手机：</td>
                <td style="height: 42px; line-height:40px;">
                    <asp:TextBox ID="mobile" runat="server" MaxLength="20"></asp:TextBox></td><td style="width:30px;color:Red; height: 42px;">
                        </td>
            </tr>
            <tr>
                <td style="text-align:right; padding-right:10px; width:70px; height: 39px;">
                    地址：
                </td>
                
               
                <td style="height: 39px;line-height:40px;" colspan="4">
                    <asp:TextBox ID="address" runat="server" Width="423px" MaxLength="120"></asp:TextBox></td><td style="width:30px;color:Red;">
                        *</td>
            </tr>
            <tr>
                <td style="text-align:right; padding-right:10px; width:70px; height: 92px;">
                    故障内容：
                </td>
                
                
                <td style="height: 92px; line-height:92px;" colspan="4">
                    <asp:TextBox ID="gucontent" runat="server" Height="76px" TextMode="MultiLine" Width="426px" MaxLength="250"></asp:TextBox></td><td style="width:30px;color:Red;">
                        *</td>
            </tr>
            <tr>
            <td colspan="6" style="height: 49px; text-align:center;">
                <asp:Button ID="Button1" runat="server" OnClientClick="return checkv()" Text="确定报障" OnClick="Button1_Click" />&nbsp;
            </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
