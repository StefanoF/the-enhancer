using UnityEngine;

namespace TheEnhancer {
    public class GameManager : SingletonAbstract<GameManager> {
        public GameData data;
        public AudioManager am;
        public UiManager um;

        protected override void Awake()
        {
            base.Awake();
            print("Gamemanager ready!");
        }

        public void EndGame() {
            if (data.wealth >= data.wealthGoal) {
                data.CalculateScore();
                am.Victory();
                um.EndGame();
            }
        }
    }

    // StatisticsManager
    // LastActionChanger
    // ScoreScreen
    // SceneLoader
}