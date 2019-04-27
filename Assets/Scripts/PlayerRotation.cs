using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public GameObject mover;
    public float moverSpeed;
    public float moverDist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");


        var relativeMovement = new Vector3(x, 0, y);

        var newPos = mover.transform.position + relativeMovement * moverSpeed;
        if (Vector3.Distance(newPos, transform.position) < moverDist)
        {
            mover.transform.position = newPos;
        }
        else
        {
            mover.transform.position = (newPos - transform.position).normalized * moverDist + transform.position;
        }
        var lookPos = new Vector3(mover.transform.position.x,transform.position.y, mover.transform.position.z);
        transform.LookAt(lookPos);
    }
}
