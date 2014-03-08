<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BasicData.aspx.cs" Inherits="admin_BasicData" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>
<%@ Register Assembly="IntegrateWithJavascriptLibrary" Namespace="IntegrateWithJavascriptLibrary"
    TagPrefix="cc2" %>
<%@ Import Namespace="BLL" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
     td{background-color:white}
    </style>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>

    <script src="../js/verification.js" type="text/javascript"></script>

    <script type="text/javascript">
    function showdis()
    {
        var ty=document.getElementById("DropDownList2");
        if(ty.value=='学生')
        {
           document.getElementById("yxzy").style.display="block";
        }
        else
        {
           document.getElementById("yxzy").style.display="none";
        }
    }
    
    
   
    
    function verification1()
    {
       //var username=document.getElementById("TextBox1");
       //var password=document.getElementById("TextBox2");
       //var password1=document.getElementById("TextBox3");
       //var truename=document.getElementById("TextBox4");
       //var phone=document.getElementById("TextBox5");
      
       if(!$.trim($("#TextBox1").val()))
       {
          alert('用户名不能为空');
          return false;
       }
       if(!$.trim($("#TextBox2").val()))
       {
          alert('密码不能为空');
          return false;
       }
       if($.trim($("#TextBox2").val())!=$.trim($("#TextBox3").val()))
       {
          alert('两次输入的密码不一致');
          return false;
       }
       if(!$.trim($("#TextBox4").val()))
       {
          alert('请输入真实姓名');
          return false;
       }
        if(!isPhone($.trim($("#TextBox5").val())))
       {
          alert('请填写正确的联系电话');
          return false;
       }
      
       
       
       
    }
    
    
    function showqueuelist()
{
   $("#addqueue").css("display","none");
   $("#listqueue").css("display","block");
   document.getElementById("printqueue").value="";
}
    
function DelAll()//删除全部
{
    var lst2=window.document.getElementById("listtarget");
    var length = lst2.options.length;
    for(var i=length;i>0;i--)
    {
        lst2.options[i-1].parentNode.removeChild(lst2.options[i-1]);
    }    
}

function DelAllselectusers()//删除全部
{
    var lst2=window.document.getElementById("ListBox2");
    var length = lst2.options.length;
    for(var i=length;i>0;i--)
    {
        lst2.options[i-1].parentNode.removeChild(lst2.options[i-1]);
    }    
}


    
    
    function checkbuild()
    {
       //if(document.getElementById("Buildname").value.length==0)
       //{
           //alert('请填写楼房名');
           //return false;
       //}
       if(!$.trim($("#Buildname").val()))
       {
          alert('请填写楼房名');
          return false;
       }
       else if(!$.trim($("#anothername").val()))
       {
            alert('请填写楼房别名');
            return false;
       }
    }

    </script>

