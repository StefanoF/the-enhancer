using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Constructor : MonoBehaviour
{
    public float delay;
    private List<GameObject> atoms;

    void Awake() {
        atoms = new List<GameObject>();
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
            atoms.Add(child.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedBuild(delay));
    }

    IEnumerator DelayedBuild (float delay) {
        while (true)
        {
            if (atoms.Any()) {
                GameObject atom = atoms.First();
                atom.SetActive(true);
                atoms.Remove(atom);
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
