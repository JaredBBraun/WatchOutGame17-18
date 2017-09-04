using UnityEngine;
using System.Collections;

public class SimpleFSM1Garg : FSM 
{
    static Animator AnimatorGarg;

    public enum FSMState
    {
        None,
        Chase,
        Attack,
        Dead,
        Waiting,
    }

    //Current state that the NPC is reaching
    public FSMState curState;

    //Speed of the tank
    private float curSpeed;

    //Tank Rotation Speed
    private float curRotSpeed;

    //Swinger
    public GameObject hitboxers;
    public GameObject spawnPoint;
    protected float timeOfSwing;

    //Whether the NPC is destroyed or not
    private bool bDead;
    private int health;

    private GazeAwareComponent _gazeAware;
    float timeLeft;
    Color targetColor;

    //Initialize the Finite state machine for the NPC tank
    protected override void Initialize () 
    {
        curState = FSMState.Waiting;
        curSpeed = 8.2f;
        curRotSpeed = 5.5f;
        bDead = false;
        elapsedTime = 0.0f;
        gazeTime = 0.0f;
        stared = 1.0f;
        attackRate = 3.0f;
        health = 100;
        timeOfSwing = -3;

        //Get the list of points
        pointList = GameObject.FindGameObjectsWithTag("WandarPoint");

        //Set Random destination point first
        FindNextPoint();

        //Get the target enemy(Player)
        GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
        playerTransform = objPlayer.transform;
        if (!playerTransform)
            print("Player doesn't exist.. Please add one with Tag named 'Player'");

        _gazeAware = GetComponent<GazeAwareComponent>();
	}

    //Update each frame
    protected override void FSMUpdate()
    {
        switch (curState)
        {
            case FSMState.Chase: UpdateChaseState(); break;
            case FSMState.Attack: UpdateAttackState(); break;
            case FSMState.Dead: UpdateDeadState(); break;
            case FSMState.Waiting: UpdateWaitingState(); break;
        }

        //Update the time
        elapsedTime += Time.deltaTime;
        if (_gazeAware.HasGaze)
            gazeTime += Time.deltaTime;
        else
            gazeTime = 0.0f;

        //Go to dead state is no health left
        if (health <= 0)
            curState = FSMState.Dead;
    }

    /// <summary>
    /// Waiting State
    /// </summary>
    protected void UpdateWaitingState()
    {
        if (_gazeAware.HasGaze)
        {
            curState = FSMState.Chase;
            AnimatorGarg.SetTrigger("isWalkingGarg");
            Debug.Log("The gargoyle is walking");

        }
        else
        {
            curState = FSMState.Waiting;
        }
    }

    /// <summary>
    /// Chase state
    /// </summary>
    protected void UpdateChaseState()
    {
        //Set the target position as the player position
        destPos = playerTransform.position;

        //Check the distance with player tank
        //When the distance is near, transition to attack state
        float dist = Vector3.Distance(transform.position, playerTransform.position);
        if (dist <= 5.0f && _gazeAware.HasGaze)
        {
            curState = FSMState.Attack;
        }

        //Go back to patrol is it become too far
        else if (dist >= 30.0f || !_gazeAware.HasGaze)
        {
            print("Switch to Patrol");
            curState = FSMState.Waiting;
        }
        if (timeLeft <= Time.deltaTime)
        {
            // transition complete
            // assign the target color
            GetComponent<Renderer>().material.color = targetColor;

            // start a new transition
            targetColor = new Color(Random.value, Random.value, Random.value);
            timeLeft = 1.0f;
        }
        else
        {
            // transition in progress
            // calculate interpolated color
            GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, targetColor, Time.deltaTime / timeLeft);

            // update the timer
            timeLeft -= Time.deltaTime;
        }
        //Rotate to the target point
        Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);

        //Go Forward
        transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
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
        if (dist >= 2.0f && dist < 5.0f && _gazeAware.HasGaze)
        {
            //Rotate to the target point
            Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);
            
            //Go Forward
            transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);

            curState = FSMState.Attack;
            if (timeLeft <= Time.deltaTime)
            {
                // transition complete
                // assign the target color
                GetComponent<Renderer>().material.color = targetColor;

                // start a new transition
                targetColor = new Color(Random.value, Random.value, Random.value);
                timeLeft = 1.0f;
            }
            else
            {
                // transition in progress
                // calculate interpolated color
                GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, targetColor, Time.deltaTime / timeLeft);

                // update the timer
                timeLeft -= Time.deltaTime;
            }
        }
        //Transition to patrol is the tank become too far
        else if (dist >= 30.0f || !_gazeAware.HasGaze)
        {
            print("Switch to Waiting");
            curState = FSMState.Waiting;
        }

        //Shoot the bullets
        ShootBullet();
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
        int rndIndex = Random.Range(0, pointList.Length);
        float rndRadius = 10.0f;
        
        Vector3 rndPosition = Vector3.zero;
        destPos = pointList[rndIndex].transform.position + rndPosition;

        //Check Range
        //Prevent to decide the random point as the same as before
        if (IsInCurrentRange(destPos))
        {
            rndPosition = new Vector3(Random.Range(-rndRadius, rndRadius), 0.0f, Random.Range(-rndRadius, rndRadius));
            destPos = pointList[rndIndex].transform.position + rndPosition;
        }
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