</head>
<body style="color: Black;">
    <form id="form1" runat="server">
        <div class="info" style="width: 95%; margin-left: auto; margin-right: auto;">
            <cc1:TabWebControl ID="TabWebControl1" runat="server" Width="98%" Style="margin-top: 20px">
                <cc1:TabPage ID="TabPage1" runat="server" Text="用户管理">
                    <!--操作列表-->
                    <div style="width: 100%; height: 30px; margin-top: 20px;" id="Div1">
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/gif-0756.gif"
                            OnClick="ImageButton2_Click" />
                    </div>
                    <!--用户列表-->
                    <div style="width: 100%; height: auto;" runat="server" id="list">
                        <div style="width: 100%; height: auto; margin-left: auto; margin-right: auto; text-align: center;">
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                AutoGenerateColumns="False" Width="95%" BackColor="GradientActiveCaption" BorderColor="White"
                                BorderStyle="Solid" BorderWidth="1px" CellSpacing="1" EmptyDataText="暂无任何用户！">
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#E3EAEB" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="用户名">
                                        <ItemTemplate>
                                            <a href="#" onclick="window.open('UserInfo.aspx?username=<%#Eval("UserName") %>','<%#Eval("UserName") %>','height=350, width=470, top=200, left=270, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')">
                                                <%#Eval("UserName") %>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TrueName" HeaderText="真实姓名" SortExpression="TrueName" />
                                    <asp:BoundField DataField="phone" HeaderText="联系电话" SortExpression="phone" />
                                    <asp:BoundField DataField="UserType" HeaderText="用户类型" SortExpression="UserType" />
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("UserName")%>' runat="server"
                                                OnClick="LinkButton1_Click">修改</asp:LinkButton>
                                            &nbsp; &nbsp;
                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("UserName")%>'
                                                OnClick="LinkButton2_Click" OnClientClick="return confirm('你确定要删除此项吗？')">删除</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">修改密码</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="pager" style="text-align: right;">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                                NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="DropDownList"
                                PrevPageText="上一页" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页"
                                TextBeforePageIndexBox="转到">
                            </webdiyer:AspNetPager>
                            &nbsp;</div>
                    </div>
                    <div style="width: 100%; margin-left: auto; margin-right: auto;" runat="server" id="add"
                        visible="false">
                        <div style="width: 650px; height: 40px; margin-top: 20px;">
                            <div style="width: 80px; height: 100%; margin-left: 40px; float: left; line-height: 40px;">
                                用户名：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox1" runat="server" Style="margin-top: 8px"></asp:TextBox></div>
                            <div style="width: 80px; height: 100%; float: left; line-height: 40px;">
                                密码：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox2" runat="server" Style="margin-top: 8px" TextMode="Password"></asp:TextBox></div>
                        </div>
                        <div style="width: 650px; height: 40px;">
                            <div style="width: 80px; margin-left: 40px; height: 100%; float: left; line-height: 40px;">
                                确认密码：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox3" runat="server" Style="margin-top: 8px" TextMode="Password"></asp:TextBox></div>
                            <div style="width: 80px; height: 100%; float: left; line-height: 40px;">
                                真实姓名：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox4" runat="server" Style="margin-top: 8px"></asp:TextBox></div>
                        </div>
                        <div style="width: 650px; height: 40px;">
                            <div style="width: 80px; margin-left: 40px; height: 100%; float: left; line-height: 40px;">
                                性别：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:DropDownList ID="DropDownList1" runat="server" Style="margin-top: 9px">
                                    <asp:ListItem>男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:DropDownList></div>
                            <div style="width: 80px; height: 100%; float: left; line-height: 40px;">
                                用户类型：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:DropDownList ID="DropDownList2" runat="server" Style="margin-top: 9px">
                                    <asp:ListItem>老师</asp:ListItem>
                                    <asp:ListItem>学生</asp:ListItem>
                                    <asp:ListItem>超级管理员</asp:ListItem>
                                </asp:DropDownList></div>
                        </div>
                        <div id="yxzy" style="width: 650px; height: 40px; display: none;">
                            <div style="width: 80px; height: 100%; margin-left: 40px; float: left; line-height: 40px;">
                                院系：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox7" runat="server" Style="margin-top: 8px"></asp:TextBox></div>
                            <div style="width: 80px; height: 100%; float: left; line-height: 40px;">
                                专业：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox8" runat="server" Style="margin-top: 8px"></asp:TextBox></div>
                        </div>
                        <div style="width: 650px; height: 40px;">
                            <div style="width: 80px; height: 100%; margin-left: 40px; float: left; line-height: 40px;">
                                联系电话：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox5" runat="server" Style="margin-top: 9px"></asp:TextBox></div>
                        </div>
                        <div style="width: 650px; height: 60px;">
                            <div style="width: 80px; height: 100%; margin-left: 40px; float: left; line-height: 60px;">
                                备注：</div>
                            <div style="width: 410px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox9" runat="server" Style="margin-top: 8px" Height="42px" TextMode="MultiLine"
                                    Width="301px"></asp:TextBox></div>
                        </div>
                        <div style="width: 650px; height: 30px; margin-top: 20px;">
                            &nbsp;<asp:Button ID="Button2" runat="server" Text="确认" CssClass="btn" Width="41px"
                                Style="margin-left: 118px" OnClick="Button2_Click" OnClientClick="return verification1()" />
                            &nbsp;&nbsp;
                            <asp:Button ID="Button1" runat="server" Text="返回" CssClass="btn" Width="41px" OnClick="Button1_Click" /></div>
                    </div>
                    <div style="width: 100%; margin-left: auto; margin-right: auto;" runat="server" id="modifty"
                        visible="false">
                        <div style="width: 650px; height: 40px; margin-top: 20px;">
                            <div style="width: 80px; height: 100%; margin-left: 40px; float: left; line-height: 40px;">
                                用户名：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox6" runat="server" Style="margin-top: 8px" ReadOnly="True"></asp:TextBox></div>
                            <div style="width: 80px; height: 100%; float: left; line-height: 40px;">
                                真实姓名：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox12" runat="server" Style="margin-top: 8px"></asp:TextBox></div>
                        </div>
                        <div style="width: 650px; height: 40px;">
                            <div style="width: 80px; margin-left: 40px; height: 100%; float: left; line-height: 40px;">
                                性别：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:DropDownList ID="DropDownList3" runat="server" Style="margin-top: 9px">
                                    <asp:ListItem>男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:DropDownList></div>
                            <div style="width: 80px; height: 100%; float: left; line-height: 40px;">
                                用户类型：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:DropDownList ID="DropDownList4" runat="server" Style="margin-top: 9px">
                                    <asp:ListItem>老师</asp:ListItem>
                                    <asp:ListItem>学生</asp:ListItem>
                                    <asp:ListItem>超级管理员</asp:ListItem>
                                </asp:DropDownList></div>
                        </div>
                        <div id="Div3" style="width: 650px; height: 40px; display: none;" runat="server">
                            <div style="width: 80px; height: 100%; margin-left: 40px; float: left; line-height: 40px;">
                                院系：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox13" runat="server" Style="margin-top: 8px"></asp:TextBox></div>
                            <div style="width: 80px; height: 100%; float: left; line-height: 40px;">
                                专业：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox14" runat="server" Style="margin-top: 8px"></asp:TextBox></div>
                        </div>
                        <div style="width: 650px; height: 40px;">
                            <div style="width: 80px; height: 100%; margin-left: 40px; float: left; line-height: 40px;">
                                联系电话：</div>
                            <div style="width: 210px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox15" runat="server" Style="margin-top: 9px"></asp:TextBox></div>
                        </div>
                        <div style="width: 650px; height: 60px;">
                            <div style="width: 80px; height: 100%; margin-left: 40px; float: left; line-height: 60px;">
                                备注：</div>
                            <div style="width: 410px; height: 100%; float: left; line-height: 30px;">
                                <asp:TextBox ID="TextBox16" runat="server" Style="margin-top: 8px" Height="42px"
                                    TextMode="MultiLine" Width="301px"></asp:TextBox></div>
                        </div>
                        <div style="width: 650px; height: 30px; margin-top: 20px;">
                            &nbsp;<asp:Button ID="Button3" runat="server" Text="修改" CssClass="btn" Width="41px"
                                Style="margin-left: 118px" OnClick="Button3_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="Button4" runat="server" Text="返回" CssClass="btn" Width="41px" OnClick="Button4_Click" /></div>
                    </div>
                </cc1:TabPage>
                <cc1:TabPage ID="TabPage3" runat="server" Text="楼房数据">
                    <div id="op" runat="server" style="width: 95%; margin-left: auto; margin-top: 14px;
                        margin-right: auto; height: 20px;">
                        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">添加楼房</asp:LinkButton></div>
                    <div runat="server" id="list1" style="width: 95%; text-align: center; height: auto;
                        margin-left: auto; margin-top: 4px; margin-right: auto;">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%"
                            BackColor="Gray" CellPadding="4" CellSpacing="1" ForeColor="#333333" GridLines="None"
                            EmptyDataText="暂无任何信息！">
                            <Columns>
                                <asp:BoundField DataField="DongName" HeaderText="楼房名" SortExpression="DongName">
                                    <ItemStyle Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="another_name" HeaderText="别名" SortExpression="another_name" />
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton4" CommandArgument='<%#Eval("DongID") %>' runat="server"
                                            OnClick="LinkButton4_Click">修改</asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton ID="LinkButton5" CommandArgument='<%#Eval("DongID") %>' runat="server"
                                            OnClick="LinkButton5_Click" OnClientClick="return confirm('你确定要删除这条记录吗？')">删除</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E3EAEB" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <webdiyer:AspNetPager ID="AspNetPager2" runat="server" FirstPageText="首页" LastPageText="尾页"
                            NextPageText="下一页" OnPageChanged="AspNetPager2_PageChanged" PageIndexBoxType="DropDownList"
                            PrevPageText="上一页" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页"
                            TextBeforePageIndexBox="转到">
                        </webdiyer:AspNetPager>
                    </div>
                    <div style="width: 95%; margin-left: auto; margin-right: auto; margin-top: 80px;"
                        runat="server" id="add1" visible="false">
                        <table style="width: 500px; margin-left: auto; margin-right: auto; background-color: #d4d4d4;"
                            cellpadding="0" cellspacing="1">
                            <tr>
                                <td style="width: 120px; text-align: right; padding-right: 12px; height: 31px;">
                                    楼房名：</td>
                                <td colspan="2" style="height: 31px; padding-left: 10px;">
                                    <asp:TextBox ID="Buildname" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px; text-align: right; padding-right: 12px; height: 82px;">
                                    楼房别名：</td>
                                <td style="height: 82px; padding-left: 10px; width: 222px;">
                                    <asp:TextBox ID="anothername" runat="server" Height="64px" TextMode="MultiLine" Width="216px"></asp:TextBox>
                                </td>
                                <td style="width: 120px; border-left: 0px; color: Red; text-align: left; padding-left: 12px;
                                    height: 82px;">
                                    别名之间用|号隔开</td>
                            </tr>
                            <tr>
                                <td style="width: 120px; text-align: right; padding-right: 12px; height: 31px;">
                                </td>
                                <td colspan="2" style="height: 31px; padding-left: 10px;">
                                    <asp:Button ID="Button5" runat="server" Text="确定" OnClientClick="return checkbuild()"
                                        CssClass="btn" Height="21px" Width="40px" OnClick="Button5_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button6" runat="server" CssClass="btn" OnClick="Button6_Click" Text="返回" /></td>
                            </tr>
                        </table>
                    </div>
                </cc1:TabPage>
                <cc1:TabPage ID="TabPage2" runat="server" Text="房间数据">
                    <div runat="server" style="width: 95%; height: auto; margin-left: auto; margin-right: auto;"
                        id="listroom">
                        <div style="width: 100%; margin-top: 20px; height: 26px; margin-left: auto; margin-right: auto;">
                            <asp:DropDownList ID="DropDownList5" runat="server" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <input id="Button7" type="button" class="btn" value="添加" onclick="showaddroom()" /></div>
                        <div style="width: 100%; text-align: center; height: auto; margin-left: auto; margin-right: auto;">
                            <asp:GridView ID="roomlist" runat="server" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="roomname" HeaderText="房间号" SortExpression="roomname" />
                                    <asp:BoundField DataField="DongName" HeaderText="所在的楼" SortExpression="DongName" />
                                    <asp:TemplateField HeaderText="说明">
                                        <ItemTemplate>
                                            <%# Function.formateempty(Eval("intro").ToString().Trim(),"暂无说明") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton7" CommandArgument='<%#Eval("roomid") %>' runat="server"
                                                OnClick="LinkButton7_Click" OnClientClick="return confirm('你确定删除这条记录吗？')">删除</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <webdiyer:AspNetPager ID="AspNetPager3" runat="server" FirstPageText="首页" LastPageText="尾页"
                                NextPageText="下一页" OnPageChanged="AspNetPager3_PageChanged" PageIndexBoxType="DropDownList"
                                PrevPageText="上一页" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页"
                                TextBeforePageIndexBox="转到">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                    <div id="addroom" runat="server" style="width: 100%; text-align: center; height: auto;
                        margin-left: auto; display: none; margin-right: auto; margin-top: 50px;">
                        <table style="width: 400px;">
                            <tr>
                                <td style="width: 131px; text-align: right; padding-right: 12px; height: 32px;">
                                    房号：</td>
                                <td style="text-align: left; padding-left: 10px; height: 32px;">
                                    <asp:TextBox ID="roomid" runat="server" Height="18px" Width="181px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 131px; text-align: right; padding-right: 12px; height: 72px;">
                                    说明：</td>
                                <td style="text-align: left; padding-left: 10px; height: 72px;">
                                    <asp:TextBox ID="roomintro" runat="server" Height="52px" Width="181px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 131px; text-align: right; padding-right: 12px; height: 32px;">
                                </td>
                                <td style="text-align: left; padding-left: 10px; margin-top: 20px; height: 32px;">
                                    <asp:Button ID="Button8" runat="server" CssClass="btn" Text="确认" OnClientClick="return checkroom()"
                                        OnClick="Button8_Click" />&nbsp;
                                    <input id="Button9" onclick="Hiddenaddroom()" type="button" class="btn" value="返回" /></td>
                            </tr>
                        </table>
                    </div>
                </cc1:TabPage>
                <cc1:TabPage ID="TabPage4" runat="server" Text="打印队列管理">
                    <div style="width: 95%; margin-left: auto; margin-right: auto;" id="listqueue">
                        <div style="width: 100%; height: 30px; margin-top: 20px; text-align: left;">
                            <input id="Button10" onclick="showqueueadd()" class="btn" style="width: 40px" type="button"
                                value="添加" /></div>
                        <div style="width: 100%; margin-top: 5px; text-align: center;">
                            <asp:GridView ID="queueinfo" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%">
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <Columns>
                                    <asp:BoundField DataField="queuename" HeaderText="队列名" SortExpression="queuename" />
                                    <asp:BoundField DataField="createtime" HeaderText="创建日期" SortExpression="createtime" />
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton8" CommandArgument='<%#Eval("id") %>' runat="server"
                                                OnClick="LinkButton8_Click" OnClientClick="return confirm('你确定要删除此项记录吗？')">删除</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton9" runat="server" CommandArgument='<%#Eval("id") %>'
                                                OnClick="LinkButton9_Click">修改</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="60px" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div style="width: 95%; margin-left: auto; display: none; text-align: center; margin-right: auto;
                        margin-top: 60px;" id="addqueue">
                        <table style="width: 420px;">
                            <tr>
                                <td style="width: 131px; text-align: right; padding-right: 12px; height: 32px;">
                                    打印队列名：</td>
                                <td style="text-align: left; padding-left: 10px; height: 32px;">
                                    <asp:TextBox ID="printqueue" runat="server" Height="18px" Width="237px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 131px; text-align: right; padding-right: 12px; height: 269px;">
                                    所属用户：</td>
                                <td style="text-align: left; padding-left: 10px; margin-top: 20px; height: 269px;">
                                    <div style="width: 90px; height: 100%; float: left;">
                                        <asp:ListBox ID="listall" runat="server" Height="265px" Width="86px" CssClass="listbox"
                                            SelectionMode="Multiple"></asp:ListBox></div>
                                    <div style="width: 40px; height: 100%; margin-left: 20px; float: left;">
                                        <table style="width: 100%; height: 100%;">
                                            <tr>
                                                <td>
                                                    <input id="moveright" class="btn" onclick="add()" type="button" value=">>>" /><br />
                                                    <br />
                                                    <input id="moveleft" class="btn" type="button" onclick="del()" value="<<<" /></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="width: 90px; margin-left: 10px; height: 100%; float: left;">
                                        <asp:ListBox ID="listtarget" runat="server" Height="269px" Width="87px" CssClass="listbox"
                                            SelectionMode="Multiple"></asp:ListBox></div>
                                    <asp:TextBox ID="hiddenstring" Style="display: none;" runat="server" Width="213px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 131px; text-align: right; padding-right: 12px; height: 32px;">
                                </td>
                                <td style="text-align: left; padding-left: 10px; margin-top: 20px; height: 32px;">
                                    <asp:Button ID="Button11" runat="server" CssClass="btn" Text="确认" OnClientClick="return checkprintqueue()"
                                        OnClick="Button11_Click" />&nbsp;
                                    <asp:Button ID="Button12" runat="server" CssClass="btn" OnClick="Button12_Click"
                                        Text="返回" /></td>
                            </tr>
                        </table>
                    </div>
                </cc1:TabPage>
                <cc1:TabPage ID="TabPage5" runat="server" Text="常见故障管理">
                    <div style="width: 95%; margin-left: auto; display: block; margin-right: auto; text-align: right;"
                        id="commonfaulylist">
                        <div style="width: 100%; height: 30px; margin-top: 20px; text-align: left;">
                            <input id="Button13" onclick="showcommonfaultadd()" class="btn" style="width: 40px"
                                type="button" value="添加" /></div>
                        <div style="width: 100%; margin-top: 5px; text-align: center;">
                            <asp:GridView ID="commonfaultgrd" runat="server" Width="100%" AutoGenerateColumns="False"
                                BackColor="Gray" CellPadding="4" CellSpacing="1" ForeColor="#333333" GridLines="None">
                                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                <Columns>
                                    <asp:BoundField DataField="guzhangcontent" HeaderText="故障描述" SortExpression="guzhangcontent" />
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            &nbsp;<asp:ImageButton ID="ImageButton1" CommandArgument='<%#Eval("id") %>' runat="server"
                                                ImageUrl="~/images/del1.gif" OnClick="ImageButton1_Click" OnClientClick="return confirm('你确定要删除此项吗？如果删除就无法还原')" />
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            &nbsp;</div>
                        <webdiyer:AspNetPager ID="AspNetPager4" runat="server" FirstPageText="首页" LastPageText="尾页"
                            NextPageText="下一页" OnPageChanged="AspNetPager4_PageChanged" PageIndexBoxType="DropDownList"
                            PrevPageText="上一页" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页"
                            TextBeforePageIndexBox="转到">
                        </webdiyer:AspNetPager>
                    </div>
                    <div style="width: 95%; margin-left: auto; display: none; margin-top: 60px; text-align: center;
                        margin-right: auto;" id="commonfaulyadd">
                        <table style="width: 400px;">
                            <tr>
                                <td style="width: 98px; height: 70px">
                                </td>
                                <td style="height: 70px; width: 299px;">
                                    <asp:TextBox ID="commonfaultinput" runat="server" Height="60px" TextMode="MultiLine"
                                        Width="97%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 98px; height: 30px">
                                </td>
                                <td style="height: 30px; text-align: left; width: 299px;">
                                    <asp:Button ID="Button14" runat="server" Text="确认添加" CssClass="btn" OnClick="Button14_Click"
                                        OnClientClick="return Checkcommonfaultisempty()" />
                                    &nbsp;&nbsp;
                                    <input id="Button15" class="btn" onclick="hiddencommonfaultadd()" type="button" value="返回" /></td>
                            </tr>
                        </table>
                    </div>
                </cc1:TabPage>
                <cc1:TabPage ID="TabPage6" runat="server" Text="电话分组">
                    <div id="listtelephonebook" style="width: 100%; margin-left: auto; margin-top: 10px;
                        margin-right: auto; text-align: left;">
                        <div style="width: 96%; height: auto; margin-left: auto; margin-right: auto;">
                            <img alt="" src="../images/row_add.gif" />[<a href="#" onclick="showaddtelephoebook()">添加</a>]</div>
                        <div style="width: 96%; height: auto; text-align: right; margin-left: auto; margin-right: auto;
                            margin-top: 2px;">
                            <asp:GridView ID="GridView3" runat="server" Width="100%" AutoGenerateColumns="False"
                                BackColor="Silver" CellPadding="4" CellSpacing="1" ForeColor="#333333" GridLines="None"
                                OnRowDataBound="GridView3_RowDataBound">
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField HeaderText="序号">
                                        <ItemStyle Width="40px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="telbook" HeaderText="组名" ReadOnly="True" SortExpression="telbook" />
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemStyle Width="150px" />
                                        <ItemTemplate>
                                            <table style="width: 149px;" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 33px; text-align: right; height: 22px">
                                                        <img alt="" src="../images/modifty1.gif" /></td>
                                                    <td style="height: 22px; text-align: left; width: 35px;">
                                                        [<asp:LinkButton ID="LinkButton10" runat="server" CommandArgument='<%#Eval("id") %>'
                                                            OnClick="LinkButton10_Click">修改</asp:LinkButton>]</td>
                                                    <td style="height: 22px; text-align: right; width: 37px;">
                                                        <img alt="" src="../images/del1.gif" />
                                                    </td>
                                                    <td style="height: 22px; text-align: left;">
                                                        [<asp:LinkButton ID="LinkButton11" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="LinkButton11_Click">删除</asp:LinkButton>]
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div id="addtelephonebook" style="width: 95%; margin-left: auto; margin-right: auto;
                        display: none; margin-top: 20px;">
                        <table style="width: 420px;">
                            <tr>
                                <td style="width: 131px; text-align: right; padding-right: 12px; height: 32px;">
                                    组名：</td>
                                <td style="text-align: left; padding-left: 10px; height: 32px;">
                                    <asp:TextBox ID="phonebooknameinput" runat="server" Height="18px" Width="237px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 131px; text-align: right; padding-right: 12px; height: 269px;">
                                    联系人名：</td>
                                <td style="text-align: left; padding-left: 10px; margin-top: 20px; height: 269px;">
                                    <div style="width: 90px; height: 100%; float: left;">
                                        <asp:ListBox ID="ListBox1" runat="server" Height="265px" Width="86px" CssClass="listbox"
                                            SelectionMode="Multiple"></asp:ListBox></div>
                                    <div style="width: 40px; height: 100%; margin-left: 20px; float: left;">
                                        <table style="width: 100%; height: 100%;">
                                            <tr>
                                                <td>
                                                    <input id="Button17" class="btn" onclick="add1()" type="button" value=">>>" /><br />
                                                    <br />
                                                    <input id="Button18" class="btn" type="button" onclick="del1()" value="<<<" /></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="width: 90px; margin-left: 10px; height: 100%; float: left;">
                                        <asp:ListBox ID="ListBox2" runat="server" Height="269px" Width="87px" CssClass="listbox"
                                            SelectionMode="Multiple"></asp:ListBox></div>
                                    <asp:TextBox ID="TextBox11" Style="display: none;" runat="server" Width="99px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 131px; text-align: right; padding-right: 12px; height: 32px;">
                                </td>
                                <td style="text-align: left; padding-left: 10px; margin-top: 20px; height: 32px;">
                                    <asp:Button ID="Button19" runat="server" CssClass="btn" Text="确认分组" OnClick="Button19_Click" />&nbsp;
                                    <asp:Button ID="Button20" runat="server" CssClass="btn" Text="返回" /></td>
                            </tr>
                        </table>
                    </div>
                </cc1:TabPage>
            </cc1:TabWebControl>
        </div>
    </form>
