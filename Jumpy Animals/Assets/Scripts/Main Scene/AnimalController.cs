using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AnimalController : MonoBehaviour {
	


	Animator anim;
	public float Timer = 1f;
	int score;
	public Text Score;
	public GameObject restart;
	public AudioSource Rec;
	AudioSource audioSource;
	public AppoD Appodeall;


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
		Score.text = "GameOver"; Appodeall.Interstitial ();
		if (PlayerPrefs.GetInt("HighScore")<score)
		{
		PlayerPrefs.SetInt("HighScore",score);

			

	
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
		anim.SetTrigger("Jump"); 
		Rec.Play ();


	}
}




