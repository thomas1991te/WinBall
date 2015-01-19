using UnityEngine;
using System.Collections;

public class KickBallOut : MonoBehaviour {

	public float speed;

	public float angle;

	public Light spotlight;

	public int bonus;

	private int currentBonus;

	// Use this for initialization
	void Start () {
		currentBonus = bonus;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameData.Instance.CurrentGameMode == GameData.GameMode.Start || GameData.Instance.Score >= currentBonus) {
			if (GameData.Instance.CurrentGameMode == GameData.GameMode.Playing) {
				currentBonus += bonus;
			}
			spotlight.intensity = 8;
			gameObject.collider.enabled = true;
			gameObject.renderer.enabled = true;
		}
	}

	void OnCollisionEnter(Collision theCollision) {
		if (theCollision.gameObject.tag == "Ball") {
			theCollision.gameObject.rigidbody.AddForce(angle, 0, speed, ForceMode.VelocityChange);
			spotlight.intensity = 0;
			gameObject.collider.enabled = false;
			gameObject.renderer.enabled = false;
		}
	}
}
