using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBossMicrogameControls : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    [SerializeField]
    float range = 1;

    RaycastHit hit;
    Ray ray;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = transform.position;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(h * speed, v * speed, 0);
        if (Input.GetButtonDown("Jump/Fire"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.DrawRay(transform.position, Vector3.up * range, Color.green);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Enemy")
            {
                HealthTest enemyHeal = hit.collider.GetComponent<HealthTest>();
                enemyHeal.health--;
            }
        }
    }
}
