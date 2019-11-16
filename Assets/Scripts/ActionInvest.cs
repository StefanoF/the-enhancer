using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionInvest : MonoBehaviour
{
    [Header("Stats data")]
    public SharedData gameData;
    public SharedData.ActionType actionType;
    
    [Header("Costs")]
    public int culture;
    public int connections;
    private Dictionary<string, int> costDict;
    
    // [Header("Cost Texts")]
    // private Text cultureText;
    // private Text connectionsText;

    [Header("Benefits")]
    public int nBenefit;
    // private Text benefitText;

    [Header("Resources")]
    public GameObject resources;

    // Start is called before the first frame update
    void Start()
    {
        actionType = SharedData.ActionType.Job;

        costDict = new Dictionary<string, int>();
        costDict.Add("culture", culture);
        costDict.Add("connections", connections);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseExit() {
        gameData.hoverDescription = "";
    }

    void OnMouseOver() {
        gameData.hoverDescription = actionType.ToString() + "\nCulture: " + culture + "\nConnections: " + connections;

        if (Input.GetMouseButtonDown(0)) {
            // left mouse button click
            LeftMouseClick();
        }
    }

    void LeftMouseClick() {
        if (resources.activeSelf) {
            if (gameData.investCounter == nBenefit) {
                CommitAction();
                resources.SetActive(false);
            }
            else if (gameData.investCounter < nBenefit) {
                gameData.helpText = "Use all the benefit prior to conclude the action!";
            }
            return;
        }

        if (gameData.actionInProgress) {
            gameData.helpText = "One action at time!";
            return;
        }
        
        print("actionInvest click");
        if (gameData.lastActionType == actionType) {
            gameData.helpText = "Same action executed!";
            return;
        }

        if (!gameData.HasResources(costDict)) {
            gameData.helpText = "No sufficently resources!";
            return;
        }
        gameData.actionInProgress = true;
        resources.SetActive(true);
    }

    public void CommitAction() {
        gameData.actions++;
        gameData.lastActionType = actionType;
        gameData.SpendResources(costDict);
        gameData.actionInProgress = false;
        gameData.helpText = "Resources spended: invest complete!";
    }
}
