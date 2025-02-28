using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScrolling : MonoBehaviour
{
    public float scrollSpeed = 50f;

    void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

        // Quitter les cr�dits quand le texte est sorti de l'�cran
        /*if (transform.position.y > Screen.height)
        {
            SceneManager.LoadScene("MainMenu"); // Retour au menu principal
        }*/
    }
}
