using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Options()
    {
        Debug.Log("Options Menu");
    }

    // Update is called once per frame
    public void Play()
    {
        Debug.Log("Play Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
