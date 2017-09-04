using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class healthSystem : MonoBehaviour {

public Text ImDead;
public bool isHurt = false;
private float timeRecover = 30.0f;
public float flashSpeed = 5f;
private float passedTime = 0;
public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
public Image damageImage;
public bool isDead;

    void Start()
    {
        //AWP - Added Null Checks to Start
        if(ImDead == null)
        {
            Debug.LogWarning("[healthSystem] Warning, ImDead is not assigned in inspector");
        }
        else
        {
            ImDead.enabled = false;
        }

        if(damageImage == null)
        {
            Debug.LogWarning("[healthSystem] Warning, Damage Image not set.");
        }

        isDead = false;
    }

	void FixedUpdate ()
    {
		if (isHurt == true)
		{
			//damageImage.color = flashColour;
			passedTime += Time.deltaTime;
		}
		else
		{
			passedTime = 0;
            if (damageImage)
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
		}
        if (passedTime >= timeRecover)
        {
            isHurt = false;  //resets the damage back to default
        }
        if (isDead)
        {
			//ImDead.enabled = true;

			SceneManager.LoadScene ("Pax_level1");
            PlayerDeath();
        }
    }

    //STB - Collider
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Attack")
        {
            Debug.LogWarning("Player has been hit!");
            //STB - if hit by an attack and if not hurt, set to hurt
            if (!isHurt)
                isHurt = true;
            //STB - If hurt and hit by attack, pause game
            else if (passedTime < timeRecover)
            {
                Debug.LogWarning("Player is dead!");
                Time.timeScale = 0;
                isDead = true;
            }
        }
    }

    IEnumerator PlayerDeath()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("End_Credit");

    }
}
