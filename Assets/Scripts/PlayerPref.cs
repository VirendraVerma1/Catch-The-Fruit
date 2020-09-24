using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerPref : MonoBehaviour {

	public GameObject gameOverPannel;

	public Text texthighscore;
	public static int highscore;
	public Text textFruits;
	public static int fruits;
	public GameObject Life1;
	public GameObject Life2;
	public GameObject Life3;
	public GameObject Life4;
	public GameObject Life5;

	public static int lives=5;

	void Start()
	{
		gameOverPannel.SetActive (false);
		highscore = PlayerPrefs.GetInt ("highestScore");
		fruits = 0;
		lives = 5;
		Life1.SetActive (false);
        Life2.SetActive(false);
        Life3.SetActive(false);
        Life4.SetActive(false);
        Life5.SetActive(false);
	}

	void Update()
	{
		if (fruits > highscore)
			highscore = fruits;
		texthighscore.text = " " + highscore.ToString ();
		PlayerPrefs.SetInt("highestScore", highscore);
		textFruits.text = " " + fruits.ToString();
		if (lives > 4) {
			Life5.SetActive (false);
		} else if (lives > 3) {
			Life4.SetActive (false);
		} else if (lives > 2) {
			Life3.SetActive (false);
		} else if (lives > 1) {
			Life2.SetActive (false);
		} 
		else if (lives > 0) {
			Life1.SetActive (false);
		} 
		else if (lives <= 0) {
			gameOverPannel.SetActive (true);
		}
	}



}
