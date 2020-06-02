using UnityEngine;

namespace TheEnhancer {
    [CreateAssetMenu (fileName = "ActionData", menuName = "ManagersData/ActionData", order = 1)]
    public class ActionData : ScriptableObject {
        [Header("Manual settings")]
        public GameData.ActionType actionType;
        public int level;
        public int benefits;
        public ResourceAmount[] costs;
        public bool needInvestment;
        public bool doTwice;
        public Material activeMaterial;
        public Material passiveMaterial;

        [Header("Auto settings")]
        public bool isActive;
        public bool isProgress;
        public int investAmountNeeded;
        public int investCounter;
    }
}