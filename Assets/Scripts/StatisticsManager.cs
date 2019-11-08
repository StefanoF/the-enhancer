using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsManager : MonoBehaviour
{
    public Text lifeText;
    public Text intelligenceText;
    public Text socialText;
    public Text bodyText;

    public GameScriptable gameData;
    

    // Start is called before the first frame update
    void Start()
    {
        gameData.ResetStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeText) {
            lifeText.text = gameData.life.ToString();
        }
        if (intelligenceText) {
            intelligenceText.text = gameData.intelligence.ToString();
        }
        if (socialText) {
            socialText.text = gameData.social.ToString();
        }
        if (bodyText) {
            bodyText.text = gameData.body.ToString();
        }
    }
}
