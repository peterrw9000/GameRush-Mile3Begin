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
    bool wallAttackEnding = false;
    bool shieldAttackFinished = true;
    /*bool shieldAttackStarting = false;
    bool shieldAttackEnding = false;*/ //Unused variables

    int wallAttacking = 1;

    public float speed;
    public float wallSpeed;
    public float xdirection;

    public Transform deathWall1;
    public Transform deathWall2;

    public Collider shield1;
    public Collider shield2;
    public Renderer shieldEnergy1;
    public Renderer shieldEnergy2;

    public Transform camPosition;

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
        
    }

    void FixedUpdate()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= 3)
        {
            warning.SetActive(true);
            if (attackTimer >= 4)
            {
                LazerFire();
                warning.SetActive(false);
                attackTimer = 0;
            }
        }
        if (camPosition.position.y >= 55)
        {
            if (shieldAttackFinished == true)
            {
                wallAttackTimer += Time.deltaTime;
                if (wallAttackTimer >= 5)
                {
                    wallAttackFinished = false;
                    if (wallAttacking == 1)
                    {
                        deathWall1.transform.Translate(new Vector3(xdirection * wallSpeed, 0, 0));
                        if (deathWall1.position.x >= -11)
                        {
                            wallAttackEnding = true;
                            xdirection *= -1;
                        }
                        if (deathWall1.position.x == -40 && wallAttackEnding == true)
                        {
                            wallAttacking = 2;
                            wallAttackFinished = true;
                            shieldAttackFinished = false;
                            wallAttackTimer = 0;
                        }
                    }
                    else
                    {
                        if (deathWall2.position.x <= 11)
                        {
                            wallAttackEnding = true;
                            xdirection *= -1;
                            deathWall2.transform.Translate(new Vector3(xdirection * wallSpeed, 0, 0));
                        }
                        else
                        {
                            deathWall2.transform.Translate(new Vector3(xdirection * wallSpeed, 0, 0));
                        }
                        if (deathWall2.position.x == 40 && wallAttackEnding == true)
                        {
                            wallAttacking = 1;
                            wallAttackFinished = true;
                            shieldAttackFinished = false;
                            wallAttackTimer = 0;
                        }
                    }
                }
            }
            if (wallAttackFinished == true)
            {
                shieldAttackTimer += Time.deltaTime;
                if (shieldAttackTimer >= 2)
                {
                    ShieldAttack();
                }
            }
        }
    }

    void ShieldAttack()
    {
        shieldEnergy1.material.SetFloat("_fadetiming", 3);
        shieldEnergy2.material.SetFloat("_fadetiming", 3);
        shieldAttackFinished = false;
        if (shieldAttackTimer >= 4)
        {
            shieldEnergy1.material.SetFloat("_fadetiming", 0);
            shieldEnergy2.material.SetFloat("_fadetiming", 0);
            shieldAttackFinished = true;
            wallAttackFinished = false;
            shieldAttackTimer = 0;
        }
        if (shieldEnergy1.material.GetFloat("_fadetiming") >= 1)
        {
            shield1.enabled = true;
            shield2.enabled = true;
        }
        else
        {
            shield1.enabled = false;
            shield2.enabled = false;
        }
    }

    void LazerFire()
    {
        Rigidbody enemyLazer;
        enemyLazer = Instantiate(lazer, LazerSpawn.position, LazerSpawn.rotation) as Rigidbody;
        enemyLazer.AddForce(Vector3.down * speed);
    }
}


//Unused broken script:
        /*shieldAttackStarting = true;
        Color alphaColor = shieldEnergy1.material.color;
        while (shieldAttackStarting == true)
        {
            if (alphaColor.a == 1)
            {
                shieldAttackStarting = false;
                shieldAttackEnding = true;
            }
        }
        while (shieldAttackEnding == true)
        {
            if (alphaColor.a == 0)
            {
                shieldAttackTimer = 0;
                shieldEnergy1.material.SetFloat("_fadetiming", 0);
                shieldEnergy2.material.SetFloat("_fadetiming", 0);
                wallAttackFinished = false;
                shieldAttackFinished = true;
            }
        }*/
