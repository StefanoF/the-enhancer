using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionInvest : MonoBehaviour
{
    private ActionBase actionBase;
    private ActionCounter actionCounter;


    void Awake() {
        actionBase = gameObject.GetComponent<ActionBase>();
        actionCounter = gameObject.GetComponent<ActionCounter>();
    }

    void OnMouseDown() {
        if (actionBase.gameData.wealth >= actionBase.gameData.wealthGoal) {
            return;
        }
        if (!actionBase.actionActive) {
            actionBase.StartBlinking();
        }
        LeftMouseClick();
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
            actionCounter.ResetBenefits();
            actionBase.gameData.investCounter = 0;
            actionBase.gameData.investments = new bool[4];
            actionBase.resources.GetComponent<Resources>().UpdateHighlight();
        }

        ActionEvents.Instance.investStarted.Raise();
        actionBase.Activate();
    }
}
