using UnityEngine;
using System.Collections;

public class endSceneScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			showGameOver ();
		}
	}

	void showGameOver() {
		Application.LoadLevel(2);
	}

//	void EndScene() {
//		Application.LoadLevel (3);
//
//	}
}

