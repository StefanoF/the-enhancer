using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsManager : MonoBehaviour
{
    [Header("ResourcesText")]
    public Text wealthText;
    public Text cultureText;
    public Text connectionsText;
    public Text sustainabilityText;
    public Text humanityText;
    public Text starsText;

    [Header("ResourcesBack")]
    public Image cultureBack;
    public Image connectionsBack;
    public Image sustainabilityBack;
    public Image humanityBack;
    public Color highlightBackColor;
    public Color defaultBackColor;

    [Header("UI Text")]
    public Text actionsCounterText;
    public Text hoverDescriptorText;
    public Text hoverInvestmentText;
    public Text helpText;

    public GameObject endGame;
    public SharedData gameData;

    // public float blinkingTime;
    // public Color redColor;
    // public Color greenColor;
    // private Color originalColor;
    

    // Start is called before the first frame update
    void Start()
    {
        gameData.ResetStats();
    }

    // public void BlinkStat(int last, int actual, Text textObj) {
    //     originalColor = textObj.color;
    //     if (last > actual) {
    //         StartCoroutine(Blink(textObj, redColor));
    //     } else if (actual > last) {
    //         StartCoroutine(Blink(textObj, greenColor));
    //     }
    // }

    // IEnumerator Blink(Text obj, Color color) {
    //     obj.enabled = false;
    //     obj.color = color;
    //     yield return new WaitForSeconds(0.2f);
    //     obj.enabled = true;

    //     yield return new WaitForSeconds(0.2f);
    //     obj.color = originalColor;

    //     yield return null;
    // }

    // Update is called once per frame
    void Update()
    {
        if (wealthText) {
            wealthText.text = gameData.wealth.ToString();
            // BlinkStat(0, gameData.wealth, wealthText);
        }
        if (cultureText) {
            cultureText.text = gameData.culture.ToString();
        }
        if (connectionsText) {
            connectionsText.text = gameData.connections.ToString();
        }
        if (sustainabilityText) {
            sustainabilityText.text = gameData.sustainability.ToString();
        }
        if (humanityText) {
            humanityText.text = gameData.humanity.ToString();
        }
        if (starsText) {
            starsText.text = gameData.stars.ToString();
        }
        if (actionsCounterText) {
            actionsCounterText.text = gameData.actions.ToString();
        }
        if (hoverDescriptorText) {
            hoverDescriptorText.text = gameData.hoverDescription.ToString();
        }
        if (hoverInvestmentText) {
            hoverInvestmentText.text = gameData.hoverInvestment.ToString();
        }
        if (helpText) {
            helpText.text = gameData.helpText.ToString();
        }

        if (gameData.wealth >= gameData.wealthGoal) {
            gameData.CalculateScore();
            endGame.SetActive(true);
            gameObject.SetActive(false);
        }

        HighlightInvested();
    }

    void HighlightInvested() {
        if (gameData.investments[0]) {
            cultureBack.color = highlightBackColor;
        }
        else {
            cultureBack.color = defaultBackColor;
        }
        if (gameData.investments[1]) {
            connectionsBack.color = highlightBackColor;
        }
        else {
            connectionsBack.color = defaultBackColor;
        }
        if (gameData.investments[2]) {
            sustainabilityBack.color = highlightBackColor;
        }
        else {
            sustainabilityBack.color = defaultBackColor;
        }
        if (gameData.investments[3]) {
            humanityBack.color = highlightBackColor;
        }
        else {
            humanityBack.color = defaultBackColor;
        }
    }
}
