using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneHandler : MonoBehaviour {

	private static string LEFT_WALL = "LeftWall";
	private static string RIGHT_WALL = "RightWall";

	[SerializeField] GameObject ball;

	[SerializeField] GameObject leftWall;
	[SerializeField] GameObject rightWall;

	[SerializeField] float moveSpeed;
	[SerializeField] bool isMoving;
	Vector3 direction = Vector3.right;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			ball.GetComponent<Rigidbody> ().isKinematic = false;	
			isMoving = false;
		}

		MoveCrane ();

	}

	void MoveCrane(){

		if(isMoving)
			transform.Translate (direction * moveSpeed * Time.deltaTime);

	}

	void OnTriggerEnter(Collider col){
		Debug.Log (col.name);

		if (!isMoving)
			return;
		
		if (col.name == LEFT_WALL) {
			direction = Vector3.right;
		} else if (col.name == RIGHT_WALL) {
			direction = Vector3.left;
		}
	}
}
