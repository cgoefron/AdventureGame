﻿using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {


	public float speed;
	private float xSpeed;
	public float jumpspeed;
	private Rigidbody2D rb2d;
	private Animator animator;
	private Vector3 scale;
	public bool grounded;
	public bool inspecting;
	public bool isMovable = true;
	public bool trailing = false;

	void Start () {

		animator = gameObject.GetComponent<Animator> ();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		scale = transform.localScale;

	}

	void Update () {
		Debug.Log ("inspecting:" + inspecting);
		//Debug.Log ("grounded:" + grounded);

		if (isMovable == true) Movement ();

		if (Input.GetButtonDown("Fire1")) Inspection ();

//	void OnCollisionEnter2D(Collision2D coll) {
//		if (coll.gameObject.tag == ("Enemy")) {
//			showGameOver ();
//		}
//	}
//
//	void showGameOver() {
//		Application.LoadLevel(2);
//	}
//
//	void winGame() {
//		Application.LoadLevel (3);

	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("Ground")) {
			grounded = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("trail")) {
			trailing = true;
		}
	}

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.CompareTag("Ground")) {
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.CompareTag("Ground")) {
			grounded = false;
		}
	}

	void Inspection() {
		if (grounded == true) {
			if (inspecting == true) {
				//stop inspecting
				animator.SetBool ("Kneeling", false);
				animator.SetBool ("Inspect", false);
				inspecting = false;
				isMovable = true;
			} else {
				// start inspecting
				animator.SetBool ("Inspect", true);
				animator.SetBool ("Kneeling", true);
				inspecting = true;
				isMovable = false;
			}
		}
	}

	void Movement (){
		xSpeed = Input.GetAxis ("Horizontal") * speed;
		rb2d.velocity = new Vector2 (xSpeed, rb2d.velocity.y);

		if (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.01) {
			animator.SetBool ("Walk", true);
		} else {
			animator.SetBool ("Walk", false);
		}

		if ((xSpeed > 0 && scale.x < 0) || (xSpeed < 0 && scale.x > 0)) {

			scale.x *= -1;
			transform.localScale = scale;
		}


		if (Input.GetButton ("Jump") && grounded == true) {
			animator.SetBool ("Jump", true);
			rb2d.AddForce (Vector2.up * jumpspeed);

		} else {
			animator.SetBool ("Jump", false);
		}
	
	}

}



