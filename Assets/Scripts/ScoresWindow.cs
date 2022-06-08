using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoresWindow : MonoBehaviour
{
	public Text lastScore;
	public Text hightScore;
	
	private ScoresList listeScore;
	public List<Scores> scoreList;
	
	public List<int> triList;
	
    // Start is called before the first frame update
	
    void Start()
    {
        LoadFromJson();
		Debug.Log(listeScore.allscore[1].player);
		scoreList = listeScore.allscore; 
		Debug.Log(scoreList[1].score);
		Debug.Log(HighestScore());
		
		hightScore.text = scoreList[HighestScore()].player + " - " + scoreList[HighestScore()].doneDate + " - " + (scoreList[HighestScore()].score).ToString();
		//lastScore.text = LastScore();
		LastScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void LoadFromJson(){
		
		string filePath = Application.persistentDataPath + "/scoreData.json";
		string scoreData = System.IO.File.ReadAllText(filePath);
		
		listeScore = JsonUtility.FromJson<ScoresList>(scoreData);
	}
	
	// Renvois l'index du plus haut score
	public int HighestScore(){	
		foreach (Scores i in scoreList){
			triList.Add(i.score);
		}
		return triList.IndexOf(triList.Max());
	}
	
	// Affiche les 5 derniers scores enregistré
	public void LastScore(){		
		for (int i = (scoreList.Count)-5; i < scoreList.Count; i++){
			lastScore.text += scoreList[i].player + " - " +
			scoreList[i].doneDate + " - " +
			(scoreList[i].score).ToString() + " \n" ;
		}
	}
}


