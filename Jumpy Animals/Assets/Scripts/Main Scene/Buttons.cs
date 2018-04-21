using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

	public Sprite mus_on, mus_off;

	public float bigger = 0.4f, lower = 0.3f;

	void Start () {
		if (gameObject.name == "Settings") {
			if (PlayerPrefs.GetString ("Sound") == "off") {
				transform.GetChild (0).gameObject.GetComponent <Image> ().sprite = mus_off;
				Camera.main.GetComponent <AudioListener> ().enabled = false; // Switch off music
			}
		}
	}

	void OnMouseDown () {
		transform.localScale = new Vector3 (bigger, bigger, bigger);
	}

	void OnMouseUp () {
		transform.localScale = new Vector3 (lower, lower, lower);
	}

	void OnMouseUpAsButton () {
		GetComponent <AudioSource> ().Play ();
		switch (gameObject.name)  { 

		case "Restart":
			Application.LoadLevel ("Play");
			break;



		case "Respect":
			Application.LoadLevel ("Respect");
			break;

		case "HomeRespect":
			Application.LoadLevel ("Main");
			break;

		case "HomePlay":
			Application.LoadLevel ("Main");
			break;

		case "Person":
			Application.LoadLevel ("Choice of character");
			break;

			

		case "Yes":
			Application.LoadLevel ("Main");
			break;


		case "Mail":
			Application.OpenURL ("http://google.com");
			break;

		case "Share":
			Application.OpenURL ("http://unity3d.ru/distribution/viewtopic.php?f=105&t=7495");
			break;
		case "Sound":

			if (PlayerPrefs.GetString ("Sound") == "off") { //Play music now
				GetComponent <Image> ().sprite = mus_on;
				PlayerPrefs.SetString ("Sound", "on");
				Camera.main.GetComponent <AudioListener> ().enabled = true; // Switch on music
			} else {  // Off music
				GetComponent <Image> ().sprite = mus_off;
				PlayerPrefs.SetString ("Sound","off");
				Camera.main.GetComponent <AudioListener> ().enabled = false; // Switch off music
			}

			break;

		case "Settings":
			for (int i = 0; i < transform.childCount; i++)
				transform.GetChild (i).gameObject.SetActive (!transform.GetChild (i).gameObject.activeSelf);
			break;

		case "Logo":
			Application.OpenURL ("https://www.instagram.com/ezakharov13/");
			break;

		}

	}

}
