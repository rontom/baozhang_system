<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mybreakdown.aspx.cs" Inherits="admin_Mybreakdown" %>

<%@ Register Assembly="dotnetCHARTING" Namespace="dotnetCHARTING" TagPrefix="dotnetCHARTING" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

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
    
    <script type="text/javascript" src="../js/Common.js"></script>
    <link href="../css/date_input.css" type="text/css" rel="stylesheet" />
    <script src="../js/verification.js" type="text/javascript"></script>
    <script src="../js/default.js" type="text/javascript"></script>

    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
     <script src="../js/jquery.date_input.js" type="text/javascript"></script>
     <style type="text/css">
  .showguzhanginfo{width:95%; margin-left:auto; display:none; margin-right:auto; margin-top:30px;}
  .showguzhanginfo td{background-color:white;}
   a{text-decoration:none; color:#040404}
   a:hover{text-decoration:underline;}
   a:visited{color:#040404};
  </style>
    
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
    <script src="../js/ajax.js" type="text/javascript"></script>

        <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="info">
            <cc1:TabWebControl ID="TabWebControl1" runat="server" Width="98%" style="margin-bottom: 30px">
                <cc1:TabPage ID="TabPage1" runat="server" Text="未处理的故障">
                    <div style="width: 100%; height: auto; display: block; margin-left: auto; margin-right: auto;"
                        id="listinfor" runat="server">
                        <div style="width: 95%; text-align: center; margin-left: auto; margin-right: auto;
                            margin-top: 0px;">
                            </div>
                        <div style="width: 99%; text-align: left; height: 25px; margin-top: 1px; margin-left: auto;
                            margin-right: auto;">
                            <div style="width:670px; line-height:25px; float:left; height:100%;">
                            &nbsp;<asp:Button ID="putintodustbin" runat="server" Text="放入回收站" OnClientClick="return PutIntoRecycle_Bin()" CssClass="btn" OnClick="Button1_Click" />&nbsp;
                            <asp:Button ID="BatchFoward" runat="server" Text="批量转发" CssClass="btn" OnClientClick="return FaultForward()" OnClick="Button2_Click" />&nbsp;
                            <asp:DropDownList ID="printQueue" runat="server" AutoPostBack="True" OnSelectedIndexChanged="printQueue_SelectedIndexChanged" Font-Size="12px">
                            </asp:DropDownList>
                                <img src="../images/newfault.gif" alt="" />
                                最新故障
                                <img src="../images/ergin.gif" alt="" />&nbsp; 2-4天的故障&nbsp;
                                <img src="../images/longtime.gif" alt="" />
                                超过四天的故障</div>
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
                                            <input id="Checkbox2" type="checkbox"   />
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
                                        <a href="javascript:showfaultinmyfault(<%#Eval("GuZhangSecondID") %>,'listinfor','showsecondfaultinforimmybreak','myfaluinforlistcontent')">
                                            <%# Function.FormatFaultQueue(Eval("GuZhangContent").ToString(),DateTime.Parse(Eval("ReceivedDate").ToString()),DateTime.Now)%></a>
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
                                    <asp:BoundField DataField="ReceivedDate" HeaderText="报障日期" >
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="打印">
                                    <ItemTemplate>
                                    <%# Function.FormatBool(Convert.ToBoolean(Eval("MyBit")),"打印队列","待处理队列")  %>
                                        <asp:Label ID="isonprintlab" runat="server" Text='<%# Eval("MyBit").ToString() %>' Visible="false" Width="12px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="54px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="常用操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("GuZhangSecondID") %>' runat="server" OnClick="LinkButton1_Click">转发</asp:LinkButton>
                                            &nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" CommandArgument='<%#Eval("GuZhangSecondID") %>'  runat="server" OnClick="LinkButton2_Click">已维护</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="75px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle BorderStyle="None" Font-Size="12px" ForeColor="Black" />
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
                                    转发说明：</td>
                                <td style="height: 97px; text-align: left; padding-left: 12px;">
                                    <asp:TextBox ID="TextBox1" runat="server" Height="59px" TextMode="MultiLine" Width="240px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="height: 36px; text-align: right; padding-right: 10px; width: 119px;">
                                </td>
                                <td style="height: 36px; text-align: left; padding-left: 12px;">
                                    <asp:Button ID="confirmtoForward" runat="server" CssClass="btn" Text="确认转发" OnClick="Button4_Click" />
                                    &nbsp;
                                    <input id="Button5" class="btn" style="width: 42px" type="button" value="返回" onclick="javascript:history.go(-1)" /></td>
                            </tr>
                        </table>
                    </div>
                    
                    <div id="havedo" visible="false" runat="server" style="width: 100%; height: auto; text-align: center; margin-top: 10px;
                         margin-left: auto; margin-right: auto;">
                        <table width="500">
                            <tr>
                                <td style=" padding-top:10px; padding-bottom:10px; text-align: right; padding-right: 10px; width: 119px; ">
                                    位置：</td>
                                <td id="postion" style="padding-top:10px; padding-bottom:10px; text-align: left; padding-left: 12px; ">
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
                            </tr>
                            
                             <tr>
                                <td style=" padding-top:10px; padding-bottom:10px; text-align: right; padding-right: 10px; width: 119px; ">
                                    故障内容：</td>
                                <td id="Td2" style="padding-top:10px; padding-bottom:10px; text-align: left; padding-left: 12px; ">
                                    <asp:Literal ID="Literal2" runat="server"></asp:Literal></td>
                            </tr>
                            
                            <tr>
                                <td style=" padding-top:10px; padding-bottom:10px; text-align: right; padding-right: 10px; width: 119px; ">
                                    联系电话：</td>
                                <td id="Td3" style="padding-top:10px; padding-bottom:10px; text-align: left; padding-left: 12px; ">
                                    <asp:Literal ID="Literal3" runat="server"></asp:Literal></td>
                            </tr>
                            
                            
                             <tr>
                                <td style="padding-top:10px; padding-bottom:10px; text-align: right; padding-right: 10px; width: 119px; height: 143px;">
                                    处理人：</td>
                                <td style="padding-top:10px; padding-bottom:10px; text-align: left; padding-left: 7px; height: 143px;">
                                <div style="width:90px; height:100%; float:left;">
                                    <asp:ListBox ID="listall" runat="server" Height="154px" Width="86px" CssClass="listbox" SelectionMode="Multiple"></asp:ListBox></div>
                                    <div style="width:40px;  height:100%; margin-left:20px; float:left;">
                                        <table style="width:100%; height:100%;">
                                            <tr>
                                                <td>
                                                    <input id="moveright" class="btn" onclick="add()" type="button" value=">>>" /><br />
                                                    <br />
                                                    <input id="moveleft" class="btn" type="button" onclick="del()" value="<<<" /></td>
                                                </tr>
                                        </table>
                                    </div>
                                    <div style="width:90px; margin-left:20px; height:100%; float:left;">
                                    <asp:ListBox ID="listtarget" runat="server" Height="163px" Width="87px" CssClass="listbox" SelectionMode="Multiple"></asp:ListBox></div>
                                    <asp:TextBox ID="hiddenstring" style="display:none;" runat="server" Width="213px"></asp:TextBox>
                                    <asp:TextBox ID="hidendopeoples" runat="server"  style="display:none;"></asp:TextBox></td>
                            </tr>
                            
                            <tr>
                                <td style=" padding-top:10px; padding-bottom:10px; text-align: right; padding-right: 10px; width: 119px; height: 19px;">
                                    处理日期：</td>
                                <td id="Td1" style="padding-top:10px; padding-bottom:10px; text-align: left; padding-left: 12px; height: 19px;">
                                    <asp:TextBox ID="finishdate" CssClass="date_input" runat="server"></asp:TextBox></td>
                            </tr>
                            
                            <tr>
                                <td style="height: 75px; text-align: right; padding-right: 10px; width: 119px;">
                                    处理结果：</td>
                                <td style="height: 75px; text-align: left; padding-left: 12px;">
                                    <asp:TextBox ID="beizhu" runat="server" Height="59px" TextMode="MultiLine" Width="240px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="height: 36px; text-align: right; padding-right: 10px; width: 119px;">
                                </td>
                                <td style="height: 36px; text-align: left; padding-left: 12px;">
                                    <asp:Button ID="confirmtodo" runat="server" CssClass="btn" Text="确认处理" OnClick="Button3_Click" OnClientClick="return verificationconfir()" />
                                    &nbsp;
                                    <input id="Button6" class="btn" style="width: 42px" type="button" value="返回" onclick="javascript:history.go(-1)" /></td>
                            </tr>
                        </table>
                    </div>
                <!--故障显示模块-->   
                <div style="width:100%; text-align:center; display:none;" class="showguzhanginfo" id="showsecondfaultinforimmybreak">
                <div style="width:90%; margin-left:auto; text-align:center; cursor:hand; margin-right:auto; margin-top:30px;" id="myfaluinforlistcontent"></div>
                <div style="width:90%; margin-left:auto; text-align:center; cursor:hand; margin-right:auto; margin-top:16px;"><img alt="" src="../images/return.gif" onclick="Seconfaultreturnback('listinfor','showsecondfaultinforimmybreak')"/></div>
                
                </div>
                </cc1:TabPage>
                <cc1:TabPage ID="TabPage2" runat="server" Text="已处理的故障">
                <div style="width:100%; margin-left:auto; margin-right:auto; margin-top:10px;" id="listhavedonefault">
                    <div style="width:100%; margin-left:auto; margin-right:auto; height:30px; text-align:right;">
                        <table style="width:320px; height:100%;" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 86px; text-align:right; padding-right:3px; height: 30px;">
                                    <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="12px">
                                        <asp:ListItem>姓名</asp:ListItem>
                                        <asp:ListItem>地址</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="width: 190px; height: 28px;">
                                    <asp:TextBox ID="TextBox2" runat="server" Width="180px"></asp:TextBox></td>
                                <td style="height: 28px">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/gif-0564.gif"
                                        /></td>
                            </tr>
                        </table>
                     </div>
                     
                     <div style="width:100%; margin-left:auto; margin-right:auto; text-align:right;">
                         <asp:GridView ID="haovedonefaultdrid" runat="server" BackColor="Gray" CellPadding="4" CellSpacing="1"
                             ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
                             <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                             <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                             <EditRowStyle BackColor="#999999" />
                             <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                             <Columns>
                                 <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" >
                                     <ItemStyle Width="60px" />
                                 </asp:BoundField>
                                 <asp:TemplateField HeaderText="故障内容">
                                 <ItemTemplate>
                                 <a href="javascript:showfaultinmyfault(<%#Eval("GuZhangSecondID") %>,'listhavedonefault','showmyhaovedonefaultbyajax','myhavedonefaultinfor')">
                                 <%#Eval("GuZhangContent") %></a>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:BoundField DataField="phone" HeaderText="联系电话" SortExpression="phone" >
                                     <ItemStyle Width="110px" />
                                 </asp:BoundField>
                                 
                                 <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
                                 <asp:BoundField DataField="DoDate" DataFormatString="{0:yy-MM-dd HH:mm}" HeaderText="处理时间">
                                     <ItemStyle Width="80px" />
                                 </asp:BoundField>
                                 <asp:BoundField HeaderText="报障时间" DataFormatString="{0:yy-MM-dd HH:mm}" DataField="ReceivedDate" >
                                     <ItemStyle Width="80px" />
                                 </asp:BoundField>
                                
                                 <asp:TemplateField HeaderText="报障方式">
                                  
                                 <ItemTemplate>
                                 <%# Function.FormatFaultMenth(Eval("menth").ToString()) %>
                                 </ItemTemplate>
                                 <ItemStyle Width="80px" />
                                 </asp:TemplateField>
                             </Columns>
                         </asp:GridView>
                         <webdiyer:AspNetPager ID="AspNetPager3" runat="server" FirstPageText="首页" LastPageText="尾页"
                             NextPageText="下一页" PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowPageIndexBox="Always"
                             SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager3_PageChanged">
                         </webdiyer:AspNetPager>
                     
                     </div>
                </div>
                
                <div style="width:100%; text-align:center; display:none;" class="showguzhanginfo" id="showmyhaovedonefaultbyajax">
                <div style="width:90%; margin-left:auto; text-align:center; cursor:hand; margin-right:auto; margin-top:30px;" id="myhavedonefaultinfor"></div>
                <div style="width:90%; margin-left:auto; text-align:center; cursor:hand; margin-right:auto; margin-top:16px;"><img alt="" src="../images/return.gif" onclick="Seconfaultreturnback('listhavedonefault','showmyhaovedonefaultbyajax')"/></div>
                </div>
                </cc1:TabPage>
                <cc1:TabPage ID="TabPage3" runat="server" Text="我的回收站">
                <div style="width:100%; height:auto;" id="Recycle_Bin_list">
                <div style="width:100%; margin-left:auto; margin-top:10px; margin-right:auto; text-align:left; height:26px;">
                    <asp:Button ID="Button2" runat="server" CssClass="btn" OnClientClick="return checkselectatleastone('SeconFaultRecycle_Bin','Checkbox6','至少选择一项','您确定要还原所选中的项吗？')" Text="批量还原" OnClick="Button2_Click1" />
                    <asp:Button ID="BatchDelInRecycle_Bin" runat="server" CssClass="btn" Text="批量删除" OnClientClick="return checkselectatleastone('SeconFaultRecycle_Bin','Checkbox6','至少选择一项','您确定要删除所选中的项吗？此操作将永远删除数据！')" OnClick="BatchDelInRecycle_Bin_Click" />
                    <asp:Button ID="EmptyInRecycle_Bin" runat="server" CssClass="btn" Text="清空回收站" OnClientClick="return Emptyseconfaultbyjs()" OnClick="EmptyInRecycle_Bin_Click" /></div>
                    
                     <div style="width:100%; margin-left:auto; margin-top:2px; margin-right:auto; text-align:right;">
                         <asp:GridView ID="SeconFaultRecycle_Bin" runat="server" BackColor="White" BorderColor="#CC9966"
                             BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False" EmptyDataText="回收站为空！">
                             <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                             <RowStyle BackColor="White" ForeColor="#330099" HorizontalAlign="Center" />
                             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                             <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" HorizontalAlign="Center" />
                             <Columns>
                                 <asp:TemplateField>
                                     <HeaderTemplate>
                                         <input id="Checkbox6" type="checkbox" onclick=" CheckAll(this,'SeconFaultRecycle_Bin')" />
                                     </HeaderTemplate>
                                     <ItemTemplate>
                                         <asp:CheckBox ID="CheckBox5" runat="server" />
                                     </ItemTemplate>
                                     <ItemStyle Width="30px" />
                                 </asp:TemplateField>
                                 <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" >
                                     <ItemStyle Width="60px" />
                                 </asp:BoundField>
                                 <asp:TemplateField HeaderText="故障内容">
                                 <ItemTemplate>
                                  <a href="javascript:showfaultinmyfault(<%#Eval("GuZhangSecondID") %>,'Recycle_Bin_list','showfaultinRecycle_Bin','showfaultinRecycle_Bin_infor')">
                                 <%#Eval("GuZhangContent") %></a>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
                                 <asp:BoundField DataField="ReceivedDate" HeaderText="日期" SortExpression="ReceivedDate" >
                                     <ItemStyle Width="110px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="phone" HeaderText="联系电话" SortExpression="phone" >
                                     <ItemStyle Width="110px" />
                                 </asp:BoundField>
                                 <asp:TemplateField HeaderText="还原">
                                     <ItemTemplate>
                                         <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Eval("GuZhangSecondID") %>' runat="server" ImageUrl="~/images/returnback.gif" OnClientClick="return confirm('你确定要还原所选的故障')" OnClick="ImageButton2_Click" />
                                     </ItemTemplate>
                                 </asp:TemplateField>
                             </Columns>
                             <EmptyDataRowStyle Font-Size="12px" HorizontalAlign="Center" />
                         </asp:GridView>
                         <webdiyer:AspNetPager ID="AspNetPager4" runat="server" FirstPageText="首页" LastPageText="尾页"
                             NextPageText="下一页" PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowPageIndexBox="Always"
                             SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager4_PageChanged">
                         </webdiyer:AspNetPager>
                     
                     </div>
                
                </div>
                
                
                <div style="width:100%; text-align:center; display:none;" class="showguzhanginfo" id="showfaultinRecycle_Bin">
                <div style="width:90%; margin-left:auto; text-align:center; cursor:hand; margin-right:auto; margin-top:30px;" id="showfaultinRecycle_Bin_infor"></div>
                <div style="width:90%; margin-left:auto; text-align:center; cursor:hand; margin-right:auto; margin-top:16px;"><img alt="" src="../images/return.gif" onclick="Seconfaultreturnback('Recycle_Bin_list','showfaultinRecycle_Bin')"/></div>
                
                </div>
                </cc1:TabPage>
                
                <cc1:TabPage ID="TabPage4" runat="server" Text="打印队列">
                <div style="width:100%; height:auto; margin-left:auto; margin-right:auto;" id="listprintqueues" runat="server">
                  <div style="width:95%; margin-left:auto; text-align:left; margin-right:auto; margin-top:10px; height:26px;">
                      <asp:DropDownList ID="printqueinqueue" runat="server" AutoPostBack="True" OnSelectedIndexChanged="printqueinqueue_SelectedIndexChanged">
                      </asp:DropDownList>&nbsp;
                      <asp:Button ID="printfaulttablebtn" runat="server" CssClass="btn" Text="打印故障单" OnClientClick="return checkselectatleastone('GridView2','Checkbox4','至少选择一项','您确定要打印所选中的项吗？')" OnClick="printfaulttablebtn_Click" />&nbsp;
                      <asp:Button ID="BatchMoveoutbtn" runat="server" CssClass="btn" Text="批量移出打印队列" OnClientClick="return checkselectatleastone('GridView2','Checkbox4','至少选择一项','您确定要把选中项从打印队列中移出吗？')" OnClick="BatchMoveoutbtn_Click" />&nbsp;
                      <asp:Button ID="Button1" runat="server" CssClass="btn" Text="清空打印队列" OnClientClick="return checkselectatleastone('GridView2','Checkbox4','至少选择一项','是否清空打印队列？')" OnClick="Button1_Click1" /></div>
                   <div style="width:95%; text-align:right; margin-left:auto;  margin-right:auto; margin-top:3px;">
                       <asp:GridView ID="GridView2" runat="server" BackColor="Black" BorderColor="Black"
                           BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False" HorizontalAlign="Center" EmptyDataText="暂无任何数据">
                           <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                           <RowStyle BackColor="White" ForeColor="#330099" HorizontalAlign="Center" />
                           <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                           <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                           <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" HorizontalAlign="Center" />
                           <Columns>
                               <asp:TemplateField>
                                   <HeaderTemplate>
                                       <input id="Checkbox4" type="checkbox" onclick="CheckAll(this,'GridView2')"  />
                                   </HeaderTemplate>
                                   <ItemTemplate>
                                    
                                       <asp:CheckBox ID="CheckBox3"  runat="server" />
                                   </ItemTemplate>
                                   <ItemStyle Width="15px" />
                               </asp:TemplateField>
                               <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" >
                                   <ItemStyle Width="60px" />
                               </asp:BoundField>
                               <asp:TemplateField HeaderText="内容">
                               <ItemTemplate>
                               <a href="javascript:showfaultinmyfault(<%#Eval("faultid") %>,'listprintqueues','printqueuelistbyajax','printqueuelistbyajax_infor')">
                               <%#Eval("GuZhangContent") %></a>
                               </ItemTemplate>
                              
                               </asp:TemplateField>
                               <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
                               <asp:BoundField DataField="ReceivedDate" HeaderText="日期" SortExpression="ReceivedDate" >
                                   <ItemStyle Width="120px" />
                               </asp:BoundField>
                               <asp:TemplateField HeaderText="操作">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton3" CommandArgument='<%#Eval("faultid") %>' runat="server" OnClick="LinkButton3_Click" OnClientClick="return confirm('你确定要把本条记录移出打印队列吗？')">移出队列</asp:LinkButton>
                                   </ItemTemplate>
                                   <ItemStyle Width="70px" />
                               </asp:TemplateField>
                           </Columns>
                           <EmptyDataRowStyle BackColor="White" Font-Size="12px" HorizontalAlign="Center" />
                       </asp:GridView>
                       <webdiyer:AspNetPager ID="AspNetPager2" runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager2_PageChanged">
                       </webdiyer:AspNetPager>
                      </div>
                
                </div>
                
               <div style="width:100%; text-align:center; display:none;" class="showguzhanginfo" id="printqueuelistbyajax">
                <div style="width:90%; margin-left:auto; text-align:center; cursor:hand; margin-right:auto; margin-top:30px;" id="printqueuelistbyajax_infor"></div>
                <div style="width:90%; margin-left:auto; text-align:center; cursor:hand; margin-right:auto; margin-top:16px;"><img alt="" src="../images/return.gif" onclick="Seconfaultreturnback('listprintqueues','printqueuelistbyajax')"/></div>
                
                </div>
                
                </cc1:TabPage>
                <cc1:TabPage ID="TabPage5" runat="server" Text="故障统计报表">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <div style="width:98%; margin-left:auto; margin-right:auto; height:auto; margin-top:10px;">
                 <div style="width:100%; text-align:left; margin-left:auto; margin-right:auto;">
                     <asp:DropDownList ID="CheckFaultChartByYear" runat="server">
                     </asp:DropDownList>
                     <asp:Button ID="Button3" runat="server" CssClass="btn" Text="查看" OnClick="Button3_Click1" OnClientClick="return SelectArightYear()" /></div>
                 
                </div>
                <div style="width:100%; height:auto; text-align:center; margin-top:5px;">
                    <dotnetcharting:chart id="Chart1" runat="server" EmptyElementText="ada" ImageFormat="Jpg" Height="300px" Width="400px">
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
                                    <Line Length="4" />
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
                    </dotnetcharting:chart>
                </div>
                
                </ContentTemplate>
                    </asp:UpdatePanel>
                </cc1:TabPage>
            </cc1:TabWebControl></div>
    </form>
</body>
</html>

<script type="text/javascript">
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

function PutIntoRecycle_Bin()
{
if(verificationatlistselectone('GridView1','Checkbox2')==false)
{
alert('至少选择一项');
return false;
}
else
{
return confirm('你确定要把选中项移入回收站吗？');
}
}

function putintoprintqueuecheck()
{
if(verificationatlistselectone('GridView1','Checkbox2')==false)
{
$('#printQueue')[0].selectedIndex =0;
alert('至少选择一项');
return false;

}
else
{
return true;
}

}

function FaultForward()
{
if(verificationatlistselectone('GridView1')==false)
{
alert('至少选择一项');
return false;
}
else
{
   var a=document.getElementById("listinfor");
   var b=document.getElementById("Forward"); 
   a.style.display="none";
   b.style.display="block";
   Getusers();
   return true;
}
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


function checkbatchdel()
{
   if(verificationatlistselectone('SeconFaultRecycle_Bin')==false)
   {
       alert('至少选择其中一项');
       return false;
   }
   else
   {
       return confirm('你确定要删除回收站中选中的记录，此操作将永久删除故障');
   }
}


function Emptyseconfaultbyjs()
{
   if(verificationatlistselectone('SeconFaultRecycle_Bin')==false)
   {
       alert('至少选择其中一项');
       return false;
   }
   else
   {
       return confirm('你确定要清空回收站中选中的记录，此操作将永久删除故障');
   }
}


function showfaultinmyfault(id,obj,target,myfaluinforlistcontent)
{
$("#"+obj).css("display","none");
$("#"+target).css("display","block");
Getsecondfaultinfobyajax(id,myfaluinforlistcontent);
}

function Seconfaultreturnback(obj,target)
{
$("#"+obj).css("display","block");
$("#"+target).css("display","none");
}


function SelectArightYear()
{
  if(!$.trim($("#CheckFaultChartByYear").val()))
  {
     alert('请选择查看的年份');
     return false;
  }
}





</script>

