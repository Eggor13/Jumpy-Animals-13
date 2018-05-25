using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AnimalController : MonoBehaviour {
	

	public bool logingStuff;
	Animator anim;
	public float Timer = 1f;
	int score;
	public Text Score;
	public GameObject restart;
	public AudioSource Rec;
	AudioSource audioSource;
	public AppoD Appodeall;
	public VideoTimer video;


	bool GameOver = false;
	bool Play = true;

	Coroutine counter;
	// Use this for initialization
	void Start () 
	{
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
		if (!GameOver){
		if (Play) {
			#if UNITY_EDITOR
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
					Play = false;
				SetJump ();
			}
			#else
			if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
				Play = false;
		SetJump();
		}
			#endif
		}
		}
	}
		


	public void LandingEvent()
	{
		if (logingStuff)
		{
			Debug.Log("Landing");
		}
		//display
		Score.text = score.ToString();
		//start count for loose;
		Play = true;
		anim.ResetTrigger("Jump");
		counter = StartCoroutine(StartCount());
		if (Rec != null)
		Rec.Stop ();
	}

	IEnumerator StartCount()
	{
		yield return null;
		if (logingStuff)
		{
			Debug.Log("StartCoroutine");
		}
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
		GameOver = true;
		if (logingStuff)
		{
			Debug.Log("GameOver");
		}
		Score.text = "GameOver"; 
		if (PlayerPrefs.GetInt("HighScore")<score)
		{
		PlayerPrefs.SetInt("HighScore",score);

		}

		//stop input;
		Play = false;
		restart.SetActive (true);
		if (video != null)
		video.gameObject.SetActive(true);

		int GOCounts = PlayerPrefs.GetInt ("GameoverCount");
		if (GOCounts % 5 == 0) {
			
			Appodeall.Interstitial ();
		}
		GOCounts++;
		PlayerPrefs.SetInt ("GameoverCount", GOCounts);
	}

	void SetJump()
	{
		
		if (counter!=null){
			StopCoroutine(counter);
			if (logingStuff)
			{
				Debug.Log("Stop Corotine");
			}
		}

		// count score;
		score+=15;
		if (logingStuff)
		{
			Debug.Log("Stop Corotine");
		}
		anim.SetInteger ("New Int", Random.Range (0, 7));//Random.Range (0, 7));
		//anim.SetInteger ("New Int", 6);
		anim.SetTrigger("Jump"); 
		if (Rec != null)
		Rec.Play ();


	}
}




