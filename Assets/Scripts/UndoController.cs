using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoController : MonoBehaviour
{
    private Dictionary<string, object> undoState;
    private ActionBase obj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit = new RaycastHit();        
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject.tag == "BackPlane" && obj != null) {
                    obj.RestoreState();
                }
            }
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
