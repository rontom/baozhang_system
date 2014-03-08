<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoticeManage.aspx.cs" Inherits="admin_NoticeManage" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <link href="../css/StyleSheet.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../js/verification.js" type="text/javascript"></script>
    <script type="text/javascript">
    function verification()
    {
       if(!IsIP($.trim($("#serverip").val())))
       {
           alert('请填写合法的IP地址');
           return false;
       }
        if(!IsPort($.trim($("#port").val())))
       {
           alert('请填写合法的端口号');
           return false;
       }
       
    }
    
    function verificationsms()
    {
      if(!$.trim($("#phonebooklist").val()))
      {
      if(!$.trim($("#SMSContent").val()))
      {
         alert('请填写通知内容');
         return false;
      }
      if(verificationatlistselectoneincheckboxlist('CheckBoxList1')==false)
      {
         alert('至少选择一个短信接收者'); 
         return false;
      }
      }
      else
      {
         return true;
      }
    }
    
    
  function Verificationwebnotice()
  {
      if(!$.trim($("#NoticeTitle").val()))
      {
         alert('通知标题必填');
         return false;
      }
      
      if(!$.trim($("#NoticeContent").val()))
      {
         alert('通知内容');
         return false;
      }
      
      if(!$.trim($("#UserType").val()))
      {
         alert('请选择用户类型');
         return false;
      }
      
      if(!$.trim($("#Validity").val()))
      {
         alert('有效日期必填必填');
         return false;
      }
      
      if(verificationatlistselectoneincheckboxlist('NoticeObj')==false)
      {
         alert('至少选择一个用户');
         return false;
      }
      
      if(!IsInteger($.trim($("#Validity").val())))
      {
         alert('有效期限必须为正整数');
         return false;
      }
  }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="info">
        <cc1:tabwebcontrol id="TabWebControl1" runat="server" Width="98%">
        <cc1:TabPage id="TabPage1" runat="server" Text="发布短信通知">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
           <div style="width:98%; margin-left:auto; margin-right:auto; margin-top:37px;">
               <table cellpadding="0" cellspacing="0" style="width:500px; margin-left:auto; margin-right:auto; height:auto;">
                   <tr>
                       <td style="width: 91px; height: 112px; text-align:right; padding-right:10px;">
                           通知内容：</td>
                       <td style="height: 112px; text-align:left; ;">
                           <asp:TextBox ID="SMSContent" runat="server" Height="95px" TextMode="MultiLine" Width="306px" MaxLength="250"></asp:TextBox>
                          

                           </td>
                       <td style="width:70px;  text-align:left; padding-left:10px; color:Red;">
                           限250字</td>
                   </tr>
                 <tr>
                 <td style="height:auto; text-align:right; padding-right:10px;">
                     接收用户：</td>
                 <td colspan="2" style="height:auto; text-align:left; padding-left:0px; padding-top:15px; padding-bottom:15px;">
                     <asp:DropDownList ID="phonebooklist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="phonebooklist_SelectedIndexChanged">
                     </asp:DropDownList></td>
                 </tr>
                  <tr id="Customizeuser" runat="server" visible="false">
                 <td style="height:auto; text-align:right; padding-right:10px;">
                     自定义用户：</td>
                 <td colspan="2" style="height:auto; text-align:left; padding-left:0px; padding-top:7px; padding-bottom:7px;">
                     <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                     </asp:CheckBoxList></td>
                 </tr>
                    <tr>
                 <td style="height: 37px; text-align:right; padding-right:10px;">
                     </td>
                 <td colspan="2" style="height: 37px; text-align:left;">
                     <asp:Button ID="Button2" runat="server" CssClass="btn" Height="26px" OnClientClick="return verificationsms()" Text="发送" Width="75px" OnClick="Button2_Click" /></td>
                 </tr>
               </table>
           </div>
           </ContentTemplate>
            </asp:UpdatePanel>
        </cc1:TabPage> 
        <cc1:TabPage id="TabPage2" runat="server" Text="发布网络通知">  
       
        <div style="width:98%; margin-left:auto; margin-right:auto; margin-top:50px;"> <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
            <table style="margin-left:auto; margin-right:auto; width:600px;" cellpadding="0" cellspacing="0">
            
                <tr>
                    <td style="height: 40px; text-align:right; width:80px; padding-right:10px;">
                    标题：
                    </td>
                    <td style="height: 40px; text-align:left;">
                        <asp:TextBox ID="NoticeTitle" runat="server" Width="379px"></asp:TextBox>
                    </td>
                    <td style="height: 40px; color:Red; text-align:left; width:120px;">
                        限填50字</td>
                </tr>
                <tr>
                    <td style="height: 118px; text-align:right; width:80px; padding-right:10px;">
                        内容：
                    </td>
                    <td style="height: 118px; text-align:left;">
                        <asp:TextBox ID="NoticeContent" runat="server" Width="377px" Height="101px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td style="height: 118px;color:Red; text-align:left; width:120px;">
                        限填250字</td>
                </tr>
              
                <tr>
                    <td style="height: 40px; text-align:right; width:80px; padding-right:10px;">
                        通知对象：
                    </td>
                    <td style="height: 40px; text-align:left;">
                        &nbsp;<asp:DropDownList ID="UserType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Value="">--用户类型--</asp:ListItem>
                            <asp:ListItem>老师</asp:ListItem>
                            <asp:ListItem>学生</asp:ListItem>
                            <asp:ListItem>超级管理员</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="height: 40px; color:Red; text-align:left; width:120px;">
                    </td>
                </tr>
                 <tr runat="server" id="usertypelist" visible="false">
                    <td style=" text-align:right; width:80px; padding-right:10px;">
                        &nbsp;</td>
                    <td style=" text-align:left;">
                        <asp:CheckBoxList ID="NoticeObj" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                        </asp:CheckBoxList></td>
                    <td style="text-align:left; color:Red; width:120px;">
                        至少选择一个</td>
                </tr> 
                <tr>
                    <td style="height: 40px; text-align:right; width:80px; padding-right:10px;">
                        有效期限：</td>
                    <td style="height: 40px; text-align:left;">
                        &nbsp;<asp:TextBox ID="Validity" runat="server" Width="31px"></asp:TextBox>(/天)</td>
                    <td style="height: 40px; color:Red;text-align:left; width:120px;">
                        必填</td>
                </tr>
               
                <tr>
                    <td style="height: 40px; text-align:right; width:80px; padding-right:10px;">
                        </td>
                    <td style="height: 40px; text-align:left;">
                        &nbsp;<asp:Button ID="Button3" runat="server" OnClientClick="return Verificationwebnotice()" CssClass="btn" Height="25px" Text="发布通知"
                            Width="83px" OnClick="Button3_Click" /></td>
                    <td style="height: 40px; text-align:left; width:120px;">
                    </td>
                </tr>
            </table></ContentTemplate></asp:UpdatePanel>
        
        </div>
        
        </cc1:TabPage>
            <cc1:TabPage ID="TabPage3" runat="server" Text="短信设置">
            <div style="width:98%; margin-left:auto; text-align:center; margin-right:auto; margin-top:20px;">
                <table style="width:400px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 140px; height: 36px; text-align:right; padding-right:8px;">
                            服务器IP：</td>
                        <td style="height: 36px; text-align:left;">
                            <asp:TextBox ID="serverip" runat="server" Width="213px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 140px; height: 36px; text-align:right; padding-right:8px;">
                            端口：</td>
                        <td style="height: 36px; text-align:left;">
                            <asp:TextBox ID="port" runat="server" Width="49px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 140px; height: 36px; text-align:right; padding-right:8px;">
                            </td>
                        <td style="height: 36px; text-align:left;">
                            <asp:Button ID="Button1" runat="server" Text="确认修改" CssClass="btn" OnClientClick="return verification()" OnClick="Button1_Click" /></td>
                    </tr>
                    
                </table>
            
            </div>
            
            </cc1:TabPage>
        </cc1:tabwebcontrol>
    
    </div>
    </form>
</body>
</html>
