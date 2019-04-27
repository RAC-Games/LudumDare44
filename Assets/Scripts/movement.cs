using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Camera camera;
    public GameObject mouseHit;
    Rigidbody rb;

    Vector3 rotation = new Vector3(0, 0, 0);
    Vector2 oldInput;
    float angle;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 oldInput = new Vector2(0, 0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var direction = new Vector3(horizontal, 0, vertical);
        rb.MovePosition(transform.position + direction * speed);



        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        var mask = LayerMask.GetMask("ground");
        if (Physics.Raycast(ray, out hit, mask))
        {
            if (!hit.transform.CompareTag("Player"))
            {
                mouseHit.transform.position = hit.point;
                transform.LookAt(new Vector3(hit.point.x,transform.position.y,hit.point.z));
            }
            
        }


    }
}