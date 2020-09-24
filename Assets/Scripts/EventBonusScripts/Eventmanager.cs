using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Eventmanager : MonoBehaviour
{
    public Transform[] bonusWaypoints;
    private GameObject go;
    public GameObject SideEffect;
    public GameObject TaskText;
    public GameObject CountEffectTextCanvas;

    private float mainEventTimer;
    TextMeshPro CountTextMeshPro;
    private int perticularFruitID=0;
    private int perticularFruitCounter = 0;
    private int perticularFruitLimit = 0;

    private float eventTimer = 5;
    private float eventCounter = 5;

    private bool isEventOn = false;

    public GameObject addscoreGO;

    void Start()
    {
        eventOnGoing = false;
        eventCounter = 20;
        mainEventTimer = Random.Range(2, 7);
        mainEventTimer *=10;
        objectPlaceCountdown = 3f;
        eventTimer = eventCounter;
        SideEffect.SetActive(false);
        TaskText.SetActive(false);
        CountEffectTextCanvas.SetActive(false);
        CountTextMeshPro = CountEffectTextCanvas.GetComponentInChildren<TextMeshPro>();
        addscoreGO.SetActive(false);
    }

    void Update()
    {
        mainEventTimer-=Time.deltaTime;
       
        if (CatcherMAIN.isGameOver == false && mainEventTimer<0)
        {
            
            mainEventTimer = Random.Range(2, 7);
            mainEventTimer *= 20;
            //print("Next event time"+mainEventTimer);
            FindObjectOfType<AudioManager>().Play("Special");
            int temp=Random.Range(0, 1);
            if (temp == 0)
            {
                
                //start perticular fruit event
                FruitEvent();
                isEventOn = true;
                eventTimer = eventCounter;
            }
            else
            {
                //rain of bombs
                StartCoroutine(BombPattern());
                
            }
        }

        EventTImerMethod();
    }

    bool eventOnGoing = false;
    
    void EventTImerMethod()
    {
        eventTimer -= Time.deltaTime;
        if (eventTimer < 0 && isEventOn)
        {
            isEventOn = false;
            StartCoroutine(FruitEventEffectOff());
        }
        else if (isEventOn)
        {
            TaskText.GetComponent<Text>().text = "Collect " + perticularFruitLimit + " " + thing + "\n"+((int)eventTimer).ToString();
            objectPlaceTimer -= Time.deltaTime;
            if (objectPlaceTimer < 0)
            {
                objectPlaceTimer = objectPlaceCountdown;
                GenerateEventItems();
            }
        }
    }

    float objectPlaceTimer;
    float objectPlaceCountdown;
    void GenerateEventItems()
    {
        int randomno = Random.Range(1, 12);
        
        gameObject.GetComponent<CatcherMAIN>().IncreaseSpawnTimer();
        gameObject.GetComponent<CatcherMAIN>().SpawnThings(perticularFruitID, randomno);
    }

    private string thing = "";
    void FruitEvent()
    {
        //effects on
        SideEffect.SetActive(true);
        TaskText.SetActive(true);
        //CountEffectTextCanvas.SetActive(true);

        int randomFruit = Random.Range(0, 4);
        perticularFruitLimit = Random.Range(5, 10);

        if (randomFruit == 0)
        {
            //apple event start
            perticularFruitID = 1;
            
            thing = "Eggs";
            
        }
        else if (randomFruit == 1)
        {
            //apple event start
            perticularFruitID = 2;
            thing = "Pine Apple";
            
            //TaskText.GetComponent<Text>().text = "Collect " + perticularFruitLimit + " Pine Apple";
        }
        else if (randomFruit == 2)
        {
            //apple event start
            perticularFruitID = 3;
            thing = "Apple";
            
            //TaskText.GetComponent<Text>().text = "Collect " + perticularFruitLimit + " Apple";
        }
        else if (randomFruit == 3)
        {
            //apple event start
            perticularFruitID = 4;
            thing = "Orrange";
            
            //TaskText.GetComponent<Text>().text = "Collect " + perticularFruitLimit + " Orrange";
        }
        else if (randomFruit == 4)
        {
            //apple event start
            perticularFruitID = 5;
            thing = "Tomatoes";
            
            //TaskText.GetComponent<Text>().text = "Collect " + perticularFruitLimit + " Tomatoes";
        }
        TaskText.GetComponent<Text>().text = "Collect " + perticularFruitLimit + " " + thing+"\n";
    }
    public void FruitCounterUpdate(Collider col)
    {
        if (isEventOn)
        {
            if (col.name == "1(Clone)" && perticularFruitID == 1)
            {
                perticularFruitCounter += 1;
                CountEffectTextCanvas.SetActive(true);
                GameObject t = Instantiate(CountEffectTextCanvas, col.transform.position, col.transform.rotation);
                t.GetComponentInChildren<TextMeshProUGUI>().text = perticularFruitCounter.ToString();
                //t.transform.position = col.transform.position + new Vector3(0, 0.2f, 0);
                Destroy(t, 0.5f);
            }
            else if (col.name == "2(Clone)" && perticularFruitID == 2)
            {
                perticularFruitCounter += 1;
                CountEffectTextCanvas.SetActive(true);
                GameObject t = Instantiate(CountEffectTextCanvas, col.transform.position, col.transform.rotation);
                t.GetComponentInChildren<TextMeshProUGUI>().text = perticularFruitCounter.ToString();
                //t.transform.position = col.transform.position + new Vector3(0, 0.2f, 0);
                Destroy(t, 0.5f);
            }
            else if (col.name == "3(Clone)" && perticularFruitID == 3)
            {
                perticularFruitCounter += 1;
                CountEffectTextCanvas.SetActive(true);
                GameObject t = Instantiate(CountEffectTextCanvas, col.transform.position, col.transform.rotation);
                t.GetComponentInChildren<TextMeshProUGUI>().text = perticularFruitCounter.ToString();
                //t.transform.position = col.transform.position + new Vector3(0, 0.2f, 0);
                Destroy(t, 0.5f);
            }
            else if (col.name == "4(Clone)" && perticularFruitID == 4)
            {
                perticularFruitCounter += 1;
                CountEffectTextCanvas.SetActive(true);
                GameObject t = Instantiate(CountEffectTextCanvas, col.transform.position, col.transform.rotation);
                t.GetComponentInChildren<TextMeshProUGUI>().text = perticularFruitCounter.ToString();
                //t.transform.position = col.transform.position + new Vector3(0, 0.2f, 0);
                Destroy(t, 0.5f);
            }
            else if (col.name == "5(Clone)" && perticularFruitID == 5)
            {
                perticularFruitCounter += 1;
                CountEffectTextCanvas.SetActive(true);
                GameObject t = Instantiate(CountEffectTextCanvas, col.transform.position, col.transform.rotation);
                t.GetComponentInChildren<TextMeshProUGUI>().text = perticularFruitCounter.ToString();
                //t.transform.position = col.transform.position + new Vector3(0, 0.2f, 0);
                Destroy(t, 0.5f);
            }
            if (perticularFruitLimit == perticularFruitCounter)
            {
                //end the event and add score
                perticularFruitCounter = 0;
                PlayerPref.fruits += perticularFruitLimit * 5;
                isEventOn = false;
                addscoreGO.SetActive(true);
                addscoreGO.GetComponent<Text>().text = "+" + (perticularFruitLimit * 5).ToString();
                StartCoroutine(FruitEventEffectOff());
            }
        }
    }

    IEnumerator FruitEventEffectOff()
    {
        yield return new WaitForSeconds(1);
        SideEffect.SetActive(false);
        TaskText.SetActive(false);
        FindObjectOfType<AudioManager>().Stop("Special");
        StartCoroutine(DisableFruitEventScore());
       // CountEffectTextCanvas.SetActive(false);
    }

    IEnumerator DisableFruitEventScore()
    {
        yield return new WaitForSeconds(3);
        addscoreGO.SetActive(false);
    }

    IEnumerator BombPattern()
    {
        go = gameObject.GetComponent<CatcherMAIN>().bombGO;
        foreach (Transform t in bonusWaypoints)
        {
            yield return new WaitForSeconds(0.5f);
        
            GameObject tempgo = Instantiate(go, t.position, t.rotation);
            tempgo.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 200, ForceMode.Impulse);
        }
    }
}
