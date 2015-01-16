using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {

	// Reference to the controller driver.
	//Controller controller;

	// Max angle of the flippers.
	public float maxAngle;

	// Determines the speed with which the flippers is rotated.
	public float rotationSpeed;

	// The acceleration speed the ball will be accelerated when it hits the flipper.
	public float accelerationSpeed;

	// The original rotation of this flipper.
	private Quaternion originalRotation;

	// Current rotation speed of flipper
	private float currentRotationSpeed;

	// Use this for initialization
	void Start () {
		//controller = (Controller) this.gameObject.GetComponent(typeof(Controller));
		originalRotation = transform.localRotation;
		currentRotationSpeed = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		float angle = transform.localRotation.z - originalRotation.z;
		float rotate = 0;

		Controller controller = ActiveController.getActiveController();

		if (this.gameObject.tag == "Flipper01_right") {
			if (Input.GetButton("RightArrow") || (controller.isConnected() && controller.getButton(Controller.button05))) {
				if (angle < maxAngle) {
					rotate = rotationSpeed * Time.deltaTime;
				}
			} else {
				if (angle > 0f) {
					rotate = rotationSpeed * Time.deltaTime * -1f;
				}
			}
		}
		if (this.gameObject.tag == "Flipper01_left") {
			angle *= -1;
			if (Input.GetButton("LeftArrow") || (controller.isConnected() && controller.getButton(Controller.button06))) {
				if (angle < maxAngle) {
					rotate = rotationSpeed * Time.deltaTime * -1f;
				}
			} else {
				if (angle > 0f) {
					rotate = rotationSpeed * Time.deltaTime;
				}
			}
		}

		if (angle < 0f) {
			transform.localRotation = originalRotation;
		}

		if (rotate < 0) {
			currentRotationSpeed = rotate * -1f;
		} else {
			currentRotationSpeed = rotate;
		}

		GameObject rotatingPoint = this.gameObject.transform.FindChild("RotatingPoint").gameObject;
		if (rotatingPoint == null) {
			Debug.LogError("No rotating point for flipper " + this.gameObject.name + " could be found!");
		} else {
			transform.RotateAround(rotatingPoint.transform.position, Vector3.up, rotate);
		}
	}

	void OnCollisionEnter(Collision theCollision) {
		if (theCollision.gameObject.tag == "Ball") {
			// calculate the angel of contact between the two colliding objects
			float angleOfContact = UtilityClass.calculateAngleOfContact(theCollision.gameObject, this.gameObject);
			// get current velocity of the ball
			Vector3 velocityBall = theCollision.gameObject.rigidbody.velocity;
			// update force according to ball velocity, hit angle and current speed of flipper
			Debug.Log("Rotation speed: " + currentRotationSpeed);
			Debug.Log("Angle of Contact: " + angleOfContact);
			Debug.Log("Velocity Ball: " + velocityBall);
			float zAcc = -accelerationSpeed * currentRotationSpeed;
			theCollision.gameObject.rigidbody.AddForce(velocityBall.x * currentRotationSpeed * angleOfContact, velocityBall.y, zAcc, ForceMode.Acceleration);
		}
	}
}
