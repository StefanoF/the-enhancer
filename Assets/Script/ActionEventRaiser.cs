using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEventRaiser : MonoBehaviour
{
    public GameEvent ActionHover;
    public GameEvent ActionExitHover;
    public GameEvent ActionClicked;
    public GameEvent ActionStarted;
    public GameEvent ActionCompleted;
    public GameEvent ActionDuplicated;
    public GameEvent NotEnoughResources;
    public GameEvent NotAllBenefitsUsed;

    public ActionData actionData;
    public StatsData actionCostsData;
    public StatsData gameStatsData;
    public GameData gameData;

    // void Update() {
    //     if (Input.GetMouseButtonDown(0)) {
    //         print("ActionClicked raised");
    //         ActionClicked.Raise();
    //     }
    // }

    private void OnMouseEnter() {
        print("ActionHover raised");
        ActionHover.Raise();
    }

    private void OnMouseExit() {
        print("ActionExitHover raised");
        ActionExitHover.Raise();
    }

    private void OnMouseDown() {
        print("ActionClicked raised");
        ActionClicked.Raise();

        if (!gameData.actionInProgress) {
            if (actionData.uniqueName == gameData.lastActionName && !actionData.doTwice) {
                print("ActionDuplicated raised");
                ActionDuplicated.Raise();
                return;
            }

            if (!gameStatsData.HasEnough(actionCostsData)) {
                print("NotEnoughResources raised");
                NotEnoughResources.Raise();
                return;
            }

            print("ActionStarted raised");
            ActionStarted.Raise();
            return;
        }

        if (actionData.benefitsUsed < actionData.benefits) {
            print("NotAllBenefitsUsed raised");
            NotAllBenefitsUsed.Raise();
            return;
        }

        if (actionData.uniqueName == gameData.lastActionName) {
            print("ActionCompleted raised");
            ActionCompleted.Raise();
            return;
        }
    }
}
