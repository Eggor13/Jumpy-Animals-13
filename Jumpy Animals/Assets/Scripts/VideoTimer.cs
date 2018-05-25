using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTimer : MonoBehaviour {
	public float Timer;

	Coroutine timerCoroutine;

	IEnumerator timerForVideo()
	{
		yield return null;
		yield return new WaitForSeconds(Timer);
		gameObject.SetActive(false);
	}
	void OnEnable ()
	{
		timerCoroutine = StartCoroutine(timerForVideo());
	}

	public void StopCor () {
		StopCoroutine(timerForVideo());
		gameObject.SetActive(false);
	}
}
