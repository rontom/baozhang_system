<%@ Page Language="C#" AutoEventWireup="true" CodeFile="副本 Mybreakdown.aspx.cs" Inherits="admin_Mybreakdown" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/StyleSheet.css" type="text/css" rel="stylesheet" />
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="info">
            <cc1:TabWebControl ID="TabWebControl1" runat="server" Width="98%" style="margin-bottom: 30px">
                <cc1:TabPage ID="TabPage1" runat="server" Text="我的故障">
                    <div style="width: 100%; height: auto; display: block; margin-left: auto; margin-right: auto;"
                        id="listinfor" runat="server">
                        <div style="width: 95%; text-align: center; margin-left: auto; margin-right: auto;
                            margin-top: 0px;">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="0">未处理</asp:ListItem>
                                <asp:ListItem Value="1">已处理</asp:ListItem>
                            </asp:RadioButtonList></div>
                        <div style="width: 99%; text-align: left; height: 25px; margin-top: 1px; margin-left: auto;
                            margin-right: auto;">
                            <div style="width:300px; float:left; height:25px;">
                            &nbsp;<asp:Button ID="Button1" runat="server" Text="放入回收站" CssClass="btn" OnClick="Button1_Click" />&nbsp;
                            <asp:Button ID="Button2" runat="server" Text="批量转发" CssClass="btn" OnClientClick="FaultForward()" OnClick="Button2_Click" />&nbsp;
                            <asp:DropDownList ID="printQueue" runat="server" AutoPostBack="True">
                            </asp:DropDownList></div>
                            <div id="putintoqueueresult" style="width:170px; float:right; text-align:center; line-height:25px; margin-right:30px; display:none; background-color:#66b100; color:White; height:25px;">
                                故障已成功移入打印队列</div>
                            </div>
                        <div style="width: 99%; text-align: center; margin-left: auto; margin-right: auto;
                            margin-top: 4px;">
                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False"
                                EmptyDataText="暂无任何故障与您有关">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <input id="Checkbox2" type="checkbox" onclick="CheckAll(this)" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name">
                                        <ItemStyle Width="60px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="故障内容">
                                        <ItemTemplate>
                                            <%#Eval("GuZhangContent") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="地址">
                                        <ItemTemplate>
                                            <%#Eval("Address") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="联系电话">
                                        <ItemTemplate>
                                            <%#Eval("phone") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ReceivedDate" HeaderText="报障日期" />
                                    <asp:TemplateField HeaderText="常用操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("GuZhangSecondID") %>' runat="server" OnClick="LinkButton1_Click">转发</asp:LinkButton>
                                            &nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" runat="server">已维护</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="75px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle BorderStyle="None" Font-Size="Medium" ForeColor="Black" />
                            </asp:GridView>
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                                NextPageText="下一页" PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowPageIndexBox="Always"
                                SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                    <div id="Forward" visible="false" runat="server" style="width: 100%; height: auto; text-align: center; margin-top: 50px;
                         margin-left: auto; margin-right: auto;">
                        <table width="400">
                            <tr>
                                <td style="height: 36px; text-align: right; padding-right: 10px; width: 119px;">
                                    转发人：</td>
                                <td style="height: 36px; text-align: left; padding-left: 12px;">
                                    <asp:DropDownList ID="useres" runat="server">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 97px; text-align: right; padding-right: 10px; width: 119px;">
                                    说明：</td>
                                <td style="height: 97px; text-align: left; padding-left: 12px;">
                                    <asp:TextBox ID="TextBox1" runat="server" Height="59px" TextMode="MultiLine" Width="240px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="height: 36px; text-align: right; padding-right: 10px; width: 119px;">
                                </td>
                                <td style="height: 36px; text-align: left; padding-left: 12px;">
                                    <asp:Button ID="Button4" runat="server" CssClass="btn" Text="确认转发" OnClick="Button4_Click" />
                                    &nbsp;
                                    <input id="Button5" class="btn" style="width: 42px" type="button" value="返回" /></td>
                            </tr>
                        </table>
                    </div>
                <!--故障显示模块-->   
                <div style="width:100%; text-align:center;"></div>
                </cc1:TabPage>
                <cc1:TabPage ID="TabPage2" runat="server" Text="历史记录">
                </cc1:TabPage>
            </cc1:TabWebControl>
        </div>
    </form>
</body>
</html>

<script type="text/javascript">
function CheckAll(checkbox)
{
var elements = checkbox.form.elements; 
for(var i = 0;i < elements.length;i++)
{ 
if(elements[i].type == "checkbox" && elements[i].id != checkbox.id) 
{
elements[i].checked = checkbox.checked;
}
} 
}












//function chekprintqueue()
//{
   //var d=document.getElementById("printQueue");
   //if(d.options[d.selectedIndex].value.length==0)
   //{
      
      //return false;
   //}
   //else
   //{
      //return true;
   //}
//}


//function bindcity(strcode)
//{
   //var obj=document.getElementById("useres");
   //var start=strcode.indexOf("<select");
   //var end=strcode.indexOf("</select>")+9;
   //var strHtml=strcode.substring(start,end);
   //if(obj!=null)
   //{
      //obj.innerHTML=strHtml;
   //}
//}
</script>

