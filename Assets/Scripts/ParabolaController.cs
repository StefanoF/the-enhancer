using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaController : MonoBehaviour
{
    public float time;
    public float height;
    public float durationTime;

    public Transform startPos;

    public bool notReady;

    public int lastSphere;
    public int nSpheres;
    public GameObject hourSphere;
    private GameObject[] hourSpheres;

    // Start is called before the first frame update
    void Start()
    {
        hourSpheres = new GameObject[nSpheres];
        for (int i = 0; i < hourSpheres.Length; i++) {
            hourSpheres[i] = Instantiate(hourSphere, startPos.position, Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Coroutine AnimCo;

    public void StartAnim() {
        print(hourSpheres[lastSphere].name);
        if (startPos && hourSpheres[lastSphere]) {
            if (lastSphere < nSpheres) {
                StartCoroutine(AnimCoroutine(hourSpheres[lastSphere]));
                lastSphere++;
            }
            else {
                lastSphere = 0;
            }
        }
    }

    private IEnumerator AnimCoroutine(GameObject sphere) {
        time = Time.deltaTime;
        while (time < durationTime)
        {
            time += Time.deltaTime;
            // time = time % durationTime;
            sphere.transform.position = Parabola(startPos.position, transform.position, height, time/durationTime);
            yield return null;
        }
        
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Sphere") {
            print("end animation!");
            if (AnimCo != null)
            {
                // StopCoroutine(AnimCo);
            }
        }
    }

    public Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Vector3 mid = Vector3.Lerp(start, end, t);
        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }

    private float f (float x) { 
        return -(5-1) * height * x * x + (5-1) * height * x;
    }

    // void OnDrawGizmos () {
    //     //Draw the parabola by sample a few times
    //     //Only on test
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(startPos.position, endPos.position);
    //     float count = 20;
    //     Vector3 lastP = startPos.position;
    //     for (float i = 0; i < count + 1; i++) {
    //         Vector3 p = Parabola(startPos.position, endPos.position, height, i/count);
    //         Gizmos.color = i % 2 == 0 ? Color.blue : Color.green;
    //         Gizmos.DrawLine(lastP, p);
    //         lastP = p;
    //     }
    // }

}
