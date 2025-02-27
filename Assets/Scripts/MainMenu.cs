using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
        Debug.Log("Credit Menu");
		SceneManager.LoadScene("Menu");
		}
	}

    public void Credit()
    {
        Debug.Log("Credit Menu");
		SceneManager.LoadScene("Credit");
    }

    public void Play()
    {
        Debug.Log("Play Game");
		SceneManager.LoadScene("Tutorial");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
