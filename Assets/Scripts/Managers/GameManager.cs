using UnityEngine;
using Game.Utilities.Singletons;
using System;

namespace Game.Managers {
	public class GameManager : Singleton<GameManager> {
		public GameState GameState { get; private set; }
		public static event Action<GameState> BeforeGameStateChanged = delegate { };
		public static event Action<GameState> AfterGameStateChanged = delegate { };
		protected override void Awake() {
			base.Awake();
		}
		private void Start() => ChangeGameState(GameState.SetUp);
		public void ChangeGameState(GameState newState) {
			if (GameState == newState) {
				Debug.LogWarning($"Ignoring redundant state change: {newState}");
				return;
			}
			BeforeGameStateChanged?.Invoke(newState);
			GameState = newState;
			switch (newState) {
				case GameState.SetUp:
					break;
				case GameState.Lose:
					break;

			}

			AfterGameStateChanged?.Invoke(newState);
		}

	}
}
[Serializable]
public enum GameState {
	None = 0,
	SetUp = 1,
	Lose = 2,


}


