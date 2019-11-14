using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Data", menuName = "GameScriptable", order = 1)]
public class GameScriptable : ScriptableObject {
    public enum ActivityType {
        JobExtra, NoConflictExtra, GoodAccessExtra, SensibilizationExtra,
        Job, Job1, Job2, 
        NoConflict, NoConflict1, NoConflict2, 
        GoodAccess, GoodAccess1, GoodAccess2, 
        Sensibilization, Sensibilization1, Sensibilization2
    };
    
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

    // general stats
    public int culture; 
    public int connections; 
    public int sustainability; 
    public int humanity;
    public int actions;
    
    public int remainingActions;

    public void ResetStats() {
        culture = 0; 
        connections = 0; 
        sustainability = 0; 
        humanity = 0;
    }

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

    public int currentHour;
    public int dayHours;

    public int remainingHours;
}