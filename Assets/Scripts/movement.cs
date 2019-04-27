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

    public float speed = 3;
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
        rb.MovePosition(transform.position + direction * Time.deltaTime);



        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");
        

    }
}