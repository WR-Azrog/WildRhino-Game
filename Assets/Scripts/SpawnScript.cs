using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
	public GameObject[] Objects;

    void Start()
    {
        InvokeRepeating("enemyGenerator", 5.0f, 10.0f);
    }
	
	void enemyGenerator(){
		// Pioche un enemy aléatoire dans la liste.
		int rand = Random.Range(0, Objects.Length);
				
		//Génération aléatoir de son spawn
		Vector3 pos = new Vector3(
		Random.Range(-5f, 5f),
		Random.Range(-5f, 5f),
		(0));
		
		//Instantie et place l'objet
		GameObject obj = Instantiate(Objects[rand], pos, Quaternion.identity);
		
		//Active l'objet
		obj.SetActive(true);
	}
}
