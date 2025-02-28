using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.anyKeyDown) // Change d'image � chaque touche press�e
        {
            currentSlide = (currentSlide + 1);
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
