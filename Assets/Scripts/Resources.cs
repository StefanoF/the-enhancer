
using UnityEngine;

public class Resources : MonoBehaviour
{
    public ResourceSel[] resourceChilds;

    void Awake() 
    {
        resourceChilds = GetComponentsInChildren<ResourceSel>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (ResourceSel resourceSel in resourceChilds) {
            resourceSel.HighlightResource();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
