using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaController : MonoBehaviour
{
    public float time;
    public float height;
    public float durationTime;
    public float speed;

    public Transform startPos;
    public Transform endPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startPos && endPos) {
            time += Time.deltaTime;
            time = time % durationTime;
            transform.position = Parabola(startPos.position, endPos.position, height, time * speed);
        }
    }

    public Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Vector3 mid = Vector3.Lerp(start, end, t);
        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }

    private float f (float x) {
        return -(durationTime-1) * height * x * x + (durationTime-1) * height * x;
    }

    void OnDrawGizmos () {
        //Draw the parabola by sample a few times
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPos.position, endPos.position);
        float count = 20;
        Vector3 lastP = startPos.position;
        for (float i = 0; i < count + 1; i++) {
            Vector3 p = Parabola(startPos.position, endPos.position, height, i/count);
            Gizmos.color = i % 2 == 0 ? Color.blue : Color.green;
            Gizmos.DrawLine(lastP, p);
            lastP = p;
        }
    }

}
