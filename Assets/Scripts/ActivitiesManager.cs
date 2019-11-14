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
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
