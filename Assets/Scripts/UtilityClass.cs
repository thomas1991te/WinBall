using UnityEngine;
using System.Collections;

public class UtilityClass {

	// calculates and returns the angle between the two game objects
	public static float calculateAngle(GameObject object1, GameObject object2) {
		return Vector3.Angle(object1.transform.position, object2.transform.position);
	}
}
