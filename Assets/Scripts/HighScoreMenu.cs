using UnityEngine;
using System.Collections;

public class HighScoreMenu : MonoBehaviour {

	public Texture highScoreMenuBackground;
	private int highScoreOne;
	private int highScoreTwo;
	private int highScoreThree;
	private int highScoreFour;
	private int highScoreFive;
		
	private int buttonWidth = 200;
	private int buttonHeight = 50;
	void Start () {
		highScoreOne = PlayerPrefs.GetInt (0+"highscore");
		highScoreTwo = PlayerPrefs.GetInt (1+"highscore");
		highScoreThree = PlayerPrefs.GetInt (2+"highscore");
		highScoreFour = PlayerPrefs.GetInt (3+"highscore");
		highScoreFive = PlayerPrefs.GetInt (4+"highscore");
	}
	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), highScoreMenuBackground);
		if(GUI.Button(new Rect(Screen.width / 2 -10- buttonWidth / 2, Screen.height  - buttonHeight * 2 ,
		                       buttonWidth, buttonHeight), "Back to Menu"))
		{
			Application.LoadLevel(0);
		}
		if(GUI.Button (new Rect(Screen.width /2 +10+ buttonWidth* 1/2,Screen.height - buttonHeight*2,buttonWidth,buttonHeight),
		               "reset highscore"))
		{
			for(int i=0;i<5;i++){
				PlayerPrefs.SetInt(i+"highscore",0);
			}
			Application.LoadLevel(4);
		}
		GUI.Label (new Rect (Screen.width / 2 - buttonWidth / 2, 50, 250, 200), "0: "+highScoreOne);
		GUI.Label (new Rect (Screen.width / 2 - buttonWidth / 2, 100, 250, 200), "1: "+highScoreTwo);
		GUI.Label (new Rect (Screen.width / 2 - buttonWidth / 2, 150, 250, 200), "2: "+highScoreThree);
		GUI.Label (new Rect (Screen.width / 2 - buttonWidth / 2, 200, 250, 200),"3: "+ highScoreFour);
		GUI.Label (new Rect (Screen.width / 2 - buttonWidth / 2, 250, 250, 200), "4: "+highScoreFive);
	}
}
