using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMicrogameAttack : MonoBehaviour
{
    //int damage;
    float attackTimer = 0;
    float wallAttackTimer = 0;
    float shieldAttackTimer = 0;

    bool wallAttackFinished = false;
    bool shieldAttackFinished = true;

    public float speed;
    public float wallSpeed;

    float xdirection;

    public GameObject warning;
    public Transform LazerSpawn;
    public Rigidbody lazer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= 3)
        {
            warning.SetActive(true);
            if (attackTimer >= 4)
            {
                lazerFire();
                warning.SetActive(false);
                attackTimer = 0;
            }
        }
        if (shieldAttackFinished == true)
        {
            wallAttackTimer += Time.deltaTime;
            if (wallAttackTimer >= 10)
            {

                //if ()
                //wallAttackFinished = true;
            }
        }
        if (wallAttackFinished == true)
        {
            shieldAttackTimer += Time.deltaTime;
            if (shieldAttackTimer >= 5)
            {
                shieldAttackFinished = false;
            }
        }
    }

    void lazerFire()
    {
        Rigidbody enemyLazer;
        enemyLazer = Instantiate(lazer, LazerSpawn.position, LazerSpawn.rotation) as Rigidbody;
        enemyLazer.AddForce(Vector3.down * speed);
    }
}
