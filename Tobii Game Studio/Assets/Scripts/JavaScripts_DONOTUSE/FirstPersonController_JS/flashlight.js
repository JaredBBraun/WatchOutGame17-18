//Script made by StrupsGames
 
var flashlight : Light;
var soundOn : GameObject;
var soundOff : GameObject;
var flicker;

 
function Start () {
flashlight.enabled = true; 

}
 
 
function Update () 
{ 
    if(Input.GetKeyDown(KeyCode.F)) // You can choose any button, im using the button F, rename it if you want a diffrent button to use.
    {
        if(flashlight.enabled == false)
        {
            flicker = true;
            flashlight.enabled = true;
            //soundOn.GetComponent.<AudioSource>().Play();
        }
        else
        {
            flicker = false;
            flashlight.enabled = false;
            //soundOff.GetComponent.<AudioSource>().Play();
        }
    }






    if (flicker == true)
    {
        if ( Random.value < .05 )//a random chance
        {
            if (flashlight.enabled == true ) //if the light is on...
            {
                flashlight.intensity = 0.9f; //turn it off
            }
            else
            {
                flashlight.intensity = 3.87f; //turn it on
            }
        }
    }
}








