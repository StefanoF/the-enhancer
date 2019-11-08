using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activity : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 moveVector;
    private ParabolaController pbController;

    [Header("Activity Movement")]
    public float moveRange;
    public float moveSpeed;

    [Header("Stats data")]
    public GameScriptable.ActivityType activity;
    public GameScriptable gameData;

    [Header("Hours")]
    public int hourIn; 
    public int minHours;
    public int maxHours;

    [Header("Hour Bar")]
    public Image hourBar;
    public float hourBarSpeed;

    void Awake()
    {
        pbController = gameObject.GetComponent<ParabolaController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        moveVector = Vector3.up;
        hourBar.fillAmount = 0f;
    }

    
    // Update is called once per frame
    void Update()
    {
        UpdateHourBar();
    }

    private float timeMovement;
    void OnMouseOver() {
        // animated block
        timeMovement += Time.deltaTime;
        transform.position = startPosition + moveVector * (moveRange * Mathf.Sin(timeMovement * moveSpeed));

        if (Input.GetMouseButtonDown(0)) {
            if (hourIn < maxHours && gameData.remainingHours > 0) {
                hourIn++;
                gameData.AddActivity(activity.ToString(), 1);
                pbController.StartAnim();
            }
        }
        else if (Input.GetMouseButtonDown(1)) {
            if (hourIn > minHours) {
                hourIn--;
                gameData.remainingHours++;
            }
        }
    }

    void OnMouseExit() {
        transform.position = startPosition;
    }

    public float calculated = 0f;
    public float lastAmount;
    private float t;
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
