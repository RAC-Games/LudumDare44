﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    public float health;

    public float stopDistance;

    bool dead = false;

    float alternator = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            if (dead)
            {
                return;
            }
            dead = true;
            agent.isStopped = false;
            var enemyAttack = GetComponent<EnemyAttack>();
            StopCoroutine(enemyAttack.runningCoRoutine);
            Destroy(gameObject, 2);
            StartCoroutine(growRoutine());
        }

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

    private void OnCollisionEnter(Collision collision)
    {
        var dmgScript = collision.collider.GetComponent<damage>();
        if (dmgScript != null) {
            health -= dmgScript.dmg;
        }
    }

    IEnumerator growRoutine()
    {
        while (true)
        {
            transform.localScale *= alternator * 1.01f;
            alternator *= -1;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
