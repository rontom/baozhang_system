<%@ Page Language="C#" AutoEventWireup="true" CodeFile="副本(2) Mybreakdown.aspx.cs" Inherits="admin_Mybreakdown" %>
<%@ Import Namespace="BLL" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/StyleSheet.css" type="text/css" rel="stylesheet" />
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <link href="../css/date_input.css" type="text/css" rel="stylesheet" />

    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
     <script src="../js/jquery.date_input.js" type="text/javascript"></script>
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

    function verificationconfir()
{
   
   if(document.getElementById("finishdate").value.length==0)
   {
     alert('日期必填');
     return false;
   }
   
   var rbltable =document.getElementById("CheckBoxList1") 
  var rbs= rbltable.getElementsByTagName("INPUT"); 
  var n=0;
   
  for(var i = 0;i <rbs.length;i++) 
   { 
    if(rbs[i].checked) 
   { 
    n++;
   } 
  } 
  
  if(n==0)
  {
     alert('至少选择一个故障负责人');
     return false;
  }
   
}
    </script>

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
                            </div>
                        <div style="width: 99%; text-align: left; height: 25px; margin-top: 1px; margin-left: auto;
                            margin-right: auto;">
                            <div style="width:550px; line-height:25px; float:left; height:100%;">
                            &nbsp;<asp:Button ID="Button1" runat="server" Text="放入回收站" CssClass="btn" OnClick="Button1_Click" />&nbsp;
                            <asp:Button ID="Button2" runat="server" Text="批量转发" CssClass="btn" OnClientClick="FaultForward()" OnClick="Button2_Click" />&nbsp;
                            <asp:DropDownList ID="printQueue" runat="server" AutoPostBack="True" OnSelectedIndexChanged="printQueue_SelectedIndexChanged" Font-Size="12px">
                            </asp:DropDownList>
                                <img src="../images/newfault.gif" alt="" />
                                最新故障
                                <img src="../images/ergin.gif" alt="" />&nbsp; 2-4天的故障&nbsp;
                                <img src="../images/longtime.gif" alt="" />
                                超过四天的故障</div>
                            <div runat="server" id="putintoqueueresult" style="width:270px; float:right; display:none; text-align:center; line-height:25px; margin-right:30px;  background-color:#66b100; color:White; height:100%;">
                                故障已成功移入打印队列 <a onclick="HiddenResult()" style="cursor:pointer;">[确定]</a></div>
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
                                            <%# Function.FormatFaultQueue(Eval("GuZhangContent").ToString(),DateTime.Parse(Eval("ReceivedDate").ToString()),DateTime.Now)%>
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
                                    <asp:TemplateField HeaderText="位置">
                                    <ItemTemplate>
                                    <%# Function.FormatBool(Convert.ToBoolean(Eval("MyBit")),"打印队列","待处理队列")  %>
                                        <asp:Label ID="isonprintlab" runat="server" Text='<%# Eval("MyBit").ToString() %>' Visible="false" Width="12px"></asp:Label>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="常用操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("GuZhangSecondID") %>' runat="server" OnClick="LinkButton1_Click">转发</asp:LinkButton>
                                            &nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" CommandArgument='<%#Eval("GuZhangSecondID") %>'  runat="server" OnClick="LinkButton2_Click">已维护</asp:LinkButton>
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
                                    <input id="Button5" class="btn" style="width: 42px" type="button" value="返回" onclick="javascript:history.go(-1)" /></td>
                            </tr>
                        </table>
                    </div>
                    
                    <div id="havedo" visible="false" runat="server" style="width: 100%; height: auto; text-align: center; margin-top: 50px;
                         margin-left: auto; margin-right: auto;">
                        <table width="500">
                            <tr>
                                <td style=" padding-top:10px; padding-bottom:10px; text-align: right; padding-right: 10px; width: 119px; ">
                                    位置：</td>
                                <td id="postion" style="padding-top:10px; padding-bottom:10px; text-align: left; padding-left: 12px; ">
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
                            </tr>
                            
                             <tr>
                                <td style="padding-top:10px; padding-bottom:10px; text-align: right; padding-right: 10px; width: 119px;">
                                    处理人：</td>
                                <td style="padding-top:10px; padding-bottom:10px; text-align: left; padding-left: 7px;">
                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                    </asp:CheckBoxList></td>
                            </tr>
                            
                            <tr>
                                <td style=" padding-top:10px; padding-bottom:10px; text-align: right; padding-right: 10px; width: 119px; height: 24px;">
                                    处理日期：</td>
                                <td id="Td1" style="padding-top:10px; padding-bottom:10px; text-align: left; padding-left: 12px; height: 24px;">
                                    <asp:TextBox ID="finishdate" CssClass="date_input" runat="server"></asp:TextBox></td>
                            </tr>
                            
                            <tr>
                                <td style="height: 97px; text-align: right; padding-right: 10px; width: 119px;">
                                    备注：</td>
                                <td style="height: 97px; text-align: left; padding-left: 12px;">
                                    <asp:TextBox ID="beizhu" runat="server" Height="59px" TextMode="MultiLine" Width="240px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="height: 36px; text-align: right; padding-right: 10px; width: 119px;">
                                </td>
                                <td style="height: 36px; text-align: left; padding-left: 12px;">
                                    <asp:Button ID="Button3" runat="server" CssClass="btn" Text="确认处理" OnClick="Button3_Click" OnClientClick="return verificationconfir()" />
                                    &nbsp;
                                    <input id="Button6" class="btn" style="width: 42px" type="button" value="返回" onclick="javascript:history.go(-1)" /></td>
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








function FaultForward()
{
   //window.showModalDialog("SecondFaultForward.aspx","","dialogWidth=200px;dialogHeight=100px");
   var a=document.getElementById("listinfor");
   var b=document.getElementById("Forward");
   a.style.display="none";
   b.style.display="block";
   Getusers();
}

function PutintoPrintQue()
{
      $("#putintoqueueresult").css("display","block");
      //settimeout(30000,HiddenResult());
   //}
}

function HiddenResult()
{
    $("#putintoqueueresult").css("display","none");
}










function GetRblSeletedValue(obj) 
{
  var rbltable =$(obj); 
  var rbs= rbltable.getElementsByTagName("INPUT"); 
  var n=0;
  for(var i = 0;i <rbs.length;i++) 
   { 
    if(rbs[i].checked) 
   { 
    n++;
   } 
  } 
  
  if(n==0)
  {
     alert('至少选择一个故障福');
     return false;
  }
 } 
  function $(id) 
 { 
  return document.getElementById(id); 
  } 

</script>

