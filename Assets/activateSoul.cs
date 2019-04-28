using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateSoul : MonoBehaviour
{
    public GameObject psGO;
    ParticleSystem ps;
    public progressSO progress;

    // Start is called before the first frame update
    void Start()
    {
        ps = psGO.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var main = ps.main;
            main.startColor = Color.red;
            progress.setDoor2(true);
        }
        
    }
}
