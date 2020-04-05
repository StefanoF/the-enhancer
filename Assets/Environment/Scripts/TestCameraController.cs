using UnityEngine;

public class TestCameraController : MonoBehaviour {

    private float moveSpeed = 0.5f;
    private float scrollSpeed = 10f;

    float horizontalInput;
    float verticalInput;
    float wheelInput;

    void Update () {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        wheelInput = Input.GetAxis("Mouse ScrollWheel");
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || verticalInput != 0) {
            transform.position += moveSpeed * new Vector3(horizontalInput, 0, verticalInput);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);
        }
    }
}
