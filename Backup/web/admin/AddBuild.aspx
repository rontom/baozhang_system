<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddBuild.aspx.cs" Inherits="admin_AddBuild" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
    td{background-color:white}
    </style>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
</head>
<body style="margin:0px; padding:0px; font-size:12px;">
    <form id="form1" runat="server">
    <div style="width:100%; height:auto;">
    <div style="width:95%; margin-left:auto; margin-top:10px; margin-right:auto;">
        <table style="width:500px; margin-left:auto; margin-right:auto; background-color:#d4d4d4;" cellpadding="0" cellspacing="1">
            <tr>
                <td style="width:120px; text-align:right; padding-right:12px; height: 31px;">
                    楼房名：</td>
                <td colspan="2" style="height: 31px; padding-left:10px;">
                    <asp:TextBox ID="Buildname" runat="server"></asp:TextBox>
                    </td>
            </tr>
            
             <tr>
                <td style="width:120px; text-align:right; padding-right:12px; height: 82px;">
                    楼房别名：</td>
                <td style="height: 82px; padding-left:10px; width: 222px;">
                    <asp:TextBox ID="anothername" runat="server" Height="64px" TextMode="MultiLine" Width="216px"></asp:TextBox>
                    </td>
                        <td style="width:120px; border-left:0px; color:Red; text-align:left; padding-left:12px; height: 82px;">
                            别名之间用|号隔开</td>
            </tr>
            
            <tr>
                <td style="width:120px; text-align:right; padding-right:12px; height: 31px;">
                  </td>
                <td colspan="2" style="height: 31px; padding-left:10px;">
                    <asp:Button ID="add" runat="server" Text="确定" CssClass="btn" Height="21px" Width="40px" OnClick="add_Click" />
                    &nbsp;&nbsp;
                    <input id="Button2" type="button" value="返回" style="width: 42px" class="btn" /></td>
            </tr>
        </table>
     
    </div>
    </div>
    </form>
</body>
</html>
