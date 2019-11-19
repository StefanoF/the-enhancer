using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Data", menuName = "SharedData", order = 1)]
public class SharedData : ScriptableObject {
    public enum ActionType {
        None, Goods, Job, Sensibilization, Conciliation, Star
    };

    public enum ResourceType {
        Culture, Connections, Sustainability, Humanity, Wealth, Stars
    };

    public ActionType lastActionType;

    // general stats
    public int culture; 
    public int connections; 
    public int sustainability; 
    public int humanity;
    public int wealth;
    public int wealthGoal; // to be setted

    public bool[] investments;
    public int investCounter;

    public int[] productions;
    public int productCounter;

    public int stars;
    public int totalStars;
    public int actions;


    public string helpText;
    public string hoverDescription;
    public string hoverInvestment;

    public bool actionInProgress;
    public float score;

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

        productions = new int[6];
        productCounter = 0;

        lastActionType = ActionType.None;

        helpText = "Click on a action box";
        hoverDescription = "";
        hoverInvestment = "";

        actionInProgress = false;
        score = 0f;
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

    // invest
    public bool InvestResource(ResourceType resourceType, int n, int localInvestCounter) {
        if (localInvestCounter >= n) {
            return false;
        }

        int nResType = (int) resourceType;

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

    // production
    public bool ProductResource(ResourceType resourceType, int n, bool withInvestment) {
        if (productCounter >= n) {
            return false;
        }

        int nResType = (int) resourceType;

        if (withInvestment) {
            if (!investments[nResType]) {
                return false;
            }
        }

        productions[nResType] += 1;
        productCounter++;
        
        return true;
    }

    public bool DeProductResource(ResourceType resourceType, int n, bool withInvestment) {
        int nResType = (int) resourceType;

        if (withInvestment) {
            if (!investments[nResType]) {
                return false;
            }
        }

        if (productions[nResType] == 0) {
            return false;
        }
        
        productions[nResType] -= 1;
        productCounter--;
        return true;
    }

    public void AddProductResources() {
        if (productions[0] > 0) {
            culture += productions[0];
        }
        if (productions[1] > 0) {
            connections += productions[1];
        }
        if (productions[2] > 0) {
            sustainability += productions[2];
        }
        if (productions[3] > 0) {
            humanity += productions[3];
        }
        if (productions[4] > 0) {
            wealth += productions[4];
        }
        if (productions[5] > 0) {
            stars += productions[5];
        }

        productions = new int[6];
        productCounter = 0;
    }

    public void CalculateScore() {
        if (actions == 0) {
            return;
        }
        float relativeScore = (100 * wealth) / actions;
        score = relativeScore + ((stars / totalStars) * relativeScore);
    }
}