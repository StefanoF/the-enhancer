﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoController : MonoBehaviour
{
    private Dictionary<string, object> undoState;
    private ActionBase obj;

    public SharedData gameData;

    void OnMouseEnter() {
        gameData.inPlane = true;
    }

    void OnMouseExit() {
        gameData.inPlane = false;
    }

    void OnMouseDown() {
        ActionEvents.Instance.clickOnBottomPlane.Raise();
        if (obj != null) {
            obj.RestoreState();
        }
    }

    public void SaveState(ActionBase actionBaseObj, Dictionary<string, object> state) {
        obj = actionBaseObj;
        undoState = state;
    }

    public Dictionary<string, object> GetUndoState() {
        return undoState;
    }

    public void Reset() {
        undoState = new Dictionary<string, object>();
        obj = null;
    }   
}
