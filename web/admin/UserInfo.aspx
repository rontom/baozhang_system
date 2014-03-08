<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="admin_UserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    
    <script type="text/javascript">
    function beizhu()
    {
       document.getElementById("beizhu").innerHTML="<%=beizhu %>";
    }
    </script>
    <style type="text/css">
    
    td{background-color:white}
    </style>
</head>
<body onload="beizhu()" style="margin:0px; padding:0px; font-size:12px; ">
    <form id="form1" runat="server">
    <div style="width:100%; height:100%;">
         <div style=" width:400px;  margin-top:80px; height:auto; margin-left:auto; margin-right:auto;">
              <div style="width:100%; height:auto;">
                  <table style="width:100%; background-color:Black;" cellpadding="0" cellspacing="1">
                      <tr>
                          <td style="width:85px; padding-right:6px; text-align:right; height: 31px;" valign="middle">
                              用户名：</td>
                          <td style=" padding-left:8px; height: 31px;" valign="middle">
                              <asp:Label ID="username" runat="server" Text="Label"></asp:Label></td>
                          <td style="width:70px; padding-right:6px; text-align:right; height: 31px;" valign="middle">
                              状态：</td>
                          <td style=" padding-left:8px; height: 31px;" valign="middle">
                              <asp:Label ID="state" runat="server" Text="Label"></asp:Label></td>
                      </tr>
                     
                      <tr>
                          <td style="width:85px; padding-right:6px; text-align:right; height: 31px;" valign="middle">
                              性别：</td>
                          <td style=" padding-left:8px; height: 31px;" valign="middle">
                              <asp:Label ID="sex" runat="server" Text="Label"></asp:Label></td>
                          <td style="width:70px; padding-right:6px; text-align:right; height: 31px;" valign="middle">
                              联系电话：</td>
                          <td style=" padding-left:8px; height: 31px;" valign="middle">
                              <asp:Label ID="phone" runat="server" Text="Label"></asp:Label></td>
                      </tr>
                      <tr>
                          <td style="width:85px; padding-right:6px; text-align:right; height: 31px;" valign="middle">
                              院系：</td>
                          <td style=" padding-left:8px; height: 31px;" valign="middle">
                              <asp:Label ID="yuanxi" runat="server" Text="Label"></asp:Label></td>
                          <td style="width:70px; padding-right:6px; text-align:right; height: 31px;" valign="middle">
                              专业：</td>
                          <td style=" padding-left:8px; height: 31px;" valign="middle">
                              <asp:Label ID="zhuanye" runat="server" Text="Label"></asp:Label></td>
                      </tr>
                      
                      
                       <tr>
                          <td style="width:85px; padding-right:6px; text-align:right; height: 31px;" valign="middle">
                              上次登录IP：</td>
                          <td style=" padding-left:8px; height: 31px;" valign="middle">
                              <asp:Label ID="ip" runat="server" Text="Label"></asp:Label></td>
                          <td style="width:70px; padding-right:6px; text-align:right; height: 31px;" valign="middle">
                              姓名：</td>
                          <td style=" padding-left:8px; height: 31px;" valign="middle">
                              <asp:Label ID="truename" runat="server" Text="Label"></asp:Label></td>
                      </tr>
                       <tr>
                          <td style="width:85px; padding-right:6px; text-align:right; height: 31px;" valign="middle">
                              上次登录时间：</td>
                          <td style=" padding-left:8px; height: 31px;" valign="middle">
                              <asp:Label ID="logintime" runat="server" Text="Label"></asp:Label></td>
                          <td style="width:70px; padding-right:6px; text-align:right; height: 31px;" valign="middle">
                              用户类型：</td>
                          <td style=" padding-left:8px; height: 31px;" valign="middle">
                              <asp:Label ID="usertype" runat="server" Text="Label"></asp:Label></td>
                      </tr>
                      
                      <tr>
                          <td style="width:85px; padding-right:6px; text-align:right; height: 65px;" valign="middle">
                              备注：</td>
                          <td id="beizhu" colspan="3" style=" padding-left:8px; height: 65px;" valign="middle">
                             </td>
                          
                      </tr>
              
                  </table>
         
              
              </div>
         
         </div>
    </div>
    </form>
</body>
</html>
