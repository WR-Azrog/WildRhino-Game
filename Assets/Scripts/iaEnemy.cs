using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iaEnemy : MonoBehaviour
{
	public GameObject player;
	public float iaDifficulty;
	public Vector3 playerLocation;
	public Sprite[] sprites;
	
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
		playerLocation = playerLoc;
	}
	
}
