// JScript 文件

function showcustomfault()
{
   var a=$("#commonfaultdrop").val();
   if(a=="自定义")
   {
      $("#customfault").css("display","block");
   }
   else
   {
       $("#customfault").css("display","none");
   }
}


function clearcustomfault()
{
    if($("#customfaultinput").val()=="自定义故障内容")
    {
      $("#customfaultinput").val('');
    }
    
}

function showcustomadrress()
{
   if($.trim($("#addressimput").val())=='自定义地址')
   {
      $("#addressimput").val('');
   }
}

function showforwarddescript()
{
   if($.trim($("#userdrop").val())!='')
   {
      $("#forwarddescripttr").css("display","block");
      $("#CheckBox1").attr("disabled",true);
      $("#forwarddescripttitle").html("转发说明：")
   }
   else
   {
     $("#forwarddescripttr").css("display","none");
      $("#CheckBox1").attr("disabled",false);
   }
}

function showdoresult()
{
   if($("#CheckBox1").attr("checked"))
   {
     $("#userdrop").attr("disabled",true);
     $("#forwarddescripttr").css("display","block");
     $("#forwarddescripttitle").html("处理结果：")
   }
   else
   {
     
     $("#userdrop").attr("disabled",false);
     $("#forwarddescripttr").css("display","none");
     $("#forwarddescripttitle").html("转发说明：")
   }
}


function CheckPowerIsAllow()
{
    //var btn=$("#"+obj);
    //if(btn.attr.disabled==true)
    //{
        alert('您没有权限执行本操作');
    //}
}


function Switchdisplay(disp,hidden)
{
   $("#"+disp).css("display","block");
   $("#"+hidden).css("display","none");
}

