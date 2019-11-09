using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HourManager : MonoBehaviour
{
    public GameScriptable gameData;
    public Text dayHoursText;
    public Text remainingHoursText;

    // Start is called before the first frame update
    void Start()
    {
        gameData.currentHour = 0;
        gameData.remainingHours = 0;
        StartCoroutine("Decrease");
    }

    // Update is called once per frame
    void Update()
    {
        // public Text healthtext;
        // healthtext.text = healthpack.ToString();
        // Color zm = healthtext.color;  //  makes a new color zm
        // zm.a = 0.0f; // makes the color zm transparent
        dayHoursText.text = gameData.currentHour.ToString() + 's';
        remainingHoursText.text = gameData.remainingHours.ToString();
    }

    IEnumerator Decrease() {
        while (gameData.currentHour < gameData.dayHours)
        {
            gameData.currentHour += 1;
            gameData.remainingHours++;
            yield return new WaitForSeconds(1);
        }
    }
}
