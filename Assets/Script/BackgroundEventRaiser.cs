using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEventRaiser : MonoBehaviour
{
    public GameEvent BackgroundHover;
    public GameEvent BackgroundExitHover;
    public GameEvent BackgroundClicked;
    public GameEvent ActionCanceled;
    public GameData gameData;

    private void OnMouseEnter() {
        print("BackgroundHover raised");
        BackgroundHover.Raise();
    }

    private void OnMouseExit() {
        print("BackgroundExitHover raised");
        BackgroundExitHover.Raise();
    }

    private void OnMouseDown() {
        print("BackgroundClicked raised");
        BackgroundClicked.Raise();

        if (gameData.actionInProgress) {
            print("ActionCanceled raised");
            ActionCanceled.Raise();
            return;
        }
    }
}
