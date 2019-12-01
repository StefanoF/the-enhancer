using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMan : MonoBehaviour
{
    [Header("AudioClips")]
    public AudioSource background;
    public AudioSource victory;

    void Start() {
        background.Play();
    }

    public void Victory() {
        background.Pause();
        victory.Play();
    }
}
