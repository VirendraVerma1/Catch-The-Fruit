using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restobjectTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		Destroy (col.gameObject);
		//PlayerPref.lives--;
		FindObjectOfType<AudioManager>().Play("Left");
	}
}
