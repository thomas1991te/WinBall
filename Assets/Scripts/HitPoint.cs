using UnityEngine;
using System.Collections;

public class HitPoint : MonoBehaviour {

	public int points;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter( Collider coll){
		
		GameData.Instance.Score += points;
	}
}
