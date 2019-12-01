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
    public Text helpText;

    public GameObject endGame;
    public SharedData gameData;

    public int[] lastResource;
    public bool[] isBlinkingResource;
    public int blinkingTimes;
    public float blinkingRatio;
    public Color redColor;
    public Color greenColor;
    private Color originalColor;

    public AudioMan audioMan;

    // Start is called before the first frame update
    void Start()
    {
        lastResource = new int[6];
        isBlinkingResource = new bool[6];
        gameData.ResetStats();
    }

    public void BlinkStat(int last, int actual, Text textObj, SharedData.ResourceType resourceType) {
        if (!isBlinkingResource[(int) resourceType]){
            originalColor = textObj.color;
            if (last > actual) {
                StartCoroutine(Blink(textObj, redColor, resourceType));
                isBlinkingResource[(int) resourceType] = true;
            } else if (last < actual) {
                StartCoroutine(Blink(textObj, greenColor, resourceType));
                isBlinkingResource[(int) resourceType] = true;
            }
        }
    }

    void BlinkStatUpdate(SharedData.ResourceType resourceType, bool isExecuted) {
        isBlinkingResource[(int) resourceType] = isExecuted;
        switch (resourceType) {
            case SharedData.ResourceType.Culture:
                lastResource[(int) resourceType] = gameData.culture;
                break;

            case SharedData.ResourceType.Connections:
                lastResource[(int) resourceType] = gameData.connections;
                break;

            case SharedData.ResourceType.Sustainability:
                lastResource[(int) resourceType] = gameData.sustainability;
                break;

            case SharedData.ResourceType.Humanity:
                lastResource[(int) resourceType] = gameData.humanity;
                break;

            case SharedData.ResourceType.Stars:
                lastResource[(int) resourceType] = gameData.stars;
                break;

            case SharedData.ResourceType.Wealth:
                lastResource[(int) resourceType] = gameData.wealth;
                break;

            default:
                return;
        }
        return;
    }

    IEnumerator Blink(Text obj, Color color, SharedData.ResourceType resourceType) {
        float countTimes = 0;
        while (countTimes < blinkingTimes) {
            obj.enabled = false;

            yield return new WaitForSeconds(blinkingRatio);
            obj.enabled = true;
            obj.color = color;

            yield return new WaitForSeconds(blinkingRatio);
            obj.enabled = false;

            yield return new WaitForSeconds(blinkingRatio);
            obj.enabled = true;
            obj.color = originalColor;

            countTimes++;
        }
        yield return null;
        BlinkStatUpdate(resourceType, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (wealthText) {
            wealthText.text = gameData.wealth.ToString() + "/" + gameData.wealthGoal;
            SharedData.ResourceType rWealth = SharedData.ResourceType.Wealth;
            BlinkStat(lastResource[(int) rWealth], gameData.wealth, wealthText, rWealth);
        }
        if (cultureText) {
            cultureText.text = gameData.culture.ToString();
            SharedData.ResourceType rCulture = SharedData.ResourceType.Culture;
            BlinkStat(lastResource[(int) rCulture], gameData.culture, cultureText, rCulture);
        }
        if (connectionsText) {
            connectionsText.text = gameData.connections.ToString();
            SharedData.ResourceType rConnections = SharedData.ResourceType.Connections;
            BlinkStat(lastResource[(int) rConnections], gameData.connections, connectionsText, rConnections);
        }
        if (sustainabilityText) {
            sustainabilityText.text = gameData.sustainability.ToString();
            SharedData.ResourceType rSustainability = SharedData.ResourceType.Sustainability;
            BlinkStat(lastResource[(int) rSustainability], gameData.sustainability, sustainabilityText, rSustainability);
        }
        if (humanityText) {
            humanityText.text = gameData.humanity.ToString();
            SharedData.ResourceType rHumanity = SharedData.ResourceType.Humanity;
            BlinkStat(lastResource[(int) rHumanity], gameData.humanity, humanityText, rHumanity);
        }
        if (starsText) {
            starsText.text = gameData.stars.ToString();
            SharedData.ResourceType rStars = SharedData.ResourceType.Stars;
            BlinkStat(lastResource[(int) rStars], gameData.stars, starsText, rStars);
        }
        if (actionsCounterText) {
            actionsCounterText.text = gameData.actions.ToString();
        }
        if (helpText) {
            helpText.text = gameData.helpText.ToString();
        }

        if (gameData.wealth >= gameData.wealthGoal) {
            audioMan.Victory();
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
