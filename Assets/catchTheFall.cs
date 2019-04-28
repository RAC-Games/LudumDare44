﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchTheFall : MonoBehaviour
{
    public GameObject Player;
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
            var memory = GameObject.FindGameObjectWithTag("memory");
            var spawName = memory.GetComponent<transitionMemory>().nextDoor;
            var door = GameObject.Find(spawName);
            Player.transform.position = door.transform.position;
        }
    }
}
