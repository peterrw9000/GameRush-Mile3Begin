using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
//[RequireComponent(typeof(Rigidbody))]
public class HomingRocket : MonoBehaviour
{
    [SerializeField]
    int rocketDam = 50;

    [SerializeField]
    float rocketSpeed = 5.50f;

  /*  [SerializeField]
    float rotateSpeed = 200f;*/

    public int rocketHP = 2;

   // [SerializeField]
   // float rocketLife = 1f;

    
    Transform targetPlayer;

    PlayerHealth playerHealth;

    Rigidbody rb;

    public bool paused;
    void OnPauseGame()
    {
        paused = true;
    }

    void OnResumeGame()
    {
        paused = false;
    }



    // Start is called before the first frame update
    void Start()
    {
            rb = GetComponent<Rigidbody>();

            targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!paused)
        {
            if (targetPlayer != null)
            {
                /*Vector3 targetDirect = targetPlayer.position - rb.position;

                targetDirect.Normalize();

                Vector3 rotateAmount = Vector3.Cross(transform.forward, targetDirect);

                rb.angularVelocity = rotateAmount * rotateSpeed;

                rb.velocity = transform.forward * rocketSpeed;*/

                transform.LookAt(targetPlayer);

                rb.velocity = transform.forward * rocketSpeed;

                rb.WakeUp();
                
            }
            
            
        }
        else
        {
            rb.Sleep();
        }
       
       
    }
   
    public void RocketDamage(int Dmg)
    {
        rocketHP -= Dmg;

        if(rocketHP <=0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        
        if(col.gameObject.tag == "Player")
        {
            playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(rocketDam);
            //add rocketlife after gameobject only if you want to.
            Destroy(gameObject);
        }
        
    }
  

    
}

