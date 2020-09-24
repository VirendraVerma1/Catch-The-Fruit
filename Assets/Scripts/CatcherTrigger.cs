using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherTrigger : MonoBehaviour {

    public GameObject burstCatcherEffects;
    

	void OnTriggerEnter(Collider col)
	{
        if (col.gameObject.tag == "Fruits")
        {
            
            Destroy(col.gameObject);
            PlayerPref.fruits++;
            FindObjectOfType<AudioManager>().Play("Catch");
            Eventmanager eventScript = FindObjectOfType<Eventmanager>();
            eventScript.FruitCounterUpdate(col);
            
        }
        else if (col.gameObject.tag == "BOMB")
        {
            
            //bomb activity
            Destroy(col.gameObject);
            Instantiate(burstCatcherEffects, transform.position, transform.rotation);
            gamecontroller gamecontrollerscript = FindObjectOfType<gamecontroller>();
            gamecontrollerscript.ActivateCatcher();
            FindObjectOfType<AudioManager>().Play("Bomb");

        }
        else if (col.gameObject.tag == "Egg")
        {
            Destroy(col.gameObject);
            PlayerPref.fruits--;
            FindObjectOfType<AudioManager>().Play("Left");
            Eventmanager eventScript = FindObjectOfType<Eventmanager>();
            eventScript.FruitCounterUpdate(col);
        }
       
	}
   
   
}
