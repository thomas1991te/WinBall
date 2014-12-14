using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {

	// The maximum speed the ball bounces off a bumper.
	public float bouncingSpeedMax;

	// The minimal speed the ball bounces off a bumper
	public float bouncingSpeedMin;

	// The spotlight of this bumper.
	public Light spotlight;

	// The maximum intensity of the spotlight (0 - 8)
	public float spotlightIntensity;

	// Duration of the spotlight to light
	public float spotlightDuration;

	// Use this for initialization
	void Start () {
		if (spotlight != null) {
			spotlight.intensity = 0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision theCollision) {
		if(theCollision.gameObject.tag == "Ball") {
			// calculate angel between the two colliding objects
			float angle = UtilityClass.calculateAngle(theCollision.gameObject, this.gameObject);
			// get current velocity of the ball
			Vector3 velocityBall = theCollision.gameObject.rigidbody.velocity;
			// calculate random bouncing speed
			float bouncingSpeed = Random.Range(bouncingSpeedMin, bouncingSpeedMax);
			// update force according to ball velocity, hit angle and current speed of flipper
			theCollision.gameObject.rigidbody.AddForce(velocityBall.x * angle * bouncingSpeed, velocityBall.y, -bouncingSpeed * angle * velocityBall.z, ForceMode.Acceleration);
			if (spotlight != null) {
				StartCoroutine(LightSpotlight());
			}
		}
	}

	// light spotlight for spotlight duration seconds
	IEnumerator LightSpotlight() {
		this.spotlight.intensity = spotlightIntensity;
		yield return new WaitForSeconds(spotlightDuration);
		this.spotlight.intensity = 0f;
	}
}
