using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed;
    public Vector3 offset;
    private Vector3 target;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        target = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
    }

    public void SetTarget(Vector3 pos) {
        target = pos + offset;
    }

    public void ResetTarget() {
        target = startPosition;
    }
}
