using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatcherMAIN : MonoBehaviour {

	public GameObject fallingObject;
	public GameObject fallingObject1;
	public GameObject fallingObject2;
	public GameObject fallingObject3;
	public GameObject fallingObject4;
	public Waypoints waypoint;
	public float countdown=5f;
	public static bool isGameOver=false;

    public GameObject bombGO;

	//private Transform target;
	private int randomno;
	private int randomObject;
	private float timeinterval;
//	private float fallingobjectDrag;
	private float fruitRatemin;
	private float fruitRatemax;
	private int fruitno;
    private float gravityValue;

	public Text counterText;
	private float time;
    private float tempTime;

    //bomb variables
    private float bombFrequency = 5;

	void Start()
	{
		fruitRatemin = 0.4f;
		fruitRatemax = 0.8f;
		fruitno = 50;
		isGameOver=false;
		countdown=3f;
		timeinterval = countdown;
		time = 1 * 60;
        tempTime = 1 * 10;
		//target = Waypoints.points [0];
		//fallingobjectDrag = 4;
        gravityValue = -9.8f;
	}
	void Update()
	{

        BombMechanism();
        FruitsSpawnSystem();
        
		
		if (isGameOver) {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Fruits");
			foreach(GameObject enemy in enemies)
				GameObject.Destroy(enemy);
		}
	}

    void BombMechanism()
    {
        //bomb system
        bombFrequency -= Time.deltaTime;
        if (bombFrequency < 0 && !isGameOver)
        {
            bombGO.GetComponent<Rigidbody>().drag = Random.Range(3, 5);
            randomno = Random.Range(1, 12);
            Instantiate(bombGO, Waypoints.points[randomno]);
            bombFrequency = Random.Range(3, 10);
        }
    }

    void FruitsSpawnSystem()
    {
        timeinterval = timeinterval - Time.deltaTime;
        if (timeinterval < 0 && isGameOver == false)
        {
            randomno = Random.Range(1, 12);
            randomObject = Random.Range(1, 6);
            //print (randomno);
            countdown = Random.Range(fruitRatemin, fruitRatemax);
            SpawnThings(randomObject, randomno);
            timeinterval = countdown;

            if (PlayerPref.fruits > fruitno && PlayerPref.fruits < 300)
            {
                if (fruitRatemin>0.1f)
                fruitRatemin = fruitRatemin - 0.1f;
                if(fruitRatemax>0.5f)
                fruitRatemax = fruitRatemax - 0.1f;
                fruitno = fruitno * 10;
                print("FruitNo:" + fruitno);
            }
            else if (PlayerPref.fruits > fruitno && PlayerPref.fruits < 1000)
            {
                gravityValue -= 0.005f;
                Physics.gravity = new Vector3(0, gravityValue, 0);
            }
        }
        
    }

    public void IncreaseSpawnTimer()
    {
        timeinterval = countdown;
    }
    public void SpawnThings(int randomObject, int randomno)
    {
        if (randomObject == 1)
        {
            fallingObject.GetComponent<Rigidbody>().drag = Random.Range(3, 5);
            Instantiate(fallingObject, Waypoints.points[randomno]);
        }
        else if (randomObject == 2)
        {
            fallingObject1.GetComponent<Rigidbody>().drag = Random.Range(3, 5);
            Instantiate(fallingObject1, Waypoints.points[randomno]);
        }
        else if (randomObject == 3)
        {
            fallingObject2.GetComponent<Rigidbody>().drag = Random.Range(3, 5);
            Instantiate(fallingObject2, Waypoints.points[randomno]);
        }
        else if (randomObject == 4)
        {
            fallingObject3.GetComponent<Rigidbody>().drag = Random.Range(3, 5);
            Instantiate(fallingObject3, Waypoints.points[randomno]);
        }
        else if (randomObject == 5)
        {
            fallingObject4.GetComponent<Rigidbody>().drag = Random.Range(3, 5);
            Instantiate(fallingObject4, Waypoints.points[randomno]);
        }
    }
}


/*

time = time - Time.deltaTime;
        
		int tempmin = Mathf.FloorToInt (time / 60);
		counterText.text =tempmin.ToString()+":"+Mathf.RoundToInt (time / (tempmin+1)).ToString();

*/