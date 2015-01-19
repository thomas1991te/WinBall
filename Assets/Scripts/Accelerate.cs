using UnityEngine;
using System.Collections;

public class Accelerate : MonoBehaviour {

	// The factor to accelerate the current accelerate.
	public float accelerationFactor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision theCollision) {
		if(theCollision.gameObject.tag == "Ball") {
			Vector3 velocityBall = Vector3.Normalize(theCollision.rigidbody.velocity);
			theCollision.gameObject.rigidbody.AddForce(velocityBall.x, 0, velocityBall.z * accelerationFactor, ForceMode.VelocityChange);
		}
	}
}
