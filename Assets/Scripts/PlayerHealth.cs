#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;

    private int damage;
    
    [SerializeField]private HealthBar healthBar;
    
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
        Destroy(gameObject);
		UnityEditor.EditorApplication.isPlaying = false;
    }
}
