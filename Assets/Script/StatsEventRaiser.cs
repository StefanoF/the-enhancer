using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StatsEventRaiser : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameEvent StatsHover;
    public GameEvent StatsExitHover;

    public void OnPointerEnter(PointerEventData eventData) {
        print("StatsHover raised");
        StatsHover.Raise();
    }

    public void OnPointerExit(PointerEventData eventData) {
        print("StatsExitHover raised");
        StatsExitHover.Raise();
    }
}