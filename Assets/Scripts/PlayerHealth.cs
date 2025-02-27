using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;
    private int damage;
    [SerializeField]private HealthBar healthBar;
    [SerializeField]private string thisScene;
    public GameObject deathScreen;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
		if (currentHealth <= 0)
        {
            Die();
        }
    }
	
    public void Die()
    {
        healthBar.SetHealth(0);
        Debug.Log(gameObject.name + " est mort !");
        deathScreen.SetActive(true);
        SceneManager.LoadScene(thisScene);
    }
}
