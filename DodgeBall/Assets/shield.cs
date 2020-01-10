using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class shield : MonoBehaviour {
    Transform target;
    NavMeshAgent agent;
    // Use this for initialization
    void Start () {
        target = playerMan.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        faceTarget();
	}

    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
