// JScript 文件

function GetAllbuild()
{
  $.ajax({
       url:'ajax.aspx',
       data:{t:"getBuild"},
       timeout: 3000,
       dataType:'xml',
       cache:false,
       error:function()
       {
         alert('创建xml文档出错');
       },
       success:function(xml){
       
       //$("#roomdrop").empty();
       var tOptionsel = document.createElement("Option");
         tOptionsel.text='---请选择---';
         tOptionsel.value='---选择---';
         document.getElementById("builddrop").add(tOptionsel);
       $(xml).find("Table").each(function(i){ 
         //var id=$(this).children("Table"); //取对象 
         //var drp2=$("#DropDownList2");
         
         var idvalue=$(this).children("DongID").text(); //取文本 
          var idtext=$(this).children("DongName").text(); //取文本 
            //alert(idtext);
            var tOption = document.createElement("Option");
         tOption.text=idtext;
         tOption.value=idvalue;
         document.getElementById("builddrop").add(tOption);
         }); 
         
          var tOptioncustom = document.createElement("Option");
         tOptioncustom.text='自定义';
         tOptioncustom.value='';
         document.getElementById("builddrop").add(tOptioncustom);
         }
    }); 
}

function GetRoombyBuild()
    {
        //var va=$("#"+id).val();
       if($("#builddrop").val()!='---选择---')
       {
        $.ajax({
       url:'ajax.aspx',
       data:{t:"getroom",aa:$("#builddrop").val()},
       timeout: 3000,
       dataType:'xml',
       cache:false,
       error:function()
       {
         alert('创建xml文档出错');
       },
       success:function(xml){
       
       $("#roomdrop").empty();
       var tOptionsel = document.createElement("Option");
         tOptionsel.text='---请选择---';
         tOptionsel.value='请选择';
         document.getElementById("roomdrop").add(tOptionsel);
       $(xml).find("Table").each(function(i){ 
         //var id=$(this).children("Table"); //取对象 
         //var drp2=$("#DropDownList2");
         
         var idvalue=$(this).children("roomid").text(); //取文本 
          var idtext=$(this).children("roomname").text(); //取文本 
            //alert(idtext);
            var tOption = document.createElement("Option");
         tOption.text=idtext;
         tOption.value=idvalue;
         document.getElementById("roomdrop").add(tOption);
         }); 
          var tOptioncustom = document.createElement("Option");
         tOptioncustom.text='自定义';
         tOptioncustom.value='';
         document.getElementById("roomdrop").add(tOptioncustom);
         
     } 

    }); 
    }
    else
    {
        $("#roomdrop").attr('disabled',true);
    }
        
        //document.getElementById("Msg").innerHTML='';
    }
    
    
    function RemoveAllItemInRoomDrop()
    {
      var t=document.getElementById("roomdrop");
      for(var i=t.options.length-1;i>=0;i--)
      {
         t.remove(i);
      }
    }
    
    
    function Builddropchange()
    {
        if($("#builddrop").val()=='')
        {
           $("#roomdrop").attr('disabled',true);
           $("#CustomAddress").css("display","block");
           $("#addressimput").val('');
             $("#guzhangarea").val('');
        }
        else
        {
           $("#roomdrop").attr('disabled',false);
           $("#CustomAddress").css("display","none");
           GetRoombyBuild();
           $("#addressimput").val($("#builddrop").find('option:selected').text());
           $("#guzhangarea").val($("#builddrop").find('option:selected').val());
         
        }
        
        //alert($("#builddrop").val());
    }
    
    function Roomdropchange()
    {
       if($("#roomdrop").val()=='')
       {
            $("#addressimput").val($("#builddrop").find('option:selected').text())
           $("#CustomAddress").css("display","block");
       }
       else
       {
           $("#addressimput").val('');
           $("#CustomAddress").css("display","none");
           var lo=$("#addressimput").val();
           $("#addressimput").val($("#builddrop").find('option:selected').text()+$("#roomdrop").find('option:selected').text());
       }
    }
    
    
    
    
  

function hidden(obj,target)
{
   var a=document.getElementById(obj);
   var b=document.getElementById(target);
   a.style.display="block";
   
   b.style.display="none";
}
 
    //处理方法
    function Getsecondfaultinfobyajax(id,obj)
    {
        $.ajax({
       url:'ajax.aspx',
       data:{t:"secondfaultinfor",aa:id},
       timeout: 10000,
       beforeSend:function(){
       $("#"+obj).html('<img src="../images/loading.gif" alt="">载入中...');
       },
       success:function(result){
           $("#"+obj).html(result);
        }
    }); 
    }
