using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionProduction : MonoBehaviour
{
    private ActionBase actionBase;

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
        if (actionBase.resources.activeSelf) {
            if (actionBase.gameData.investCounter == actionBase.nBenefit) {
                actionBase.ConcludeAction();
                actionBase.gameData.AddProductResources();
                actionBase.gameData.helpText = "Resources spended: production complete!";
            }
            else if (actionBase.gameData.investCounter < actionBase.nBenefit) {
                actionBase.gameData.helpText = "Use all the benefit prior to conclude the action!";
            }
            return;
        }

        if (!actionBase.Validate()) {
            return;
        }

        if (actionBase.gameData.investCounter == 0) {
            actionBase.gameData.helpText = "No sufficently resources!";
            return;
        }

        actionBase.Activate();
    }
}
