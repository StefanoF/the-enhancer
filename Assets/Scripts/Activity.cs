using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour
{
    public int hourIn; 
    public int minHours;
    public int maxHours;
    private Vector3 startPosition;
    private Vector3 moveVector;
    public float moveRange;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        moveVector = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + moveVector * (moveRange * Mathf.Sin(Time.timeSinceLevelLoad * moveSpeed));
    }

    void OnMouseOver(){
        if (Input.GetMouseButtonDown(0)) {
            if (hourIn < maxHours) {
                hourIn++;
            }
        }
        else if (Input.GetMouseButtonDown(1)) {
            if (hourIn > minHours) {
                hourIn--;
            }
        }
    }
}
