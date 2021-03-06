using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
	public int currentHealth;	
	public bool isInvincible = false;
	 
	public SpriteRenderer graphics;
	public Health healthBar;
	
	public GameOver gameOver;
	
    void Start()
    {
        currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.H)){TakeDamage(101);}
		if (currentHealth < 1){gameOver.endGame();}
    }
	
	public void TakeDamage(int damage)
	{
		// Check si invincible
		if (!isInvincible){
		// Applique les dommages  
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		isInvincible=true;
		// Animation d'invisibilitée
		StartCoroutine(InvincibilityFlash());
		StartCoroutine(HandleInvincibleDelay());
		}
	}
	
	public IEnumerator InvincibilityFlash(){
		while (isInvincible){
			graphics.color = new Color(1f, 1f, 1f, 0f);
			yield return new WaitForSeconds(0.2f);
			graphics.color = new Color(1f, 1f, 1f, 1f);
			yield return new WaitForSeconds(0.2f);
		}
	}
	
	public IEnumerator HandleInvincibleDelay(){
		yield return new WaitForSeconds(3f);
		isInvincible = false;
	}
}
