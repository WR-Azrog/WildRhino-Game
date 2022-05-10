using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public bool gameOver = false;
	
	public GameObject player;
	public GameObject overMenu;
	
	public void endGame(){
		gameOver = true;
		Score.instance.FinalScore();
		SaveData.instance.SaveToJson();
		Destroy(player);
		overMenu.SetActive(true);
	}
}
