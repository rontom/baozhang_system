<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mybreakdown.aspx.cs" Inherits="admin_Mybreakdown" %>

<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/StyleSheet.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="info">
        <cc1:tabwebcontrol id="TabWebControl1" runat="server" Width="95%"><cc1:TabPage id="TabPage1" runat="server" Height="450px" Text="最近两天故障"></cc1:TabPage> <cc1:TabPage id="TabPage2" runat="server" Height="450px" Text="历史记录"></cc1:TabPage></cc1:tabwebcontrol>
    
    </div>
    </form>
</body>
</html>
