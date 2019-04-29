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
        Scroll(0);
    }

    // Update is called once per frame
    void Update()
    {
        float scrollAmount = Input.GetAxis("Mouse ScrollWheel");
        if(transform.position.y >= minHeight && transform.position.y <= maxHeight)
        {
            if (scrollAmount != 0)
            {
                print("scrolling");
                Scroll(scrollAmount);
            }
        }
    }

    void Scroll(float scrollAmount)
    {
        transform.Translate(transform.forward * scrollAmount * speed);
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minHeight, maxHeight);
        transform.position = pos;
        transform.LookAt(lookAtOffset);
    }

    private void LateUpdate()
    {
        //transform.LookAt(lookAtOffset);
    }
}
