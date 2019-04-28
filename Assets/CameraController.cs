using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float minHeight;
    [SerializeField]
    float maxHeight;
    [SerializeField]
    float speed;
    GameObject player;
    Transform lookAtOffset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lookAtOffset = GameObject.Find("CameraLookAtOffset").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        print("scroll: " + scroll);
        if(transform.position.y > minHeight && transform.position.y < maxHeight)
        {
            print("scrolling");
            transform.Translate(transform.forward * scroll * speed);
        }
    }

    private void LateUpdate()
    {
        transform.LookAt(lookAtOffset);
    }
}
