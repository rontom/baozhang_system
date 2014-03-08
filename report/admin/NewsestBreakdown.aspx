<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsestBreakdown.aspx.cs" Inherits="admin_NewsestBreakdown" %>

<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>
<%@ Register Assembly="IntegrateWithJavascriptLibrary" Namespace="IntegrateWithJavascriptLibrary"
    TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/StyleSheet.css" type="text/css" rel="stylesheet" />
    <link href="../css/tab.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="info">
        <cc1:TabWebControl ID="TabWebControl1" runat="server" Width="95%">
            <cc1:TabPage ID="TabPage1" runat="server" Height="450px" Text="未分类故障">
            </cc1:TabPage>
            <cc1:TabPage ID="TabPage2" runat="server" Height="450px" Text="已分类故障">
            </cc1:TabPage>
            <cc1:TabPage ID="TabPage3" runat="server" Height="450px" Text="全部故障">
            </cc1:TabPage>
        </cc1:TabWebControl></div>
    </form>
</body>
</html>
