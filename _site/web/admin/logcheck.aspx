<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logcheck.aspx.cs" Inherits="admin_logcheck" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="BLL" %>

<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/newsbreak.css" type="text/css" rel="Stylesheet" />
    <script src="../js/verification.js" type="text/javascript"></script>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
    
    <script src="../js/jquery.date_input.js" type="text/javascript"></script>
    <script src="../js/jquery.date_input.zh_CN.js" type="text/javascript"></script>
    <link href="../css/date_input.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
     $($.date_input.initialize);
    $.extend(DateInput.DEFAULT_OPTS, {
  stringToDate: function(string) {
    var matches;
    if (matches = string.match(/^(\d{4,4})-(\d{2,2})-(\d{2,2})$/)) {
      return new Date(matches[1], matches[2] - 1, matches[3]);
    } else {
      return null;
    };
  },
  dateToString: function(date) {
    var month = (date.getMonth() + 1).toString();
    var dom = date.getDate().toString();
    if (month.length == 1) month = "0" + month;
    if (dom.length == 1) dom = "0" + dom;
    return date.getFullYear() + "-" + month + "-" + dom;
  }
});
    
    
    function checkselectatleastone(grd,che,error,conf)
    {
     if(verificationatlistselectone(grd,che)==false)
{
alert(error);
return false;
}
else
{
return confirm(conf);
}
}
    </script>
</head>
<body style="margin:0px; padding:0px; font-size:12px;">
    <form id="form1" runat="server">
    <div style="width:98%; height:auto; margin-left:auto; margin-right:auto; margin-top:10px;">
        <cc1:TabWebControl ID="TabWebControl1" runat="server">
            <cc1:TabPage ID="TabPage1" runat="server" Text="系统日志">
            <div class="menubreak"><asp:Button ID="Button1" runat="server" Text="批量删除" OnClientClick="return checkselectatleastone('Systemlog','Checkbox2','未选中任何删除项','是否删除日志？')" CssClass="btn" OnClick="Button1_Click" />&nbsp;
                <asp:DropDownList ID="Userdrop" runat="server">
                </asp:DropDownList>
                <asp:TextBox ID="starttime" runat="server" Width="80px" CssClass="date_input"></asp:TextBox>到<asp:TextBox
                    ID="endtime" runat="server" Width="80px" CssClass="date_input"></asp:TextBox>&nbsp;
                <asp:Button ID="Button4" runat="server" CssClass="btn" Text="删除日志" OnClientClick="return Checkdate('starttime','endtime')" OnClick="Button4_Click" />&nbsp;<asp:Button
                    ID="Button6" runat="server" CssClass="btn" OnClick="Button6_Click" Text="查看日志" /></div>
            <div class="showbygrd"><asp:GridView ID="Systemlog" runat="server" AutoGenerateColumns="False" BorderColor="Black" CellPadding="4" CellSpacing="1" ForeColor="#333333" GridLines="None" Width="100%" EmptyDataText="暂无任何记录">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="Checkbox2" type="checkbox" onclick="CheckAll(this,'Systemlog')" />
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="27px" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="用户" DataField="TrueName" >
                        <ItemStyle Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="date" HeaderText="时间" SortExpression="date" >
                        <ItemStyle Width="110px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ip" HeaderText="登录IP" SortExpression="ip" >
                        <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="url" HeaderText="访问URl" SortExpression="url" />
                </Columns>
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <EmptyDataRowStyle Font-Size="12px" />
                </asp:GridView>
            </div>
            <div class="grdpage">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" PageSize="20" PageIndexBoxType="DropDownList">
                </webdiyer:AspNetPager>
            </div>
            </cc1:TabPage>
            <cc1:TabPage ID="TabPage2" runat="server" Text="网络报障日志">
             <div class="menubreak"><asp:Button ID="Button2" runat="server" Text="批量删除" OnClientClick="return checkselectatleastone('weblogslist','Checkbox4','未选中任何删除项','是否删除日志？')" CssClass="btn" OnClick="Button2_Click" />&nbsp;&nbsp;
                <asp:TextBox ID="weblogstart" runat="server" Width="80px" CssClass="date_input"></asp:TextBox>到<asp:TextBox
                    ID="weblogend" runat="server" Width="80px" CssClass="date_input"></asp:TextBox>&nbsp;
                <asp:Button ID="Button3" runat="server" CssClass="btn" Text="删除日志" OnClientClick="return Checkdate('weblogstart','weblogend')" OnClick="Button3_Click" />&nbsp;<asp:Button
                    ID="Button5" runat="server" CssClass="btn" Text="查看日志" OnClick="Button5_Click" /></div>
            <div class="showbygrd"><asp:GridView ID="weblogslist" runat="server" AutoGenerateColumns="False" BorderColor="Black" CellPadding="4" CellSpacing="1" ForeColor="#333333" GridLines="None" Width="100%" EmptyDataText="暂无任何记录">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingRowStyle BackColor="White" />
                <EmptyDataRowStyle Font-Size="12px" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="Checkbox4" type="checkbox" onclick="CheckAll(this,'weblogslist')" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox3" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="username" HeaderText="登录用户名" SortExpression="username" />
                    <asp:BoundField DataField="loginip" HeaderText="登录IP地址" SortExpression="loginip" ItemStyle-Width="80px" />
                    <asp:TemplateField HeaderText="登录结果" ItemStyle-Width="60px">
                    <ItemTemplate>
                    <%#Function.FormatBool(Convert.ToBoolean(Eval("result").ToString()) ,"成功","失败") %>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="url" HeaderText="URL地址" SortExpression="url" />
                </Columns>
                </asp:GridView>
            </div>
            <div class="grdpage">
                <webdiyer:AspNetPager ID="AspNetPager2" runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" PageSize="20" OnPageChanged="AspNetPager2_PageChanged" PageIndexBoxType="DropDownList">
                </webdiyer:AspNetPager>
            </div>
            </cc1:TabPage>
        </cc1:TabWebControl>
    
    </div>
    </form>
</body>
</html>

<script type="text/javascript">
function Checkdate(start,end)
{
   var startdate=$.trim($("#"+start).val());
    var endtdate=$.trim($("#"+end).val());
   if(!isDate(startdate))
   {
      alert('请输入正确的开始日期');
      return false;
   }
   if(!isDate(endtdate))
   {
      alert('请输入正确的结束日期');
      return false;
   }
   if(!compareDate(startdate,endtdate))
   {
      alert('开始日期大于结束日期');
      return false;
   }
   else
   {
      return confirm('你确定要删除'+startdate+'到'+endtdate+"期间的日志记录");
   }
}
</script>
