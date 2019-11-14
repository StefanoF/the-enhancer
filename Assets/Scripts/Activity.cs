using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activity : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 moveVector;
    private ParabolaController pbController;

    [Header("UpDown Movement")]
    public float moveRange;
    public float moveSpeed;
    private float timeMovement;

    [Header("Right Movement")]
    public float xMoveSpeed;
    public float xMoveLimit;
    public bool xMoving;
    public ActivitiesManager activitiesManager;

    [Header("Stats data")]
    public GameScriptable.ActivityType activity;
    public GameScriptable gameData;

    [Header("Hours")]
    public int hourIn;
    public int totalHourIn;
    public int minHours;
    public int maxHours;
    private Text hoverHoursText;
    public float consumeRateTime;
    public float consumeHoursTimer;

    [Header("Hour Bar")]
    public Image hourBar;
    public float hourBarSpeed;
    public float calculated = 0f;
    public float lastAmount;
    private float t;

    void Awake()
    {
        pbController = gameObject.GetComponent<ParabolaController>();
        hoverHoursText = GameObject.Find("/UI/HoverHours").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        activitiesManager = gameObject.GetComponentInParent<ActivitiesManager>();
        startPosition = transform.position;
        moveVector = Vector3.up;
        hourBar.fillAmount = 0f;
    }

    
    // Update is called once per frame
    void Update()
    {
        UpdateHourBar();
        UpdatePosition();
        ConsumeHours();
    }
    
    void UpdatePosition() {
        if (xMoving) {
            if (transform.position.x < xMoveLimit) {
                transform.Translate(Vector3.right * Time.deltaTime * xMoveSpeed);
            }
            else {
                xMoving = false;
                transform.position = startPosition;
                activitiesManager.currentsInGame--;
            }
        }
    }

    void OnMouseOver() {
        // animated block
        timeMovement += Time.deltaTime;
        transform.position = transform.position + moveVector * (moveRange * Mathf.Sin(timeMovement * moveSpeed));

        if (Input.GetMouseButtonDown(0)) {
            if (hourIn < maxHours && gameData.remainingHours > 0) {
                hourIn++;
                totalHourIn++;
                gameData.remainingHours--;
                pbController.StartAnim();
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
        Vector3 exitPos = transform.position;
        exitPos.y = startPosition.y;
        transform.position = exitPos;
        hoverHoursText.text = "";
    }

    void ConsumeHours() {
        if (hourIn > 0) {
            consumeHoursTimer += Time.deltaTime;
            if (consumeHoursTimer > consumeRateTime) {
                print(activity.ToString() + "consumed!");
                consumeHoursTimer = 0;
                hourIn--;
                gameData.AddActivity(activity.ToString(), 1);
            }
        }
    }

    void UpdateHourBar() {
        calculated = (float) hourIn / maxHours;

        if (calculated != lastAmount) {
            hourBar.fillAmount = Mathf.Lerp(lastAmount, calculated, t);
            t += Time.deltaTime * hourBarSpeed;
        }

        if (hourBar.fillAmount == calculated) {
            t = 0f;
            lastAmount = calculated;
        }
    }
}
