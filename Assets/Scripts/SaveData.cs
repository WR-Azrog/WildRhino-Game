using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
	
	public ScoresList listeScore;
	
    void Start(){
        instance = this;
		LoadFromJson();
    }
	
	void Update(){
		// TEST KEY
		if(Input.GetKeyDown(KeyCode.S)){
			SaveToJson();
		}
		if(Input.GetKeyDown(KeyCode.L)){
			LoadFromJson();
		}
	}
	
	// Load TOUT les scores sous forme d'objet ScoresList
	public void LoadFromJson(){
		
		string filePath = Application.persistentDataPath + "/scoreData.json";
		string scoreData = System.IO.File.ReadAllText(filePath);
		
		listeScore = JsonUtility.FromJson<ScoresList>(scoreData);
	}
	
	// Ajoute le score a la list des scores sous forme d'objets ScoresList
	public void SaveToJson(){
		// Ajoute a la liste le score
		listeScore.allscore.Add(new Scores() {			
		doneDate = System.DateTime.Now.ToString(),
		player = "Julien", 
		score = Score.instance.scoreCount });
		
		string scoreData = JsonUtility.ToJson(listeScore);
		string filePath = Application.persistentDataPath + "/scoreData.json";
		Debug.Log(filePath);
		System.IO.File.WriteAllText(filePath, scoreData);
		Debug.Log("Sauvergarde effectuée");
	}
		
}

	[System.Serializable]
public class ScoresList {
	public List<Scores> allscore;
}
	[System.Serializable]
public class Scores {
	public string doneDate;
	public string player;
	public int score;
}