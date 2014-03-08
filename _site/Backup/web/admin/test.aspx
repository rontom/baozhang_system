<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="admin_test" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Yc.HuangXiao.FrameWork.WebControls" Namespace="Yc.HuangXiao.FrameWork.WebControls.TabWebControl"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>asd</title>
<script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
<script  type="text/javascript">
     function ss()
     {
        var a=document.getElementsByTagName("input");
        for(var b=0;b<a.length;b++)
        {
        alert(a[b].id);
        }
     }
               
    </script>

</head>   
<body onload="ss()">   
<form id="Form1" runat="server">   
    <input id="Checkbox1" checked="checked" type="checkbox" />


</form>   
</body>   
</html>  

