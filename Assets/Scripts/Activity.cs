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
    private ParabolaController pbController;

    void Awake()
    {
        pbController = gameObject.GetComponent<ParabolaController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        moveVector = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        // animated block
        transform.position = startPosition + moveVector * (moveRange * Mathf.Sin(Time.timeSinceLevelLoad * moveSpeed));
    }

    void LaunchSphere(Transform endPos) {
        
    }

    void OnMouseOver(){
        if (Input.GetMouseButtonDown(0)) {
            if (hourIn < maxHours) {
                hourIn++;
                pbController.StartAnim();
            }
        }
        else if (Input.GetMouseButtonDown(1)) {
            if (hourIn > minHours) {
                hourIn--;
            }
        }
    }
}
