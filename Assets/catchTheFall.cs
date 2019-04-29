using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchTheFall : MonoBehaviour
{
    public Health playerHealthSO;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var Player = GameObject.Find("player");
            var playerRb = Player.GetComponent<Rigidbody>();
            playerRb.velocity = Vector3.zero;
            playerRb.Sleep();
            var memoryObj = GameObject.FindGameObjectWithTag("memory");
            var memory = memoryObj.GetComponent<transitionMemory>();
            memory.doTransition = false;
            var spawName = memory.nextDoor;
            var door = GameObject.Find(spawName);
            Player.transform.position = door.transform.position;
            playerHealthSO.decreaseHealth(1);
            if (playerHealthSO.health > 0)
            {
                Player.GetComponent<PlayerHealth>().hurtEvent.Invoke();
               
            }
            else
            {
                
                Player.GetComponent<PlayerHealth>().deathEvent.Invoke();
            }
        }
    }
}
