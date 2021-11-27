using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
	
	public Rigidbody2D rb;
	public SpriteRenderer spriteRenderer;
	public BoxCollider2D playerBox;
	
	private Vector3 velocity = Vector3.zero;
	private Vector3 moveDirection;
	private float moveSpeed;
	
	public Sprite upSprite;
	public Sprite downSprite;
	public Sprite leftSprite;
	public Sprite rightSprite;
	
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
		
	 //Aligne le sprite sur la direction(vecteur)
	
		//transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(moveDirection));
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
				
				playerBox.size = new Vector2(0.3054974f , 0.4665129f);	
				playerBox.offset = new Vector2(0.000820592f , -0.002076507f);
				
				spriteRenderer.sprite = upSprite;
			}
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			if (moveDirection.y != +1 || !Input.GetKey(KeyCode.Space)){
				moveDirection.x = 0;
				moveDirection.y = -1;
				
				playerBox.size = new Vector2(0.3054974f , 0.4665129f);	
				playerBox.offset = new Vector2(0.000820592f , -0.002076507f);
				
				spriteRenderer.sprite = downSprite;
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			if (moveDirection.x != +1 || !Input.GetKey(KeyCode.Space)){
				moveDirection.x = -1;
				moveDirection.y = 0;
				
				playerBox.size = new Vector2(0.5842918f , 0.2992364f);	
				playerBox.offset = new Vector2(-0.0668866f , -0.08571476f);
				
				spriteRenderer.sprite = leftSprite;
			}
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			if (moveDirection.x != -1 || !Input.GetKey(KeyCode.Space)){
				moveDirection.x = +1;
				moveDirection.y = 0;
				
				playerBox.size = new Vector2(0.5842918f , 0.2992364f);	
				playerBox.offset = new Vector2(0.0844588f , -0.08571476f);
			
				spriteRenderer.sprite = rightSprite;
			}
		}
	}
}
