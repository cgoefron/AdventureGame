using UnityEngine;
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

	void Start () {

		animator = gameObject.GetComponent<Animator> ();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		scale = transform.localScale;

	}

	void Update () {

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

		if (Input.GetButton ("Fire1") && grounded == true) {
			animator.SetBool ("Inspect", true);
			inspecting = true;
			animator.SetBool ("Kneeling", true);
			Debug.Log ("inspecting:" + inspecting);
			//add logic for checking artifactObjects
		} else {
			//animator.SetBool ("Inspect", false);
			//inspecting = false;
		}

		if (Input.GetButton ("Fire1") && inspecting == true) {
			animator.SetBool ("Inspect", false);
			animator.SetBool ("Kneeling", false);
			inspecting = false;

		}

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

}



