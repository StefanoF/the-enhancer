using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBase : MonoBehaviour
{   
    public bool inProgress;

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
    public GameObject nextAction;

    [Header("Resources")]
    public GameObject resources;

    [Header("UI Title")]
    public Text actionTitleText;

    [Header("UI Need")]
    public GameObject hoverCountersNeed;

    public GameObject needTextObj;
    public GameObject needCultureObj;
    public GameObject needConnectionsObj;
    public GameObject needHumanityObj;
    public GameObject needSustainabilityObj;

    [Header("UI Costs")]
    public GameObject costsTextObj;
    public GameObject costCultureObj;
    public Text costCultureText;
    public GameObject costConnectionsObj;
    public Text costConnectionsText;
    public GameObject costHumanityObj;
    public Text costHumanityText;
    public GameObject costSustainabilityObj;
    public Text costSustainabilityText;
    public GameObject costWealthObj;
    public Text costWealthText;
    public bool uiUpdated;

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
    }

    void ShowCostsAndNeeds() {
        if (uiUpdated) {
            return;
        }
        actionTitleText.enabled = true;
        actionTitleText.text = actionType.ToString();
        if (culture > 0) {
            costsTextObj.SetActive(true);
            costCultureObj.SetActive(true);
            costCultureText.text = culture.ToString();
        }
        if (connections > 0) {
            costsTextObj.SetActive(true);
            costConnectionsObj.SetActive(true);
            costConnectionsText.text = connections.ToString();
        }
        if (sustainability > 0) {
            costsTextObj.SetActive(true);
            costSustainabilityObj.SetActive(true);
            costSustainabilityText.text = sustainability.ToString();
        }
        if (humanity > 0) {
            costsTextObj.SetActive(true);
            costHumanityObj.SetActive(true);
            costHumanityText.text = humanity.ToString();
        }
        if (wealth > 0) {
            costsTextObj.SetActive(true);
            costWealthObj.SetActive(true);
            costWealthText.text = wealth.ToString();
        }
        if (needInvestment) {
            needTextObj.SetActive(true);
            if (actionProduction.investmentNeeded[0]) {
                needCultureObj.SetActive(true);
            }
            if (actionProduction.investmentNeeded[1]) {
                needConnectionsObj.SetActive(true);
            }
            if (actionProduction.investmentNeeded[2]) {
                needHumanityObj.SetActive(true);
            }
            if (actionProduction.investmentNeeded[3]) {
                needSustainabilityObj.SetActive(true);
            }
        }
        hoverCountersNeed.SetActive(true);
        uiUpdated = true;
    }

    void HideCostsAndNeeds() {
        needTextObj.SetActive(false);
        needCultureObj.SetActive(false);
        needConnectionsObj.SetActive(false);
        needHumanityObj.SetActive(false);
        needSustainabilityObj.SetActive(false);
        costsTextObj.SetActive(false);
        costCultureObj.SetActive(false);
        costConnectionsObj.SetActive(false);
        costHumanityObj.SetActive(false);
        costSustainabilityObj.SetActive(false);
        costWealthObj.SetActive(false);
        actionTitleText.enabled = false;
        hoverCountersNeed.SetActive(false);
        uiUpdated = false;
    }

    void OnMouseExit() {
        HideCostsAndNeeds();
        if (!inProgress) {
            resources.SetActive(false);
        }
    }

    void OnMouseOver() {
        if (!gameData.actionInProgress) {
            ShowCostsAndNeeds();
            resources.SetActive(true);
        }
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
        actionTitleText.enabled = true;
        cameraFollow.SetTarget(transform.position);
        gameData.actionInProgress = true;
        inProgress = true;
        resources.SetActive(true);
    }

    public void ConcludeAction() {
        actionTitleText.enabled = false;
        gameData.actions++;
        gameData.lastActionType = actionType;
        gameData.SpendResources(costDict);
        gameData.actionInProgress = false;
        inProgress = false;
        resources.SetActive(false);
        cameraFollow.ResetTarget();

        if (actionType == SharedData.ActionType.Star) {
            gameObject.SetActive(false);
        }

        if (nextAction) {
            if (!nextAction.activeSelf) {
                nextAction.SetActive(true);
            }
        }
    }
}
