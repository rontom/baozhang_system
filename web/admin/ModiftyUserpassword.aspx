<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModiftyUserpassword.aspx.cs" Inherits="admin_ModiftyUserpassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript">
    function che()
    {
       
        var newpassword=document.getElementById("newpassword");
        var check=document.getElementById("check");
        if(newpassword.value.length==0||check.value.length==0)
        {
           alert('请填写完整信息');
           return false;
        }
        if(newpassword.value!=check.value)
        {
               alert('两次输入的新密码不一致');
               newpassword.value="";
               check.value="";
               return false;
        }
    }
    </script>
    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
</head>
<body style="font-size:12px;">
    <form id="form1" runat="server">
    <div style="width:100%; height:auto; margin-top:100px; margin-left:auto; margin-right:auto;">
      
       <div style="width:250px; margin-left:auto; margin-right:auto;">
      <div style="width:70px; height:30px; line-height:30px; float:left; text-align:right;">
          新密码：</div>
      <div style="width:150px; float:left; margin-left:10px; height:30px;">
          <asp:TextBox ID="newpassword" runat="server" TextMode="Password"></asp:TextBox></div>
          
       </div>
        <div style="width:250px; margin-left:auto; margin-right:auto;">
      <div style="width:70px; height:30px; line-height:30px; float:left; text-align:right;">
          确认密码：</div>
      <div style="width:150px; float:left; margin-left:10px; height:30px;">
          <asp:TextBox ID="check" runat="server" TextMode="Password"></asp:TextBox></div>
          
       </div>
       
        <div style="width:250px; margin-left:auto; margin-right:auto;">
      <div style="width:70px; height:30px; line-height:30px; float:left; text-align:right;">
         </div>
      <div style="width:150px; float:left; margin-left:10px; height:40px;">
          <asp:Button ID="Button1" runat="server" Style="margin-top: 6px" Text="确认修改" CssClass="btn" OnClick="Button1_Click" OnClientClick="return che()" />
          &nbsp; &nbsp;
          <input id="Button2" class="btn" type="button" onclick="javascript:window.location='BasicData.aspx'" value="返回" /></div>
          
       </div>
          
       </div>
    </form>
</body>
</html>