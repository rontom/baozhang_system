<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test1.aspx.cs" Inherits="test1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <link rel="stylesheet" href="dialog.css"/>
<script language="javascript" src="jquery-latest.pack.js"></script>
<script language="javascript" src="dialog.js"></script>
<style type="text/css">
body.iframe.content{padding:0;}
</style>
</head>
<body>


<a href="#" onclick='dialog("show.html","url:get?show.html","200px","auto","text"); '>content</a>

</body>
</html>