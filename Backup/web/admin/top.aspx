<%@ Page Language="C#" AutoEventWireup="true" CodeFile="top.aspx.cs" Inherits="admin_top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body style="margin:0px; padding:0px; font-size:12px;">
    <form id="form1" runat="server">
    
        <table cellpadding="0" cellspacing="0" style="width:100%; height:95px;">
            <tr style=" width:100%; height:95px;">
                <td style="width:257px; height:95px; background-image:url(../images/header_r1_c1.gif);  background-repeat:no-repeat;">
                    <table style="width:100%; height:100%;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="height: 36px">
                            </td>
                        </tr>
                        <tr>
                            <td style=" padding-left:7px;">
                                </td>
                        </tr>
                        
                    </table>
                </td>
                <td style="background-image:url(../images/header_r1_c2.gif); background-repeat:repeat-x; height: 95px;">
                    <table cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                        <tr style="height:55px;">
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height:40px; color:White;">
                            <td style="width:190px;">
                            欢迎您：<asp:Label ID="truename" runat="server" Text="Label"></asp:Label>    
                            角色：<asp:Label ID="Role" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td id="aa" style="width:auto; text-align:left;">
                            <script type="text/javascript">
  setInterval("aa.innerHTML='现在时间：'+new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());",1000);
</script> 
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    </table>
                            </td>
                            
                        </tr>
                    </table>
                </td>
                <td style="width:85px; height:95px; background-image:url(../images/header_r1_c3.gif);  background-repeat:no-repeat;">
                </td>
            </tr>
           
        </table>
     
    </form>
</body>
</html>
