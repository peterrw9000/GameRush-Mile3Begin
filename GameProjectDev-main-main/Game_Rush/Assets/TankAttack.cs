using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    
    [SerializeField]
    float fireRate = 3.50f;

    // [SerializeField]
    // float attackRange = 60f;

    float timer;

    [SerializeField]
    GameObject rocket;

    [SerializeField]
    GameObject player;

    [SerializeField]
    public Animator animator;

    bool inRangeOfPlayer;

    //TankMovement tankMovement;

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
        player = GameObject.FindGameObjectWithTag("Player");
        //tankMovement = GetComponent<TankMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            TankFire();
        }

        
   
    }

    void TankFire()
    {
        if(Time.time > timer )
        {
            Instantiate(rocket, transform.position, transform.rotation);
            timer = Time.time + fireRate;
           // animator.SetBool("Firing", true);
            
           
        }
        /*else
        {
            animator.SetBool("Firing", false);
        }*/
        
    }


  
/*
    private void OnTriggerEnter(Collider other)
    {
        if (player.gameObject.tag == "player")
        {
            inRangeOfPlayer = true;
            
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (player.gameObject.tag == "player")
        {
            inRangeOfPlayer = false;
            
            
        }
    }

*/

}
