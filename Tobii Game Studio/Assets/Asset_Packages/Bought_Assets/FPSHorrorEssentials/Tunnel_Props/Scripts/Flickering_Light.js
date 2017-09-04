#pragma strict

public var flickering : boolean = true;
public var flickerrate : float = 0.1f;
private var randomHolder : float =0.0f;
private var lightToggle : int = 0;
private var lighOnDuration : int = 4000;
//public var bulbRenderer : MeshRenderer;
//private var bulbMaterial : Material;

function Start() {
	//this.bulbMaterial = this.bulbRenderer.material;
	//this.lightToggle = 1;
}

function Update () {
	flickerLight();
}


function flickerLight() {
	//Debug.Log("Flickin an lickin yo mom");
	//this.bulbMaterial.SetColor("_EmissionColor", Color.white);

	//while(flickering) {
		if (Random.Range(0,lighOnDuration)>lighOnDuration-10) 
			{
			lightToggle = 1-lightToggle;
			}
		//yield WaitForSeconds(Random.Range(5, 25));
		randomHolder = 0.5+Random.Range(0.0, 3.0);
		if (lightToggle ==1)
		{
			
			gameObject.GetComponent.<Light>().intensity = randomHolder+Random.Range(-1, 1);
			gameObject.GetComponent.<ParticleSystem>().startSize = randomHolder/4;
			lighOnDuration=2000;
		}

 		//yield WaitForSeconds(Random.Range(flickerrate, flickerrate*20));
 		if (lightToggle ==0)
			{	
 			gameObject.GetComponent.<Light>().intensity = 0;
			gameObject.GetComponent.<ParticleSystem>().startSize =Random.Range(0.06, 0.1);
			lighOnDuration=4000;
			}

				
		
 
 	//}

}