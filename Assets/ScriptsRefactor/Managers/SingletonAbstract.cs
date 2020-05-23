using UnityEngine;

namespace TheEnhancer {
    public abstract class SingletonAbstract<T> : MonoBehaviour where T : MonoBehaviour {
        private static T _instance;
        public static T Instance { get { return _instance; } }
        protected virtual void Awake() {
            if (_instance != null && _instance != this) {
                Destroy(this.gameObject);
            } else {
                _instance = this as T;
            }
        }
    }
}