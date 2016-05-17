using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	void Update () {
		if (Input.GetButton ("Jump")) {
			beginGame ();
		}
	}

	void beginGame() {
		Application.LoadLevel (1);

	}
}