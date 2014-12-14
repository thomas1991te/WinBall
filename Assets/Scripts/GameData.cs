public class GameData {

	// the singleton instance
	private static GameData instance;

	// private constructor to prevent this class from being instanciated
	private GameData() {
		if(instance != null) {
			return;
		}
		instance = this;
		gameMode = GameMode.Start;
	}

	// returns the existing singleton instance, or creates a new one of non does exist
	public static GameData Instance {
		get {
			if(instance == null) {
				new GameData();
			}
			
			return instance;
		}
	}

	// the current score
	private int score = 0;

	// returns and updates the score
	public int Score {
		get {
			return score;
		}
		set {
			score = value;
		}
	}

	// the current number of lives
	private int lives = 3;

	// returns and updates the live
	public int Lives {
		get {
			return lives;
		}
		set {
			lives = value;
		}
	}

	// the current player's name
	private string playerName = "";

	// returns and udpates the player's name
	public string PlayerName {
		get {
			return playerName;
		}
		set {
			playerName = value;
		}
	}

	// the different available game modes
	public enum GameMode {
		Start,
		Playing,
		GameOver,
		Paused,
		BonusRound
	};

	// the current game mode
	private GameMode gameMode;

	// returns and updates the current game mode
	public GameMode CurrentGameMode {
		get {
			return gameMode;
		} 
		set {
			gameMode = value;
		}
	}
}