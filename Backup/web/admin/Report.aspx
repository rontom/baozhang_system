<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="admin_Report" %>

<%@ Register Assembly="dotnetCHARTING" Namespace="dotnetCHARTING" TagPrefix="dotnetCHARTING" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/StyleSheet.css" type="text/css" rel="Stylesheet" />
    <link href="../css/default.css" type="text/css" rel="Stylesheet" />
    <script src="../js/jquery-1.3.2.js" type="text/javascript" ></script>
    <script type="text/javascript">
    function CheckIsSelect(obj)
    {
      if(!$.trim($("#"+obj).val()))
      {
         return false;
      }
    }
    function checktab1()
    {
       if(CheckIsSelect('yearintabone')==false)
       {
          alert('请选择年份');
          return false;
       }
    }
    
    function checktab2()
     {
       if(CheckIsSelect('yearintabtwo')==false)
       {
          alert('请选择年份');
          return false;
       }
    }
    
     
    function checktab3()
     {
       if(CheckIsSelect('yearintab3')==false)
       {
          alert('请选择年份');
          return false;
       }
       
        if(CheckIsSelect('xueqi')==false)
       {
          alert('请选择学期');
          return false;
       }
    }
    
    function checktab4()
     {
       if(CheckIsSelect('AllUser')==false)
       {
          alert('请选择用户');
          return false;
       }
       
        if(CheckIsSelect('yearuntab4')==false)
       {
          alert('请选择年份');
          return false;
       }
    }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div style="width:100%; height:auto; margin-left:auto; margin-right:auto;">
        <cc1:TabWebControl ID="TabWebControl1" runat="server" style="margin-top: 10px; margin-left: 10px" Width="98%">
            <cc1:TabPage ID="TabPage1" runat="server" Text="报障方式统计图">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <div class="content">
                <div style="width:100%; height:25px; margin-left:auto; margin-right:auto; text-align:left;">
                    <asp:DropDownList ID="yearintabone" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClientClick="return checktab1()" Text="查询" OnClick="Button1_Click" /></div>
                <div style="width:100%; margin-left:auto; margin-right:auto; text-align:center; margin-top:4px;">
                    <dotnetCHARTING:Chart ID="Chart1" runat="server" ImageFormat="Jpg" Dpi="100" FileQuality="100" PieLabelMode="Inside" Height="380px">
                        <DefaultLegendBox CornerBottomRight="Cut" Padding="4">
                            <DefaultEntry ShapeType="None">
                            </DefaultEntry>
                            <HeaderEntry ShapeType="None" Visible="False">
                            </HeaderEntry>
                        </DefaultLegendBox>
                        <SmartForecast Start="" TimeSpan="00:00:00" />
                        <DefaultElement ShapeType="None">
                            <DefaultSubValue Name="">
                            </DefaultSubValue>
                            <LegendEntry ShapeType="None">
                            </LegendEntry>
                            <SmartLabel PieLabelMode="Inside">
                            </SmartLabel>
                        </DefaultElement>
                        <ChartArea StartDateOfYear="">
                            <Label Font="Tahoma, 8pt">
                            </Label>
                            <TitleBox Position="Left">
                                <Label Color="Black">
                                </Label>
                            </TitleBox>
                            <DefaultElement ShapeType="None">
                                <DefaultSubValue Name="">
                                </DefaultSubValue>
                                <LegendEntry ShapeType="None">
                                </LegendEntry>
                                <SmartLabel PieLabelMode="Inside">
                                </SmartLabel>
                            </DefaultElement>
                            <LegendBox CornerBottomRight="Cut" Padding="4" Orientation="TopRight">
                                <DefaultEntry ShapeType="None">
                                </DefaultEntry>
                                <HeaderEntry Name="Name" ShapeType="None" SortOrder="-1" Value="Value" Visible="False">
                                    <LabelStyle Font="Arial, 8pt, style=Bold" />
                                </HeaderEntry>
                            </LegendBox>
                            <XAxis GaugeLabelMode="Default" GaugeNeedleType="One" SmartScaleBreakLimit="2" TimeInterval="Minutes">
                                <TimeScaleLabels MaximumRangeRows="4">
                                </TimeScaleLabels>
                                <ScaleBreakLine Color="Gray" />
                                <ZeroTick>
                                    <Line Length="3" />
                                </ZeroTick>
                                <MinorTimeIntervalAdvanced Start="" TimeSpan="00:00:00" />
                                <Label Alignment="Center" Font="Arial, 9pt, style=Bold" LineAlignment="Center">
                                </Label>
                                <TimeIntervalAdvanced Start="" TimeSpan="00:00:00" />
                                <DefaultTick>
                                    <Line Length="3" />
                                    <Label Text="%Value">
                                    </Label>
                                </DefaultTick>
                            </XAxis>
                            <YAxis GaugeLabelMode="Default" GaugeNeedleType="One" SmartScaleBreakLimit="2" TimeInterval="Minutes">
                                <TimeScaleLabels MaximumRangeRows="4">
                                </TimeScaleLabels>
                                <ScaleBreakLine Color="Gray" />
                                <ZeroTick>
                                    <Line Length="3" />
                                </ZeroTick>
                                <MinorTimeIntervalAdvanced Start="" TimeSpan="00:00:00" />
                                <Label Alignment="Center" Font="Arial, 9pt, style=Bold" LineAlignment="Center">
                                </Label>
                                <TimeIntervalAdvanced Start="" TimeSpan="00:00:00" />
                                <DefaultTick>
                                    <Line Length="3" />
                                    <Label Text="%Value">
                                    </Label>
                                </DefaultTick>
                            </YAxis>
                        </ChartArea>
                        <TitleBox Position="Left">
                            <Label Color="Black">
                            </Label>
                        </TitleBox>
                    </dotnetCHARTING:Chart>
                </div>
                
                </div>
                </ContentTemplate>
                </asp:UpdatePanel>
            </cc1:TabPage>
            <cc1:TabPage ID="TabPage2" runat="server" Text="故障分布图">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                 <div class="content">
                <div style="width:100%; height:25px; margin-left:auto; margin-right:auto; text-align:left;">
                    <asp:DropDownList ID="yearintabtwo" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="Button2" runat="server" CssClass="btn" Text="查询" OnClientClick="return checktab2()" OnClick="Button2_Click" /></div>
                <div style="width:100%; margin-left:auto; margin-right:auto; text-align:center; margin-top:4px;">
                    <dotnetCHARTING:Chart ID="Chart2" runat="server" Height="380px" Width="440px" Dpi="100">
                        <DefaultLegendBox CornerBottomRight="Cut" Padding="4">
                            <DefaultEntry ShapeType="None">
                            </DefaultEntry>
                            <HeaderEntry ShapeType="None" Visible="False">
                            </HeaderEntry>
                        </DefaultLegendBox>
                        <SmartForecast Start="" TimeSpan="00:00:00" />
                        <DefaultElement ShapeType="None">
                            <DefaultSubValue Name="">
                            </DefaultSubValue>
                            <LegendEntry ShapeType="None">
                            </LegendEntry>
                        </DefaultElement>
                        <ChartArea StartDateOfYear="">
                            <Label Font="Tahoma, 8pt">
                            </Label>
                            <TitleBox Position="Left">
                                <Label Color="Black">
                                </Label>
                            </TitleBox>
                            <DefaultElement ShapeType="None">
                                <DefaultSubValue Name="">
                                </DefaultSubValue>
                                <LegendEntry ShapeType="None">
                                </LegendEntry>
                            </DefaultElement>
                            <LegendBox CornerBottomRight="Cut" Padding="4" Orientation="TopRight">
                                <DefaultEntry ShapeType="None">
                                </DefaultEntry>
                                <HeaderEntry Name="Name" ShapeType="None" SortOrder="-1" Value="Value" Visible="False">
                                    <LabelStyle Font="Arial, 8pt, style=Bold" />
                                </HeaderEntry>
                            </LegendBox>
                            <XAxis GaugeLabelMode="Default" GaugeNeedleType="One" SmartScaleBreakLimit="2" TimeInterval="Minutes">
                                <TimeScaleLabels MaximumRangeRows="4">
                                </TimeScaleLabels>
                                <ScaleBreakLine Color="Gray" />
                                <ZeroTick>
                                    <Line Length="3" />
                                </ZeroTick>
                                <MinorTimeIntervalAdvanced Start="" TimeSpan="00:00:00" />
                                <Label Alignment="Center" Font="Arial, 9pt, style=Bold" LineAlignment="Center">
                                </Label>
                                <TimeIntervalAdvanced Start="" TimeSpan="00:00:00" />
                                <DefaultTick>
                                    <Line Length="3" />
                                    <Label Text="%Value">
                                    </Label>
                                </DefaultTick>
                            </XAxis>
                            <YAxis GaugeLabelMode="Default" GaugeNeedleType="One" SmartScaleBreakLimit="2" TimeInterval="Minutes">
                                <TimeScaleLabels MaximumRangeRows="4">
                                </TimeScaleLabels>
                                <ScaleBreakLine Color="Gray" />
                                <ZeroTick>
                                    <Line Length="3" />
                                </ZeroTick>
                                <MinorTimeIntervalAdvanced Start="" TimeSpan="00:00:00" />
                                <Label Alignment="Center" Font="Arial, 9pt, style=Bold" LineAlignment="Center">
                                </Label>
                                <TimeIntervalAdvanced Start="" TimeSpan="00:00:00" />
                                <DefaultTick>
                                    <Line Length="3" />
                                    <Label Text="%Value">
                                    </Label>
                                </DefaultTick>
                            </YAxis>
                        </ChartArea>
                        <TitleBox Position="Left">
                            <Label Color="Black">
                            </Label>
                        </TitleBox>
                    </dotnetCHARTING:Chart>
                </div></div>
                </ContentTemplate>
                </asp:UpdatePanel>
            </cc1:TabPage>
            <cc1:TabPage ID="TabPage3" runat="server" Text="年度人员故障统计图">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                  <div style="width:100%; height:auto; margin-left:auto; margin-right:auto;">
                  <div style="width:100%; height:25px; text-align:left;">
                      <asp:DropDownList ID="yearintab3" runat="server">
                      </asp:DropDownList>
                      <asp:DropDownList ID="xueqi" runat="server">
                          <asp:ListItem Value="">选择学期</asp:ListItem>
                          <asp:ListItem Value="1">上学期</asp:ListItem>
                          <asp:ListItem Value="2">下学期</asp:ListItem>
                      </asp:DropDownList>
                      <asp:DropDownList ID="usertype" runat="server">
                          <asp:ListItem Value="学生">学生</asp:ListItem>
                          <asp:ListItem Value="1">其它</asp:ListItem>
                      </asp:DropDownList>
                      <asp:Button ID="Button3" runat="server" CssClass="btn" Text="查看" OnClientClick="return checktab3()" OnClick="Button3_Click" /></div>
                  <div style="width:100%; margin-left:auto; text-align:center; margin-right:auto; margin-top:5px;">
                      <dotnetCHARTING:Chart ID="Chart3" runat="server" Dpi="100">
                          <DefaultLegendBox CornerBottomRight="Cut" Padding="4">
                              <DefaultEntry ShapeType="None">
                              </DefaultEntry>
                              <HeaderEntry ShapeType="None" Visible="False">
                              </HeaderEntry>
                          </DefaultLegendBox>
                          <SmartForecast Start="" />
                          <DefaultElement ShapeType="None">
                              <DefaultSubValue Name="">
                              </DefaultSubValue>
                              <LegendEntry ShapeType="None">
                              </LegendEntry>
                          </DefaultElement>
                          <ChartArea StartDateOfYear="">
                              <Label Font="Tahoma, 8pt">
                              </Label>
                              <TitleBox Position="Left">
                                  <Label Color="Black">
                                  </Label>
                              </TitleBox>
                              <DefaultElement ShapeType="None">
                                  <DefaultSubValue Name="">
                                      <Line Length="4" />
                                  </DefaultSubValue>
                                  <LegendEntry ShapeType="None">
                                  </LegendEntry>
                              </DefaultElement>
                              <LegendBox CornerBottomRight="Cut" Padding="4" Position="Top">
                                  <DefaultEntry ShapeType="None">
                                  </DefaultEntry>
                                  <HeaderEntry Name="Name" ShapeType="None" SortOrder="-1" Value="Value" Visible="False">
                                  </HeaderEntry>
                              </LegendBox>
                              <XAxis GaugeLabelMode="Default" GaugeNeedleType="One" SmartScaleBreakLimit="2">
                                  <TimeScaleLabels MaximumRangeRows="4">
                                  </TimeScaleLabels>
                                  <ScaleBreakLine Color="Gray" />
                                  <ZeroTick>
                                      <Line Length="3" />
                                  </ZeroTick>
                                  <MinorTimeIntervalAdvanced Start="" />
                                  <Label Alignment="Center" Font="Arial, 9pt, style=Bold" LineAlignment="Center">
                                  </Label>
                                  <TimeIntervalAdvanced Start="" />
                                  <DefaultTick>
                                      <Line Length="3" />
                                      <Label Text="%Value">
                                      </Label>
                                  </DefaultTick>
                              </XAxis>
                              <YAxis GaugeLabelMode="Default" GaugeNeedleType="One" SmartScaleBreakLimit="2">
                                  <TimeScaleLabels MaximumRangeRows="4">
                                  </TimeScaleLabels>
                                  <ScaleBreakLine Color="Gray" />
                                  <ZeroTick>
                                      <Line Length="3" />
                                  </ZeroTick>
                                  <MinorTimeIntervalAdvanced Start="" />
                                  <Label Alignment="Center" Font="Arial, 9pt, style=Bold" LineAlignment="Center">
                                  </Label>
                                  <TimeIntervalAdvanced Start="" />
                                  <DefaultTick>
                                      <Line Length="3" />
                                      <Label Text="%Value">
                                      </Label>
                                  </DefaultTick>
                              </YAxis>
                          </ChartArea>
                          <TitleBox Position="Left">
                              <Label Color="Black">
                              </Label>
                          </TitleBox>
                      </dotnetCHARTING:Chart>
                  </div>
                  </div>
                </ContentTemplate>
                </asp:UpdatePanel>
            </cc1:TabPage>
            <cc1:TabPage ID="TabPage4" runat="server" Text="个人处理故障详细统计图">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
            <div style="width:100%; height:auto; margin-left:auto; margin-right:auto;">
            <div style="width:100%; height:22px; text-align:left; margin-top:7px;">
                <asp:DropDownList ID="AllUser" runat="server" AutoPostBack="True" OnSelectedIndexChanged="AllUser_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="yearuntab4" runat="server" Enabled="False">
                </asp:DropDownList>
                <asp:Button ID="Button4" runat="server" OnClientClick="return checktab4()" CssClass="btn" Text="查看" OnClick="Button4_Click" /></div>
                <div style="width:100%; text-align:center; height:auto; margin-left:auto; margin-right:auto;">
                    <dotnetCHARTING:Chart ID="Chart4" runat="server">
                    </dotnetCHARTING:Chart>
                </div>
            </div></ContentTemplate>
                </asp:UpdatePanel>
            </cc1:TabPage>
        </cc1:TabWebControl>
    </div>
    </form>
</body>
</html>
