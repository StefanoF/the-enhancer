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
        Start, Rules, Credits, Menu
    };

    public ActionType actionType;
    public GameObject menuObj;
    public GameObject creditsObj;

    void Awake() {
        elemText = gameObject.GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        originalSize = elemText.fontSize;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        elemText.fontSize = originalSize;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        elemText.fontSize = fontSize;
    }
}
