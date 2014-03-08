<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="admin_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>海南师范大学报障管理系统</title>
</head>
    <frameset rows="95,*"  border="0" frameSpacing="0" frameBorder="0">
		<frame src="top.aspx" frameborder="0" noresize="noresize" scrolling="no">
		<frameset cols="160,*" border="0" frameSpacing="0" id="FramesetLeft" >
			<frame src="Left.aspx" frameborder="0" name="LeftIframe" id="LeftIframe">
			<frame src="SystemInfo.aspx" name="conte" id="conte"    scrolling="auto">
		</frameset>
	  
	</frameset>
</html>
