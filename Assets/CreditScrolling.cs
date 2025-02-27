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

        // Quitter les crédits quand le texte est sorti de l'écran
        /*if (transform.position.y > Screen.height)
        {
            SceneManager.LoadScene("MainMenu"); // Retour au menu principal
        }*/
    }
}
