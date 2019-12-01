using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionProduction : MonoBehaviour
{
    private ActionBase actionBase;

    public bool[] investmentNeeded;


    void Awake() {
        actionBase = gameObject.GetComponent<ActionBase>();
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            // left mouse button click
            LeftMouseClick();
        }
    }

    void LeftMouseClick() {
        if (actionBase.inProgress) {
            if (actionBase.gameData.productCounter == actionBase.nBenefit) {
                actionBase.ConcludeAction();
                actionBase.gameData.AddProductResources();
                actionBase.gameData.helpText = "Resources spended: production complete!";
            }
            else if (actionBase.gameData.productCounter < actionBase.nBenefit) {
                actionBase.gameData.helpText = "Use all the benefit prior to confirm the action!";
            }
            return;
        }

        if (!actionBase.Validate()) {
            return;
        }

        if (actionBase.needInvestment) {
            if (actionBase.gameData.investCounter == 0) {
                actionBase.gameData.helpText = "Not have investments!\nYou need to invest prior to produce!";
                return;
            }

            int investmentsFinded = 0;
            for (int i = 0; i<investmentNeeded.Length; i++) {
                if (investmentNeeded[i] == true && investmentNeeded[i] == actionBase.gameData.investments[i]) {
                    investmentsFinded++;
                }
            }

            if (investmentsFinded == 0) {
                actionBase.gameData.helpText = "No correct investments!\nYou need to invest the required resources!";
                return;
            } 
        }

        actionBase.SaveStateToUndo();

        actionBase.gameData.helpText = "Want you want to produce?\nLeft click to increase\nRight click to decrease";
        actionBase.Activate();
    }
}
