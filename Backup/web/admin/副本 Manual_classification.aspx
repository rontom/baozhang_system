<%@ Page Language="C#" AutoEventWireup="true" CodeFile="副本 Manual_classification.aspx.cs" Inherits="admin_Manual_classification" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
    function dip()
    {
       document.getElementById("aa").innerHTML="<%=a %>";
    }
    
    </script>
</head>
<body style="font-size:12px;" onload="dip()" >
    <form id="form1" runat="server">
   
    <div style="width:400px; height:auto; margin-left:auto; margin-right:auto;">
        <div style="margin-top:20px; height:auto; width:400px;">
             <div style="width:100px; text-align:right; float:left; height:100%; ">
                 <table style="width:100%; height:100%;">
                     <tr>
                         <td valign="middle">
                         原始故障：
                         </td>
         
                     </tr>
                 </table></div>
             <div style="width:270px; float:right; height:100%; ">
                 <table style="width:100%; height:100%;">
                     <tr>
                         <td valign="middle" id="aa">
                             
                         
                         </td>
         
                     </tr>
                 </table>
             </div>
        </div>
        <div style="margin-top:10px; height:30px; width:400px;">
             <div style="width:100px; text-align:right; float:left; height:100%; line-height:30px; ">
                 姓名：</div>
             <div style="width:270px; float:right; text-align:center; height:100%; line-height:30px; ">
                 <asp:TextBox ID="TextBox1" runat="server" Width="249px"></asp:TextBox></div>
        </div>
        <div style="margin-top:10px; height:30px; width:400px;">
             <div style="width:100px; text-align:right; float:left; height:100%; line-height:30px; ">
                 联系电话：</div>
             <div style="width:270px; float:right; text-align:center; height:100%; line-height:30px; ">
                 <asp:TextBox ID="TextBox2" runat="server" Width="253px"></asp:TextBox></div>
        </div>
        <div style="margin-top:10px; height:50px; width:400px;">
             <div style="width:100px; text-align:right; float:left; height:100%; line-height:50px; ">
                 故障内容：</div>
             <div style="width:270px; float:right; text-align:center; height:100%; line-height:50px; ">
                 <asp:TextBox ID="TextBox4" runat="server" Height="37px" TextMode="MultiLine" Width="253px"></asp:TextBox></div>
        </div>
        <div style="margin-top:10px; height:50px; width:400px;">
             <div style="width:100px; text-align:right; float:left; height:100%; line-height:50px; ">
                 联系地址：</div>
             <div style="width:270px; float:right; text-align:center; height:100%; line-height:50px; ">
                 <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Width="253px" Height="38px"></asp:TextBox></div>
        </div>
        
        <div style="margin-top:10px; height:50px; width:400px;">
             <div style="width:100px; text-align:right; float:left; height:100%; line-height:50px; ">
                 故障转发：</div>
             <div style="width:270px; float:right; text-align:center; height:100%; ">
                  <table style="width:100%; height:100%;">
                     <tr>
                         <td valign="middle">
                             <asp:DropDownList ID="DropDownList1" runat="server" Width="253px">
                             </asp:DropDownList></td>
         
                     </tr>
                 </table>
                 </div>
                 
        </div>
        
        <div style="margin-top:10px; height:50px; width:400px;">
             <div style="width:100px; text-align:right; float:left; height:100%; line-height:50px; ">
                 故障地点：</div>
             <div style="width:270px; float:right; text-align:center; height:100%; ">
                  <table style="width:100%; height:100%;">
                     <tr>
                         <td valign="middle">
                             <asp:DropDownList ID="DropDownList2" runat="server" Width="253px">
                             </asp:DropDownList></td>
         
                     </tr>
                 </table>
                 </div>
                 
        </div>
        <div style="margin-top:10px; height:50px; width:400px;">
             <div style="width:100px; text-align:right; float:left; height:100%; line-height:50px; ">
                 备注：</div>
             <div style="width:270px; float:right; text-align:center; height:100%; ">
                  <table style="width:100%; height:100%;">
                     <tr>
                         <td valign="middle">
                             <asp:TextBox ID="TextBox5" runat="server" Height="37px" TextMode="MultiLine" Width="251px"></asp:TextBox></td>
         
                     </tr>
                 </table>
                 </div>
                 
        </div>
        
        <div style="margin-top:10px; height:50px; text-align:center; width:400px;">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Button1" runat="server" Text="确认短信" CssClass="btn" OnClick="Button1_Click" />
            &nbsp; &nbsp; &nbsp;
            <input id="Button2" type="button" value="返回" onclick="history.go(-1)" class="btn" style="width: 48px" /></div>
    </div>
    </form>
</body>
</html>
