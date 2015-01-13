using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	private int score;
	private int lives;

	void OnGUI(){
		GUI.Label (new Rect (10, 10, 250, 200), "Score: "+score);
		GUI.Label (new Rect (10, 30, 250, 200), "Lives:"+lives);

	}

	void Update(){
		score=GameData.Instance.Score;
		lives=GameData.Instance.Lives;
	}
}
