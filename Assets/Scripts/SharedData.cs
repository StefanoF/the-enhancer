using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Data", menuName = "SharedData", order = 1)]
public class SharedData : ScriptableObject {
    public enum ActionType {
        None, Goods, Job, Spread, Conciliaton
    };

    public enum ResourceType {
        Culture, Connections, Sustainability, Humanity
    };

    public ActionType lastActionType;

    // general stats
    public int culture; 
    public int connections; 
    public int sustainability; 
    public int humanity;
    public int wealth;

    public bool[] investments;
    public int investCounter;

    public int stars;
    public int actions;
    
    public int currentHour;
    public int dayHours;

    public void ResetStats() {
        culture = 0; 
        connections = 0; 
        sustainability = 0; 
        humanity = 0;
        wealth = 0;
        stars = 0;
        actions = 0;

        investments = new bool[4];
        investCounter = 0;

        lastActionType = ActionType.None;
    }

    public bool HasResources(Dictionary<string, int> costDict) {
        int results = 0;
        foreach(KeyValuePair<string, int> cost in costDict) {
            if (cost.Key == "culture" && culture >= cost.Value) {
                results++;
            }
            else if (cost.Key == "connections" && connections >= cost.Value) {
                results++;
            }
            else if (cost.Key == "sustainability" && sustainability >= cost.Value) {
                results++;
            }
            else if (cost.Key == "humanity" && humanity >= cost.Value) {
                results++;
            }
            else if (cost.Key == "wealth" && wealth >= cost.Value) {
                results++;
            }
            else {
                results--;
            }
        }
        return results == costDict.Count;
    }

    public void SpendResources(Dictionary<string, int> costDict) {
        foreach(KeyValuePair<string, int> cost in costDict){
            if (cost.Key == "culture") {
                culture -= cost.Value;
            }
            else if (cost.Key == "connections") {
                connections -= cost.Value;
            }
            else if (cost.Key == "sustainability") {
                sustainability -= cost.Value;
            }
            else if (cost.Key == "humanity") {
                humanity -= cost.Value;
            }
            else if (cost.Key == "wealth") {
                wealth -= cost.Value;
            }
        }
    }

    public bool InvestResource(ResourceType resourceType, int n) {
        if (investCounter >= n) {
            return false;
        }

        int nResType = (int) resourceType;
        Debug.Log(nResType);

        if (!investments[nResType]) {
            investments[nResType] = true;
            investCounter++;
        }
        else {
            return false;
        }
        
        return true;
    }

    public bool DisinvestResource(ResourceType resourceType, int n) {
        int nResType = (int) resourceType;

        if (investments[nResType]) {
            investments[nResType] = false;
            investCounter--;
        }
        else {
            return false;
        }
        
        return true;
    }
}