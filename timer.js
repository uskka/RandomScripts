function CountDownTimer()
{
		var div = document.getElementById("date");
	
	var k = div.outerHTML;
	k= k.slice(48,k.length-14);

	document.getElementById("data").innerHTML = k;
	
	var arraydate = k.split(":");
	
	var tempsec =12;// arraydate[5];
	var tempmin =12; //arraydate[4];
	var temph = 12;//arraydate[3];
	var tempday =2; //arraydate[0];
	var tempm = 0;//arraydate[1];
	var tempy =0; //arraydate[2];
	
	
	
	
	
	
  var d = 0;
  var h = 0;
  var m = 0;
  var s = 0;
  var seconds = 0;
  var ts=0;
  var tm=30;
  var th=13;
  var td=5;
  var secondst=0;
   
  var timer = 0;
  
  var days=0;
  var hours=0;
  var minutes=0;
  var secondsPrint=0;
   s=tempsec;
  m=tempmin;
  h=temph;
  d=tempday;
var x = setInterval(function() {




  
  seconds = s+(m*60)+(h*3600)+(d*86400);
  
  secondst = ts+(tm*60)+(th*3600)+(td*86400);
  
  timer = secondst-seconds;
  
  //s = s+1;
  tempsec=s;
  if(s=60){
	m=m+1;
	s=0;
	tempsec=s;
	tempmin=m;
  }
  if(m=60){
	  h=h+1;
	  m=0; 
	  tempmin=m;
	  temph=h;
  }
  if(h=60){
	  d=d+1;
	  h=0; 
	  tempday=d;
	  temph=h;
  }


 days = (timer/86400);
 if(days>=10){
days= days.toString().slice(0,2);	 
 }else{
	 days= days.toString().slice(0,1);
 }
// days = parseInt(days);
 timer = timer-(days*86400);
 
 hours = (timer/3600);
  if(hours>=10){
hours= hours.toString().slice(0,2);	 
 }else{
	 hours= hours.toString().slice(0,1);
 }
 // hours = parseInt(hours);
 timer = timer-(hours*3600);
 
 minutes = (timer/60);
   if(minutes>=10){
minutes= minutes.toString().slice(0,2);	 
 }else{
	 minutes= minutes.toString().slice(0,1);
 }
 //minutes = parseInt(minutes);
 timer = timer-(minutes*60);
 
 secondsPrint = timer;
  
  
  document.getElementById("demo").innerHTML = days + "d " + hours + "h "
  + minutes + "m " + secondsPrint + "s ";
 
   
  if (secondsPrint ==0&& minutes==0&&hours==0&&days==0) {
    clearInterval(x);
    document.getElementById("demo").innerHTML = "EXPIRED";
  }
}, 5000);
}