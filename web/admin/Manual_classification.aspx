<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manual_classification.aspx.cs" Inherits="admin_Manual_classification" %>

<!DOCTYPE  html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
   
    <style type="text/css">
    td{ background-color:white;}
    </style>
</head>
<body style="font-size:12px;"  >
    <form id="form1" runat="server">
   
    <div style="width:600px; height:auto; margin-left:auto; margin-right:auto;">
        <div style="margin-top:20px; height:auto; width:600px;">
        <table style="width:100%; background-color:Gray;" cellpadding="0" cellspacing="1">
                 <tr>
                    <td style="width:71px; height: 58px; text-align:right; padding-right:10px;">
                        原始故障：</td>
                    <td colspan="3" id="aa" style="height: 58px; padding-left:8px; padding-left:8px;">
                    <%=a%>
                        </td>
                    
                </tr>
                <tr>
                    <td style="width:71px; height: 35px; text-align:right; padding-right:10px;">
                        姓名：</td>
                    <td style="height: 35px; width: 201px;">
                        <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 5px"></asp:TextBox></td>
                    <td style="width:75px; height: 35px; text-align:right; padding-right:10px;">
                        联系电话：</td>
                     <td style="height: 35px; width: 223px;">
                         <asp:TextBox ID="TextBox5" runat="server" Width="170px" style="margin-left: 6px"></asp:TextBox></td>
                </tr>
                
                 <tr>
                    <td style="width:71px; height: 94px; text-align:right; padding-right:10px;">
                        故障内容：</td>
                    <td colspan="3" style="height: 94px;">
                        <asp:TextBox ID="TextBox1" runat="server" Height="76px" TextMode="MultiLine" Width="461px" style="margin-left: 6px"></asp:TextBox></td>
                   
                </tr>
                
                <tr>
                    <td style="width:71px; height: 38px; text-align:right; padding-right:10px;">
                        联系地址：</td>
                    <td colspan="3" style="height: 38px;">
                        <asp:TextBox ID="TextBox2" runat="server" Height="19px" Width="465px" style="margin-left: 6px"></asp:TextBox></td>
                    
                </tr>
                
                 <tr>
                    <td style="width:71px; height: 35px; text-align:right; padding-right:10px;">
                        转发：</td>
                    <td style="height: 35px; width: 201px;">
                        <asp:DropDownList ID="DropDownList1" runat="server" style="margin-left: 6px">
                        </asp:DropDownList></td>
                    <td style="width:75px; height: 35px; text-align:right; padding-right:10px;">
                        故障地点：</td>
                     <td style="height: 35px; width: 223px;">
                         <asp:DropDownList ID="DropDownList2" runat="server" style="margin-left: 6px">
                         </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width:71px; height: 63px; text-align:right; padding-right:10px;">
                        转发说明：</td>
                    <td colspan="3" style="height: 63px;">
                        <asp:TextBox ID="TextBox3" runat="server" Height="46px" Width="465px" style="margin-left: 6px" TextMode="MultiLine"></asp:TextBox></td>
                    
                </tr>
                
                <tr>
                    <td colspan="4" style="height: 57px; text-align:center; ">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="确认短信" OnClientClick="return CheckValidate()" />
                        &nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" CssClass="btn" Text="返回" Width="42px" OnClick="Button2_Click" /></td>
                   
                    
                </tr>
         </table>
             
       </div>
    </div>
    </form>
</body>
</html>

<script type="text/javascript">
function CheckValidate()
    {
        if(!$.trim($("#TextBox4").val()))
        {
              alert('请填写报障人姓名');
              return false;
        }
        if(!$.trim($("#TextBox5").val()))
        {
             alert('请填写电话号码');
             return false;
        }
        if(!$.trim($("#TextBox2").val()))
        {
            alert('地址必须填写');
            return false;
        }
        
        if(!$.trim($("#DropDownList2").val()))
        {
            alert('选择故障的范围');
            return false;
        }
       
    }
</script>
