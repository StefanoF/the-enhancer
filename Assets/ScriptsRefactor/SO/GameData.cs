using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace TheEnhancer {
    [CreateAssetMenu (fileName = "GameData", menuName = "ManagersData/GameData", order = 1)]
    public class GameData : ScriptableObject {
        public Vector3 currentActionPos;
        public ActionType lastActionType;
        public int lastActionLevel;
        public enum ActionType {
            Conciliation,
            Goods,
            Invest,
            Sensibilization,
            Bonus
        }

        public enum ResourceType {
            Connections,
            Culture,
            Humanity,
            Sustainability,
            Wealth,
            Stars
        }

        public string lastActionName;

        // general stats
        public Dictionary<string, int> resources;
        public int wealthGoal; // to be setted

        public bool[] investments;
        public int investCounter;

        public int[] productions;
        public int productCounter;
        public int totalStars;
        public int actions;

        public string helpText;

        public bool actionInProgress;
        public float score;

        public bool inPlane;

        public string currentLang;

        public bool pause;

        public void ResetStats () {
            pause = false;
            inPlane = false;

            foreach(string r in Enum.GetNames(typeof(ResourceType))) {
                resources[r] = 0;
            }

            actions = 0;

            investments = new bool[4];
            investCounter = 0;

            productions = new int[6];
            productCounter = 0;

            lastActionName = "";

            helpText = "The goal is to reach " + wealthGoal.ToString () + " of wealth (see the stats upward).\nClick on a action box to start!";

            actionInProgress = false;
            score = 0f;
        }

        public bool IsWealthAchieved() {
            return (resources[ResourceType.Wealth.ToString()] >= wealthGoal);
        }

        public bool IsLastAction(ActionData actionData) {
            return (actionData.actionType == lastActionType && actionData.level == lastActionLevel); 
        }

        public bool HasResources (ResourceAmount[] costs) {
            int results = 0;
            foreach (ResourceAmount cost in costs) {
                if (resources[cost.resource.ToString()] <= cost.value) {
                    results++;
                }
            }
            return results == costs.Length;
        }

        public void SpendResources (ResourceAmount[] costs) {
            if (HasResources(costs)) {
                foreach (ResourceAmount cost in costs) {
                    resources[cost.resource.ToString()] -= cost.value;
                }
            }
        }

        // invest
        // public bool InvestResource (ResourceType resourceType, int n, int localInvestCounter) {
        //     if (localInvestCounter >= n) {
        //         return false;
        //     }

        //     int nResType = (int) resourceType;

        //     if (!investments[nResType]) {
        //         investments[nResType] = true;
        //         investCounter++;
        //     } else {
        //         return false;
        //     }

        //     return true;
        // }

        // public bool DisinvestResource (ResourceType resourceType, int n) {
        //     int nResType = (int) resourceType;

        //     if (investments[nResType]) {
        //         investments[nResType] = false;
        //         investCounter--;
        //     } else {
        //         return false;
        //     }

        //     return true;
        // }

        // // production
        // public bool ProductResource (ResourceType resourceType, int n, bool withInvestment) {
        //     if (productCounter >= n) {
        //         return false;
        //     }

        //     int nResType = (int) resourceType;

        //     if (withInvestment) {
        //         if (!investments[nResType]) {
        //             return false;
        //         }
        //     }

        //     productions[nResType] += 1;
        //     productCounter++;

        //     return true;
        // }

        // public bool DeProductResource (ResourceType resourceType, int n, bool withInvestment) {
        //     int nResType = (int) resourceType;

        //     if (withInvestment) {
        //         if (!investments[nResType]) {
        //             return false;
        //         }
        //     }

        //     if (productions[nResType] == 0) {
        //         return false;
        //     }

        //     productions[nResType] -= 1;
        //     productCounter--;
        //     return true;
        // }

        // public void AddProductResources () {
        //     if (productions[0] > 0) {
        //         culture += productions[0];
        //     }
        //     if (productions[1] > 0) {
        //         connections += productions[1];
        //     }
        //     if (productions[2] > 0) {
        //         sustainability += productions[2];
        //     }
        //     if (productions[3] > 0) {
        //         humanity += productions[3];
        //     }
        //     if (productions[4] > 0) {
        //         wealth += productions[4];
        //     }
        //     if (productions[5] > 0) {
        //         stars += productions[5];
        //     }

        //     productions = new int[6];
        //     productCounter = 0;
        // }

        public void CalculateScore () {
            if (actions == 0) {
                score = 0f;
                return;
            }
            int wealth = resources[ResourceType.Wealth.ToString()];
            int stars = resources[ResourceType.Stars.ToString()];
            score = ((wealth * 100) + (stars * 100)) / actions;
        }
    }
}