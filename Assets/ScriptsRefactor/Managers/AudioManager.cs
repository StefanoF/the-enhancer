using UnityEngine;

namespace TheEnhancer {
    public class AudioManager : SingletonAbstract<AudioManager> {
        public AudioSource menuBackground;
        public AudioSource gameBackground;
        public AudioSource tutorialBackground;
        public AudioSource victory;
        public AudioSource actionStarted;
        public AudioSource actionCanceled;
        public AudioSource actionCompleted;

        protected override void Awake()
        {
            base.Awake();
            print("AudioManager ready!");
        }

        public void Victory() {
            gameBackground.Pause();
            victory.Play();
        }
    }
}