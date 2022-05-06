using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
	public GameObject settingWindow;
	
	public void Play(){
		SceneManager.LoadScene("Main");
	}
	
	public void Scores(){
		
	}
	
	public void Settings(){
		settingWindow.SetActive(true);
	}
	
	public void CloseSettings(){
		settingWindow.SetActive(false);
	}
	
	public void Quit(){
		Application.Quit();
	}
}
