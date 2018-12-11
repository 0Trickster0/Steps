using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public bool isShown;
    public string sceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ShowMenu();
	}

    private void ShowMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isShown)
            {
                gameObject.transform.Find("MenuCanvas").gameObject.SetActive(true);
                Time.timeScale = 0;
                Player.Instance.isDisabled = true;
                isShown = true;
            }
            else if(isShown)
            {
                GameObject.Find("MenuCanvas").SetActive(false);
                Time.timeScale = 1;
                Player.Instance.isDisabled = false;
                isShown = false;
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Player.Instance.isDisabled = false;
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Player.Instance.isDisabled = false;
        Destroy(GameObject.Find("WisePointController")); 
        SceneManager.LoadScene("0");
    }
}
