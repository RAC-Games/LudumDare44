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
    public float splitTime;
    public bool recursive;
    [SerializeField]
    bool isRoot;
    int minCount;


    // Start is called before the first frame update
    void Start()
    {
        if (!isRoot&&recursive)
        {
            StartCoroutine(Splitting());
        }
    }

    public float getCooldownDuration()
    {
        return count * splitTime;
    }

    
    public void SpawnCircleAttack()
    {
        if (isRoot)
        {
            minCount = count - 3;
            minCount = Mathf.Clamp(minCount, 1, count);
            CircleShot();
        }
    }


    public void CircleShot()
    {
        if (count > 0)
        {
            float step = 360.0f / count;
            Vector3 dir = transform.forward;
            for (float angle = 0; angle < 360f; angle += step)
            {
                dir = Quaternion.AngleAxis(step, Vector3.up) * dir;
                GameObject shot = Instantiate(projectile, transform.position+dir.normalized* spawnDistanceFromCenter, transform.rotation);
                shot.GetComponent<Rigidbody>().AddForce(dir * force);
                CircleShoot newCircleShoot = shot.GetComponent<CircleShoot>();
                newCircleShoot.count = count - 1;
                newCircleShoot.force = force;
                newCircleShoot.minCount = minCount;
                newCircleShoot.splitTime = splitTime;
                newCircleShoot.recursive = recursive;
                if (!recursive)
                {
                    Destroy(newCircleShoot.gameObject, splitTime*4f);
                }
            }
        }
    }

    void Split()
    {
        if (count > minCount)
        {
            CircleShot();
        }
        Destroy(gameObject);
    }

    IEnumerator Splitting()
    {
        if (splitTime > 0)
        {
            yield return new WaitForSeconds(splitTime);
            Split();
        }
    }

    
}
