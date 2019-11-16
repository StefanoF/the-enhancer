using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegacyAction : MonoBehaviour
{
    // private ParabolaController pbController;

    // [Header("Stats data")]
    // public SharedData.ActionType actionType;
    // public SharedData gameData;

    // [Header("Actions")]
    // public int actionIn;
    // public int totalActionIn;
    // public int minActions;
    // public int maxActions;
    // private Text hoverActionsText;

    // [Header("Consume Hours")]
    // public float consumeRateTime;
    // public float consumeHoursTimer;

    // void Awake()
    // {
    //     pbController = gameObject.GetComponent<ParabolaController>();
    //     hoverActionsText = GameObject.Find("/UI/HoverHours").GetComponent<Text>();
    // }

    // // Start is called before the first frame update
    // void Start()
    // {

    // }

    
    // // Update is called once per frame
    // void Update()
    // {
    //     ConsumeHours();
    // }

    // void IncrementDecrementActions() {
    //     if (Input.GetMouseButtonDown(0)) {
    //         if (actionIn < maxActions && gameData.remainingHours > 0) {
    //             actionIn++;
    //             totalActionIn++;
    //             gameData.remainingHours--;
    //             pbController.StartAnim();
    //         }
    //     }
    //     else if (Input.GetMouseButtonDown(1)) {
    //         if (actionIn > minActions) {
    //             actionIn--;
    //             totalActionIn--;
    //             gameData.remainingHours++;
    //         }
    //     }
    // }

    // void ConsumeHours() {
    //     if (actionIn > 0) {
    //         consumeHoursTimer += Time.deltaTime;
    //         if (consumeHoursTimer > consumeRateTime) {
    //             print(actionType.ToString() + "consumed!");
    //             consumeHoursTimer = 0;
    //             actionIn--;
    //             gameData.AddActivity(actionType.ToString(), 1);
    //         }
    //     }
    // }
}




    // activity stats
    // public Dictionary <string, int> activityDict = new Dictionary<string, int>();

    // public void AddActivity(string name, int value) {
    //     if (activityDict.ContainsKey(name)) {
    //         activityDict[name] = activityDict[name] + value;  
    //     }
    //     else {
    //         activityDict.Add(name, value);
    //     }

    //     ConsoleOutput();
    //     life = CalculateStat(GetLifeActivities());
    //     intelligence = CalculateStat(GetIntelligenceActivities());
    //     social = CalculateStat(GetSocialActivities());
    //     body = CalculateStat(GetBodyActivities());
    // }

    // // TODO
    // private void ConsoleOutput()
    // {
    //     foreach(var kvp in activityDict)
    //     {
    //         // Debug.Log(kvp.Key + ": " + kvp.Value);
    //     }
    // }

    // public Dictionary<string, int> GetLifeActivities() {
    //     return activityDict.Where(pair => pair.Key == "Eat" || pair.Key == "Sleep" || pair.Key == "Drink")
    //         .ToDictionary(pair => pair.Key, pair => pair.Value);
    // }

    // public Dictionary<string, int> GetIntelligenceActivities() {
    //     return activityDict.Where(pair => pair.Key == "Sleep" || pair.Key == "Study" || pair.Key == "ReadBook")
    //         .ToDictionary(pair => pair.Key, pair => pair.Value);
    // }

    // public Dictionary<string, int> GetSocialActivities() {
    //     return activityDict.Where(pair => pair.Key == "Play" || pair.Key == "Sport" || pair.Key == "Study")
    //         .ToDictionary(pair => pair.Key, pair => pair.Value);
    // }

    // public Dictionary<string, int> GetBodyActivities() {
    //     return activityDict.Where(pair => pair.Key == "Eat" || pair.Key == "Sport" || pair.Key == "Drink")
    //         .ToDictionary(pair => pair.Key, pair => pair.Value);
    // }

    // public int CalculateStat(Dictionary<string, int> filtered) {
    //     int sum = filtered.Sum(x => x.Value);
    //     int count = filtered.Count();
    //     if (count > 0)
    //         return sum / count;
        
    //     return sum;
    // }