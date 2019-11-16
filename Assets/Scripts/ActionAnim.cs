using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAnim : MonoBehaviour
{
    public float moveRange;
    public float moveSpeed;
    private float timeMovement;
    private Vector3 startPosition;
    private Vector3 moveVector;

    void Awake()
    {

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

    }

    void OnMouseOver() {
        timeMovement += Time.deltaTime;
        transform.position = transform.position + moveVector * (moveRange * Mathf.Sin(timeMovement * moveSpeed));
    }

    void OnMouseExit() {
        Vector3 exitPos = transform.position;
        exitPos.y = startPosition.y;
        transform.position = exitPos;
        timeMovement = 0f;
    }
}
