using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsManager : MonoBehaviour
{
    public Text cultureText;
    public Text connectionsText;
    public Text sustainabilityText;
    public Text humanityText;

    // wealth

    public SharedData gameData;
    

    // Start is called before the first frame update
    void Start()
    {
        gameData.ResetStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (cultureText) {
            cultureText.text = gameData.culture.ToString();
        }
        if (connectionsText) {
            connectionsText.text = gameData.connections.ToString();
        }
        if (sustainabilityText) {
            sustainabilityText.text = gameData.sustainability.ToString();
        }
        if (humanityText) {
            humanityText.text = gameData.humanity.ToString();
        }
    }
}
