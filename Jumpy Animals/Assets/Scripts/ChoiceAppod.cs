using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceAppod : MonoBehaviour {

	public AppoD ChoiceCharacter;

	void Start () 
	{
		if (ChoiceCharacter!= null)
		{
			ChoiceCharacter.Banner ();
		}
	}

}
