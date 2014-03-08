﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="print.aspx.cs" Inherits="admin_Default3" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
            Height="1106px" ReportSourceID="CrystalReportSource1" Width="878px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="../CrystalReport/FauluTable.rpt">
            </Report>
        </CR:CrystalReportSource>
      
    </div>
    </form>
</body>
</html>
