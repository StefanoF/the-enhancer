using UnityEngine;
using UnityEngine.UI;

namespace TheEnhancer {
    [CreateAssetMenu (fileName = "UiData", menuName = "ManagersData/UiData", order = 1)]
    public class UiData : ScriptableObject {
        public string lastActionLvl;
        public Sprite lastActionIcon;
        public Color lastActionColor;

        public void EndGame() {
            Debug.Log("UiManager Endgame()");
            // endGame.SetActive(true);
        }

        public void ChangeColor(Image actualImage) {
            actualImage.color = lastActionColor;
        }

        public void ChangeActionLvl(Text actualText) {
            actualText.text = lastActionLvl;
        }

        public void ChangeActionIcon(Image actualImage) {
            actualImage.sprite = lastActionIcon;
            actualImage.color = new Color(255, 255, 255, 255);
        }
    }
}