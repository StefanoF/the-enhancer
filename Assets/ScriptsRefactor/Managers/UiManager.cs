using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheEnhancer {
    [CreateAssetMenu(fileName = "UiData", menuName = "UiData", order = 1)]
    public class UiManager : ScriptableObject {
        public GameObject endGame;
        public void EndGame() {
            endGame.SetActive(true);
        }

        public void ChangeColor(Image actualImage) {
            actualImage.color = GameManager.Instance.gameData.lastActionColor;
        }

        public void ChangeActionLvl(Text actualText) {
            actualText.text = GameManager.Instance.gameData.lastActionLvl;
        }

        public void ChangeActionIcon(Image actualImage) {
            actualImage.sprite = GameManager.Instance.gameData.lastActionIcon;
            actualImage.color = new Color(255, 255, 255, 255);
        }
    }
}