using UnityEngine;

namespace TheEnhancer {
    public class ActionClick : MonoBehaviour
    {
        public GameData gameData;
        public ActionData actionData;
        public AllEvents events;

        void OnMouseDown() {
            if (!gameData.pause) {
                if (gameData.IsWealthAchieved()) {
                    return;
                }
                // if (!actionData.isActive) {
                //     actionData.StartBlinking();
                // }
                if (actionData.isProgress) {
                    if (actionData.investCounter == actionData.benefits) {
                        events.investComplete.Raise();
                        events.changeLastAction.Raise();
                    }
                    else if (actionData.investCounter < actionData.benefits) {
                        events.useAllBenefits.Raise();
                    }
                    return;
                }

                if (!Validate()) {
                    return;
                }

                // actionData.SaveStateToUndo();

                // if (actionData.benefits < gameData.investCounter) {
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

        public bool Validate() {
            if (gameData.actionInProgress) {
                events.oneActionAtTime.Raise();
                return false;
            }

            if (gameData.IsLastAction(actionData) && !actionData.doTwice) {
                events.sameActionTwice.Raise();
                return false;
            }

            if (!gameData.HasResources(actionData.costs)) {
                events.notEnoughResources.Raise();
                return false;
            }

            return true;
        }
        
        // raise on investComplete
        // public void ConcludeAction() {
        //     // mmMM.Play();
        //     // undoController.Reset();
        //     uiData.lastActionName = gameObject.transform.parent.gameObject.name;
        //     uiData.lastActionLvl = actionData.level.ToString();
        //     uiData.lastActionIcon = actionIcon.sprite;
        //     uiData.lastActionColor = actionColor;
        //     DeActivate();
        //     gameData.actions++;
        //     gameData.SpendResources(costDict);

        //     if (actionType == SharedData.ActionType.Star) {
        //         gameObject.SetActive(false);
        //     }

        //     if (nextAction) {
        //         if (!nextAction.activeSelf) {
        //             nextAction.SetActive(true);
        //         }
        //     }
        // }

    }
}