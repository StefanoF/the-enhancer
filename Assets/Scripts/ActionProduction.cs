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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
                actionBase.gameData.helpText = "No investments!";
                return;
            }

            int investmentsFinded = 0;
            for (int i = 0; i<investmentNeeded.Length; i++) {
                if (investmentNeeded[i] == true && investmentNeeded[i] == actionBase.gameData.investments[i]) {
                    investmentsFinded++;
                }
            }

            if (investmentsFinded == 0) {
                actionBase.gameData.helpText = "No correct investments!";
                return;
            } 
        }

        actionBase.gameData.helpText = "Want you want to produce?\nLeft click to increase\nRight click to decrease";
        actionBase.Activate();
    }

    // public string GetHoverDesc() {
    //     string desc = "";
    //     int investments = 0;
    //     for (int i = 0; i < investmentNeeded.Length; i++) {
    //         if (investmentNeeded[i]) {
    //             investments++;
    //         }
    //     }
    //     if (investments == investmentNeeded.Length) {
    //         desc = "\nAny resource";
    //         return desc;
    //     }
    //     if (investmentNeeded[0]) {
    //         desc += "\nCulture";
    //     }
    //     if (investmentNeeded[1]) {
    //         desc += "\nConnections";
    //     }
    //     if (investmentNeeded[2]) {
    //         desc += "\nSustainability";
    //     }
    //     if (investmentNeeded[3]) {
    //         desc += "\nHumanity";
    //     }
    //     return desc;
    // } 
}
