using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionCounter : MonoBehaviour
{
    // array di oggetti alla quale mettere il benefitObj
    // ordinati come SharedData.ResourceType
    // Culture, Connections, Sustainability, Humanity, Wealth, Stars
    public GameObject[] resourceObjs;
    public GameObject benefitObj;
    public Vector3 spacing;
    public Vector3 spacingLeft;
    public Vector3 spacingBottomDefault;
    public Vector3 spacingBottom;
    public Vector3 spacingBottomDelta;

    private Transform startPos;
    private GameObject[] benefitObjs;
    private GameObject[,] benefitResourceObjs;
    private ActionBase actionBase;

    void Start() {
        actionBase = gameObject.GetComponent<ActionBase>();
        startPos = benefitObj.GetComponent<Transform>();

        benefitObjs = GenerateBenefits(startPos, actionBase.nBenefit, false);

        // prepare the benefits block on the bottom of each available resources in this action
        benefitResourceObjs = new GameObject[resourceObjs.Length,actionBase.nBenefit];
        for(int i = 0; i < resourceObjs.Length; i++) {
            GameObject[] generated = GenerateBenefits(resourceObjs[i].transform, actionBase.nBenefit, true);
            for(int g = 0; g < generated.Length; g++) {
                benefitResourceObjs[i,g] = generated[g];
            }
        }
    }

    public void ResetBenefits() {
        for(int i = 0; i < actionBase.gameData.investments.Length; i++) {
            if (actionBase.gameData.investments[i]) {
                benefitResourceObjs[i,0].SetActive(false);
            }
        }
    }

    GameObject[] GenerateBenefits(Transform initialPos, int size, bool bottom) {
        GameObject[] benefits = new GameObject[size];
        for(int i = 0; i < size; i++) {
            Vector3 pos = initialPos.position;
            if (bottom) {
                if (i % 2 == 0) {
                    pos = pos + spacingBottomDefault;
                }
                else {
                    pos = pos + spacingBottom;
                }
                pos = pos + ((i % size/2) * spacingBottomDelta);
            }
            else {
                if (i >= 4) {
                    pos = pos + spacingLeft + ((i%4) * spacing);
                }
                else {
                    pos = pos + (i * spacing);
                }
            }
            benefits[i] = Instantiate(benefitObj, pos, Quaternion.identity) as GameObject;
            benefits[i].transform.parent = gameObject.transform;
            benefits[i].SetActive(false);
        }

        return benefits;
    }

    public void ActivateBenefits() {
        int last = actionBase.nBenefit;
        if (actionBase.actionType == SharedData.ActionType.Invest) {
            if (actionBase.gameData.investCounter > 0) {
                last = actionBase.nBenefit - actionBase.gameData.investCounter;
            }
        }
        for(int i = 0; i < last; i++) {
            benefitObjs[i].SetActive(true);
        }

        if (!actionBase.gameData.actionInProgress && actionBase.actionType == SharedData.ActionType.Invest) {
            for(int i = 0; i < actionBase.gameData.investments.Length; i++) {
                if (actionBase.gameData.investments[i]) {
                    RemoveBenefit(i, true);
                }
            }
        }
    }

    public void DeActivateBenefits() {
        for(int i = 0; i < actionBase.nBenefit; i++) {
            if (benefitObjs[i].activeSelf) {
                benefitObjs[i].SetActive(false);
            }
        }

        for(int i = 0; i < resourceObjs.Length; i++) {
            for(int g = 0; g < actionBase.nBenefit; g++) {
                benefitResourceObjs[i,g].SetActive(false);
            }
        }
    }

    
    public void AddBenefit(int resourceType) {
        for(int i = actionBase.nBenefit - 1; i >= 0; i--) {
            if (benefitResourceObjs[resourceType,i].activeSelf) {
                benefitResourceObjs[resourceType,i].SetActive(false);
                break;
            }
        }

        for(int i = 0; i < actionBase.nBenefit; i++) {
            if (!benefitObjs[i].activeSelf) {
                benefitObjs[i].SetActive(true);
                return;
            }
        }
    }

    public void RemoveBenefit(int resourceType, bool single = false) {
        if (single && !benefitResourceObjs[resourceType,0].activeSelf) {
            benefitResourceObjs[resourceType,0].SetActive(true);
        }
        else {
            for(int i = 0; i < actionBase.nBenefit; i++) {
                if (!benefitResourceObjs[resourceType,i].activeSelf) {
                    benefitResourceObjs[resourceType,i].SetActive(true);
                    break;
                }
            }
        }
        

        for(int i = actionBase.nBenefit - 1; i >= 0; i--) {
            if (benefitObjs[i].activeSelf) {
                benefitObjs[i].SetActive(false);
                return;
            }
        }
    }
}
