using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text highSCoreText;
	public Text ScoreText;

	private int highscores;
	private int scores;
	private int addcounter=0;
	// Use this for initialization
	void Start () {
		highscores = PlayerPref.highscore;
		scores = PlayerPref.fruits;
		addcounter = PlayerPrefs.GetInt ("adds");
		highSCoreText.text ="High Score "+ highscores.ToString ();
		ScoreText.text = "Fruits "+scores.ToString ();
		FindObjectOfType<AudioManager>().Play("Left");
		CatcherMAIN.isGameOver = true;
		addcounter++;
		//if (addcounter % 2 == 0)
			
		//PlayerPrefs.SetInt ("adds", addcounter);
	}
	

}
