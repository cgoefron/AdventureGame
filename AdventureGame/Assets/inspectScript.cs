using UnityEngine;
using System.Collections;

public class inspectScript : MonoBehaviour {

	void OnCollisionStay2D(Collision2D other){
		if (Input.GetButton ("Fire1") && other.gameObject.CompareTag("Player")) {
			//insert tick canvas text popup on & off

		}
	}
}
