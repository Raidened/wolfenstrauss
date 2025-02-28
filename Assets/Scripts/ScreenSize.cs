using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float aspectRatio = (float)Screen.width / Screen.height;
        if (Mathf.Approximately(aspectRatio, 16f / 9f)) // Comparaison avec tolérance
        {
            Debug.Log("L'aspect est en 16/9"); // Ajuste la taille de la caméra
        }
        else
        {
            Camera.main.orthographicSize = 11.15f; // Ajuste la taille de la caméra
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
