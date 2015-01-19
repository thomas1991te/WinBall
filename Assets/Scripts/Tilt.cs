using UnityEngine;
using System.Collections;

public class Tilt : MonoBehaviour {

	// The amount to tilt the table
	public Vector3 tilt;

	// the speed of the tilt
	public float speed;

	// the delay between two tilts
	public float delay;

	// the last tilt
	private float lastTilt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Controller controller = ActiveController.getActiveController();
		lastTilt += Time.deltaTime;
		if (lastTilt > delay && (Input.GetKey("t") || (controller.isConnected() && controller.getButton(Controller.button02)))) {
			lastTilt = 0.0f;
			StartCoroutine(Tilten());
			if (controller.isConnected()) {
				controller.setLED1(false);
				controller.setLED2(false);
				controller.setLED3(false);
				controller.setLED4(false);
			}
		}

		float ledTimes = delay / 4.0f;


		if (lastTilt >= ledTimes) {
			if (controller.isConnected()) {
				controller.setLED1(true);
			}
		}

		ledTimes += ledTimes;

		if (lastTilt >= ledTimes) {
			if (controller.isConnected()) {
				controller.setLED2(true);
			}
		}

		ledTimes += ledTimes;
		
		if (lastTilt >= ledTimes) {
			if (controller.isConnected()) {
				controller.setLED3(true);
			};
		}

		ledTimes += ledTimes;
		
		if (lastTilt >= ledTimes) {
			if (controller.isConnected()) {
				controller.setLED4(true);
			}
		}
	}

	// light spotlight for spotlight duration seconds
	public IEnumerator Tilten() {
		transform.position += tilt;
		yield return new WaitForSeconds (speed);
		transform.position -= tilt * 2;
		yield return new WaitForSeconds (speed);
		transform.position += tilt;
	}
}
