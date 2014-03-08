<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="admin_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/StyleSheet.css" type="text/css" rel="stylesheet" />

    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>

    <style type="text/css">
	html{overflow:hidden;}
	body{height:100%;overflow:auto;}
	
</style>

    <script type="text/javascript">
    function slideToggle(){
    $("#tg").slideToggle(500);//窗帘效果的切换,点一下收,点一下开,参数可以无,参数说明同上
    }
     function slideToggle1(){
    $("#tg1").slideToggle(500);//窗帘效果的切换,点一下收,点一下开,参数可以无,参数说明同上
    }
     function slideToggle2(){
    $("#tg2").slideToggle(500);//窗帘效果的切换,点一下收,点一下开,参数可以无,参数说明同上
    }
     function slideToggle3(){
    $("#tg3").slideToggle(500);//窗帘效果的切换,点一下收,点一下开,参数可以无,参数说明同上
    }
    
     function slideToggle4(){
    $("#tg4").slideToggle(500);//窗帘效果的切换,点一下收,点一下开,参数可以无,参数说明同上
    }
    
    </script>

</head>
<body style="margin: 0px; padding: 0px;">
    <form id="form1" runat="server">
        <div class="left">
            <div class="menu1" onmousedown="slideToggle()">
                报障管理</div>
            <div class="menuitem" id="tg">
                <div class="ah">
                    <a href="NewsestBreakdown.aspx" target="conte">最新故障</a></div>
                <div class="ah">
                    <a href="Mybreakdown.aspx" target="conte">我的故障</a></div>
                <div class="ah">
                    <a href="TelBreakdown.aspx" target="conte">电话故障登记</a></div>
            </div>
            <div class="menu1" onmousedown="slideToggle3()">
                办公管理</div>
            <div class="menuitem" id="tg3">
                <div class="ah">
                    <a href="NoticeManage.aspx" target="conte">通知发布</a></div>
                <div class="ah">
                    <a href="logcheck.aspx" target="conte">日志查看</a></div>
                <div class="ah">
                    <a href="Report.aspx" target="conte">常见报表</a></div>
            </div>
            <div class="menu1" onmousedown="slideToggle4()">
                考勤管理</div>
            <div class="menuitem" id="tg4">
                <div class="ah">
               <!--
                    <a href="WatcherManager.aspx" target="conte">值班安排</a></div>
                <div class="ah"> -->
                    <!--<a href="logcheck.aspx" target="conte">出勤统计</a></div>
                <div class="ah">-->
                   <!-- <a href="Report.aspx" target="conte">值班表查看</a>-->
                   
                   
                    <a href="Building.aspx" target="conte">值班安排</a></div>
                <div class="ah"> 
                    <a href="Building.aspx" target="conte">出勤统计</a></div>
                <div class="ah">
                   <a href="Building.aspx" target="conte">值班表查看</a></div>
            </div>
            <div class="menu1" onmousedown="slideToggle2()">
                系统设置</div>
            <div class="menuitem" id="tg2">
                <div class="ah">
                    <a href="SMSconfig.aspx" target="conte">常用设置</a></div>
                <div class="ah">
                    <a href="BasicData.aspx" target="conte">基础数据录入</a></div>
            </div>
            <div class="menubuttom">
            </div>
        </div>
    </form>
</body>
</html>
