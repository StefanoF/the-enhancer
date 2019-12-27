using UnityEngine;

[CreateAssetMenu(fileName = "ActionData", menuName = "SharedData/ActionData", order = 1)]
public class ActionData : ScriptableObject {
    public bool doTwice;
    public int benefits;
    public int benefitsUsed;
    public string uniqueName;
}