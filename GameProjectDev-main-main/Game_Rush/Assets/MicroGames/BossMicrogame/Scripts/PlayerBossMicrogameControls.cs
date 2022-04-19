using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBossMicrogameControls : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    [SerializeField]
    float range = 1;

    public LayerMask thisEnemy;

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
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, range, thisEnemy))
            {
                BossMicrogameHealth enemyHeal = hit.collider.GetComponent<BossMicrogameHealth>();
                enemyHeal.health--;
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lazer" || other.tag == "Shield")
        {
            if (GameManager.instance.playerLives <= 0)
            {
                SceneManager.LoadScene(8);
            }
            else
            {
                GameManager.instance.playerLives--;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "DeathWall")
        {
            SceneManager.LoadScene(8);
        }
    }
}
