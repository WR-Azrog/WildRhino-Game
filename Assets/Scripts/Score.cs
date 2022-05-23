using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public int scoreCount = 0;
	public bool party = true;
	
	public Text scoreUpdate;
	public Text finalScore;
	
	public static Score instance;
	
    void Start()
    {
        instance = this;
		StartCoroutine(AddScoreBySecond());
    }

    public void AddScore(int pt){
		scoreCount += pt;
		scoreUpdate.text = scoreCount.ToString();
	}
	
	public IEnumerator AddScoreBySecond(){
		
		while (party) {
		scoreCount += 1;
		scoreUpdate.text = scoreCount.ToString();
		yield return new WaitForSeconds(1f);
		
		}
	}
	
	public void FinalScore(){
		party = false;
		finalScore.text = scoreCount.ToString();
	}
}
