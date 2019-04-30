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
    public GameObject model;
    public GameObject transModel;

    bool animationPlayed = false;
    public bool isInvincible = false;

    private void Start()
    {
        healthSO.health = 15;
        healthSO.maxHealth = 15;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile") && !(collision.gameObject.GetComponent<damage>().isFromPlayer))
        {
            int dmg = collision.gameObject.GetComponent<damage>().dmg;

            if (!isInvincible)
            {
                healthSO.decreaseHealth(dmg);
                if (healthSO.health <= 0 )
                {
                    deathEvent.Invoke();  
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

    public void Death()
    {
        if (!animationPlayed)
        {
            print("death");
            anim.SetTrigger("died");
            animationPlayed = true;
            StartCoroutine(revive());
        }
    }

    

    IEnumerator invincible()
    {

        for (int i = 0; i < 4; i++)
        {
            model.SetActive(false);
            transModel.SetActive(true);
            yield return new WaitForSeconds(.2f);
            model.SetActive(true);
            transModel.SetActive(false);
            yield return new WaitForSeconds(.2f);
        }
        isInvincible = false;
    }

    IEnumerator revive()
    {
        yield return new WaitForSeconds(1.8f);
        anim.SetTrigger("revived");
        animationPlayed = false;
        FindObjectOfType<sceneTransition>().teleportToHub();
    }
}
