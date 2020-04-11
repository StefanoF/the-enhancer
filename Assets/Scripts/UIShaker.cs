using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShaker : MonoBehaviour
{
    public float shakeDuration; // 1
    public float shakeAmount; // 4
    public float decreaseFactor; // 2
    
    private RectTransform rect;
    private Vector3 originalPos;
    private float actualShakeDuration;
    private bool shaking;
	
	void Awake()
	{
		if (rect == null)
		{
			rect = GetComponent(typeof(RectTransform)) as RectTransform;
		}
	}
	
	void OnEnable()
	{
        actualShakeDuration = shakeDuration;
		originalPos = rect.localPosition;
	}
        
    IEnumerator Shake() {
        if (!shaking) {
            yield return null;
        }
        while (actualShakeDuration > 0)
        {
            Vector3 newPos = originalPos + Random.insideUnitSphere * shakeAmount;
            rect.localPosition = newPos;
            actualShakeDuration -= Time.deltaTime * decreaseFactor;
            yield return null;
        }
        
        shaking = false;
        actualShakeDuration = shakeDuration;
        rect.localPosition = originalPos;
    }

    public void ShakeNow() {
        shaking = true;
        StartCoroutine(Shake());
    }
}
