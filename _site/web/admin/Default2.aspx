<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="admin_Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title> New Product Quality Management </title> 
<script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript"> 

function CheckUserName()
    {
        //var va=$("#"+id).val();
        
        $.ajax({
       url:'ajax.aspx',
       data:{t:"getroom",aa:$("#DropDownList1").val()},
       timeout: 10000,
       dataType:'xml',
       error:function()
       {
         alert('创建xml文档出错');
       },
       success:function(xml){
       
          
       $(xml).find("Table").each(function(i){ 
         //var id=$(this).children("Table"); //取对象 
         var drp2=$("#DropDownList2");
         var idvalue=$(this).children("roomid").text(); //取文本 
          var idtext=$(this).children("roomname").text(); //取文本 
            //alert(idtext);
            var tOption = document.createElement("Option");
         tOption.text=idtext;
         tOption.value=idvalue;
         document.getElementById("DropDownList2").add(tOption);


              }); 
     } 

    }); 
        
        //document.getElementById("Msg").innerHTML='';
    }
</script> 
<style type="text/css">
.ss{display:none}
</style>
</head> 
<body > 
<form id="form1" runat="server"> 
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
  
      
  
</form> 
</body> 
</html> 
