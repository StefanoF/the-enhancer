using UnityEngine;

[CreateAssetMenu(fileName = "StatsData", menuName = "SharedData/StatsData", order = 1)]
public class StatsData : ScriptableObject {
    public int culture;
    public int connections;
    public int sustainability;
    public int humanity;
    public int wealth;
    public int stars;

    public int actions;

    public bool HasEnough(StatsData costs) {
        return culture >= costs.culture && 
            connections >= costs.connections && 
            sustainability >= costs.sustainability && 
            humanity >= costs.humanity && 
            wealth >= costs.wealth && 
            stars >= costs.stars;
    }

    public void Spend(StatsData costs) {
        culture -= costs.culture;
        connections -= costs.connections;
        sustainability -= costs.sustainability;
        humanity -= costs.humanity;
        wealth -= costs.wealth;
        stars -= costs.stars;
    }

    // public int Sum() {
    //     return culture + connections + sustainability + humanity + wealth + stars;
    // }
}