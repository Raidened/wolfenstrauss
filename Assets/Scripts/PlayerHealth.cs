#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;

    private int damage;
    
    [SerializeField]private HealthBar healthBar;
    public GameOverScript GameOverScript;
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
        Debug.Log(gameObject.name + " has died!");
        GameOverScript.Setup();
        //Destroy(gameObject);
        // UnityEditor.EditorApplication.isPlaying = false;
    }
}
