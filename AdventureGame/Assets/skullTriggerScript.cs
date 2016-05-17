using UnityEngine;
using System.Collections;

public class skullTriggerScript : MonoBehaviour {

	private Animator animator;

	void Start () {

		animator = gameObject.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Player")) {
			animator.SetBool ("skullYell", true);
		}
	}
}
