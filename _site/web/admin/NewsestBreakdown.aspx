<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsestBreakdown.aspx.cs" EnableEventValidation="false" Inherits="admin_NewsestBreakdown" %>
<%@ Import Namespace="BLL" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>
<%@ Register Assembly="IntegrateWithJavascriptLibrary" Namespace="IntegrateWithJavascriptLibrary"
    TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript" src="../js/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../js/Common.js"></script>
    <link href="../css/date_input.css" type="text/css" rel="stylesheet" />
    <link href="../css/StyleSheet.css" type="text/css" rel="stylesheet" />
    <link href="../css/default.css" type="text/css" rel="Stylesheet" />
    <script src="../js/ajax.js" type="text/javascript"></script>
    <script src="../js/verification.js" type="text/javascript"></script>
    <link href="../css/newsbreak.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript" src="../js/jquery-1.3.2.js"></script>
    <script src="../js/jquery.date_input.js" type="text/javascript"></script>
    <script src="../js/jquery.date_input.zh_CN.js" type="text/javascript"></script>
    
    
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
    
    
    function clickshow(id)
    {
   
			var sURL="Manual_classification.aspx?id="+id;
			var vReturnValue = window.open(sURL,'_blank','Height=300,Width=400,top=200,left=200');
		
      
    }
    
    
  
    </script>
  <style type="text/css">
  .showguzhanginfo{width:95%; margin-left:auto; display:none; margin-right:auto; margin-top:30px;}
  .showguzhanginfo td{background-color:white;}
  a{color:Black; text-decoration:none;}
  a:hover{color:Blue; text-decoration:underline;}
  .itemsty{padding-left:5px; padding-right:5px;text-align:left;}
  .contentcss{ padding-left:4px; padding-right:4px;padding-top:4px; padding-bottom:4px;  }
  </style>


