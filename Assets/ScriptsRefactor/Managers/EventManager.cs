using UnityEngine;

namespace TheEnhancer {
    public class EventManager : SingletonAbstract<EventManager> {
        protected override void Awake()
        {
            base.Awake();
            print("EventManager ready!");
        }

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
        public GameEvent deProduct;
        public GameEvent invest;
        public GameEvent product;

        [Header("Utils")]
        public GameEvent changeLanguage;

        [Header("Validators")]
        public GameEvent allBenefitPlaced;
        public GameEvent allBenefitNotPlaced;
        public GameEvent needCorrectInvest;
        public GameEvent needToInvest;
        public GameEvent notEnoughResources;
        public GameEvent oneActionAtTime;
        public GameEvent sameActionTwice;
        public GameEvent useAllBenefits;
    }
}