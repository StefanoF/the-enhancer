using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSel : MonoBehaviour
{
    public ActionInvest actionInvest;
    public ActionProduction actionProduction;
    // public ActionChoose actionChoose;

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
        if (actionInvest) {
            Invest();
            HighlightResource();
        }
        else if (actionProduction) {
            Production();
        }
        // else if (actionChoose) {
        //     Choose();
        // }
        else {
            return;
        }    
    }

    void Invest() {
        if (gameData.InvestResource(resourceType, actionInvest.nBenefit)) {
        }
        else {
            gameData.DisinvestResource(resourceType, actionInvest.nBenefit);
        }
    }

    void Production() {
        if (gameData.ProductResource(resourceType, actionProduction.nBenefit)) {
            gameData.helpText = "+1 "+ resourceType.ToString() + "(" + gameData.productions[(int) resourceType] + ")";
        }
        else if (gameData.DeProductResource(resourceType, actionProduction.nBenefit)) {
            gameData.helpText = "-1 "+ resourceType.ToString() + "(" + gameData.productions[(int) resourceType] + ")";
        }
    }
}
