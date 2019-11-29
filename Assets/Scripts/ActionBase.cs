using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBase : MonoBehaviour
{   
    public bool inProgress;
    public string actionDescription;

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
    private ActionCounter actionCounter;
    private UndoController undoController;
    private Image actionTitlePanel;
    private Text actionTitleText;
    private Text actionSubTitleText;

    void Awake() {
        cameraFollow = Camera.main.gameObject.GetComponent<CameraFollow>();
        actionProduction = gameObject.GetComponent<ActionProduction>();
        actionCounter = gameObject.GetComponent<ActionCounter>();
        undoController = GameObject.Find("/Activities").GetComponent<UndoController>();
        actionTitlePanel = GameObject.Find("/UI/ActionTitle/Panel").GetComponent<Image>();
        actionTitleText = GameObject.Find("/UI/ActionTitle/Text").GetComponent<Text>();
        actionSubTitleText = GameObject.Find("/UI/ActionTitle/SubText").GetComponent<Text>();
        ToogleTitle(false);
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

        actionTitleText.text = "";
        actionSubTitleText.text = "";
    }

    void ToogleTitle(bool active) {
        actionTitlePanel.enabled = active;
        actionTitleText.enabled = active;
        actionSubTitleText.enabled = active;
    }

    void ShowCostsAndNeeds() {
        if (uiUpdated) {
            return;
        }
        actionTitleText.text = actionType.ToString();
        actionSubTitleText.text = actionDescription.ToString();
        ToogleTitle(true);
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
                needSustainabilityObj.SetActive(true);
            }
            if (actionProduction.investmentNeeded[3]) {
                needHumanityObj.SetActive(true);
            }
        }
        hoverCountersNeed.SetActive(true);
        uiUpdated = true;
        actionCounter.ActivateBenefits();
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
        ToogleTitle(false);
        hoverCountersNeed.SetActive(false);
        uiUpdated = false;
        actionCounter.DeActivateBenefits();
    }

    void OnMouseExit() {
        if (!gameData.actionInProgress) {
            HideCostsAndNeeds();
        }
        
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

        if (gameData.lastActionName == gameObject.transform.parent.gameObject.name && !doTwice) {
            gameData.helpText = "Don't do same action twice!";
            return false;
        }

        if (!gameData.HasResources(costDict)) {
            gameData.helpText = "Not have enough resources!\nYou need to produce resources according to the costs on the left!";
            return false;
        }

        return true;
    }

    public void Activate() {
        ToogleTitle(true);
        cameraFollow.SetTarget(transform.position);
        gameData.actionInProgress = true;
        inProgress = true;
        resources.SetActive(true);
        localInvestCounter = gameData.investCounter;
        actionCounter.ActivateBenefits();
    }

    public void DeActivate() {
        ToogleTitle(false);
        cameraFollow.ResetTarget();
        gameData.actionInProgress = false;
        inProgress = false;
        resources.SetActive(false);
        actionCounter.DeActivateBenefits();
    }

    public void ConcludeAction() {
        undoController.Reset();
        DeActivate();
        gameData.actions++;
        gameData.lastActionName = gameObject.transform.parent.gameObject.name;
        gameData.SpendResources(costDict);

        if (actionType == SharedData.ActionType.Star) {
            gameObject.SetActive(false);
        }

        if (nextAction) {
            if (!nextAction.activeSelf) {
                nextAction.SetActive(true);
            }
        }
    }

    public void SaveStateToUndo() {
        Dictionary<string, object> state = new Dictionary<string, object>();
        state.Add("actionBase.localInvestCounter", localInvestCounter); 
        state.Add("gameData.investments", (bool[]) gameData.investments.Clone());
        state.Add("gameData.investCounter", gameData.investCounter);
        state.Add("gameData.productions", (int[]) gameData.productions.Clone());
        state.Add("gameData.productCounter", gameData.productCounter);

        undoController.SaveState(this, state);
    }

    public void RestoreState() {
        Dictionary<string, object> undoState = undoController.GetUndoState();
        localInvestCounter = (int) undoState["actionBase.localInvestCounter"];
        gameData.investments = (bool[]) undoState["gameData.investments"];
        gameData.investCounter = (int) undoState["gameData.investCounter"];
        gameData.productions = (int[]) undoState["gameData.productions"];
        gameData.productCounter = (int) undoState["gameData.productCounter"];

        gameData.helpText = "Action canceled successfully!";
        undoController.Reset();
        DeActivate();
    }
}
