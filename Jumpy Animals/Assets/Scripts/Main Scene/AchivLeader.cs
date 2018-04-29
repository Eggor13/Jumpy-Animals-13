using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class AchivLeader : MonoBehaviour {
	



	public const string achiv_StartGame = "CgkI5KKt7ekZEAIQAQ";
	public const string achiv_100 = "CgkI5KKt7ekZEAIQAg";
	public const string achiv_1000 = "CgkI5KKt7ekZEAIQAw";
	public const string leaderboard = "CgkI5KKt7ekZEAIQBQ";
	public const string achiv_10000 = "CgkI5KKt7ekZEAIQBA";
	

	void Start()
	{
		PlayGamesPlatform.Activate ();
		Social.localUser.Authenticate ((bool succes) => {
			if (succes)	print("Удачно вошёл!");
			else print("Неудачно вошёл!");
		
		});
	
	}

	//Достижения
	public void GetTheAchiv(string id)
	{
		Social.ReportProgress (id, 100.0f, (bool succes) => {
			if (succes)	print("Unlock achievement: " + id);	
		});
	}
	public void achivBttn()
	{
		Social.ShowAchievementsUI ();
	}



	//if (выполняется условие) GetTheAchiv (ачивка);

	//Рейтинг игроков

	public void ReportScore(int score)
	{
		Social.ReportScore (score, leaderboard, (bool succes) => 
			{
			if (succes)	print("Удачно добавлен в таблицу лидеров!");
		});
	}
	public void leaderBttn()
	{
		Social.ShowLeaderboardUI ();
	}

}
