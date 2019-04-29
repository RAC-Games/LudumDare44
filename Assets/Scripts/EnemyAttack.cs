using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(projectile))]
public class EnemyAttack : MonoBehaviour
{
    public GameObject attack1;
    public Transform startPosition;
    projectile projectile;
    Transform player;

    public Coroutine runningCoRoutine;
    public float intervalSec;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        projectile = GetComponent<projectile>();
        //runningCoRoutine = StartCoroutine(shootRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*IEnumerator shootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalSec);
            shoot();
        }
    }*/
    public void shootBone() {
        Vector3 dir = (player.position - startPosition.position).normalized;
        projectile.shoot(startPosition.position, dir, attack1);
    }
}
