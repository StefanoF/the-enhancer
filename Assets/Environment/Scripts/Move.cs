using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    public float distance;
    public Animator anim;
    public Transform target;
    NavMeshAgent nav;

    public Vector3 initial;
    public Vector3 currentTarget;
    public bool going;

    void Awake() {
        nav = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        initial = transform.position;
    }

    public void StartMoving() {
        // https://docs.unity3d.com/Manual/nav-CouplingAnimationAndNavigation.html
        // anim.Start();
        nav.isStopped = false;
        anim.SetBool("move", true);
        nav.SetDestination(currentTarget);
    }

    void SwitchTarget() {
        going = !going;
        if (going) {
            currentTarget = initial;
        }
        else {
            currentTarget = target.position;
        }
    }

    public void StopMoving() {
        nav.isStopped = true;
        anim.SetBool("move", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (nav.remainingDistance < distance) {
            print("Stop - Switch - Start");
            StopMoving();
            SwitchTarget();
            StartMoving();
        }
    }
}
