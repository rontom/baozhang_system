<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMSconfig.aspx.cs" Inherits="admin_SMSconfig" %>

<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/default.css" type="text/css" rel="Stylesheet" />
    
    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../js/verification.js" type="text/javascript"></script>
    
    <script type="text/javascript">
    function  CheckSeparator()
    {
       if(!$.trim($("#TextBox1").val()))
       {
           alert('短信分割符必填');
           return false;
       }
       if(CheckStringLengthIsOdd('TextBox1')==false)
       {
           alert('短信分割符格式不正确');
           return false;
       }
       else
       {
          return confirm('修改配置会导致当前的会话中断！是否执行修改？');
       }
    }
    </script>
</head>
<body style="font-size:12px;">
    <form id="form1" runat="server">
        <cc1:TabWebControl ID="TabWebControl1" runat="server" style="margin-top: 10px; margin-left: 10px" Width="98%">
        
            <cc1:TabPage ID="TabPage1" runat="server" Height="400px" Text="短信分隔符设置">
           
    <div style="width:500px; height:auto; margin-left:auto; margin-right:auto; margin-top:120px; text-align:center;">
    <div style="width:100%; height:30px; text-align:left;">
        <asp:TextBox ID="TextBox1" runat="server" Width="323px"></asp:TextBox>(分隔符之间用|号隔开)</div>
    <div style="width:100%; float:left; margin-top:5px; text-align:left;">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="修改" CssClass="btn" OnClientClick="return CheckSeparator()" />
        </div>
        </div>
         </cc1:TabPage>
         
            <cc1:TabPage ID="TabPage2" runat="server" Text="校园网上网用户数据导出">
                <table cellpadding="0" cellspacing="0" style="width:98%; margin-left:auto; margin-right:auto; margin-top:8px;">
                    <tr>
                        <td style="height: 34px">
                            <asp:Button ID="Button2" CssClass="btn" runat="server" Text="导出校园网用户数据到Excel" OnClick="Button2_Click" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="username" HeaderText="账号" SortExpression="username" />
                                    <asp:BoundField DataField="truename" HeaderText="姓名" SortExpression="truename" />
                                    <asp:BoundField DataField="address" HeaderText="地址" SortExpression="address" />
                                    <asp:BoundField DataField="phone" HeaderText="联系电话" SortExpression="phone" />
                                    <asp:BoundField DataField="mobile" HeaderText="手机" SortExpression="mobile" />
                                </Columns>
                            </asp:GridView>
                            
                        </td>
                    </tr>
                    
                </table>
            </cc1:TabPage>
        </cc1:TabWebControl>
    </form>
</body>
</html>
