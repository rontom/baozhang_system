<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FaultChart.aspx.cs" Inherits="admin_FaultChart" %>

<%@ Register Assembly="WebChart" Namespace="WebChart" TagPrefix="Web" %>
<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body style="margin: 0px; padding: 0px; font-size: 12px;">
    <form id="form1" runat="server">
        <div>
            <cc1:TabWebControl ID="TabWebControl1" runat="server" Width="98%" Style="margin-top: 20px;
                margin-left: auto; margin-right: auto;">
                <cc1:TabPage ID="TabPage1" runat="server" Text="报障方式统计图">
                    <div style="width: 98%; margin-left: auto; margin-right: auto;">
                        <Web:ChartControl ID="ChartControl1" runat="server" BorderStyle="Outset" BorderWidth="5px"
                            Height="328px" Width="700px" YCustomEnd="500" YCustomStart="100">
                            <YAxisFont StringFormat="Far,Near,Character,LineLimit" Text="errer" />
                            <XTitle StringFormat="Center,Near,Character,LineLimit" Text="erererer" />
                            <ChartTitle StringFormat="Center,Near,Character,LineLimit" />
                            <XAxisFont StringFormat="Center,Near,Character,LineLimit" />
                            <Background Color="LightSteelBlue" />
                            <YTitle StringFormat="Center,Near,Character,LineLimit" />
                        </Web:ChartControl></div>
                </cc1:TabPage>
                <cc1:TabPage ID="TabPage2" runat="server" Text="月故障统计图">
                </cc1:TabPage>
            </cc1:TabWebControl>
        </div>
    </form>
</body>
</html>
