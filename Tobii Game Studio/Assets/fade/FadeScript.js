#pragma strict


var timer :float = 1;
function Start () {

GetComponent.<Renderer>().material.color.a=1;

}

function Update () {

timer=timer-Time.deltaTime;
if (timer>=0)
{
GetComponent.<Renderer>().material.color.a -=0.1*Time.deltaTime;
}

if (timer<=0)
{
timer=0;
Destroy(gameObject);
}



	
}
