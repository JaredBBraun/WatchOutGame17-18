using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SimonSaysV2 : MonoBehaviour
{

    ///<summary>
    ///Do a simon says game where the user has to follow a visual pattern
    ///follow the pattern with your eyes
    ///if not they die
    ///<\summary>

    public bool Looking;
	public GameObject Blocks;
	private GazeAwareComponent _gazeComp;
    private int Rand;
    public Animator anim;
    public Light cubeLight;
    public FirstPersonController myscript;
    public GameObject triggerCube;
    public bool isInside = false;
    public IMP_Door theDoor;
    public DoorCheckIMP script;


    public bool WORK;

    // Use this for initialization
    void Start () {

        //_gazeAware = GetComponent<GazeAwareComponent>();
        //_gazeComp = GetComponentsInChildren<GazeAwareComponent>();


        cubeLight.enabled = false;
        _gazeComp = GetComponent<GazeAwareComponent>();
        
        myscript = GetComponent<FirstPersonController>();
        

    }

    // Update is called once per frame
    void Update()
    {
        Looking = _gazeComp.HasGaze;
        anim.SetBool("PlayAnim", Looking);
        cubeLight.enabled = Looking;
       
       if (script.isDone == true)
       {
           theDoor.doorOut();
       }
        if (WORK)
        {
            //theDoor.doorOut();
        }
    // if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
    //   {
    //       theDoor.open = true;
    //   }
        
          //  if (Looking == true)
          //  {
          //      //play animation
          //     // anim.enabled = true;
          //      
          //
          //  }
          //  else if (Looking == false)
          //  {
          //      //anim.enabled = false;
          //      Restart();
          //      //  anim.SetBool("noPlay", Looking);
          //      //stop or pause animation
          //  }
            if (isInside)
        {
            myscript.enabled = false;
        }

    }

    

    void Awake()
    {
        
    }
    public void Restart()
    {


       //Do 

    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInside = false;
        }
    }
}

