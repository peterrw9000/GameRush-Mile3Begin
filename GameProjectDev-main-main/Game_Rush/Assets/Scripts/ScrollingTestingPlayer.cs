using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTestingPlayer : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    [SerializeField]
    float jump = 1;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(h * speed, rb.velocity.y, v * speed);
        if (Input.GetButtonDown("Jump/Fire"))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
    }
}
