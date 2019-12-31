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
                ActionEvents.Instance.investComplete.Raise();
            }
            else if (actionBase.localInvestCounter < actionBase.nBenefit) {
                ActionEvents.Instance.useAllBenefits.Raise();
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

        ActionEvents.Instance.investStarted.Raise();
        actionBase.Activate();
    }
}
