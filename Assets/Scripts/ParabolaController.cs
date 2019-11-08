using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaController : MonoBehaviour
{
    public float height;
    public float durationTime;

    public Transform startPos;
    public float offsetEndPos;

    public bool notReady;

    public int lastSphere;
    public int nSpheres;
    public GameObject hourSphere;
    private GameObject[] hourSpheres;

    // Start is called before the first frame update
    void Awake()
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

    public void StartAnim() {
        if (!startPos) {
            return;
        }
        if (lastSphere < nSpheres - 1) {
            lastSphere++;
        }
        else {
            lastSphere = 0;
        }
        if (hourSpheres[lastSphere]) {
            StartCoroutine(AnimCoroutine(hourSpheres[lastSphere]));
        }
    }

    private IEnumerator AnimCoroutine(GameObject sphere) {
        float time = Time.deltaTime;
        while (time < durationTime)
        {
            time += Time.deltaTime;
            // time = time % durationTime;
            Vector3 endPos = transform.position;
            endPos.y = endPos.y + offsetEndPos;
            sphere.transform.position = Parabola(startPos.position, endPos, height, time/durationTime);
            yield return null;
        }
        sphere.transform.position = startPos.position;
    }

    public Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Vector3 mid = Vector3.Lerp(start, end, t);
        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }

    private float f (float x) { 
        return -(5-1) * height * x * x + (5-1) * height * x;
    }
    
    // private Coroutine AnimCo;
    // void OnTriggerExit(Collider collider)
    // {
    //     if (collider.gameObject.tag == "Sphere") {
    //         print("end animation!");
    //         if (AnimCo != null)
    //         {
    //             StopCoroutine(AnimCo);
    //         }
    //     }
    // }

    

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
