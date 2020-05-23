using UnityEngine;
using UnityEngine.UI;

namespace TheEnhancer {
    [CreateAssetMenu (fileName = "UiData", menuName = "UiData", order = 1)]
    public class UiData : ScriptableObject {
        public string lastActionLvl;
        public Sprite lastActionIcon;
        public Color lastActionColor;
    }
}