using UnityEngine;
using System.Collections;

public class HitLight : MonoBehaviour {

	// All spotlights assigned to this bumper.
	public Spotlight[] spotlights;
	
	// Use this for initialization
	void Start () {
		foreach (Spotlight spotlight in spotlights) {
			spotlight.initialize();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider theCollision) {
		if(theCollision.gameObject.tag == "Ball") {
			foreach (Spotlight spotlight in spotlights) {
				StartCoroutine(spotlight.LightSpotlight());
			}
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
