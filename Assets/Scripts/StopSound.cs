using UnityEngine;
using System.Collections;

public class StopSound : MonoBehaviour {
	void Update () {
		if (GameData.Instance.CurrentGameMode == GameData.GameMode.Start && !audio.isPlaying) {
			audio.PlayDelayed(2f);
		}
		if (GameData.Instance.CurrentGameMode == GameData.GameMode.Playing && audio.isPlaying) {
			audio.Stop();
		}
	}
}
