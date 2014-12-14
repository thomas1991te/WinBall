using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// the force that pulls the ball down
	public float downForce;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		rigidbody.AddForce(new Vector3(0, -1, 1) * downForce, ForceMode.Acceleration);
	}
}
