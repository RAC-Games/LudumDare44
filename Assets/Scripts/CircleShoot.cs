using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShoot : MonoBehaviour
{
    [SerializeField]
    Vector3 spawnOffset;
    [SerializeField]
    float spawnDistanceFromCenter;
    public GameObject projectile;
    public int count;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            CircleShot();
        }   
    }

    public void CircleShot()
    {
        if (count > 0)
        {
            float step = 360.0f / count;
            Vector3 dir = Vector3.forward;
            for (float angle = 0; angle < 360f; angle += step)
            {
               
                //Vector3 dir = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));

                dir = Quaternion.AngleAxis(step, Vector3.up) * dir;
                Debug.Log(angle+ " Dir: "+dir);
                GameObject shot = Instantiate(projectile, transform.position+dir.normalized* spawnDistanceFromCenter, transform.rotation);
                shot.GetComponent<Rigidbody>().AddForce(dir * force);
                Destroy(shot, 5);
            }
        }

    }
}
