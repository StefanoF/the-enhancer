using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslateOnChange : GameEventListener
{
    public SharedData gameData;
    public Text[] texts;
    private string[] TextIds;

    public void Awake() {
        TextIds = new string[texts.Length];
        for (int i = 0; i < texts.Length; i++) {
            TextIds[i] = texts[i].text;
        }
        TranslateIt();
    }

    public void TranslateIt() {
        if (gameData.currentLang == "") {
            gameData.currentLang = I18n.GetLanguage();
        }

        I18n.ChangeLanguage(gameData.currentLang);

        for (int i = 0; i < texts.Length; i++) {
            texts[i].text = I18n.Fields[TextIds[i]];
        }
    }
}