using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
	public GameObject[] Objects;
	
	public GameOver gameOver;
	
	public Transform[] sp;
	private Vector3 pos;

    void Start()
    {
		SpawnCreator();
        InvokeRepeating("enemyGenerator", 5.0f, 1.0f);	
    }
	
	void enemyGenerator(){
		if (!gameOver.gameOver){
		// Pioche une IA aléatoire dans la liste.
		int rand = Random.Range(0, Objects.Length);
		
		//Assigne la position de l'ennemi a un des spawner aléatoirement dans le list sp.	
		pos = sp[Random.Range(0, sp.Length)].transform.position;
		
		//Instantie et place l'objet et bloque la rotation avec Quaternion.
		GameObject obj = Instantiate(Objects[rand], pos, Quaternion.identity);
		
		//Active l'objet
		obj.SetActive(true);
		}
	}
	
	void SpawnCreator(){
		// Crée la largeur du tableau de spawnpoint
		sp = new Transform[transform.childCount];
		
		for (int i=0; i<transform.childCount; i++){
			sp[i] = transform.GetChild(i);
		}
	}
}
