using UnityEngine;

namespace TheEnhancer {
    public class GameManager : MonoBehaviour {
        private static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            } else {
                _instance = this;
            }
        }

        public SharedData gameData;
        public AudioManager audioData;
        public UiManager uiData;

        public void EndGame() {
            if (gameData.wealth >= gameData.wealthGoal) {
                audioData.Victory();
                gameData.CalculateScore();
                uiData.EndGame();
            }
        }
    }

    // StatisticsManager
    // LastActionChanger
    // ScoreScreen
    // SceneLoader
}