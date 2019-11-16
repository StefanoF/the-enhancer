using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionInvest : MonoBehaviour
{
    [Header("Stats data")]
    public SharedData gameData;
    public SharedData.ActionType actionType;

    private Text hoverActionsText;
    
    [Header("Costs")]
    public int culture;
    public int connections;
    private Dictionary<string, int> costDict;
    
    [Header("Cost Texts")]
    private Text cultureText;
    private Text connectionsText;

    [Header("Benefits")]
    public int nBenefit;
    private Text benefitText;

    private Dictionary<string, int> investDict;

    [Header("Resources")]
    public GameObject resources;

    void Awake()
    {
        hoverActionsText = GameObject.Find("/UI/HoverHours").GetComponent<Text>();
    }


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
        hoverActionsText.text = "";
    }

    void OnMouseOver() {
        hoverActionsText.text = actionType.ToString();

        if (Input.GetMouseButtonDown(0)) {
            // left mouse button click
            LeftMouseClick();
        }
    }

    public void CommitAction() {
        print("actionInvest CommitAction");
        gameData.lastActionType = actionType;
        gameData.SpendResources(costDict);
        gameData.actions++;
    }

    void LeftMouseClick() {
        if (resources.activeSelf) {
            resources.SetActive(false);
            return;
        }
        
        print("actionInvest click");
        if (gameData.lastActionType == actionType) {
            print("Same action executed!");
            return;
        }

        if (!gameData.HasResources(costDict)) {
            print("No sufficently resources!");
            return;
        }
        resources.SetActive(true);
    }
}
