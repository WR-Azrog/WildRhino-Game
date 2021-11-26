using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
	
	public Rigidbody2D rb;
	private Vector3 velocity = Vector3.zero;
	private Vector3 moveDirection;
	private float moveSpeed;
	
	//On set nos valeurs speed + direction d'origine
	private void Awake() {
		//Orientation
		moveDirection = new Vector3(1, 0);
		//Speed de base
		moveSpeed = 100;
	}
	
    void FixedUpdate(){	
	
		HandleInput();
		
		float horizontalMovement = moveDirection.x * moveSpeed * Time.deltaTime;
		float verticalMovement = moveDirection.y * moveSpeed * Time.deltaTime;

		MovePlayer(horizontalMovement, verticalMovement);
		
    }
	// ------------------------------------------------------------------------------------------------------------------------------ //
	
	void MovePlayer(float _horizontalMovement,  float _verticalMovement){
		if (Input.GetKey(KeyCode.Space)){
			
			// SetUP de la charge
			if (moveSpeed < 600){moveSpeed += 2;}
			
			Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
			rb.velocity = targetVelocity;	
			
		}
		
		else {
			moveSpeed = 100;
			rb.velocity = Vector3.zero;
		}
		
	// Aligne le sprite sur la direction(vecteur)
	
		transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(moveDirection) -90);
	}
	
	
	// Calcule l'angle de déplacement
	private float GetAngleFromVector(Vector3 dir) {
		float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		if (n < 0) n += 360;
		return n;
	}
	
	// Set la movedirection en vecteur2 et empêche le demi-tour
	private void HandleInput(){
		
		if (Input.GetKey(KeyCode.UpArrow)){
			if (moveDirection.y != -1 || !Input.GetKey(KeyCode.Space)){
				moveDirection.x = 0;
				moveDirection.y = +1;
			}
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			if (moveDirection.y != +1 || !Input.GetKey(KeyCode.Space)){
				moveDirection.x = 0;
				moveDirection.y = -1;
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			if (moveDirection.x != +1 || !Input.GetKey(KeyCode.Space)){
				moveDirection.x = -1;
				moveDirection.y = 0;
			}
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			if (moveDirection.x != -1 || !Input.GetKey(KeyCode.Space)){
				moveDirection.x = +1;
				moveDirection.y = 0;
			}
		}
	}
}
