using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public SharedData gameData;

    public void Pause() {
        gameData.pause = true;
    }

    public void Unpause() {
        gameData.pause = false;
    }
}
