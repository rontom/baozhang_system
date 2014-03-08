<%@ Page Language="C#" AutoEventWireup="true" CodeFile="副本 left.aspx.cs" Inherits="admin_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body style="margin:0px; padding:0px;background-image:url(../images/menurepeate.jpg); background-repeat:repeat-y;">
    <form id="form1" runat="server">
        <div style="width:203px; height:100%; margin-bottom:0px; margin-left:auto; margin-right:auto;">
        <div style="width:203px; height:87px; background-image:url(../images/menutitle.jpg); background-repeat:no-repeat;"></div>
        <div style="width:203px;">
            <asp:TreeView ID="TreeView1" runat="server" ForeColor="White" Style="margin-top: 13px;
                margin-left: 20px">
                <Nodes>
                    <asp:TreeNode ImageUrl="~/images/plus.gif" Text="最新故障" Value="最新故障">
                        <asp:TreeNode Text="未分类故障" Value="未分类故障"></asp:TreeNode>
                        <asp:TreeNode Text="已分类的故障" Value="已分类的故障"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="我的故障" Value="我的故障">
                        <asp:TreeNode Text="我的故障" Value="我的故障"></asp:TreeNode>
                        <asp:TreeNode Text="故障历史记录" Value="故障历史记录"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="基础数据录入" Value="基础数据录入">
                        <asp:TreeNode Text="用户数据" Value="用户数据"></asp:TreeNode>
                        <asp:TreeNode Text="楼房数据" Value="楼房数据"></asp:TreeNode>
                    </asp:TreeNode>
                </Nodes>
            </asp:TreeView>
        </div>
        </div>
    </form>
</body>
</html>
