using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {

	// The maximum speed the ball bounces off a bumper.
	public float bouncingSpeedMax;

	// The minimal speed the ball bounces off a bumper
	public float bouncingSpeedMin;

	// All spotlights assigned to this bumper.
	public Spotlight[] spotlights;

	public int points;

	// Use this for initialization
	void Start () {
		foreach (Spotlight spotlight in spotlights) {
			spotlight.initialize();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision theCollision) {
		if(theCollision.gameObject.tag == "Ball") {
			// calculate the angle of contact between the two colliding objects
			float angleOfContact = UtilityClass.calculateAngleOfContact(theCollision.gameObject, this.gameObject);
			// get current velocity of the ball
			Vector3 velocityBall = Vector3.Normalize(theCollision.gameObject.rigidbody.velocity);
			// calculate random bouncing speed
			float bouncingSpeed = Random.Range(bouncingSpeedMin, bouncingSpeedMax);
			// update force according to ball velocity, hit angle and current speed of flipper
			theCollision.gameObject.rigidbody.AddForce(velocityBall.x * bouncingSpeed, velocityBall.y, -bouncingSpeed * velocityBall.z, ForceMode.Acceleration);

			foreach (Spotlight spotlight in spotlights) {
				StartCoroutine(spotlight.LightSpotlight());
			}
			GameData.Instance.Score+=points;

		}
	}

	[System.Serializable]
	public class Spotlight {
		// The spotlight
		public Light spotlight;

		// The intensity of this spotlight when lit
		public float intensity;

		// How long the spotlight should be lit
		public float duration;

		// public constructor
		public Spotlight() {

		}

		// Initializes the spotlight's intensity to zero
		public void initialize() {
			this.spotlight.intensity = 0f;
		}

		// light spotlight for spotlight duration seconds
		public IEnumerator LightSpotlight() {
			this.spotlight.intensity = intensity;
			yield return new WaitForSeconds(duration);
			this.spotlight.intensity = 0f;
		}

	}
}