</body>
</html>

<script type="text/javascript">
function checkroom()
{
  if(!$.trim($("#roomid").val()))
  {
     alert('房号必填');
     return false;
  }
}


function showaddroom()
{
  if(!$.trim($("#DropDownList5").val()))
  {
     alert('请选择楼房');
     return false;
  }
  else
  {
  $("#listroom").css("display","none");
  $("#addroom").css("display","block");
  }
}


function Hiddenaddroom()
{
  $("#listroom").css("display","block");
  $("#addroom").css("display","none");
}


function checkprintqueue()
{
   if(!$.trim($("#printqueue").val()))
   {
       alert('打印队列名必填');
       return false;
   }
   if(!$.trim($("#hiddenstring").val()))
   {
      alert('打印队列至少属于一个用户');
      return false;
   }
}




function showqueueadd()
{
   $("#addqueue").css("display","block");
   $("#listqueue").css("display","none");
   document.getElementById("printqueue").value="";
}

function showcommonfaultadd()
{
    $("#commonfaulylist").css("display","none");
   $("#commonfaulyadd").css("display","block");
   document.getElementById("commonfaultinput").value="";
}

function hiddencommonfaultadd()
{
    $("#commonfaulylist").css("display","block");
   $("#commonfaulyadd").css("display","none");
   document.getElementById("commonfaultinput").value="";
}


function Checkcommonfaultisempty()
{
    if(!$.trim($("#commonfaultinput").val()))
    {
        alert('故障描述必填');
        return false;
    }
}


function showaddtelephoebook()
{
     $("#addtelephonebook").css("display","block");
     $("#listtelephonebook").css("display","none");
}


function disaddtelephoebook()
{
     $("#addtelephonebook").css("display","none");
     $("#listtelephonebook").css("display","block");
}
 



</script>

