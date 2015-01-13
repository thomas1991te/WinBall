using UnityEngine;
using System.Collections;

public class WinMenu : MonoBehaviour {

	public Texture winBackground;
	
	private string instructionText = "Congratulations!";
	private int buttonWidth = 200;
	private int buttonHeight = 50;
	
	void OnGUI()
	{
		
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), winBackground);
		GUI.Label (new Rect (Screen.width / 2 , 10, 250, 200), instructionText);
		if(GUI.Button(new Rect(Screen.width / 2 - buttonWidth , Screen.height  - buttonHeight ,
		                       buttonWidth, buttonHeight), "Play again"))
		{
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(Screen.width / 2 +10 , Screen.height  - buttonHeight ,
		                       buttonWidth, buttonHeight), "View Highscores"))
		{
			Application.LoadLevel(4);
		}
		
	}
	
	
	
	
	
}