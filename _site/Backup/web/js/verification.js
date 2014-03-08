// JScript 文件

//gridview中checkbox验证是至少有一项被选中
function verificationatlistselectone(obj,che)
{
var grid=document.getElementById(obj);
var checks=grid.getElementsByTagName("input");
var n=0;
for(var i=0;i<checks.length;i++)
{
if(checks[i].type=="checkbox"&&checks[i].id!=che &&checks[i].checked==true)
{
   n++;
}

}

if(n==0)
{

return false;
}


}




function verificationatlistselectoneincheckboxlist(obj)
{
var grid=document.getElementById(obj);
var checks=grid.getElementsByTagName("input");
var n=0;
for(var i=0;i<checks.length;i++)
{
if(checks[i].type=="checkbox" &&checks[i].checked==true)
{
   n++;
}

}

if(n==0)
{

return false;
}


}





//checkb全选与反选
function CheckAll(checkbox,grid)
{
var state=checkbox.checked;
var element1=document.getElementById(grid);
var elements=element1.getElementsByTagName("input");
for(var i = 0;i < elements.length;i++)
{ 
if(elements[i].type == "checkbox" && elements[i].id != checkbox.id) 
{
elements[i].checked =state;
}
} 
}



function add()

    {

        var left;

        var right;
        var count=0;

        left = document.getElementById("listall");

        right = document.getElementById("listtarget");

        for(var i=left.length-1;i>-1;i--)

        {

            if(left.options[i].selected)

            {

                //判断该项是否已经存在

                for(j=0;j<right.length;j++)

                {

                    if(right.options[j].value==left.options[i].value)

                    {

                       return;

                    }
                   
                    

                }
               
                right.add(new Option(left.options[i].text,left.options[i].value));
                left.remove(i);
                count++;

            }

        }
        gets()
        if(count==0)
        {
          alert('至少要选择一项才能移动');
        }

    }


    function del()

    {
       var count=0;
        right=document.getElementById("listtarget");
        left = document.getElementById("listall");
        for(i=right.length-1;i>=0;i--)

        {

            if(right.options[i].selected)

            {
                for(j=0;j<left.length;j++)

                {

                    if(left.options[j].value==right.options[i].value)

                    {

                        return;

                    }
                   

                }

                 left.add(new Option(right.options[i].text,right.options[i].value));
                      right.remove(i);
                count++;

            }

        }

     gets();
     
     if(count==0)
     {
        alert('至少要选择一项才能移动');
     }
     

    }
    
    
    
    function add1()

    {

        var left;

        var right;
        var count=0;

        left = document.getElementById("ListBox1");

        right = document.getElementById("ListBox2");

        for(var i=left.length-1;i>-1;i--)

        {

            if(left.options[i].selected)

            {

                //判断该项是否已经存在

                for(j=0;j<right.length;j++)

                {

                    if(right.options[j].value==left.options[i].value)

                    {

                       return;

                    }
                   
                    

                }
               
                right.add(new Option(left.options[i].text,left.options[i].value));
                left.remove(i);
                count++;

            }

        }
        gets1()
        if(count==0)
        {
          alert('至少要选择一项才能移动');
        }

    }


    function del1()

    {
       var count=0;
        right=document.getElementById("ListBox2");
        left = document.getElementById("ListBox1");
        for(i=right.length-1;i>=0;i--)

        {

            if(right.options[i].selected)

            {
                for(j=0;j<left.length;j++)

                {

                    if(left.options[j].value==right.options[i].value)

                    {

                        return;

                    }
                   

                }

                 left.add(new Option(right.options[i].text,right.options[i].value));
                      right.remove(i);
                count++;

            }

        }

     gets1();
     
     if(count==0)
     {
        alert('至少要选择一项才能移动');
     }
     

    }


function gets()
{
  var s="";
  var tt="";
  var t=document.getElementById("listtarget"); 
  var len=t.options.length; 
  var a=document.getElementById("hiddenstring");
  var b=document.getElementById("hidendopeoples");
  for(var i=0;i<len; i++)
  {
    s=s+t.options[i].value+"+";
    tt=tt+t.options[i].text+"、";
  }
  a.value=s;
  b.value=tt;
}

function gets1()
{
  var s="";
  var names="";
  var t=document.getElementById("ListBox2"); 
  var len=t.options.length; 
  var a=document.getElementById("TextBox11");
  for(var i=0;i<len; i++)
  {
    s=s+t.options[i].value+"+";
  }
  a.value=s;
}


function checktelfault()
{
    var you_phone=/((\d{11})|^((\d{7,8})|[0-9]{4}|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/
    if(!$.trim($("#nameinput").val()))
    {
       alert('姓名必填');
       return false;
    }
    if(!$.trim($("#phoneinput").val()))
    {
        alert('联系电话必填');
        return false;
    }
    if($("#commonfaultdrop").val()=='自定义'&&!$.trim($("#customfaultinput").val()))
    {
       alert('自定义的故障必须填写');
       return false;
    }
    
    if($("#addressimput").val()=='---请选择---')
    {
       alert('请填写故障地址');
       return false;
    }
    
    if(!$.trim($("#addressimput").val()))
    {
         alert('请填写完整的地址');
         return false;
    }
    
    
    if(!you_phone.test($("#phoneinput").val()))
    {
        alert('请填写正确的联系电话');
        return false;
    }
    
}




//联系电话表达式验证
function isPhone(obj){
   reg=/((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/;
   if(!reg.test(obj)){
   return false;
   }else{
    return true;
   }
}

//日期正则表达式验证
function isDate(obj){
   reg=/(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29)/;
   if(!reg.test(obj)){
   return false;
   }else{
    return true;
   }
}


function compareDate(a,b)
{
   var arr=a.split("-");
   var starttime=new Date(arr[0],arr[1],arr[2]);
   var starttimes=starttime.getTime(); 
   var arrs=b.split("-"); 
   var endtime=new Date(arrs[0],arrs[1],arrs[2]);
   var endtimes=endtime.getTime();
   if(starttimes>endtimes)//开始大于结束
   {
     return false;
   } 
   else{ 
    return true; 
   }


}


//IP地址正则表达式
function IsIP(obj)
{
  var reg=/^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$/;
  if(!reg.test(obj)){
  return false;
  }else{
  return true;
  }
}


//端口号正则表达式
function IsPort(obj)
{
  var reg=/^((\d{0,4})|([1-5]\d{1,4})|(6[0-4]\d{1,3})|(65[0-4]\d{1,2})|(655[0-2]\d)|(6553[0-5]))$/;
  if(!reg.test(obj)){
  return false;
  }else{
  return true;
  }
}


///正整数正则表达式
function IsInteger(obj)
{
  var reg=/^[1-9]\d*$/;
  if(!reg.test(obj)){
  return false;
  }else{
  return true;
  }
}



///检验字符串的长度,超长弹出警告信息
function CheckStringLength(obj,warming,tarlen)
{
   var strlen=$("#"+obj).val().length;
   if(strlen>tarlen)
   {
       alert(warming);
       return false;
   }
   else
   {
   return true;
   }
}


///验证字符串长度是否为奇数
function CheckStringLengthIsOdd(obj)
{
   var strlen=$("#"+obj).val().length;
   if(strlen%2==0)
   {
     //alert(warming);
     return false;
   }
   else
   {
      return true;
   }
   
}



