using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceEventRaiser : MonoBehaviour
{
    public GameEvent ActionResourceHover;
    public GameEvent ActionResourceExitHover;
    public GameEvent ActionResourceClicked;

    public ActionData actionData;
    public GameData gameData;

    private void OnMouseEnter() {
        if (gameData.actionInProgress) {
            print("ActionResourceHover raised");
            ActionResourceHover.Raise();
        }
    }

    private void OnMouseExit() {
        if (gameData.actionInProgress) {
            print("ActionResourceExitHover raised");
            ActionResourceExitHover.Raise();
        }
    }

    private void OnMouseDown() {
        if (gameData.actionInProgress) {
            if (actionData.isToInvest || (actionData.isToProduct && actionData.benefitsUsed < actionData.benefits)) {
                print("ActionResourceClicked raised");
                ActionResourceClicked.Raise();
                return;
            }
        }
    }
}
