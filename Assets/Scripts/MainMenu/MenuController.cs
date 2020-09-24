using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour {

	void Start()
	{
		FindObjectOfType<AudioManager>().Play("Bg");
	}
	public void Plays()
	{
		SceneManager.LoadScene(1);
	}
	public void Quit()
	{
		Application.Quit ();
	}
    public void PVP()
    {
        SceneManager.LoadScene("PVPFruitcatcher");
    }
    public void PolicyButton()
    {
        Application.OpenURL("https://kreasarstudio.wixsite.com/home/catch-the-fruit");
    }
}
