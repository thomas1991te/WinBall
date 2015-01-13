using UnityEngine;
using System.Collections;

public class Mainmenu : MonoBehaviour {

	public Texture mainMenuBackground;


	private int buttonWidth = 200;
	private int buttonHeight = 50;

	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), mainMenuBackground);
		if(GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, Screen.height / 2 - buttonHeight / 2 ,
		                    buttonWidth, buttonHeight), "Start Game"))
		{
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, Screen.height / 2 + buttonHeight / 2 +10,
		                       buttonWidth, buttonHeight), "View Highscore"))
		{
			Application.LoadLevel(4);
		}
		 
	}





}
