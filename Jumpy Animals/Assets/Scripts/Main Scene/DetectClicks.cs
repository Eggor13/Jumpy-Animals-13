using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClicks : MonoBehaviour {

	void OnMouseDown () {
		switch (gameObject.name)  { 

		case "DetectClicks":
		Application.LoadLevel  ("Play");
		break;
	}

	}
}
