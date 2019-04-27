using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    public float stopDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,player.transform.position)> stopDistance)
        {
            agent.isStopped = false;
            agent.destination = player.transform.position;
        }
        else
        {
            agent.isStopped = true;
        }
    }
}
