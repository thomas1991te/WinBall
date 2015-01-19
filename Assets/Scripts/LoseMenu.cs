using UnityEngine;
using System.Collections;

public class LoseMenu : MonoBehaviour {
	
	public Texture loseBackground;
	
	private string instructionText = "You lost";
	private int buttonWidth = 200;
	private int buttonHeight = 50;

	
	void OnGUI()
	{

		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), loseBackground);
		GUI.Label (new Rect (Screen.width / 2 - buttonWidth / 2, 10, 250, 200), instructionText);
		if(GUI.Button(new Rect(Screen.width / 2 - buttonWidth , Screen.height  - buttonHeight ,
		                       buttonWidth, buttonHeight), "Play again"))
		{
			GameData.Instance.Score=0;
			GameData.Instance.Lives=3;
			GameData.Instance.CurrentGameMode = GameData.GameMode.Start;
			Application.LoadLevel(1);

		}
		if(GUI.Button(new Rect(Screen.width / 2 +10 , Screen.height  - buttonHeight ,
		                       buttonWidth, buttonHeight), "View Highscores"))
		{
			GameData.Instance.CurrentGameMode = GameData.GameMode.Start;
			Application.LoadLevel(4);
		}
		
	}
	
	
	
	
	
}
