using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
	
	public Rigidbody2D rb;
	public BoxCollider2D playerBox;
	
	public Animator animator;
	
	private Vector3 velocity = Vector3.zero;
	private Vector3 moveDirection = new Vector3(0, 1);
	public float moveSpeed = 0;
	
	public SpriteRenderer spriteRenderer;
	public Sprite upSprite;
	public Sprite downSprite;
	public Sprite leftSprite;
	public Sprite rightSprite;
	
	// Awake et FixedUpdate
	void Awake() {
	}
	
    void FixedUpdate(){	
	
		HandleInput();
		MovePlayer(speedVectorCreation());
		
    }
	
	// Fonction de calcule nécéssaire au déplacement et l'orientation
	private Vector3 speedVectorCreation(){
		
		// Creation de la valeur de déplacement sur un DeltaTime (Une durée)
		float horizontalMovement = moveDirection.x * moveSpeed * Time.deltaTime;
		float verticalMovement = moveDirection.y * moveSpeed * Time.deltaTime;
		
		// Vector2 en Vector3
		Vector3 targetVelocity = new Vector2(horizontalMovement, verticalMovement);
		
		return targetVelocity;
	}
	
	private void MovePlayer(Vector3 targetVelocity){
		if (Input.GetKey(KeyCode.Space)){
			
			// SetUP de la charge
			if (moveSpeed < 1000){moveSpeed += 2;}
			
			// Passe l'info qu'on avance et la direction
			animator.SetFloat("Speed", moveSpeed);
			if (moveDirection.y == 1){animator.SetTrigger("Up");}
			if (moveDirection.y == -1){animator.SetTrigger("Down");}
			if (moveDirection.x == 1){animator.SetTrigger("Right");}
			if (moveDirection.x == -1){animator.SetTrigger("Left");}
			
			// On fait bouger notre body
			rb.velocity = targetVelocity;			
		}
		
		else {
			moveSpeed = 0;
			rb.velocity = Vector3.zero;
			animator.SetFloat("Speed", moveSpeed);
			
		}
	}
	
	private void resetTrigger(){
		
		 animator.ResetTrigger("Up");
		 animator.ResetTrigger("Down");
		 animator.ResetTrigger("Left");
		 animator.ResetTrigger("Right");
	}
		
	// Set la moveDirection en vecteur2 et empêche le demi-tour + solution temporaire de hitbox
	private void HandleInput(){
		
		if (Input.GetKey(KeyCode.UpArrow)){
			if (moveDirection.y != -1 || !Input.GetKey(KeyCode.Space)){
				
				// Set la direction
				moveDirection = new Vector3(0, 1);
				
				// Trigger la direction pour l'animation
				//resetTrigger();
				animator.SetTrigger("Up");
				
				// Attribue la HitBox				
				playerBox.size = new Vector2(0.3054974f , 0.4665129f);	
				playerBox.offset = new Vector2(0.000820592f , -0.002076507f);
				
				// Change le sprite d'orientation
				//spriteRenderer.sprite = upSprite;
			}
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			if (moveDirection.y != +1 || !Input.GetKey(KeyCode.Space)){
				
				moveDirection = new Vector3(0, -1);
				
				//resetTrigger();
				animator.SetTrigger("Down");
				
				playerBox.size = new Vector2(0.3054974f , 0.4665129f);	
				playerBox.offset = new Vector2(0.000820592f , -0.002076507f);
				
				//spriteRenderer.sprite = downSprite;
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			if (moveDirection.x != +1 || !Input.GetKey(KeyCode.Space)){
				
				moveDirection = new Vector3(-1, 0);
				
				//resetTrigger();
				animator.SetTrigger("Left");
				
				playerBox.size = new Vector2(0.5842918f , 0.2992364f);	
				playerBox.offset = new Vector2(-0.0668866f , -0.08571476f);
				
				//spriteRenderer.sprite = leftSprite;
			}
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			if (moveDirection.x != -1 || !Input.GetKey(KeyCode.Space)){
				
				moveDirection = new Vector3(1, 0);
				
				//resetTrigger();
				animator.SetTrigger("Right");
				
				playerBox.size = new Vector2(0.5842918f , 0.2992364f);	
				playerBox.offset = new Vector2(0.0844588f , -0.08571476f);
			
				//spriteRenderer.sprite = rightSprite;
			}
		}
	}
}
