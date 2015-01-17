using UnityEngine;
using System.Collections;

public class NoRotation : MonoBehaviour {
	 
	public GameObject balli;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		balli = GameObject.FindGameObjectWithTag("Ball");
		gameObject.transform.position  = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, balli.transform.position.z);

	}
}
