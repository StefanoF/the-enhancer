using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSel : MonoBehaviour
{
    public ActionBase actionBase;

    public SharedData gameData;
    public SharedData.ResourceType resourceType;

    public Material activeMaterial;
    public Material passiveMaterial;

    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        print("resourceSel start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HighlightResource() {
        if (actionBase.actionType == SharedData.ActionType.Conciliation) {
            meshRenderer.material = activeMaterial;
            return;
        }

        if (actionBase.actionType == SharedData.ActionType.Sensibilization) {
            meshRenderer.material = activeMaterial;
            return;
        }

        if (gameData.investments[(int) resourceType]) {
            meshRenderer.material = activeMaterial;
        }
        else {
            meshRenderer.material = passiveMaterial;
        }
    }

    void OnMouseOver() {
        print("resource OnMouseOver");
        if (Input.GetMouseButtonDown(0)) {
            // left mouse button click
            LeftMouseClick();
        }
        else if (Input.GetMouseButtonDown(1)) {
            // right mouse button click
            // RightMouseClick();
        }
    }

    void LeftMouseClick() {
        print("resource click");
        if (actionBase.actionType == SharedData.ActionType.Job) {
            Invest();
            HighlightResource();
        }
        else if (actionBase.actionType == SharedData.ActionType.Goods) {
            Production(true);
        }
        else if (actionBase.actionType == SharedData.ActionType.Sensibilization) {
            Production(false);
        }
        else if (actionBase.actionType == SharedData.ActionType.Conciliation) {
            Production(false);
        }
        else {
            return;
        }    
    }

    void Invest() {
        if (gameData.InvestResource(resourceType, actionBase.nBenefit)) {
        }
        else {
            gameData.DisinvestResource(resourceType, actionBase.nBenefit);
        }
    }

    void Production(bool withInvestments) {
        if (gameData.ProductResource(resourceType, actionBase.nBenefit, withInvestments)) {
            gameData.helpText = "+1 "+ resourceType.ToString() + "(" + gameData.productions[(int) resourceType] + ")";
        }
        else if (gameData.DeProductResource(resourceType, actionBase.nBenefit, withInvestments)) {
            gameData.helpText = "-1 "+ resourceType.ToString() + "(" + gameData.productions[(int) resourceType] + ")";
        }
    }
}
