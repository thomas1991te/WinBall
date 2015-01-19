using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {

	// Reference to the controller driver.
	//Controller controller;

	// Max angle of the flippers.
	public float maxAngle;

	public float angleImpact;

	// Determines the speed with which the flippers is rotated.
	public float rotationSpeed;

	// The acceleration speed the ball will be accelerated when it hits the flipper.
	public float accelerationSpeed;

	// The original rotation of this flipper.
	private Quaternion originalRotation;

	// Current rotation speed of flipper
	private float currentRotationSpeed;

	private bool leftFlipper;
	private bool rightFlipper;

	// Use this for initialization
	void Start () {
		//controller = (Controller) this.gameObject.GetComponent(typeof(Controller));
		originalRotation = transform.localRotation;
		currentRotationSpeed = 0f;
		rightFlipper = false;
		leftFlipper = false;
	}
	
	// Update is called once per frame
	void Update () {
		Controller controller = ActiveController.getActiveController();
		if (Time.frameCount % 10 == 0) {
			if (controller.isConnected()) {
				if (this.gameObject.tag == "Flipper01_right") {
					rightFlipper = controller.getButton(Controller.button05);
				}
				if (this.gameObject.tag == "Flipper01_left") {
					leftFlipper = controller.getButton(Controller.button06);
				}
			}
		}
		float angle = transform.localRotation.z - originalRotation.z;
		float rotate = 0;

		if (this.gameObject.tag == "Flipper01_right") {
			if (Input.GetButton("RightArrow") || rightFlipper) {
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
			if (Input.GetButton("LeftArrow") || leftFlipper) {
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
			angleOfContact *= angleImpact;
			float rotSpeed = currentRotationSpeed / rotationSpeed;
			// get current velocity of the ball
			Vector3 velocityBall = theCollision.gameObject.rigidbody.velocity;
			// update force according to ball velocity, hit angle and current speed of flipper
			float acc = -accelerationSpeed * currentRotationSpeed;
			theCollision.gameObject.rigidbody.AddForce(acc * angleOfContact, 0, acc * rotSpeed, ForceMode.VelocityChange);
		}
	}
}
