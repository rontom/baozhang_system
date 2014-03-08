<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="admin_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>海南师范大学网络中心办公系统</title>
    <link href="../css/StyleSheet.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
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
    
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
    
    <div class="header"></div>
    <div class="mid">
      <div class="left">
         <div class="menu"></div>
         <div class="menu1"  onmousedown="slideToggle()" >故障管理</div>
         <div class="menuitem" id="tg">
             <ul>
               <li><a href="NewsestBreakdown.aspx" target="conte">最新故障</a></li>
               <li><a href="Mybreakdown.aspx" target="conte">我的故障</a></li>
               <li><a href="TelBreakdown.aspx" target="conte">故障登记</a></li>
             </ul>
         
         </div>
         <div class="menu1" onmousedown="slideToggle1()">设备管理</div>
         <div class="menuitem" id="tg1">
               <ul>
               <li><a href="DeviceTake.aspx" target="conte">设备领用</a></li>
               <li><a href="DeviceIn.aspx" target="conte">设备入库</a></li>
               <li><a href="DeviceConut.aspx" target="conte">设备统计报表</a></li>
             </ul>
         </div>
         <div class="menu1" onmousedown="slideToggle2()">考勤管理</div>
         <div class="menuitem" id="tg2">
                 <ul>
               <li><a href="StudentWatch.aspx" target="conte">学生考勤</a></li>
               <li><a href="TeacherWatch.aspx" target="conte">教师考勤</a></li>
             </ul>
         </div>
         <div class="menu1" onmousedown="slideToggle3()">办公管理</div>
         <div class="menuitem" id="tg3">
             <ul>
               <li><a href="NoticeManage.aspx" target="conte">通知发布</a></li>
               <li><a href="WorkerManager.aspx" target="conte">工作安排</a></li>
               <li><a href="BasicData.aspx" target="conte">基础数据录入</a></li>
             </ul>
         </div>
         <div class="menubuttom"></div>
      </div>
    <div class="right">
       <div class="righttop"></div>
       <div class="rightmid">
          <iframe width="704" height="500" frameborder="0" scrolling="no" style="margin-left:67px;" name="conte"></iframe>
       </div>
       <div class="rightbuttom"></div>
    </div>
    </div>
    <div class="buttom"></div>
    </div>
    </form>
</body>
</html>
