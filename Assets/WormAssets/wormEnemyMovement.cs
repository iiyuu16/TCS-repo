using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wormEnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 0.1f;

    private GameObject[] WPs;
    private NavMeshAgent agent;
    void Start()
    {
        WPs = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FollowTarget());
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds wait = new WaitForSeconds(speed);
        target = WPs[Random.Range(0, WPs.Length)];
        while (enabled)
        {
            agent.SetDestination(target.transform.position);
            yield return wait;
        }
        
    }
}
