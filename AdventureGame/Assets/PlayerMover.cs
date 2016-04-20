using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {


	public float speed;
	private float xSpeed;
	public float jumpspeed;
	private Rigidbody2D rb2d;
	private Animator animator;
	private Vector3 scale;

	void Start () {

		animator = gameObject.GetComponent<Animator> ();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		scale = transform.localScale;

	}

	void Update () {

		xSpeed = Input.GetAxis ("Horizontal") * speed;
		rb2d.velocity = new Vector2 (xSpeed, rb2d.velocity.y);

		if (Mathf.Abs(Input.GetAxis ("Horizontal")) > 0.01) {
			animator.SetBool ("Walk", true);
		} else {
			animator.SetBool ("Walk", false);
		}

		if ((xSpeed > 0 && scale.x < 0) || (xSpeed < 0 && scale.x > 0)) {

			scale.x *= -1;
			transform.localScale = scale;
		}

		if (Input.GetButton("Jump")) {
			rb2d.AddForce (Vector2.up * jumpspeed);
		}

		if (Input.GetButton("Jump")) {
			animator.SetBool ("Jump", true);

		} else {
			animator.SetBool ("Jump", false);
		}

		if (Input.GetButton ("Fire1")) {
			animator.SetBool ("Inspect", true);
		} else {
			animator.SetBool ("Inspect", false);
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
}


/*Transform lerpysPosition;

	// Use this for initialization
	void Start () {
		lerpysPosition = GameObject.Find("Lerpy").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(lerpysPosition.position);
		transform.position += Time.deltaTime * transform.forward;
	}	
}*/