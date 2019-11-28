using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCounter : MonoBehaviour
{
    public GameObject benefitObj;
    public Vector3 spacing;
    private Transform startPos;
    private GameObject[] benefitObjs;
    private ActionBase actionBase;

    void Start() {
        actionBase = gameObject.GetComponent<ActionBase>();
        startPos = benefitObj.GetComponent<Transform>();

        benefitObjs = new GameObject[actionBase.nBenefit];
        for(int i = 0; i < actionBase.nBenefit; i++) {
            Vector3 pos = startPos.position + (i * spacing);
            benefitObjs[i] = Instantiate(benefitObj, pos, Quaternion.identity) as GameObject;
            benefitObjs[i].transform.parent = gameObject.transform;
            benefitObjs[i].SetActive(false);
        }
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
    }

    public void AddBenefit() {
        for(int i = 0; i < actionBase.nBenefit; i++) {
            if (!benefitObjs[i].activeSelf) {
                benefitObjs[i].SetActive(true);
                return;
            }
        }
    }

    public void RemoveBenefit() {
        for(int i = actionBase.nBenefit - 1; i >= 0; i--) {
            if (benefitObjs[i].activeSelf) {
                benefitObjs[i].SetActive(false);
                return;
            }
        }
    }
}
