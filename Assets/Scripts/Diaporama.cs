using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diaporama : MonoBehaviour
{
    public GameObject[] slides; // Tableau des images
    private int currentSlide = 0;

    void Start()
    {
        UpdateSlides();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "intro" && currentSlide == 4)
        {
            SceneManager.LoadScene("Tutorial");
        }
        
        if (SceneManager.GetActiveScene().name == "end" && currentSlide == 6)
        {
            SceneManager.LoadScene("Credit");
        }
    }

    void FixedUpdate()
    {
        if (Input.anyKeyDown) // Change d'image � chaque touche press�e
        {
            currentSlide = (currentSlide + 1) % slides.Length;
            UpdateSlides();
        }
    }

    void UpdateSlides()
    {
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].SetActive(i == currentSlide);
        }
    }
}
