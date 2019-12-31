using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaiser : MonoBehaviour
{
    void OnMouseDown() {
        ActionEvents.Instance.oneActionAtTime.Raise();
    }
}
