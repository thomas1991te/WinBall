using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	private int score;
	private int lives;

	void OnGUI(){
		GUI.Label (new Rect (10, 10, 250, 200), "Score: "+score);
		GUI.Label (new Rect (10, 30, 250, 200), "Lives:"+lives);
		if(GUI.Button(new Rect(10 , 50 ,
		                       50, 15), "reset"))
		{
			GameData.Instance.Score=0;
			GameData.Instance.Lives=3;
			GameData.Instance.CurrentGameMode = GameData.GameMode.Start;
			Application.LoadLevel(1);
			
		}
		if(GUI.Button(new Rect(Screen.width -110 , 10 ,
		                       100, 15), "back to menu"))
		{
			GameData.Instance.Score=0;
			GameData.Instance.Lives=3;
			GameData.Instance.CurrentGameMode = GameData.GameMode.Start;
			Application.LoadLevel(0);
			
		}

	}

	void OnStart(){

	}


	void Update(){
		transform.rotation = Quaternion.Euler (new Vector3(40,180,0));
		score=GameData.Instance.Score;
		lives=GameData.Instance.Lives;

	}
}
