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


    void Update() {
        if (shaking) {
            if (actualShakeDuration > 0)
            {
                Vector3 newPos = originalPos + Random.insideUnitSphere * shakeAmount;
                // newPos.y = originalPos.y;
                // newPos.z = originalPos.z;
                rect.localPosition = newPos;

                actualShakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shaking = false;
                actualShakeDuration = shakeDuration;
                rect.localPosition = originalPos;
            }
        }
    }

    public void ShakeNow() {
        shaking = true;
    }
}
