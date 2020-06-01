using UnityEngine;

namespace TheEnhancer {
    public class ActionClick : MonoBehaviour
    {
        public GameData gameData;
        // public ActionData actionData;
        public AllEvents events;

        void OnMouseDown() {
            if (!gameData.pause) {
                if (gameData.wealth >= gameData.wealthGoal) {
                    return;
                }
                // if (!actionData.actionActive) {
                //     actionData.StartBlinking();
                // }
                LeftMouseClick();
            }
        }

        void LeftMouseClick() {
            // if (actionData.inProgress) {
            //     if (actionData.localInvestCounter == actionData.nBenefit) {
            //         actionData.ConcludeAction();
            //         ActionEvents.Instance.investComplete.Raise();
            //     }
            //     else if (actionData.localInvestCounter < actionData.nBenefit) {
            //         ActionEvents.Instance.useAllBenefits.Raise();
            //     }
            //     return;
            // }

            // if (!actionData.Validate()) {
            //     return;
            // }

            // actionData.SaveStateToUndo();

            // if (actionData.nBenefit < gameData.investCounter) {
            //     actionCounter.ResetBenefits();
            //     gameData.investCounter = 0;
            //     gameData.investments = new bool[4];
            //     // resources.GetComponent<ResourceManager>().UpdateHighlight();
            // }
            print("actionclick mousedown");
            gameData.currentActionPos = gameObject.transform.position;
            events.investStarted.Raise();
            // actionData.Activate();
        }

    }
}