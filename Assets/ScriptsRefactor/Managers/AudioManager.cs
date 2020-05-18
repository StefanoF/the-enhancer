using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheEnhancer {
    [CreateAssetMenu(fileName = "AudioData", menuName = "AudioData", order = 1)]
    public class AudioManager : ScriptableObject {
        public AudioSource background;
        public AudioSource victory;
        public void Victory() {
        background.Pause();
        victory.Play();
        }
    }
}