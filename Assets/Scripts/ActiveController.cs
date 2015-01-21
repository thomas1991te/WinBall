using UnityEngine;
using System.Collections;

public class ActiveController : MonoBehaviour {

	private static GameObject activeController;

	// Use this for initialization
	void Start () {
		activeController = new GameObject();
		activeController.AddComponent("Controller");
	}
	
	public static Controller getActiveController() {
		return activeController.GetComponent("Controller") as Controller;
	}
}
