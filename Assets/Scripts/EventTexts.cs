using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTexts : MonoBehaviour
{
    public Text text;

    public string[] OneActionAtTime;
    public string[] ActionCanceled;
    public string[] InvestComplete;
    public string[] InvestStarted;
    public string[] NeedCorrectInvestment;
    public string[] NeedToInvest;
    public string[] NotEnoughResources;
    public string[] ProductionComplete;
    public string[] ProductionStarted;
    public string[] SameActionTwice;
    public string[] UseAllBenefits;
    public string[] ResourceInvest;
    public string[] ResourceDeInvest;
    public string[] ResourceProduct;
    public string[] ResourceDeProduct;

    public void ResourceText(string key) {
        text.text = I18n.Fields[key] + " " + I18n.Fields[ResourceEvents.Instance.actualResourceType.ToString().ToLower()];
    }
    
    public void RandomIn(string eventName) {
        string[] selectedTexts = (string[]) this.GetType().GetField(eventName).GetValue(this);
        string selectedKey = selectedTexts[Random.Range(0, selectedTexts.Length)];
        text.text = I18n.Fields[selectedKey];
    }
}