using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionProduction : MonoBehaviour
{
    private ActionBase actionBase;

    public bool[] investmentNeeded;
    public int investmentNeededCounter;

    void Awake() {
        actionBase = gameObject.GetComponent<ActionBase>();
    }

    void Start() {
        int count = 0;
        foreach(bool i in investmentNeeded) {
            if (i) {
                count++;
            }
        }
        investmentNeededCounter = count;
    }

    void OnMouseDown() {
        LeftMouseClick();
    }

    void LeftMouseClick() {
        if (actionBase.inProgress) {
            if (actionBase.gameData.productCounter == actionBase.nBenefit) {
                actionBase.ConcludeAction();
                actionBase.gameData.AddProductResources();
                ActionEvents.Instance.productionComplete.Raise();
            }
            else if (actionBase.gameData.productCounter < actionBase.nBenefit) {
                ActionEvents.Instance.useAllBenefits.Raise();
            }
            return;
        }

        if (!actionBase.Validate()) {
            return;
        }

        if (actionBase.needInvestment) {
            if (actionBase.gameData.investCounter == 0) {
                ActionEvents.Instance.needToInvest.Raise();
                return;
            }

            int investmentsFinded = 0;
            for (int i = 0; i<investmentNeeded.Length; i++) {
                if (investmentNeeded[i] == true && investmentNeeded[i] == actionBase.gameData.investments[i]) {
                    investmentsFinded++;
                }
            }

            if (investmentsFinded == 0) {
                ActionEvents.Instance.needCorrectInvest.Raise();
                return;
            } 
        }

        actionBase.SaveStateToUndo();

        ActionEvents.Instance.productionStarted.Raise();
        actionBase.Activate();
    }
}
