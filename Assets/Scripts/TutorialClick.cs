using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialClick : MonoBehaviour, IPointerDownHandler
{
    public GameEvent customEvent;
    public bool pauseGame;
    public bool unpauseOnClick;

    public void Start() {
        if (pauseGame) {
            Time.timeScale = 0f;
        }
    }

    public void OnPointerDown (PointerEventData eventData) {
        customEvent.Raise();
        if (pauseGame && unpauseOnClick) {
            Time.timeScale = 1.0f;
        }
    }
}
