using UnityEngine;
using System.Collections;

public class UtilityClass {

	// calculates and returns the angle of contact between the two game objects
	// the first object is the moving object the second one the fixed one
	public static float calculateAngleOfContact(GameObject object1, GameObject object2) {
		float angleOfContact = Vector3.Angle(object1.rigidbody.velocity, object2.transform.position);
		return angleOfContact / 180.0f;
	}
}
