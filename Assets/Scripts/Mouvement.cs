using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mouvement : MonoBehaviour
{	
	public Rigidbody2D rb;
	public BoxCollider2D playerBox;
	
	public bool mobileVersion = true;
	
	public Animator animator;
	
	private Vector3 velocity = Vector3.zero;
	private Vector3 moveDirection = new Vector3(0, 1);
	public float moveSpeed = 0;
	
	public Press pressSpace;
	public Press pressUp;
	public Press pressDown;
	public Press pressLeft;
	public Press pressRight;
	
	public bool InputSpace = false;
	public bool InputUp = false;
	public bool InputDown = false;
	public bool InputLeft = false;
	public bool InputRight = false;
	
	public SpriteRenderer spriteRenderer;
	
	// Awake et FixedUpdate
	void Awake() {}
	
    void FixedUpdate(){	
		
		HandleInput();
		MovePlayer(speedVectorCreation());		
    }

	// Mobile ou PC check les INPUT
	public void checkInput(){
		
			if (!mobileVersion){
			InputSpace = Input.GetKey(KeyCode.Space);
			InputUp = Input.GetKey(KeyCode.UpArrow);
			InputDown = Input.GetKey(KeyCode.DownArrow);
			InputLeft = Input.GetKey(KeyCode.LeftArrow);
			InputRight = Input.GetKey(KeyCode.RightArrow);
			}
			else {
			InputSpace = pressSpace.buttonPressed;
			InputUp = pressUp.buttonPressed;
			InputDown = pressDown.buttonPressed;
			InputLeft = pressLeft.buttonPressed;
			InputRight = pressRight.buttonPressed;
			}
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
		if (InputSpace){
			
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
	
	// Set la moveDirection en vecteur2 et empêche le demi-tour + solution temporaire de hitbox
	private void HandleInput(){
		checkInput();
		if (InputUp){
			if (moveDirection.y != -1 || !InputSpace){
				
				// Set la direction
				moveDirection = new Vector3(0, 1);
				
				// Trigger la direction a l'animator;
				animator.SetTrigger("Up");
				
				// Attribue la HitBox				
				playerBox.size = new Vector2(0.3054974f , 0.4665129f);	
				playerBox.offset = new Vector2(0.000820592f , -0.002076507f);
			}
		}
		if (InputDown){
			if (moveDirection.y != +1 || !InputSpace){
				
				moveDirection = new Vector3(0, -1);
				
				animator.SetTrigger("Down");
				
				playerBox.size = new Vector2(0.3054974f , 0.4665129f);	
				playerBox.offset = new Vector2(0.000820592f , -0.002076507f);
			}
		}
		if (InputLeft){
			if (moveDirection.x != +1 || !InputSpace){
				
				moveDirection = new Vector3(-1, 0);
				
				animator.SetTrigger("Left");
				
				playerBox.size = new Vector2(0.5842918f , 0.2992364f);	
				playerBox.offset = new Vector2(-0.0668866f , -0.08571476f);
			}
		}
		if (InputRight){
			if (moveDirection.x != -1 || !InputSpace){
				
				moveDirection = new Vector3(1, 0);
				
				animator.SetTrigger("Right");
				
				playerBox.size = new Vector2(0.5842918f , 0.2992364f);	
				playerBox.offset = new Vector2(0.0844588f , -0.08571476f);
			}
		}
	}
}
