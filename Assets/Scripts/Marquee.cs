using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marquee : MonoBehaviour
{
    [Range(10,200)]
    public float scrollSpeed;
    
    RectTransform messageRect;

    void Awake() {
        messageRect = GetComponent<RectTransform>();
    }
    
    void OnGUI ()
    {
        messageRect.anchoredPosition += Vector2.left * Time.deltaTime * scrollSpeed;

        // If the message has moved past the left side, move it back to the right
        if (messageRect.anchoredPosition.x <= -Screen.width) {
            messageRect.anchoredPosition = new Vector2(messageRect.rect.width, 0f);
        }
    }
}
