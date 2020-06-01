using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheEnhancer {
    public class BottomPlaneClick : MonoBehaviour
    {
        public AllEvents events;
        void OnMouseDown() {
            events.clickOnBottomPlane.Raise();
        }
    }
}