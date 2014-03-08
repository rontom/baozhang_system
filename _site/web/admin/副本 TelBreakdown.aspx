<%@ Page Language="C#" AutoEventWireup="true" CodeFile="副本 TelBreakdown.aspx.cs" Inherits="admin_TelBreakdown"  %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/StyleSheet.css" type="text/css" rel="stylesheet" />
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
   <script src="../js/ajax.js" type="text/javascript"></script>
   <script src="../js/default.js" type="text/javascript"></script>
   <script src="../js/verification.js" type="text/javascript"></script>

</head>
<body onload="GetAllbuild()">
    <form id="form1" runat="server" >
    <div class="info" style="text-align:left; width:97%; margin-left:auto; margin-right:auto;">
        <cc1:TabWebControl ID="TabWebControl1" runat="server" Width="100%">
            <cc1:TabPage ID="TabPage1" runat="server" Text="登记新故障">
            
    <div class="content">
        <table class="contenttable" cellpadding="0" cellspacing="0">
            <tr>
                <td class="hea" >
                    姓名：</td>
                <td >
                    <asp:TextBox ID="nameinput" runat="server" Width="163px" MaxLength="10"></asp:TextBox></td>
                <td class="hea">
                    联系电话：</td>
                 <td style="width: 256px">
                     <asp:TextBox ID="phoneinput" runat="server" MaxLength="25"></asp:TextBox>
                </td>
                </tr>
                 <tr>
                <td class="guzhangcontent" >
                    故障内容：</td>
                <td colspan="3">
                    <asp:DropDownList ID="commonfaultdrop" runat="server" Width="99%">
                    </asp:DropDownList></td>
                </tr>
                 <tr style="display:none;" id="customfault">
               <td class="hea" style="height:50px;">
                   自定义故障：</td>
                 <td colspan="3" style=" padding-top:10px; padding-bottom:10px;">
                     <asp:TextBox ID="customfaultinput" runat="server" Height="45px" TextMode="MultiLine" Width="98%" MaxLength="100">自定义故障内容</asp:TextBox></td>
                </tr>
                 <tr>
                <td class="hea" >
                    地址：</td>
                <td colspan="3">
                    <select id="builddrop" onchange="Builddropchange()">
                       
                    </select>
                    &nbsp;
                    <select id="roomdrop" onchange="Roomdropchange()">
                        <option selected="selected"></option>
                    </select>
                </td>
                </tr>
                
                 <tr id="CustomAddress" style="display:none;">
               <td class="hea" style="height: 40px">
                   自定义地址：</td>
                 <td colspan="3" style="height: 40px" >
                     <asp:TextBox ID="addressimput" runat="server" Width="98%" MaxLength="25">自定义地址</asp:TextBox></td>
                </tr>
                
                 <tr>
               <td class="hea" >
                   转发：</td>
                 <td colspan="3">
                     <table style="width:100%; height:100%;">
                         <tr>
                             <td style="width:140px;">
                             <asp:DropDownList ID="userdrop" runat="server" Font-Size="12px">
                     </asp:DropDownList>
                             </td>
                             <td style="width:60px;">
                             </td>
                             <td style="width: 153px">
                             <asp:DropDownList ID="faultare" runat="server" Font-Size="12px" Visible="False">
                     </asp:DropDownList>
                                 <asp:TextBox ID="guzhangarea" style="display:none;" runat="server"></asp:TextBox></td>
                             <td style="width:60px;">
                             是否处理：
                             </td>
                             <td style="line-height:0px;">
                                 <asp:CheckBox ID="CheckBox1" runat="server" style="line-height: normal; margin-top: 0px;" />
                             </td>
                         </tr>
                     </table>
                    </td>
                </tr>
                
                
                    <tr style="display:none;" id="forwarddescripttr">
               <td class="hea" id="forwarddescripttitle" >
                   转发说明：</td>
                 <td colspan="3" >
                     <asp:TextBox ID="forwarddescipt" runat="server" Height="30px" TextMode="MultiLine" Width="98%" MaxLength="100"></asp:TextBox></td>
                </tr>
                
                 <tr>
               <td class="hea">
                   备注：</td>
                 <td colspan="3" >
                     <asp:TextBox ID="beizhiinput" runat="server" Height="39px" TextMode="MultiLine" Width="98%" MaxLength="100"></asp:TextBox></td>
                </tr>
                
                 <tr>
                 <td class="hea">
                   </td>
               <td colspan="3" style=" height:30px; text-align:left;">
                  <asp:Button ID="Button2" runat="server" CssClass="btn" Text="确认添加" OnClick="Button2_Click" OnClientClick="return checktelfault()" />
                   &nbsp;
                   <asp:Button ID="Button1" runat="server" Text="返回首页" CssClass="btn" />
                   </td>
                
                </tr>
        </table>
    </div>
    </cc1:TabPage>
    
            <cc1:TabPage ID="TabPage2" runat="server" Text="登记历史记录">
            <div style="width:100%; height:auto; text-align:right; margin-top:20px; margin-left:auto; margin-right:auto;">
                <asp:GridView ID="telfalutgrid" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" ItemStyle-Width="60px" />
                        <asp:TemplateField HeaderText="故障内容">
                        <ItemTemplate>
                        <%#Eval("GuZhangContent") %>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
                        <asp:BoundField DataField="phone" HeaderText="联系电话" SortExpression="phone" ItemStyle-Width="80px" />
                        
                        <asp:BoundField DataField="ReceivedDate" HeaderText="报障日期" SortExpression="ReceivedDate" ItemStyle-Width="110px" />
                    </Columns>
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                </asp:GridView>
                <webdiyer:aspnetpager id="AspNetPager1" runat="server" firstpagetext="首页" lastpagetext="尾页"
                    nextpagetext="下一页" pageindexboxtype="DropDownList" prevpagetext="上一页" showpageindexbox="Always"
                    submitbuttontext="Go" textafterpageindexbox="页" textbeforepageindexbox="转到" OnPageChanged="AspNetPager1_PageChanged"></webdiyer:aspnetpager>
            </div>
            </cc1:TabPage>
     </cc1:TabWebControl>
    </div>
    </form>
</body>
</html>
