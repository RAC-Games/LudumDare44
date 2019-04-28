﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class enemy : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    Animator anim;
    EnemyAttack enemyAttack;

    public float health;
    public float attackDistance;
    public float followDistance;
    public bool dead = false;
    public UnityEvent die;

    public float alternator = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemyAttack = GetComponent<EnemyAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            return;
        }
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance > attackDistance)
        {
            if(distance > followDistance)
            {
                goIdle();
            }
            follow();
        }
        else
        {
            attack();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
        var dmgScript = collision.collider.GetComponent<damage>();
        if (dmgScript != null) {
            health -= dmgScript.dmg;
        }
        if (health < 0)
            {
                isDead();
            }

        }
    }


    IEnumerator growRoutine()
    {
        while (true)
        {
            transform.localScale *= alternator + 1f;
            alternator *= -1;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void follow()
    {
        agent.isStopped = false;
        agent.destination = player.transform.position;
        anim.SetInteger("State", 1);
        enemyAttack.enabled = false;
    }


    private void attack()
    {
        agent.isStopped = true;
        transform.LookAt(player.transform.position);
        anim.SetInteger("State", 2);
        //animator Event auslösen
        enemyAttack.enabled = true;
    }

    private void goIdle()
    {
        agent.isStopped = true;
        enemyAttack.enabled = false;
        anim.SetInteger("State", 0);
        //Animator -> IdleAnimation
    }


    private void isDead()
    {
        anim.SetInteger("State", 3);
        dead = true;
        agent.isStopped = true;
        var enemyAttack = GetComponent<EnemyAttack>();
        StopCoroutine(enemyAttack.runningCoRoutine);
        Destroy(gameObject, 2);
        StartCoroutine(growRoutine());
        die.Invoke();
    }
}
