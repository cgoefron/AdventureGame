using UnityEngine;
using System.Collections;

public class trailScript : MonoBehaviour {

	public float distanceFactor;
	//public float characterSpeed;
	public Transform playerTransform;
	private Transform myTransform;
	private float posX;
	private float posY;

	void Awake()
	{
		myTransform = transform;

	}

	void Update () {
		transform.position = new Vector3(posX + distanceFactor, posY, 0);
		posX = playerTransform.position.x;
		posY = playerTransform.position.y;

	}
}
