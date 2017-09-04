using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SimpleFSM2Knight : FSM 
{

	public Animator AnimatorKnight;
	public GameObject wanderPoint;
	// public float DistanceToPatrol= 10f;
	public float DistanceToAttack = 5f;
	public float DistanceToChase = 10f;
	public float DistanceToPos = 2f;
	int pointIndex = 0;
	public float patrolS = 2;
	public float chaseS = 4;
	public bool Gazey;


	public enum FSMState
	{
		None,
		Patrol,
		Chase,
		Attack,
		Dead,
		Waiting,
	}


	float lookAway = 0f;
	//Current state that the NPC is reaching
	public FSMState curState;

	//Speed of the tank
	private float curSpeed;

	//Tank Rotation Speed
	public float curRotSpeed;

	//Swinger
	public GameObject hitboxers;
	public GameObject spawnPoint;
	protected float timeOfSwing;

	//Whether the NPC is destroyed or not
	private bool bDead;
	private int health;

	public GazeAwareComponent _gazeAware;
	private NavMeshAgent agent;


	//Initialize the Finite state machine for the NPC tank
	protected override void Initialize () 
	{
		curState = FSMState.Patrol;
		curSpeed = 1.0f;      //movement speed
		//curRotSpeed = 1.0f;
		bDead = false;
		elapsedTime = 0.0f;
		gazeTime = 0.0f;
		stared = 1.0f;       //time to look at before it attacks you
		attackRate = 1.0f;
		health = 100;



		//Get the list of points
		pointList = GameObject.FindGameObjectsWithTag("WandarPoint");

		agent = GetComponent<NavMeshAgent>();

		_gazeAware = GetComponent<GazeAwareComponent>();
		if (!_gazeAware)
		{
			Debug.Log("NO GAZE component found!");
		}

		//Set Random destination point first
		FindNextPoint();

		//Get the target enemy(Player)
		GameObject objPlayer = GameObject.FindGameObjectWithTag("EnemyTarget");
		playerTransform = objPlayer.transform;



		if (!playerTransform)
			print("Player doesn't exist.. Please add one with Tag named 'Player'");


	}

	//Update each frame
	protected override void FSMUpdate()
	{
		switch (curState)
		{
		case FSMState.Patrol: UpdatePatrolState(); break;
		case FSMState.Chase: UpdateChaseState(); break;
		case FSMState.Attack: UpdateAttackState(); break;
		case FSMState.Dead: UpdateDeadState(); break;
		case FSMState.Waiting: UpdateWaitingState(); break;
		}

		Gazey = _gazeAware.HasGaze;

		//Update the time
		elapsedTime += Time.deltaTime;
		if (_gazeAware.HasGaze)
			gazeTime += Time.deltaTime;
		else if ((gazeTime > stared) && (!_gazeAware.HasGaze))
		{

			lookAway += Time.deltaTime;
			if (lookAway > stared)
				gazeTime = 0.0f;

		}


		//Go to dead state is no health left
		if (health <= 0)
			curState = FSMState.Dead;
	}

	/// <summary>
	/// Waiting State
	/// </summary>
	protected void UpdateWaitingState()
	{
		if (!_gazeAware.HasGaze)
		{
			print("Knight: Waiting to Patrol");
			curState = FSMState.Patrol;
		}
		/*
        else if (gazeTime >= stared && _gazeAware.HasGaze)
        {
            print("Knight: Keep Waiting");
            curState = FSMState.Waiting;
        }
        */
	}

	/// <summary>
	/// Patrol state
	/// </summary>
	protected void UpdatePatrolState()
	{
		// Debug.Log(destPos);
		agent.speed = patrolS;
		Gazey = _gazeAware.HasGaze;

		float DistToPlayer = Vector3.Distance(transform.position, playerTransform.position);
		//Find another random patrol point if the current point is reached
		if (Vector3.Distance(transform.position, destPos) <= DistanceToPos)
		{
			// print("Reached, finding next");
			FindNextPoint();
		}

		//Check the distance with player tank
		//When the distance is near, transition to chase state

		if ((DistToPlayer <= DistanceToChase) && (!_gazeAware.HasGaze ))
		{

			//print("Knight: Switch to Chase");
			Debug.Log("Patrol to Chase: ");// +DistToPlayer);
			curState = FSMState.Chase;

		}
		/*
		else if (_gazeAware.HasGaze )//&& gazeTime >= stared)
        {
            print("Knight: Patrol to Waiting: ");// +DistToPlayer);
            curState = FSMState.Waiting;
        }
        */

		agent.destination = destPos;
		AnimatorKnight.SetTrigger("isWalking");
		/*
        //Rotate to the target point
		Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
		targetRotation.x = 0.0f;
		targetRotation.z = 0.0f;
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);

		//Go Forward
		transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
		AnimatorKnight.SetTrigger("isWalking");
		*/
	}

	/// <summary>
	/// Chase state
	/// </summary>
	protected void UpdateChaseState()
	{
		//Set the target position as the player position
		destPos = playerTransform.position;
		agent.speed = chaseS;

		//Check the distance with player tank
		//When the distance is near, transition to attack state
		float dist = Vector3.Distance(transform.position, playerTransform.position);
		if ((dist <= DistanceToAttack) && !_gazeAware.HasGaze)
		{
			print("Knight: Chase to Attack: ");// + dist);
			curState = FSMState.Attack;
		}

		//Go back to patrol is it become too far
		else if (dist > DistanceToChase)// && _gazeAware.HasGaze)
		{
			print("Knight: Chase back to Patrol: ");// + dist);
			curState = FSMState.Patrol;
		}

		else if (_gazeAware.HasGaze)
		{
			print("Knight: Chase to Patrol because looking ");// +dist);
			curState = FSMState.Patrol;
		}


		agent.destination = destPos;
		AnimatorKnight.SetTrigger("isWalking");

		/*
        //Rotate to the target point
		Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
		targetRotation.x = 0.0f;
		targetRotation.z = 0.0f;
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);

		//Go Forward
		transform.Translate(Vector3.forward * Time.deltaTime * (curSpeed + 1));
		// AnimatorKnight.SetTrigger("isWalking");
		*/
	}

	/// <summary>
	/// Attack state
	/// </summary>
	protected void UpdateAttackState()
	{
		//Set the target position as the player position
		destPos = playerTransform.position;

		//Check the distance with the player tank
		float dist = Vector3.Distance(transform.position, playerTransform.position);
		//Transition to patrol is the tank become too far

		if (dist > DistanceToAttack)//&& _gazeAware.HasGaze)
		{
			print("Knight: attack back to Chase: ");// +dist);
			curState = FSMState.Chase;
		}
		else if (_gazeAware.HasGaze) {
			print("Knight: Attack to Waiting: ");// +dist);
			curState = FSMState.Waiting;
		}

		//Shoot the bullets
		else {
			Debug.Log("Shooting the Bullet: ");// +dist);
			ShootBullet ();
		}
	}

	/// <summary>
	/// Dead state
	/// </summary>
	protected void UpdateDeadState()
	{
		//Show the dead animation with some physics effects
		if (!bDead)
		{
			bDead = true;
			Explode();
		}
	}

	/// <summary>
	/// Shoot the bullet from the turret
	/// </summary>
	private void ShootBullet()
	{
		print("MaybeSwing");
		if (elapsedTime >= attackRate)
		{
			print("Swing");

			//Reset the timer
			elapsedTime = 0.0f;
			timeOfSwing = Time.deltaTime;

			GameObject hammerInstance;

           

			//Also Instantiate over the PhotonNetwork
			hammerInstance = Instantiate(hitboxers, spawnPoint.transform.position, transform.rotation) as GameObject;
			hammerInstance.tag = ("Attack");
			hammerInstance.AddComponent<EndSwing>();
			hammerInstance.gameObject.SetActive(true);
		}
	}

	/// <summary>
	/// Find the next semi-random patrol point
	/// </summary>
	protected void FindNextPoint()
	{
		print("Finding next point");
		//int rndIndex = Random.Range(0, pointList.Length);
		//float rndRadius = 10.0f;

		//Vector3 rndPosition = Vector3.zero;
		destPos = pointList[pointIndex++].transform.position;

		//Check Range
		if (pointIndex > pointList.Length - 1)
		{
			pointIndex = 0;
		}
		//Prevent to decide the random point as the same as before
		/* if (IsInCurrentRange(destPos))
        {
            rndPosition = new Vector3(Random.Range(-rndRadius, rndRadius), 0.0f, Random.Range(-rndRadius, rndRadius));
            destPos = pointList[rndIndex].transform.position + rndPosition;
        }*/
	}

	/// <summary>
	/// Check whether the next random position is the same as current tank position
	/// </summary>
	/// <param name="pos">position to check</param>
	protected bool IsInCurrentRange(Vector3 pos)
	{
		float xPos = Mathf.Abs(pos.x - transform.position.x);
		float zPos = Mathf.Abs(pos.z - transform.position.z);

		if (xPos <= 50 && zPos <= 50)
			return true;

		return false;
	}

	protected void Explode()
	{
		float rndX = Random.Range(10.0f, 30.0f);
		float rndZ = Random.Range(10.0f, 30.0f);
		for (int i = 0; i < 3; i++)
		{
			GetComponent<Rigidbody>().AddExplosionForce(10000.0f, transform.position - new Vector3(rndX, 10.0f, rndZ), 40.0f, 10.0f);
			GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(rndX, 20.0f, rndZ));
		}

		Destroy(gameObject, 1.5f);
	}

}