</head>
<body style="margin:0px; padding:0px;  ">
    <form id="form1" runat="server">
    
    <div class="info" style="overflow:hidden;">
        <cc1:TabWebControl ID="TabWebControl1" runat="server" Width="98%" style="margin-left: 7px">
            <cc1:TabPage ID="TabPage1" runat="server" Text="未分类故障" Width="100%">
            <div style="width:98%; margin-left:auto;  margin-right:auto;  text-align:left; height:22px;">
                <asp:Button ID="Button2" runat="server" CssClass="btn" Text="批量删除" OnClick="Button2_Click" OnClientClick="return confirm('是否把选中的故障放入回收站？')" />
                  <img src="../images/newfault.gif" alt="" />
                                最新故障
                                <img src="../images/ergin.gif" alt="" />&nbsp; 2-4天的故障&nbsp;
                                <img src="../images/longtime.gif" alt="" />
                                超过四天的故障
                </div>
            <div style="width:98%; margin-left:auto; margin-top:3px;  margin-right:auto; text-align:right;">
            <table style="width:100%; height:auto;">
            <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="Silver"
                    CellPadding="4" CellSpacing="1" ForeColor="#333333"  GridLines="None" Width="100%" EmptyDataText="暂无任何记录！">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="Checkbox4" type="checkbox" onclick="CheckAll(this,'GridView1')" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox3" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="24px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="联系电话">
                        <ItemTemplate>
                        <%# Function.CheckOnePhone(Eval("PhoneNumber").ToString(),Eval("telephone").ToString()) %>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="短信内容">
                        <ItemTemplate>
                        <%#Function.FormatFaultQueue(Eval("MessageContent").ToString(),Convert.ToDateTime(Eval("ReceivedDate")),DateTime.Now)%>
                        
                         
                        </ItemTemplate>
                        <ItemStyle CssClass="itemsty" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="ReceivedDate" HeaderText="报障日期" SortExpression="ReceivedDate" >
                            <ItemStyle Width="110px" />
                            
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="报障方式">
                        <ItemTemplate>
                        <%# Function.FormatFaultMenth(Eval("menth").ToString())%>
                        
                        </ItemTemplate>
                        <ItemStyle Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="常规操作">
                            <ItemTemplate>
                                <a href='Manual_classification.aspx?id=<%#Eval("GuZhangFirstID")%>'  ><img alt="" src="../images/modifty1.gif" style="border:0px;" id="IMG1" /></a>&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/del1.gif" Height="18px" Width="18px" OnClick="ImageButton2_Click" OnClientClick="return confirm('你确定将该条故障放入回收站吗？')"  CommandArgument='<%#Eval("GuZhangFirstID")%>' />
                            </ItemTemplate>
                          <ItemStyle Width="60px" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="Silver" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EmptyDataRowStyle BackColor="White" HorizontalAlign="Left" />
                </asp:GridView>
                <webdiyer:aspnetpager id="AspNetPager1" runat="server" firstpagetext="首页" forecolor="Black"
                    lastpagetext="尾页" nextpagetext="下一页" onpagechanged="AspNetPager1_PageChanged"
                    pageindexboxtype="DropDownList" prevpagetext="上一页" showpageindexbox="Always"
                    submitbuttontext="Go" textafterpageindexbox="页" textbeforepageindexbox="转到" PageSize="12"></webdiyer:aspnetpager>
            
                </td>
            </tr>
            </table>
            </div>
            
            
            </cc1:TabPage>
            <cc1:TabPage ID="TabPage2" runat="server" Text="已分类故障">
                  <div id="secondfaultlist" style="width:99%; text-align:center; display:block; margin-left:auto; margin-right:auto; margin-top:20px;" runat="server">
                   <div style="width:100%; text-align:left; line-height:25px; float:left; height:100%;">
                       &nbsp; 
                       <img src="../images/noneday.gif" /> 一天之内的故障
                       <img alt="" src="../images/ergin.gif" />&nbsp; 2-4天的故障&nbsp;
                       <img alt="" src="../images/longtime.gif" />
                       超过四天的故障
                        &nbsp;
                                <img src="../images/newfault.gif" alt="" />
                       已处理的故障 &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                       <asp:DropDownList ID="printQueue" runat="server" OnSelectedIndexChanged="printQueue_SelectedIndexChanged" AutoPostBack="True">
                       </asp:DropDownList>
                       <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="185px" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                           <asp:ListItem Selected="True">全部</asp:ListItem>
                           <asp:ListItem>已处理</asp:ListItem>
                           <asp:ListItem>未处理</asp:ListItem>
                       </asp:RadioButtonList></div>
                  <div style="width:100%; height:auto; margin-left:auto; margin-right:auto; text-align:center;">
                      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="DarkGray"
                          BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0px" CellPadding="0" CellSpacing="1"
                          ForeColor="Black" GridLines="Vertical" Width="100%" OnRowDataBound="GridView2_RowDataBound">
                          <FooterStyle BackColor="#CCCC99" />
                          <Columns>
                              <asp:TemplateField>
                                  <HeaderTemplate>
                                      <input id="Checkbox6" type="checkbox" onclick="CheckAll(this,'GridView2')" />
                                      <asp:Label ID="isonprintlab" Visible="false" runat="server" Text="Label"></asp:Label>
                                  </HeaderTemplate>
                                  <ItemTemplate>
                                      <asp:CheckBox ID="CheckBox5" runat="server" />
                                  </ItemTemplate>
                                  <ItemStyle Width="20px" />
                              </asp:TemplateField>
                              <asp:BoundField DataField="name" HeaderText="报障人" SortExpression="name" >
                                  <ItemStyle Width="80px" />
                              </asp:BoundField>
                              <asp:TemplateField HeaderText="地址">
                              <ItemTemplate>
                                 
                             <%#Function.FormatFaultQueue(Convert.ToString(Eval("Address").ToString()),Convert.ToDateTime(Eval("ReceivedDate").ToString()),DateTime.Now,Convert.ToBoolean(Eval("IsDo"))) %>
                              </ItemTemplate>                              <ItemStyle Width="120px"/>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="故障内容" >
                              <ItemTemplate>
                              <%#Eval("GuZhangContent")%>
                              </ItemTemplate>
                              <ItemStyle CssClass="contentcss" />
                              </asp:TemplateField>
                              
                              <asp:BoundField DataField="phone" HeaderText="联系电话" SortExpression="phone" >
                                  <ItemStyle Width="75px" />
                              </asp:BoundField>
                              <asp:BoundField DataField="ReceivedDate" DataFormatString="{0:yy-MM-dd HH:mm}" HeaderText="报障日期" SortExpression="ReceivedDate" >
                                  <ItemStyle Width="80px" />
                              </asp:BoundField>
                              <asp:BoundField DataField="TrueName" HeaderText="负责人" SortExpression="TrueName">
                                  <ItemStyle Width="50px" />
                              </asp:BoundField>
                             
                              <asp:TemplateField HeaderText="报障方式">
                              <ItemTemplate>
                              <%# Function.FormatFaultMenth(Eval("menth").ToString())%>
                              </ItemTemplate>
                              <ItemStyle Width="56px" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="处理确认">
                              <ItemStyle Width="60px" />
                                  <ItemTemplate>
                                      <asp:Label ID="Label1" Visible="false" runat="server" Text='<%#Function.FormatBool(Convert.ToBoolean(Eval("IsDo")),"已处理","未处理")%>'></asp:Label><asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("GuZhangSecondID") %>' OnClick="LinkButton1_Click1"><%#Function.FormatBool(Convert.ToBoolean(Eval("IsDo")),"已维护","未维护")%></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="打印">
                              <ItemStyle Width="40px" />
                                  <ItemTemplate>
                                      <asp:Label ID="isinprint" runat="server" Text="Label"></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="查看">
                                  <ItemTemplate>
                                     
                                      <img  alt="" src="../images/check.gif" style="cursor:hand;" onclick="showfaultinmyfault(<%#Eval("GuZhangSecondID") %>,'secondfaultlist','showsecondfaultinforimmybreak','myfaluinforlistcontent')" />
                                  </ItemTemplate>
                                  <ItemStyle  Width="35px" />
                              </asp:TemplateField>
                          </Columns>
                          <RowStyle BackColor="#F7F7DE" HorizontalAlign="Center" Height="25px" />
                          <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                          <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Height="20px" HorizontalAlign="Center" />
                          <AlternatingRowStyle BackColor="White" />
                      </asp:GridView></div>
                      <div style="width:100%; height:25px; margin-left:auto; margin-right:auto; text-align:right;">
                      <webdiyer:AspNetPager ID="AspNetPager2" runat="server" FirstPageText="首页" LastPageText="尾页"
                          NextPageText="下一页" PrevPageText="上一页" ShowPageIndexBox="Always" Style="margin-top: 7px"
                          SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager2_PageChanged">
                      </webdiyer:AspNetPager></div>
                  </div>
                  
                 <div style="width:100%; text-align:center; display:none;" class="showguzhanginfo" id="showsecondfaultinforimmybreak">
                <div style="width:90%; margin-left:auto; text-align:center; cursor:hand; margin-right:auto; margin-top:16px;" id="myfaluinforlistcontent"></div>
                <div style="width:90%; margin-left:auto; text-align:center; cursor:hand; margin-right:auto; margin-top:16px;"><img alt="" src="../images/return.gif" onclick="Seconfaultreturnback('secondfaultlist','showsecondfaultinforimmybreak')"/></div>
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
                                    &nbsp;&nbsp;
                                    <asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="Button3_Click2" Text="返回"
                                        Width="39px" /></td>
                            </tr>
                        </table>
                    </div>
            </cc1:TabPage>
            <cc1:TabPage ID="TabPage3" runat="server" Text="未分类故障回收站" Width="100%">
            <div class="contentbreak">
               <div class="menubreak">
                   <asp:Button ID="Button1" runat="server" CssClass="btn" Text="批量还原" OnClick="Button1_Click" OnClientClick="return confirm('确定要还原选择的故障吗？')" />&nbsp;
                   <asp:Button ID="CompletelyDel" runat="server" Text="彻底删除" CssClass="btn" OnClick="CompletelyDel_Click" OnClientClick="return confirm('是否彻底删除短信故障?此操作将彻底删除数据')" />&nbsp;
                   <asp:Button ID="Empty" runat="server" CssClass="btn" Text="清空" OnClick="Empty_Click" OnClientClick="return confirm('是否清空？')" /></div>
              
            
            </div>
            
            <div class="showbygrd">  <asp:GridView ID="delfaultlist" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="暂无任何相关记录！">
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="Checkbox1" type="checkbox" onclick="CheckAll(this,'delfaultlist')" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox2" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="短信内容">
                    <ItemTemplate>
                    <%#Eval("MessageContent")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="联系电话">
                    <ItemTemplate>
                    <%# Function.CheckOnePhone(Eval("PhoneNumber").ToString(),Eval("telephone").ToString()) %>
                    </ItemTemplate>
                    <ItemStyle  Width="80px"/>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ReceivedDate" HeaderText="报障时间" SortExpression="ReceivedDate" >
                        <ItemStyle Width="120px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="报障方式">
                  <ItemTemplate>
                  <%# Function.FormatFaultMenth(Eval("menth").ToString().Trim()) %>
                  </ItemTemplate>
                  <ItemStyle Width="60px" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="删除人" DataField="TrueName" >
                        <ItemStyle Width="60px" />
                    </asp:BoundField>
                </Columns>
                <RowStyle BackColor="White" ForeColor="#404040" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <HeaderStyle BackColor="#526BBE" Font-Bold="True" ForeColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <EmptyDataRowStyle Font-Size="12px" />
                </asp:GridView></div>
            <div class="grdpage">
                <webdiyer:AspNetPager ID="AspNetPager3" runat="server" style="margin-right: 10px" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager3_PageChanged">
                </webdiyer:AspNetPager>
            </div>
            </cc1:TabPage>
            <cc1:TabPage ID="TabPage4" runat="server" Text="垃圾短信">
            </cc1:TabPage>
            
        </cc1:TabWebControl></div>
        
      
    </form>
