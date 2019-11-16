using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionProduction : MonoBehaviour
{
    [Header("Stats data")]
    public SharedData gameData;
    public SharedData.ActionType actionType;
    
    [Header("Costs")]
    public int humanity;
    public int sustainability;
    private Dictionary<string, int> costDict;
    
    // [Header("Cost Texts")]
    // private Text cultureText;
    // private Text connectionsText;

    [Header("Benefits")]
    public int nBenefit;
    // private Text benefitText;

    [Header("Resources")]
    public GameObject resources;
    private Resources resourcesScript;

    void Awake() {
        resourcesScript = resources.GetComponent<Resources>();
    }

    // Start is called before the first frame update
    void Start()
    {
        actionType = SharedData.ActionType.Goods;

        costDict = new Dictionary<string, int>();
        costDict.Add("humanity", humanity);
        costDict.Add("sustainability", sustainability);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseExit() {
        gameData.hoverDescription = "";
    }

    void OnMouseOver() {
        gameData.hoverDescription = actionType.ToString();

        if (Input.GetMouseButtonDown(0)) {
            // left mouse button click
            LeftMouseClick();
        }
    }

    void LeftMouseClick() {
        if (resources.activeSelf) {
            if (gameData.productCounter == nBenefit) {
                CommitAction();
                resources.SetActive(false);
            }
            else if (gameData.productCounter < nBenefit) {
                gameData.helpText = "Use all the benefit prior to conclude the action!";
            }
            return;
        }

        if (gameData.actionInProgress) {
            gameData.helpText = "One action at time!";
            return;
        }
        
        print("actionProduct click");
        if (gameData.lastActionType == actionType && gameData.productCounter >= nBenefit) {
            gameData.helpText = "Same action executed!";
            return;
        }

        if (!gameData.HasResources(costDict) || gameData.investCounter == 0) {
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
        gameData.AddProductResources();
        gameData.actionInProgress = false;
        gameData.helpText = "Resources spended: production complete!";
    }
}
