using UnityEngine;

namespace TheEnhancer {
    [CreateAssetMenu (fileName = "AllEvents", menuName = "ManagersData/AllEvents", order = 1)]
    public class AllEvents : ScriptableObject {
        [Header("Actions")]
        public GameEvent actionCanceled;
        public GameEvent changeLastAction;
        public GameEvent clickOnBottomPlane;
        public GameEvent investComplete;
        public GameEvent investStarted;
        public GameEvent productionComplete;
        public GameEvent productionStarted;

        [Header("Resources")]
        public GameEvent deInvest;
        public GameEvent deProduce;
        public GameEvent invest;
        public GameEvent produce;

        [Header("Utils")]
        public GameEvent changeLanguage;

        [Header("Validators")]
        public GameEvent allBenefitNotPlaced;
        public GameEvent allBenefitPlaced;
        public GameEvent needCorrectInvest;
        public GameEvent needToInvest;
        public GameEvent notEnoughResources;
        public GameEvent oneActionAtTime;
        public GameEvent sameActionTwice;
        public GameEvent useAllBenefits;
    }
}