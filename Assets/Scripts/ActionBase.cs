using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBase : MonoBehaviour
{
    public bool inProgress;
    public string actionDescription;
    public Text actionLvl;
    public Image actionIcon;
    public Color actionColor;
    public bool actionActive;
    public Material activeMaterial;
    public Material passiveMaterial;
    private MeshRenderer meshRenderer;


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

    [Header("Investments")]
    public bool needInvestment;
    public int needInvestCounter;
    public int localInvestCounter;

    [Header("Benefits")]
    public int nBenefit;
    public GameObject nextAction;

    [Header("Resources")]
    public GameObject resources;
    private ResourceManager resourcesScript;

    [Header("UI Need")]
    public GameObject hoverCountersNeed;

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

    [Header("UI Costs Blink")]
    public bool isBlinkingCosts;
    public IEnumerator co;

    private CameraFollow cameraFollow;
    private ActionProduction actionProduction;
    private ActionCounter actionCounter;
    private UndoController undoController;
    private Image actionTitlePanel;
    private Text actionTitleText;
    private Text actionSubTitleText;

    [Header("Audio Effects")]
    public AudioSource mmm;
    public AudioSource mmMM;
    public AudioSource mM;
    private Flash flashScript;

    void Awake() {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        resourcesScript = resources.GetComponent<ResourceManager>();
        cameraFollow = Camera.main.gameObject.GetComponent<CameraFollow>();
        actionProduction = gameObject.GetComponent<ActionProduction>();
        actionCounter = gameObject.GetComponent<ActionCounter>();
        undoController = GameObject.Find("/BottomPlane").GetComponent<UndoController>();
        actionTitlePanel = GameObject.Find("/UI/ActionTitle/Panel").GetComponent<Image>();
        actionTitleText = GameObject.Find("/UI/ActionTitle/Text").GetComponent<Text>();
        actionSubTitleText = GameObject.Find("/UI/ActionTitle/SubText").GetComponent<Text>();
        flashScript = gameObject.GetComponent<Flash>();
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
        ChangeMaterial();
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
        actionTitleText.text = I18n.Fields[actionType.ToString().ToLower()];
        actionSubTitleText.text = I18n.Fields[actionDescription.ToString()];
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

        hoverCountersNeed.SetActive(true);
        uiUpdated = true;
        actionCounter.ActivateBenefits();
    }

    void HideCostsAndNeeds() {
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

    void ToogleCosts(bool active) {
        if (culture > 0 || connections > 0 || humanity > 0 || sustainability > 0 || wealth > 0) {
            costsTextObj.SetActive(active);
        }
        if (culture > 0) {
            costCultureObj.SetActive(active);
        }
        if (connections > 0) {
            costConnectionsObj.SetActive(active);
        }
        if (humanity > 0) {
            costHumanityObj.SetActive(active);
        }
        if (sustainability > 0) {
            costSustainabilityObj.SetActive(active);
        }
        if (wealth > 0) {
            costWealthObj.SetActive(active);
        }
    }

    public IEnumerator BlinkCosts(float blinkingTime, float blinkingRatio) {
        if (isBlinkingCosts) {
            yield return null;
        }
        float t = 0;
        isBlinkingCosts = true;
        while (t < blinkingTime) {
            ToogleCosts(true);

            yield return new WaitForSeconds(blinkingRatio);
            ToogleCosts(false);

            yield return new WaitForSeconds(blinkingRatio);
            ToogleCosts(true);

            t += Time.deltaTime;
        }
        isBlinkingCosts = false;
        yield return null;
    }

    public void StartBlinking() {
        if (isBlinkingCosts) {
            StopCoroutine(co);
        }
        co = BlinkCosts(1f, 0.3f);
        StartCoroutine(co);
    }

    IEnumerator EndOver(float time) {
        float curTime = 0f;
        while (curTime < time) {
            curTime += Time.deltaTime;
            if (!inProgress && gameData.inPlane) {
                resources.SetActive(false);
            }
            yield return null;
        }
    }

    void OnMouseExit() {
        if (!gameData.actionInProgress) {
            HideCostsAndNeeds();
            if (isBlinkingCosts) {
                StopCoroutine(co);
            }
            
        }
        StartCoroutine(EndOver(0.5f));
    }

    void OnMouseEnter() {
        if (!gameData.actionInProgress) {
            ShowCostsAndNeeds();
            if (actionActive) {
                resourcesScript.DisableColliders();
                resources.SetActive(true);
            }
        }
    }

    public bool Validate() {
        if (gameData.actionInProgress) {
            ActionEvents.Instance.oneActionAtTime.Raise();
            return false;
        }

        if (gameData.lastActionName == gameObject.transform.parent.gameObject.name && !doTwice) {
            ActionEvents.Instance.sameActionTwice.Raise();
            return false;
        }

        if (!gameData.HasResources(costDict)) {
            ActionEvents.Instance.notEnoughResources.Raise();
            return false;
        }

        return true;
    }

    public void Activate() {
        mM.Play();
        ToogleTitle(true);
        cameraFollow.SetTarget(transform.position);
        gameData.actionInProgress = true;
        inProgress = true;
        resourcesScript.EnableColliders();
        resources.SetActive(true);
        localInvestCounter = gameData.investCounter;
        actionCounter.ActivateBenefits();
        CheckAllBenefitsUsed();
    }

    public void DeActivate() {
        ToogleTitle(false);
        cameraFollow.ResetTarget();
        gameData.actionInProgress = false;
        inProgress = false;
        resources.SetActive(false);
        actionCounter.DeActivateBenefits();
        HideCostsAndNeeds();
    }

    public void ConcludeAction() {
        mmMM.Play();
        undoController.Reset();
        ChangeLastAction();
        DeActivate();
        gameData.actions++;
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

    private void ChangeLastAction() {
        gameData.lastActionName = gameObject.transform.parent.gameObject.name;
        gameData.lastActionLvl = actionLvl.text;
        gameData.lastActionIcon = actionIcon.sprite;
        gameData.lastActionColor = actionColor;
        ActionEvents.Instance.changeLastAction.Raise();
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
        mmm.Play();
        Dictionary<string, object> undoState = undoController.GetUndoState();
        localInvestCounter = (int) undoState["actionBase.localInvestCounter"];
        gameData.investments = (bool[]) undoState["gameData.investments"];
        gameData.investCounter = (int) undoState["gameData.investCounter"];
        gameData.productions = (int[]) undoState["gameData.productions"];
        gameData.productCounter = (int) undoState["gameData.productCounter"];

        ActionEvents.Instance.actionCanceled.Raise();
        undoController.Reset();
        DeActivate();
    }

    public bool CheckInvestmentsNeeded() {
        return (needInvestment && gameData.investCounter < needInvestCounter);
    }

    public void ChangeMaterial() {
        if (!gameObject.activeSelf || costDict == null) {
            return;
        }
        if (needInvestment) {
            if (CheckInvestmentsNeeded()) {
                actionActive = false;
                meshRenderer.material = passiveMaterial;
                return;
            }
            actionActive = true;
            meshRenderer.material = activeMaterial;
        }

        if (gameData.HasResources(costDict)) {
            actionActive = true;
            meshRenderer.material = activeMaterial;
        }
        else {
            actionActive = false;
            meshRenderer.material = passiveMaterial;
        }
    }

    public void CheckAllBenefitsUsed() {
        if (inProgress && gameData.actionInProgress) {
            if (actionType == SharedData.ActionType.Invest && localInvestCounter == nBenefit) {
                ActionEvents.Instance.allBenefitPlaced.Raise();
            }
            else if (gameData.productCounter == nBenefit) {
                ActionEvents.Instance.allBenefitPlaced.Raise();
            }
            else {
                ActionEvents.Instance.allBenefitNotPlaced.Raise();
            }
        }
    }

    public void StartToFlash() {
        if (inProgress && gameData.actionInProgress) {
            flashScript.StartFlash();
        }
    }
}
