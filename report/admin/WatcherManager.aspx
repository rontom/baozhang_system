<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WatcherManager.aspx.cs" Inherits="admin_WatcherManager" %>

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
        <cc1:tabwebcontrol id="TabWebControl1" runat="server" width="95%"><cc1:TabPage id="TabPage1" runat="server" __designer:wfdid="w28" Height="450px" Text="教师值班安排"></cc1:TabPage> <cc1:TabPage id="TabPage2" runat="server" __designer:wfdid="w29" Height="450px" Text="学生值班安排"></cc1:TabPage></cc1:tabwebcontrol>
    
    </div>
    </form>
</body>
</html>
