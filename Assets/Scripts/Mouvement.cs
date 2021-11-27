using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
	
	public Rigidbody2D rb;
	public SpriteRenderer spriteRenderer;
	public BoxCollider2D playerBox;
	public Animator animator;
	
	private Vector3 velocity = Vector3.zero;
	private Vector3 moveDirection;
	public float moveSpeed = 0;
	
	public Sprite upSprite;
	public Sprite downSprite;
	public Sprite leftSprite;
	public Sprite rightSprite;
	
	//On set nos valeurs speed + direction d'origine
	private void Awake() {
		//Orientation
		moveDirection = new Vector3(1, 0);
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
			if (moveSpeed < 1000){moveSpeed += 2;}
			
			Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
			rb.velocity = targetVelocity;
			
			animator.SetFloat("Speed", moveSpeed);
			
		}
		
		else {
			moveSpeed = 0;
			rb.velocity = Vector3.zero;
		}
		
	 //Aligne le sprite sur la direction(vecteur)
	
		//transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(moveDirection));
	}
	
	
	// Calcule l'angle de déplacement
	private float GetAngleFromVector(Vector3 dir) {
		float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		if (n < 0) n += 360;
		return n;
	}
	
	// Set la moveDirection en vecteur2 et empêche le demi-tour + solution temporaire de hitbox
	private void HandleInput(){
		
		if (Input.GetKey(KeyCode.UpArrow)){
			if (moveDirection.y != -1 || !Input.GetKey(KeyCode.Space)){
				
				// Set la direction
				moveDirection = new Vector3(0, 1);
				
				// Communique la direction pour l'animation
				animator.SetFloat("Direction", 1);
				
				// Attribue la HitBox				
				playerBox.size = new Vector2(0.3054974f , 0.4665129f);	
				playerBox.offset = new Vector2(0.000820592f , -0.002076507f);
				
				// Passe l'info d'priantation a la direction
				spriteRenderer.sprite = upSprite;
			}
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			if (moveDirection.y != +1 || !Input.GetKey(KeyCode.Space)){
				
				moveDirection = new Vector3(0, -1);
				
				animator.SetFloat("Direction", 2);
				
				playerBox.size = new Vector2(0.3054974f , 0.4665129f);	
				playerBox.offset = new Vector2(0.000820592f , -0.002076507f);
				
				spriteRenderer.sprite = downSprite;
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			if (moveDirection.x != +1 || !Input.GetKey(KeyCode.Space)){
				
				moveDirection = new Vector3(-1, 0);
				
				animator.SetFloat("Direction", 3);
				
				playerBox.size = new Vector2(0.5842918f , 0.2992364f);	
				playerBox.offset = new Vector2(-0.0668866f , -0.08571476f);
				
				spriteRenderer.sprite = leftSprite;
			}
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			if (moveDirection.x != -1 || !Input.GetKey(KeyCode.Space)){
				
				moveDirection = new Vector3(1, 0);
				
				animator.SetFloat("Direction", 4);
				
				playerBox.size = new Vector2(0.5842918f , 0.2992364f);	
				playerBox.offset = new Vector2(0.0844588f , -0.08571476f);
			
				spriteRenderer.sprite = rightSprite;
			}
		}
	}
}
