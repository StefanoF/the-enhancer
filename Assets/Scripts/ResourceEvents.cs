using UnityEngine;

public class ResourceEvents : MonoBehaviour {
    private static ResourceEvents _instance;
    public static ResourceEvents Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public SharedData.ResourceType actualResourceType;

    public GameEvent invest;
    public GameEvent deInvest;
    public GameEvent product;
    public GameEvent deProduct;
}