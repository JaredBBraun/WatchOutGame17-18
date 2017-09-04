var Distance; 
var Target : Transform;
var lookAtDistance = 25.0;
var Damping = 6.0;

function Update ()
{
	Distance = Vector3.Distance(Target.position, transform.position);

	if (Distance < lookAtDistance)
	{
		lookAt();
	}
}

function lookAt ()
{
	var rotation = Quaternion.LookRotation(Target.position - transform.position);
	transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
}