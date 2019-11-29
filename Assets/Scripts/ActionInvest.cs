using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionInvest : MonoBehaviour
{
    private ActionBase actionBase;

    void Awake() {
        actionBase = gameObject.GetComponent<ActionBase>();
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            LeftMouseClick();
        }
    }

    void LeftMouseClick() {
        if (actionBase.inProgress) {
            if (actionBase.localInvestCounter == actionBase.nBenefit) {
                actionBase.ConcludeAction();
                actionBase.gameData.helpText = "Resources spended: invest complete!";
            }
            else if (actionBase.localInvestCounter < actionBase.nBenefit) {
                actionBase.gameData.helpText = "Use all the benefit prior to confirm the action!";
            }
            return;
        }

        if (!actionBase.Validate()) {
            return;
        }

        actionBase.SaveStateToUndo();

        if (actionBase.nBenefit < actionBase.gameData.investCounter) {
            actionBase.gameData.investCounter = 0;
            actionBase.gameData.investments = new bool[4];
            actionBase.resources.GetComponent<Resources>().UpdateHighlight();
        }

        actionBase.gameData.helpText = "What do you want to invest in?\nLeft click to invest\nRight click to disinvest";
        actionBase.Activate();
    }
}
