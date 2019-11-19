using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBase : MonoBehaviour
{
    [Header("Stats data")]
    public SharedData gameData;
    public SharedData.ActionType actionType;
    public bool doTwice;
    
    [Header("Costs")]
    public int culture;
    public int connections;
    public int humanity;
    public int sustainability;
    public int wealth;
    private Dictionary<string, int> costDict;

    [Header("Benefits")]
    public int nBenefit;

    [Header("Resources")]
    public GameObject resources;

    [Header("UI Descriptor")]
    public string hoverDesc;
    public string hoverInvestDesc;

    public bool needInvestment;
    public int localInvestCounter;

    private CameraFollow cameraFollow;
    private ActionProduction actionProduction;

    void Awake() {
        cameraFollow = Camera.main.gameObject.GetComponent<CameraFollow>();
        actionProduction = gameObject.GetComponent<ActionProduction>();
    }

    // Start is called before the first frame update
    void Start()
    {
        costDict = new Dictionary<string, int>();
        costDict.Add("culture", culture);
        costDict.Add("connections", connections);
        costDict.Add("humanity", humanity);
        costDict.Add("sustainability", sustainability);
        costDict.Add("wealth", wealth);

        hoverDesc = actionType.ToString();
        if (culture > 0) {
            hoverDesc += "\nCulture: " + culture;
        }
        if (connections > 0) {
            hoverDesc += "\nConnections: " + connections;
        }
        if (sustainability > 0) {
            hoverDesc += "\nSustainability: " + sustainability;
        }
        if (humanity > 0) {
            hoverDesc += "\nHumanity: " + humanity;
        }
        if (wealth > 0) {
            hoverDesc += "\nWealth: " + wealth;
        }
        if (needInvestment) {
            hoverInvestDesc += "\nNeed one investment in:";
            hoverInvestDesc += actionProduction.GetHoverDesc();
        }
        
    }

    void OnMouseExit() {
        gameData.hoverDescription = "";
        gameData.hoverInvestment = "";
    }

    void OnMouseOver() {
        gameData.hoverDescription = hoverDesc;
        gameData.hoverInvestment = hoverInvestDesc;
    }

    public bool Validate() {
        if (gameData.actionInProgress) {
            gameData.helpText = "One action at time!";
            return false;
        }

        if (gameData.lastActionType == actionType && !doTwice) {
            gameData.helpText = "Don't do same action twice!";
            return false;
        }

        if (!gameData.HasResources(costDict)) {
            gameData.helpText = "Not have enough resources!";
            return false;
        }

        return true;
    }

    public void Activate() {
        cameraFollow.SetTarget(transform.position);
        gameData.actionInProgress = true;
        resources.SetActive(true);
    }

    public void ConcludeAction() {
        gameData.actions++;
        gameData.lastActionType = actionType;
        gameData.SpendResources(costDict);
        gameData.actionInProgress = false;
        resources.SetActive(false);
        cameraFollow.ResetTarget();
        if (actionType == SharedData.ActionType.Star) {
            gameObject.SetActive(false);
        }
    }
}
