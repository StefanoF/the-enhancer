
using UnityEngine;

public class Resources : MonoBehaviour
{
    private ResourceSel[] resourceChilds;

    void Awake() 
    {
        resourceChilds = GetComponentsInChildren<ResourceSel>();

        if (gameObject.activeSelf) {
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHighlight();
    }

    void OnEnable() {
        UpdateHighlight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHighlight() {
        foreach (ResourceSel resourceSel in resourceChilds) {
            resourceSel.HighlightResource();
        }
    }
}
