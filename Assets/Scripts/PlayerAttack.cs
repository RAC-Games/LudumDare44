using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(projectile))]
public class PlayerAttack : MonoBehaviour
{
    public GameObject attack1;
    public GameObject attack2;
    public Vector3 mousePosition;
    public Transform startPosition;
    projectile projectile;
    public float elapsed = 0f;

    public float cooldownSec;
    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponent<projectile>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= cooldownSec)
        {
            
            if (Input.GetMouseButton(0))
            {
                elapsed = 0;
                projectile.shoot(startPosition.position, transform.forward, attack1);
            }

            if (Input.GetMouseButton(1))
            {
                elapsed = 0;
                projectile.shoot(startPosition.position, transform.forward, attack2);
            }
        }
    }
}
