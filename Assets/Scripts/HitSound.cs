using UnityEngine;
using System.Collections;

public class HitSound : MonoBehaviour {

	void OnTriggerEnter( Collider coll){

		audio.Play ();
	}
}
