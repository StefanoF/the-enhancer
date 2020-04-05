using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSel : MonoBehaviour
{
    public ActionBase actionBase;
    public ActionCounter actionCounter;

    public SharedData gameData;
    public SharedData.ResourceType resourceType;

    public Material activeMaterial;
    public Material passiveMaterial;

    public MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    void Awake()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    public void HighlightResource() {
        if (!meshRenderer) {
            return;
        }

        if (actionBase.actionType == SharedData.ActionType.Conciliation ||
            actionBase.actionType == SharedData.ActionType.Sensibilization ||
            actionBase.actionType == SharedData.ActionType.Star) {
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
        if (Input.GetMouseButtonDown(0)) {
            // left mouse button click
            LeftMouseClick();
        }
        else if (Input.GetMouseButtonDown(1)) {
            // right mouse button click
            RightMouseClick();
        }
    }

    void LeftMouseClick() {
        if (actionBase.actionType == SharedData.ActionType.Invest) {
            if (gameData.investments[(int) resourceType]) {
                DeInvest();
            }
            else {
                Invest();
            }
            
            HighlightResource();
        }
        else if (actionBase.actionType == SharedData.ActionType.Goods ||
            actionBase.actionType == SharedData.ActionType.Sensibilization ||
            actionBase.actionType == SharedData.ActionType.Conciliation ||
            actionBase.actionType == SharedData.ActionType.Star) 
        {
            Production(actionBase.needInvestment);
        }
        else {
            return;
        }
    }

    void RightMouseClick() {
        if (actionBase.actionType == SharedData.ActionType.Goods ||
            actionBase.actionType == SharedData.ActionType.Sensibilization ||
            actionBase.actionType == SharedData.ActionType.Conciliation ||
            actionBase.actionType == SharedData.ActionType.Star) 
        {
            DeProduction(actionBase.needInvestment);
        }
        else {
            return;
        }
    }

    void Invest() {
        if (gameData.InvestResource(resourceType, actionBase.nBenefit, actionBase.localInvestCounter)) {
            actionBase.localInvestCounter++;
            actionCounter.RemoveBenefit();

            ResourceEvents.Instance.actualResourceType = resourceType;
            ResourceEvents.Instance.invest.Raise();
        }
    }

    void DeInvest() {
        if (gameData.DisinvestResource(resourceType, actionBase.nBenefit)) {
            actionBase.localInvestCounter--;
            actionCounter.AddBenefit();

            ResourceEvents.Instance.actualResourceType = resourceType;
            ResourceEvents.Instance.deInvest.Raise();
        }
    }

    void Production(bool withInvestments) {
        if (gameData.ProductResource(resourceType, actionBase.nBenefit, withInvestments)) {
            actionCounter.RemoveBenefit();

            ResourceEvents.Instance.actualResourceType = resourceType;
            ResourceEvents.Instance.product.Raise();
        }
    }

    void DeProduction(bool withInvestments) {
        if (gameData.DeProductResource(resourceType, actionBase.nBenefit, withInvestments)) {
            actionCounter.AddBenefit();

            ResourceEvents.Instance.actualResourceType = resourceType;
            ResourceEvents.Instance.deProduct.Raise();
        }
    }

    public void EnableCollider() {
        if (boxCollider != null)
            boxCollider.enabled = true;
    }

    public void DisableCollider() {
        if (boxCollider != null)
            boxCollider.enabled = false;
    }
}
