using UnityEngine;
using System.Collections;


public class inspectScript : MonoBehaviour {

	public GameObject relicCanvas;
	private bool nearRelic;
	private bool canvasOn;

	void Update(){
		
		if (Input.GetButtonDown ("Fire1") && nearRelic == true) { //ADD LOGIC FOR INSIDE COLLIDER
			Debug.Log ("Player has hit Z" + nearRelic);
			//insert tick canvas text popup on & off
			canvasOn = !canvasOn;
			relicCanvas.SetActive(canvasOn);
		} 

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Player")) {
			nearRelic = true;
		}
	}
		
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag("Player")) {
			nearRelic = false;
		}
	}
}
