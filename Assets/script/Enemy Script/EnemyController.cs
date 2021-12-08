using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float maxRange = 100;
    private NavMeshAgent navMeshAgent;

    public Transform[] waypoints;
    private int waypointIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        player = GameObject.Find("PlayerController").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        Physics.IgnoreLayerCollision(10, 11);
    }

    // Update is called once per frame
    void Update()
    {
        float currentDis = Vector3.Distance(transform.position, player.position);
        if (isFront() && isLineOfSight())
        {
            if (currentDis < maxRange) 
            {
                Debug.DrawLine(transform.position, player.position, Color.blue);

                navMeshAgent.destination = player.position;
            }
            else
            {
                Patrol();
            }
        }
        else
        {
            Patrol();
        }
    }

    bool isFront()
    {
        Vector3 directionOfPlayer = transform.position - player.position;
        float angle = Vector3.Angle(transform.forward, directionOfPlayer);

        //Debug.Log(Mathf.Abs(angle));
        if (Mathf.Abs(angle) > 130 && Mathf.Abs(angle) < 240)
        {
            //Debug.DrawLine(transform.position, player.position, Color.red);
            return true;
        }

        return false;
    }

    bool isLineOfSight()
    {
        RaycastHit _hit;
        Vector3 directionOfPlayer = player.position - transform.position;

        if (Physics.Raycast(transform.position, directionOfPlayer, out _hit, 100f))
        {
            if (_hit.transform.name == "PlayerController")
            {
                //Debug.DrawLine(transform.position, player.position, Color.green);
                return true;
            }
        }

        return false;
    }

    void Patrol()
    {
        if (waypoints.Length > 0)
        {
            navMeshAgent.destination = waypoints[waypointIndex].position;
            if (transform.position.x == waypoints[waypointIndex].position.x &&
                transform.position.z == waypoints[waypointIndex].position.z)
            {
                waypointIndex++;
                if (waypointIndex >= waypoints.Length)
                {
                    waypointIndex = 0;
                }
            }
        }
    }
}
