using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTargetHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject target;

    void Start() {
        target.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData) {
        target.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        target.SetActive(true);
    }
}
