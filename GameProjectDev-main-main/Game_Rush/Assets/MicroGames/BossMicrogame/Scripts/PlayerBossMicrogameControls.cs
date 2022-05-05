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
    [SerializeField]
    float lazerRange = 1;

    public LayerMask thisEnemy;
    public Transform camLoc;

    Renderer enemyFlash;

    LineRenderer lazerView;
    public Transform lazerOrigin;
    public float lazerTimer = 0;
    float displayTime = 0.05f;

    RaycastHit hit;
    Ray ray;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lazerView = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = transform.position;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(h * speed, v * speed, 0);
        if (transform.position.y < (camLoc.position.y - 9))
        {
            SceneManager.LoadScene(8);
        }
        lazerTimer += Time.deltaTime;
        if (Input.GetButtonDown("Jump/Fire"))
        {
            lazerTimer = 0;
            lazerView.SetPosition(0, lazerOrigin.position);
            lazerView.enabled = true;
            if (Physics.Raycast(lazerOrigin.position, transform.TransformDirection(Vector3.up), out hit, range, thisEnemy))
            {
                lazerView.SetPosition(1, hit.point);
                BossMicrogameHealth enemyHeal = hit.collider.GetComponent<BossMicrogameHealth>();
                enemyFlash = hit.collider.GetComponent<Renderer>();
                enemyHeal.health--;
                StartCoroutine(HitFlash());
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);
            }
            if (Physics.Raycast(lazerOrigin.position, transform.TransformDirection(Vector3.up), out hit, lazerRange))
            {
                lazerView.SetPosition(1, hit.point);
            }
        }
        if (lazerTimer >= displayTime)
        {
            lazerView.enabled = false;
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

    IEnumerator HitFlash()
    {
        enemyFlash.enabled = false;
        yield return new WaitForSeconds(0.1f);
        enemyFlash.enabled = true;
    }
}
