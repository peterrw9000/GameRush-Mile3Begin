using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    [SerializeField]
    float playerSpd = 3;

    [SerializeField]
    float jump = 6;

    [SerializeField]
    float disToGround = 1;

    [SerializeField]
    bool isGround = false;

    [SerializeField]
    GameObject DeathLine;

    Vector3 startingPos;

    Rigidbody rb;

    public GameObject playerContainer;

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

        rb.velocity = new Vector3(h * playerSpd, rb.velocity.y, v * playerSpd);

        if (isGround && Input.GetButtonDown("Jump"))
        {
            Jump();

        }
        GroundCheck();
        DeathLineAndRespawn();

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
    }

    
    void GroundCheck()
    {
        if(Physics.Raycast(transform.position, Vector3.down, disToGround + 0.1f))
        {          
               isGround = true;                   
        }
        else
        {            
            isGround = false;
        }
    }
    

    void DeathLineAndRespawn()
    {
        if(transform.position.y < DeathLine.transform.position.y)
        {
            transform.position = playerContainer.transform.position;
        }
    }

    /*
    void onCollisionEnter(Collision collision)
    {
        if(collision.GameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
    */

    /*
    void onCollisionEnter(Collision collision)
    {
        if(Collision.GameObject.tag == "Enemy")
        {
            Destory(GameObject);
        }
    }
    */
    
  
    

}
