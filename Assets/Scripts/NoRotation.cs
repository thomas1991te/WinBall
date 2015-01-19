using UnityEngine;
using System.Collections;

public class NoRotation : MonoBehaviour {

	// the max distance which the camera should keep to the ball
	public float maxDistance;

	public float offset;

	private Vector3 originalPos;
	 
	public GameObject balli;
	// Use this for initialization
	void Start () {
		originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		balli = GameObject.FindGameObjectWithTag("Ball");
		if (balli != null) {
			float distance = Vector3.Distance(transform.position, balli.transform.position);

			if (distance > maxDistance) {
				transform.position  += Vector3.forward * (maxDistance - distance) * Time.deltaTime;
			} else if (transform.position.z < originalPos.z) {
				transform.position  += Vector3.back * (distance - maxDistance);
			}

		}

	}
}
