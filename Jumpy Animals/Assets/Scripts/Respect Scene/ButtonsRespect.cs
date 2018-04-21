using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsRespect : MonoBehaviour {

	public float bigger = 0.4f, lower = 0.3f;

		
		void OnMouseDown () {
			transform.localScale = new Vector3 (bigger, bigger, bigger);
		}

		void OnMouseUp () {
			transform.localScale = new Vector3 (lower, lower, lower);
		}

		void OnMouseUpAsButton () {
		switch (gameObject.name) { 



		case "ZakharovGames":
			Application.OpenURL ("https://www.instagram.com/ezakharov13/");
			break;

		case "DmitryT":
			Application.OpenURL ("https://www.facebook.com/TerpilDmitry");
			break;

		case "AlexanderA":
			Application.OpenURL ("http://antipov3d.com/");
			break;

		case "Viktor":
			Application.OpenURL ("https://www.instagram.com/vooorooon/");
			break;

		case "AlexanderY":
			Application.OpenURL ("https://vk.com/yashkamen");
			break;
		}
	}

}