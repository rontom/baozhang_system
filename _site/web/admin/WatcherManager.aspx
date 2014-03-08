<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WatcherManager.aspx.cs" Inherits="admin_WatcherManager" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/StyleSheet.css" type="text/css" rel="stylesheet" />

    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>

    <script src="../js/default.js" type="text/javascript"></script>

    <style type="text/css">
    .weektable{background-color:Gray; }
    #weekplane td{background-color:white;}
    </style>
</head>
<body>
    <form id="form1" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server">
                       
                    </asp:ScriptManager>
        <div style="width: 98%; height: auto; margin-top: 7px; margin-left: auto; margin-right: auto;">
            <cc1:TabWebControl ID="TabWebControl1" runat="server" Width="100%">
                <cc1:TabPage ID="TabPage1" runat="server" Text="教师值班安排">
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                    <table style="width: 100%; height: auto; padding-left: 10px;" cellpadding="0" cellspacing="0">
                        <tr id="list" style="display: block;">
                            <td>
                                <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 30px">
                                            <img alt="新增值班计划" src="../images/row_add.gif" />[ <a href="#" onclick="Switchdisplay('AddWatchPlane','list')">
                                                新增值班计划</a>]</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="AddWatchPlane" style="display: none;">
                            <td>
                                <table cellpadding="0" cellspacing="0" style="width: 100%; height: auto;">
                                    <tr>
                                        <td style="width: 116px; text-align: right; padding-right: 10px; height: 40px;">
                                            值班计划名称：
                                        </td>
                                        <td style="height: 40px">
                                            <asp:TextBox ID="planname" runat="server" Width="294px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 106px; text-align: right; padding-right: 10px; height: 40px;">
                                            计划时间段：
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" style="width: 454px; height: 40px;">
                                                <tr>
                                                    <td style="width: 63px">
                                                        起始时间：</td>
                                                    <td style="width: 79px">
                                                        <asp:TextBox ID="TextBox1" runat="server" Width="78px"></asp:TextBox></td>
                                                    <td style="width: 61px">
                                                        结束时间：</td>
                                                    <td style="width: 80px">
                                                        <asp:TextBox ID="TextBox5" runat="server" Width="78px"></asp:TextBox></td>
                                                    <td style="color: Red;">
                                                        日期格式为：2009-9-12</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 106px; text-align: right; padding-right: 10px; height: 40px;">
                                            轮循方式：
                                        </td>
                                        <td>
                                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="week">每周</asp:ListItem>
                                                <asp:ListItem Value="none">不循环</asp:ListItem>
                                            </asp:CheckBoxList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table id="weekplane" class="weektable" style="width: 740px; height: 300px;" cellpadding="0"
                                                cellspacing="1">
                                                <tr style="height: 60px; text-align: center;">
                                                    <td>
                                                    </td>
                                                    <td>
                                                        星期一</td>
                                                    <td>
                                                        星期二
                                                    </td>
                                                    <td>
                                                        星期三
                                                    </td>
                                                    <td>
                                                        星期四
                                                    </td>
                                                    <td>
                                                        星期五</td>
                                                    <td>
                                                        星期六
                                                    </td>
                                                    <td>
                                                        星期日
                                                    </td>
                                                </tr>
                                                <tr style="height: 120px;">
                                                    <td style="text-align: center; width: 40px;">
                                                        上午</td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr style="height: 120px; width: 40px;">
                                                    <td style="text-align: center; height: 85px;">
                                                        下午</td>
                                                    <td style="height: 85px">
                                                    </td>
                                                    <td style="height: 85px">
                                                    </td>
                                                    <td style="height: 85px">
                                                    </td>
                                                    <td style="height: 85px">
                                                    </td>
                                                    <td style="height: 85px">
                                                    </td>
                                                    <td style="height: 85px">
                                                    </td>
                                                    <td style="height: 85px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 106px; text-align: right; padding-right: 10px; height:auto;">
                                            选择值班人员：</td>
                                        <td>
                                            <asp:CheckBoxList ID="allusers" runat="server">
                                            </asp:CheckBoxList></td>
                                    </tr>
                                     <tr>
                                        <td style="width: 106px; text-align: right; padding-right: 10px; height:auto;">
                                           </td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="确定" />  </td>
                                    </tr>
                                     <tr>
                                        <td style="width: 106px; text-align: right; padding-right: 10px; height:auto;">
                                            选择值班人员：</td>
                                        <td>
                                            <asp:CheckBoxList ID="CheckBoxList3" runat="server">
                                            </asp:CheckBoxList></td>
                                    </tr>
                                     <tr>
                                        <td style="width: 106px; text-align: right; padding-right: 10px; height:auto;">
                                            选择值班人员：</td>
                                        <td>
                                            <asp:CheckBoxList ID="CheckBoxList4" runat="server" RepeatDirection="Vertical" RepeatColumns="7">
                                            </asp:CheckBoxList></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table></ContentTemplate>
                        </asp:UpdatePanel>
                </cc1:TabPage>
                <cc1:TabPage ID="TabPage2" runat="server" Text="学生值班安排">
                </cc1:TabPage>
                <cc1:TabPage ID="TabPage3" runat="server" Text="值班时间段安排">
                </cc1:TabPage>
            </cc1:TabWebControl>
        </div>
    </form>
</body>
</html>
