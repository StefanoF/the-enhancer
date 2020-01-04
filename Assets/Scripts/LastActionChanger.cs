using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastActionChanger : MonoBehaviour
{
    public SharedData gameData;

    public void ChangeColor(Image actualImage) {
        actualImage.color = gameData.lastActionColor;
    }

    public void ChangeActionLvl(Text actualText) {
        actualText.text = gameData.lastActionLvl;
    }

    public void ChangeActionIcon(Image actualImage) {
        actualImage.sprite = gameData.lastActionIcon;
        actualImage.color = new Color(255, 255, 255, 255);
    }
}
