using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchTheFall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        }
    }
}
