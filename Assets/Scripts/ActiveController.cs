using UnityEngine;
using System.Collections;

public class ActiveController : MonoBehaviour {

	private static Controller activeController;

	// Use this for initialization
	void Start () {
		activeController = new Controller();
	}
	
	public static Controller getActiveController() {
		return activeController;
	}
}
