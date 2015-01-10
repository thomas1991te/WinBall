using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	void Update () {
		if (GameData.Instance.CurrentGameMode == GameData.GameMode.Playing && !audio.isPlaying) {
						audio.Play ();
				}
		if (GameData.Instance.CurrentGameMode == GameData.GameMode.Start && audio.isPlaying) {
			audio.Stop ();
		}
	}
	
}
