using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activity : MonoBehaviour
{
    // private ParabolaController pbController;

    [Header("Stats data")]
    public GameScriptable.ActivityType activity;
    public GameScriptable gameData;

    [Header("Hours")]
    public int hourIn;
    public int totalHourIn;
    public int minHours;
    public int maxHours;
    private Text hoverHoursText;

    [Header("Consume Hours")]
    public float consumeRateTime;
    public float consumeHoursTimer;

    [Header("Evolution")]
    public GameObject evolutionObj;

    [Header("Costs")]
    public int cCulture;
    public int cConnections;
    public int cSustainability;
    public int cHumanity;
    public int cActions;

    [Header("Benefits")]
    public int bCulture;
    public int bConnections;
    public int bSustainability;
    public int bHumanity;
    public int bActions;

    [Header("Hour Bar")]
    public Image hourBar;
    public float hourBarSpeed;
    public float calculated = 0f;
    public float lastAmount;
    private float t;

    void Awake()
    {
        // pbController = gameObject.GetComponent<ParabolaController>();
        hoverHoursText = GameObject.Find("/UI/HoverHours").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        hourBar.fillAmount = 0f;
    }

    
    // Update is called once per frame
    void Update()
    {
        UpdateHourBar();
        ConsumeHours();
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            if (hourIn < maxHours && gameData.remainingHours > 0) {
                hourIn++;
                totalHourIn++;
                gameData.remainingHours--;
                // pbController.StartAnim();
            }
        }
        else if (Input.GetMouseButtonDown(1)) {
            if (hourIn > minHours) {
                hourIn--;
                totalHourIn--;
                gameData.remainingHours++;
            }
        }

        hoverHoursText.text = hourIn.ToString() + activity.ToString();
    }

    void OnMouseExit() {
        hoverHoursText.text = "";
    }

    void ConsumeHours() {
        if (hourIn > 0) {
            consumeHoursTimer += Time.deltaTime;
            if (consumeHoursTimer > consumeRateTime) {
                print(activity.ToString() + "consumed!");
                consumeHoursTimer = 0;
                hourIn--;

                // gameData.AddActivity(activity.ToString(), 1);
            }
        }
    }

    void UpdateHourBar() {
        calculated = (float) hourIn / maxHours;

        if (calculated != lastAmount) {
            // hourBar.fillAmount = Mathf.Lerp(lastAmount, calculated, t);
            hourBar.fillAmount = calculated;
            // t += Time.deltaTime * hourBarSpeed;
        }

        if (hourBar.fillAmount == calculated) {
            // t = 0f;
            lastAmount = calculated;
        }
    }
}
