using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAnimator : MonoBehaviour
{
    public float moveRange;
    public float moveSpeed;
    private bool isMouseHover;
    private float timeMovement;
    private Vector3 startPosition;
    private Vector3 moveVector;

    void Start() {
        startPosition = transform.position;
        moveVector = Vector3.up;
    }

    void Update() {
        if (isMouseHover) {
            Animate();
        }
    }

    public void EnableHover() {
        isMouseHover = true;
    }

    public void DisableHover() {
        isMouseHover = false;
        ResetAnimation();
    }

    private void Animate() {
        timeMovement += Time.deltaTime;
        transform.position = transform.position + moveVector * (moveRange * Mathf.Sin(timeMovement * moveSpeed));
    }

    private void ResetAnimation() {
        Vector3 exitPos = transform.position;
        exitPos.y = startPosition.y;
        transform.position = exitPos;
        timeMovement = 0f;
    }
}
