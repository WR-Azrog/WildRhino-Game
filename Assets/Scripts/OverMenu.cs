using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverMenu : MonoBehaviour
{	
    public void Retry(){
		SceneManager.LoadScene("Main");
	}
	
	public void Menu(){
		SceneManager.LoadScene("GameMenu");
	}
}
