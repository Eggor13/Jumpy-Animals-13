using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxScoreOutput : MonoBehaviour {
	public Text highScore;
	// Use this for initialization
	void Start () {
		if (highScore!= null){
		int Score = PlayerPrefs.GetInt("HighScore");
		if (Score > 0){
			highScore.text = "Score: " + Score; 
			}
		else
			highScore.text = "";
		}
	}

}
