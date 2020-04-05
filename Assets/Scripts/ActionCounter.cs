using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCounter : MonoBehaviour
{
    public GameObject benefitObj;
    public Vector3 spacing;
    public Vector3 spacingLeft;

    private Transform startPos;
    private GameObject[] benefitObjs;
    private GameObject[,] benefitPerResource;
    private ActionBase actionBase;

    void Start() {
        actionBase = gameObject.GetComponent<ActionBase>();
        startPos = benefitObj.GetComponent<Transform>();

        benefitObjs = new GameObject[actionBase.nBenefit];
        benefitObjs = GenerateBenefits(startPos, benefitObjs);
    }

    GameObject[] GenerateBenefits(Transform startPos, GameObject[] benefits) {
        for(int i = 0; i < actionBase.nBenefit; i++) {
            Vector3 pos = startPos.position;
            if (i >= 4) {
                pos = pos + spacingLeft + ((i%4) * spacing);
            }
            else {
                pos = pos + (i * spacing);
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
    }

    public void DeActivateBenefits() {
        for(int i = 0; i < actionBase.nBenefit; i++) {
            if (benefitObjs[i].activeSelf) {
                benefitObjs[i].SetActive(false);
            }
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
