using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceEventText : MonoBehaviour
{
    public void Invest(Text text) {
        text.text = "Invested in " + ResourceEvents.Instance.actualResourceType.ToString().ToLower();
    }

    public void DeInvest(Text text) {
        text.text = "De invested from " + ResourceEvents.Instance.actualResourceType.ToString().ToLower();
    }

    public void Product(Text text) {
        text.text = "Product of " + ResourceEvents.Instance.actualResourceType.ToString().ToLower();
    }

    public void DeProduct(Text text) {
        text.text = "DeProduct from " + ResourceEvents.Instance.actualResourceType.ToString().ToLower();
    }
}