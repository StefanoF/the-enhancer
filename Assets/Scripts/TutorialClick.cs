using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
        if (unpauseOnClick) {
            Time.timeScale = 1.0f;
        }
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene(0);
    }
}
