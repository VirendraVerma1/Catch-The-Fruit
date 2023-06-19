using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamecontroller : MonoBehaviour {

    void Start()
    {
        saveload.Load();
        CheckAccount();
    }

    public GameObject CatcherGO;
	public void Restarts()
	{
		SceneManager.LoadScene (1);
	}
	public void Mainsa()
	{
		SceneManager.LoadScene (0);
	}

    public void ActivateCatcher()
    {
        saveload.adscounter--;
        CatcherGO.SetActive(false);
        StartCoroutine(CatcherActivate());
        StartCoroutine(ShowAds());
    }

    IEnumerator CatcherActivate()
    {
        yield return new WaitForSeconds(2f);
        PlayerPref.lives = -1;
        
        //CatcherGO.SetActive(true);
    }

    IEnumerator ShowAds()
    {
        yield return new WaitForSeconds(1);
        //TODO Show Ads
        if (saveload.adscounter < 0)
        {
            saveload.adscounter = Random.Range(2, 7);
            //Show Ads
            saveload.nuAddWatched = saveload.nuAddWatched + 1;
            saveload.Save();
            gameObject.GetComponent<AdScript>().ShowInterstitialAd();
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }

    #region CheckAccount

    private string createaccountURL = "https://torrentodownloader.000webhostapp.com/CatchTheFruit/createaccount.php";
    private string updateThingsURL = "https://torrentodownloader.000webhostapp.com/CatchTheFruit/checkNotification.php";

    void CheckAccount()
    {
        if (saveload.accountID != "")
        {
            //means have account
            StartCoroutine(UpdateThings());
        }
        else
        {
            //create account
            StartCoroutine(CreateAccount());
        }
    }

    IEnumerator CreateAccount()
    {
        WWWForm form1 = new WWWForm();
        form1.AddField("account", Random.Range(10000, 999999));
        WWW www = new WWW(createaccountURL, form1);
        yield return www;
        print("CreateAccount");
        print(www.text);
        if (www.text.Contains("ID"))
        {
            saveload.accountID = GetDataValue(www.text, "ID:");
            saveload.Save();
        }
    }

    IEnumerator UpdateThings()
    {
        WWWForm form1 = new WWWForm();
        form1.AddField("id", saveload.accountID);
        form1.AddField("Ads", saveload.nuAddWatched);
        WWW www = new WWW(updateThingsURL, form1);
        yield return www;
        print("Updated");
        print(www.text);
    }

    #endregion

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains(","))
            value = value.Remove(value.IndexOf(","));
        return value;
    }
    
}
