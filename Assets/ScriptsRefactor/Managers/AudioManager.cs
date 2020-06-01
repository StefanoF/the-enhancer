using UnityEngine;

namespace TheEnhancer {
    public class AudioManager : MonoBehaviour {
        public AudioSource menuBackground;
        public AudioSource gameBackground;
        public AudioSource tutorialBackground;
        public AudioSource victory;
        public AudioSource actionStarted;
        public AudioSource actionCanceled;
        public AudioSource actionCompleted;

        void Awake() {
            print("AudioManager ready!");
        }

        public void Victory() {
            gameBackground.Pause();
            victory.Play();
        }
    }
}