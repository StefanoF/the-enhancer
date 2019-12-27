using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "SharedData/GameData", order = 1)]
public class GameData : ScriptableObject {
    public bool actionInProgress;
    public string lastActionName;
}