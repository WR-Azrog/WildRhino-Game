using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iaEnemy : MonoBehaviour
{
	public GameObject player;
	public Sprite[] sprites;
	public Rigidbody2D rb;
	
	private float moveSpeed = 50;	
	private float iaDifficulty;

	
    // Start is called before the first frame update
    void Start()
    {
        //Création de la difficultée
		iaDifficulty = 1 * (Time.realtimeSinceStartup/100);
    }

    // Update is called once per frame
    void Update()
    {
		enemyMove(player.transform.position);    
    }
	
	void enemyMove(Vector3 playerLoc) {
		
		//Creation du vecteur de déplacement
		Vector3 direction = playerLoc - transform.position; 
		
		// Mise à jour du vecteur de déplacement en fonction de la vitesse
		float horizontalMovement = direction.x * moveSpeed * Time.deltaTime;
		float verticalMovement = direction.y * moveSpeed * Time.deltaTime;
		Vector3 targetVelocity = new Vector3(horizontalMovement, verticalMovement, 0);
		
		//Rotation + Déplacement
		transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(targetVelocity));		
		rb.velocity = targetVelocity;
	}
	
	// Fonction math transformation Vecteur3 en angle
	private float GetAngleFromVector(Vector3 dir) {
		float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		n += 90;
		return n;
	}
	
	// En cas de collision
	private void OnCollisionEnter2D(Collision2D collision){
		if(collision.transform.CompareTag("Player")){
			PlayerHealth playerhealth = collision.transform.GetComponent<PlayerHealth>();
			playerhealth.TakeDamage(10);
		}
	}
}
