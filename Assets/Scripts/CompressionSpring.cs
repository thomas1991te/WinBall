using UnityEngine;
using System.Collections;

public class CompressionSpring : MonoBehaviour {

	// The maximum compression of the spring.
	public float maxCompression;

	// The compression speed (this is the speed with which the user compresses the spring)
	public float compressionSpeed;

	// The relase speed
	public float releaseSpeed;

	// The distance the plunger should go out
	public float plungerDistance;

	// The current compression.
	private float compression;

	// The ball to shoot out
	private GameObject ball;

	// Original position of the plunger
	private Vector3 originalPos;


	// Use this for initialization
	void Start () {
		compression = 0f;
		originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("space")) {
			if (compression < maxCompression) {
				compression += compressionSpeed * Time.deltaTime;
				transform.position += new Vector3(0f, 0f, (compressionSpeed / maxCompression) * Time.deltaTime * plungerDistance);
			}
		} else {
			if (compression > 0f) {
				compression -= releaseSpeed * Time.deltaTime;
				transform.position -= new Vector3(0f, 0f, (releaseSpeed / maxCompression) * Time.deltaTime * plungerDistance);
			}

		}

		if (compression < 0f) {
			compression = 0f;
			transform.position = originalPos;
		}

		if (this.ball != null && GameData.Instance.CurrentGameMode == GameData.GameMode.Start) {
			if (Input.GetKeyUp("space")) {
				this.ball.rigidbody.AddForce(Vector3.back * compression, ForceMode.Acceleration);
			}
		}
	}

	void OnCollisionEnter(Collision theCollision) {
		if(theCollision.gameObject.tag == "Ball") {
			this.ball = theCollision.gameObject;
		}
	}
}
