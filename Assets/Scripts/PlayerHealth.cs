using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{

    public Health healthSO;
    public UnityEvent deathEvent;
    public UnityEvent hurtEvent;
    
    

    private void Start()
    {
        healthSO.health = 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile") && !(collision.gameObject.GetComponent<damage>().isFromPlayer))
        {
            int dmg = collision.gameObject.GetComponent<damage>().dmg;
            

            healthSO.decreaseHealth(dmg);
            if (healthSO.health <= 0)
            {
                deathEvent.Invoke();
            }
            else
            {
                hurtEvent.Invoke();
            }
        }
        
    }
}
