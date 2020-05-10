using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour {
    public float ratio;
    public Behaviour blinkHalo;
    public IEnumerator blinkingCo;

    public void StartFlash() {
        DisableHalo();
        blinkingCo = FlashNow();
        StartCoroutine(blinkingCo);
    }

    void OnDisable()
    {
        DisableHalo();
    }

    public void DisableHalo() {
        if (blinkingCo != null) {
            StopCoroutine(blinkingCo);
        }
        blinkHalo.enabled = false;
    }

    private IEnumerator FlashNow()
    {
        while (true)
        {
            blinkHalo.enabled = !(blinkHalo.enabled);
            yield return new WaitForSeconds(ratio);
        }
    }
}