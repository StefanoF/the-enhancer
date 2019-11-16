using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBase : MonoBehaviour
{
    [Header("Stats data")]
    public SharedData gameData;
    public SharedData.ActionType actionType;
    
    [Header("Costs")]
    public int culture;
    public int connections;
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

    public string hoverDesc;
    public bool needInvestment;

    // Start is called before the first frame update
    void Start()
    {
        costDict = new Dictionary<string, int>();
        costDict.Add("culture", culture);
        costDict.Add("connections", connections);
        costDict.Add("humanity", humanity);
        costDict.Add("sustainability", sustainability);

        hoverDesc = actionType.ToString();
        hoverDesc += "\nCulture: " + culture;
        hoverDesc += "\nConnections: " + connections;
        hoverDesc += "\nSustainability: " + sustainability;
        hoverDesc += "\nHumanity: " + humanity;
        if (needInvestment) {
          hoverDesc += "\nNeed active investments";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseExit() {
        gameData.hoverDescription = "";
    }

    void OnMouseOver() {
        gameData.hoverDescription = hoverDesc;
    }

    public bool Validate() {
        if (gameData.actionInProgress) {
            gameData.helpText = "One action at time!";
            return false;
        }

        if (gameData.lastActionType == actionType) {
            gameData.helpText = "Same action executed!";
            return false;
        }

        if (!gameData.HasResources(costDict)) {
            gameData.helpText = "No sufficently resources!";
            return false;
        }

        return true;
    }

    public void Activate() {
        gameData.actionInProgress = true;
        resources.SetActive(true);
    }

    public void ConcludeAction() {
        gameData.actions++;
        gameData.lastActionType = actionType;
        gameData.SpendResources(costDict);
        gameData.actionInProgress = false;
        resources.SetActive(false);
    }
}
