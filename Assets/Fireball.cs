using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    void Explode()
    {
        print("Explode");
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
        {
            p.Stop();
        }
        //Destroy(gameObject);
    }
}
