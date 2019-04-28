using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{

    public Health healthSO;
    public UnityEvent deathEvent;
    public UnityEvent hurtEvent;
    public Animator anim;

    bool animationPlayed = false;
    bool isInvincible = false;

    private void Start()
    {
        healthSO.health = 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile") && !(collision.gameObject.GetComponent<damage>().isFromPlayer))
        {
            int dmg = collision.gameObject.GetComponent<damage>().dmg;

            if (!isInvincible)
            {
                healthSO.decreaseHealth(dmg);
                if (healthSO.health <= 0 && !animationPlayed)
                {
                    deathEvent.Invoke();
                    anim.SetTrigger("died");
                    animationPlayed = true;
                }
                else
                {
                    print("hit, health: " + healthSO.health);
                    hurtEvent.Invoke();
                    isInvincible = true;
                    StartCoroutine(invincible());

                }
            }
            
        }
        
    }

    IEnumerator invincible()
    {


        yield return new WaitForSeconds(2);
        isInvincible = false;
    }
}
