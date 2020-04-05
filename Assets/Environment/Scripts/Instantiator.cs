using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Instantiator : MonoBehaviour
{
    [Header("Objects to be instantiated")]
    public List<GameObject> structures;
    public Transform destination;

    [Header("Delimiter areas")]
    public Collider[] prohibitedAreas;
    public Collider totalArea;
    public float offset;

    [Header("Prevent overlap")]
    public float overlapRadius;

    [Header("Time between construction")]
    public float delay;

    private Bounds totalAreaBounds;

    void Start()
    {
        totalAreaBounds = totalArea.GetComponent<MeshCollider>().bounds;
        StartCoroutine(CreateCo());
    }

    bool IsValidPosition(Vector3 pos) {
        foreach(Collider prohibitedArea in prohibitedAreas) {
            if (prohibitedArea.bounds.Contains(pos)) {
                return false;
            }
        }

        Collider[] hitColliders = Physics.OverlapSphere(pos, overlapRadius);
        foreach(Collider hit in hitColliders) {
            if (hit.tag == "Building") {
                return false;
            }
        }

        return true;
    }

    Vector3 GeneratePoint(float structureY) {
        float x = Random.Range(totalAreaBounds.min.x + offset, totalAreaBounds.max.x - offset);
        float y = structureY + gameObject.transform.parent.gameObject.transform.position.y;
        float z = Random.Range(totalAreaBounds.min.z + offset, totalAreaBounds.max.z - offset);
        Vector3 pos = new Vector3(x, y, z);

        if (IsValidPosition(pos)) {
            return pos;
        }
        return GeneratePoint(structureY);
    }

    IEnumerator CreateCo() {
        while (true)
        {
            Create();
            yield return new WaitForSeconds(delay);
        }
    }

    void Create() {
        // print("Create " + Time.time);
        if (structures.Any()) {
            GameObject structure = structures.First();
            Vector3 pos = GeneratePoint(structure.transform.position.y);
            GameObject instance = Instantiate(structure, pos, Quaternion.identity);
            structures.Remove(structure);

            instance.transform.parent = gameObject.transform;

            Move instanceMove = instance.GetComponent<Move>();
            if (instanceMove != null) {
                ActivateMover(instanceMove);
            }

            Vector3 euler = instance.transform.eulerAngles;
            euler.y = Random.Range(0f, 360f);
            instance.transform.eulerAngles = euler;
        }
    }

    void ActivateMover(Move instanceMove) {
        instanceMove.target = destination;
        instanceMove.currentTarget = destination.position;
        instanceMove.StartMoving();
    }

    public void Reset() {
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void AddInList(GameObject structure) {
        structures.Add(structure);
    }
}