</body>
</html>

<script type="text/javascript">
function showsecondfaultinfo(id)
{
   
   var a=document.getElementById("secondfaultlist");
   var b=document.getElementById("showguzhanginfo");
   a.style.display="none";
   b.style.display="block";
   //b.innerHTML="<img src='../images/loading.gif' alt=''>载入中...";
   
   CheckUserName(id);
}

function hidden()
{
   var a=document.getElementById("secondfaultlist");
   var b=document.getElementById("showguzhanginfo");
   a.style.display="block";
   
   b.style.display="none";
}
 var xmlHttp;
    function createXMLHttpRequest()
    {
        if(window.ActiveXObject)
        {
            xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        else if(window.XMLHttpRequest)
        {
            xmlHttp = new XMLHttpRequest();
        }
    }
    //处理方法
    function CheckUserName(id)
    {
        $.ajax({
       url:'ajax.aspx',
       data:{t:"secondfaultinfor",aa:id},
       timeout: 10000,
       beforeSend:function(){
       $("#showguzhanginfo").html('<img src="../images/loading.gif" alt="">载入中...');
       },
       success:function(result){
           $("#showguzhanginfo").html(result);
        }
    }); 
        
        //document.getElementById("Msg").innerHTML='';
    }
    //回调方法
    function ShowResult()
    {
        if(xmlHttp.readyState==4) 
        {
            if(xmlHttp.status==200)
            {
               document.getElementById("showguzhanginfo").innerHTML=xmlHttp.responseText;
                
            }
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
</script>
