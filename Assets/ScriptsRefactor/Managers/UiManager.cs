using UnityEngine;
using UnityEngine.UI;

namespace TheEnhancer {
    public class UiManager : SingletonAbstract<UiManager> {
        // public GameObject endGame;
        public UiData data;

        protected override void Awake()
        {
            base.Awake();
            print("UiManager ready!");
        }

        public void EndGame() {
            print("UiManager Endgame()");
            // endGame.SetActive(true);
        }

        public void ChangeColor(Image actualImage) {
            actualImage.color = data.lastActionColor;
        }

        public void ChangeActionLvl(Text actualText) {
            actualText.text = data.lastActionLvl;
        }

        public void ChangeActionIcon(Image actualImage) {
            actualImage.sprite = data.lastActionIcon;
            actualImage.color = new Color(255, 255, 255, 255);
        }
    }
}