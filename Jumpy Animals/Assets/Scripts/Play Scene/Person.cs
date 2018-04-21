using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

	private Animator anim;
	public float verticalImpulse;
	Rigidbody rb;
	bool isGrounded;
	//variable for
	[Header ("Number of our jumps variable")]
	public int numberOfVariable;

	// Use this for initialization

	void Start () {
		
		rb = GetComponent<Rigidbody> ();

		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0) && isGrounded) {
			rb.AddForce (new Vector2 (0, verticalImpulse), ForceMode.Impulse);
			isGrounded = false;

			//set random variation
			anim.SetInteger("Var",Random.Range(0,numberOfVariable));
			//anim.CrossFade("Jump 1",0.2f);
			anim.SetTrigger ("Jump");
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
			isGrounded = true;
		
	}

		
}
