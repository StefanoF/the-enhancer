using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HoverMenuText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Text elemText;

    [Range(1, 100)]
    public int fontSize;
    public int originalSize;
    public enum ActionType {
        Start, Rules, Credits, Menu, Tutorial, ChangeLanguage
    };

    public ActionType actionType;
    public GameObject menuObj;
    public GameObject creditsObj;

    [Header("Language options")]
    public HoverMenuText sibling;
    public SharedData gameData;
    public GameEvent ChangeLanguage;
    private Color activeColor;
    private Color inactiveColor;

    void Awake() {
        elemText = gameObject.GetComponent<Text>();
        activeColor = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1f);
        inactiveColor = new Color(0.5754717f, 0.5754717f, 0.5754717f, 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        originalSize = elemText.fontSize;

        if (actionType == ActionType.ChangeLanguage && gameObject.name == gameData.currentLang) {
            SetCurrentLang();
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData) {
        switch (actionType){
            case ActionType.Start:
                SceneManager.LoadScene(1);
                break;

            case ActionType.Credits:
                creditsObj.SetActive(true);
                menuObj.SetActive(false);
                break;

            case ActionType.Menu:
                menuObj.SetActive(true);
                creditsObj.SetActive(false);
                break;
            
            case ActionType.Tutorial:
                SceneManager.LoadScene(2);
                break;

            case ActionType.ChangeLanguage:
                SetCurrentLang();
                break;

        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        elemText.fontSize = originalSize;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        elemText.fontSize = fontSize;
    }

    void SetCurrentLang() {
        sibling.SetInactiveText();
        SetActiveText();
        gameData.currentLang = gameObject.name;
        ChangeLanguage.Raise();
    }

    public void SetActiveText() {
        elemText.color = activeColor;
    }

    public void SetInactiveText() {
        elemText.color = inactiveColor;
    }
}
