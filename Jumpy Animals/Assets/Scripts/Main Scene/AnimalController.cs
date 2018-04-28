using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class AnimalController : MonoBehaviour {
	
	//
	private const string achiv_StartGame = "CgkI5KKt7ekZEAIQAQ";
	private const string achiv_100 = "CgkI5KKt7ekZEAIQAg";
	private const string achiv_1000 = "CgkI5KKt7ekZEAIQAw";
	private const string LeaderBoard = "CgkI5KKt7ekZEAIQBQ";
	private const string achiv_10000 = "CgkI5KKt7ekZEAIQBA";
	//

	Animator anim;
	public float Timer = 1f;
	int score;
	public Text Score;
	public GameObject restart;
	public AudioSource Rec;
	AudioSource audioSource;


	bool Play = true;

	Coroutine counter;
	// Use this for initialization
	void Start () 
	{

		PlayGamesPlatform.Activate ();
		Social.localUser.Authenticate ((bool succes) => {
			if (succes)
				print ("Удачно вошёл!");
			else
				print ("Неудачно вошёл!");
		});



		anim = GetComponent<Animator> ();
		if (anim == null)
		{
			gameObject.SetActive(false);
			Debug.LogError("EGOR!!!!! Set animator, please!!");
		}
		Score.text = "0";

	}




	// Update is called once per frame
	void Update () {
		if (Play) {
			#if UNITY_EDITOR
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				SetJump ();
			}
			#else
			if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
		SetJump();
		}
			#endif
		}
	}
		


	public void LandingEvent()
	{
		Debug.Log("Landing");
		// count score;
		score+=15;
		//display
		Score.text = score.ToString();
		//start count for loose;
		Play = true;
		counter = StartCoroutine(StartCount());
		Rec.Stop ();
	}

	IEnumerator StartCount()
	{
		yield return null;
		for (float timer = 0; timer < Timer; timer+=Time.deltaTime)
		{
			yield return new WaitForSeconds(Time.deltaTime);
		}
		//time is over so you lose;
		gameOver();
	}


	/// <summary>
	/// Game is over.
	/// wright some code here (display banner or something)
	/// </summary>
	void gameOver()
	{
		Score.text = "GameOver";
		if (PlayerPrefs.GetInt("HighScore")<score)
		{
		PlayerPrefs.SetInt("HighScore",score);
			Social.ReportScore (score, LeaderBoard, (bool succes) => 
				{
					if (succes) print("Удачно вошёл в таблицу лидеров!");	
			});
					
			if (score >= 105)
				GetTheAchiv (achiv_100);
			if (score >= 1050)
				GetTheAchiv (achiv_1000);
			if (score >= 10500)
				GetTheAchiv (achiv_10000);
	
		}
		//stop input;
		Play = false;
		restart.SetActive (true);
	}

	void SetJump()
	{
		if (counter!=null)
		StopCoroutine(counter);
		Play = false;
		anim.SetInteger ("New Int", Random.Range (0, 7));//Random.Range (0, 7));
		anim.SetTrigger("Jump"); GetTheAchiv (achiv_StartGame);
		Rec.Play ();


	}

	private void GetTheAchiv(string id)
	{
		Social.ReportProgress (id, 100.0f, (bool succes) => 
			{
				if (succes) print("Получено достижение: " + id);
		});
	}

	public void achivBttn()
	{
		Social.ShowAchievementsUI ();
	}
	public void leaderBttn()
	{
		Social.ShowLeaderboardUI ();
	}
	}




