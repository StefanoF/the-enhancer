using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesManager : MonoBehaviour
{
    [Header("Prerequisites")]
    public GameObject[] activities;
    public Transform[] startPositions;

    [Header("In Game Features")]
    public int maxInGame;
    public int currentsInGame;

    [Header("Launch Activity")]
    public float timeFromStart;
    public float timeRatio;

    public GameScriptable gameData;

    void Awake() {
        // int posId;
        // for (int i = 0; i < activities.Length; i++) {
        //     posId = Random.Range(0, startPositions.Length);
        //     activities[i] = Instantiate(activities[i], startPositions[posId].position, Quaternion.identity) as GameObject;
        //     activities[i].transform.parent = gameObject.transform;
        // }
    }

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("LaunchActivity", timeFromStart, timeRatio);
    }

    // Update is called once per frame
    void Update()
    {
        // Eat, Sleep, ReadBook, Study, Play, UseSmartphone, WatchTV, Drink, Sport
        // GetNextActivity("", 2, "");
    }

    void GetNextActivity(string name, int n, string nextActivity) {
        if (gameData.activityDict.ContainsKey(name) && gameData.activityDict[name] > n) {
            ShowActivity(nextActivity);
        }
    }

    void ShowActivity(string activityName) {
        
    }

    // void LaunchActivity() {
    //     if (currentsInGame == maxInGame) {
    //         return;
    //     }

    //     int idx = Random.Range(0, activities.Length);
    //     if (!activities[idx]) {
    //         return;
    //     }
    //     Activity activityComponent;
    //     activityComponent = activities[idx].GetComponent<Activity>();
    //     if (!activityComponent.xMoving) {
    //         activityComponent.xMoving = true;
    //         currentsInGame++;
    //     }
    // }

    // private int FindNextEmptyIdx(GameObject[] arr) {
    //     for (int i = 0; i < arr.Length; i++) {
    //         if (arr[i] == null) {
    //             return i;
    //         }
    //     }
    //     return -1;
    // }

}
