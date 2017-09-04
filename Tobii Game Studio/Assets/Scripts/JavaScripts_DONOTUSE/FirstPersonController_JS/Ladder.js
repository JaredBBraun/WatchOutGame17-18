#pragma strict
  
  var chController : Transform;
  var inside : boolean = false;
  var heightFactor : float = 3.2;
 

 private var FPSInput : FPSInputController;
 private var FPSSpeed : CharacterMotor;
 function Start()
 {
 	FPSInput = GetComponent(FPSInputController);
 	FPSSpeed = GetComponent(CharacterMotor);
 }

 function OnTriggerEnter(Col : Collider)
 {
 	if(Col.gameObject.tag == "Ladder")
 	{
 			
 			//	FPSInput.enabled = false;
 				inside = !inside;
 			
 	}
 	
 }

 function OnTriggerExit(Col : Collider)
 {
 	if(Col.gameObject.tag == "Ladder") 
 	{
 		
 			//FPSInput.enabled = true;
 			inside = !inside;
 			FPSSpeed.enabled = true;
 		
 	}

 }
 		
 function Update()
 {
 	if(inside == true && Input.GetKey("w"))
 	{
 			chController.transform.position += Vector3.up / heightFactor;
 	}

 	if(inside == true && Input.GetKey("s"))
 	{
 			chController.transform.position += (-Vector3.up / heightFactor);
 			FPSSpeed.enabled = true;
 	}
 	else if ((Input.GetKeyUp("w")) && (inside == true))
 	{
 
 			FPSSpeed.enabled = false;
 			
 	}
 }