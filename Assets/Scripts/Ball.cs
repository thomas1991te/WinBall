using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// the force that pulls the ball down
	public float downForce;

	// the spawn point of the ball
	public GameObject spawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		rigidbody.AddForce(new Vector3(0, -1, 1) * downForce, ForceMode.VelocityChange);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "GameEndTrigger") {
			GameData.Instance.Lives--;
			if (GameData.Instance.Lives > 0) {
				GameData.Instance.CurrentGameMode = GameData.GameMode.Start;
				this.gameObject.transform.position = this.spawnPoint.transform.position;
			} else {
				// game over
				GameData.Instance.CurrentGameMode = GameData.GameMode.GameOver;
				GameObject.Destroy(this.gameObject);
				Application.LoadLevel(3);
			}
		} else if (other.tag == "BallOutTrigger") {
			if (GameData.Instance.CurrentGameMode == GameData.GameMode.Start) {
				GameData.Instance.CurrentGameMode = GameData.GameMode.Playing;
			} else {
				// kick ball out if it falls back to the plunger
				this.rigidbody.AddForce(this.rigidbody.velocity.x, this.rigidbody.velocity.y, -200f * downForce, ForceMode.Acceleration);
			}
		}
	}
}
