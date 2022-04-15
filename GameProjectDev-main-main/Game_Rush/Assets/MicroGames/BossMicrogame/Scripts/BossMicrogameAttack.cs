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
    bool shieldAttackStarting = false;
    bool shieldAttackEnding = false;

    int wallAttacking = 1;

    public float speed;
    public float wallSpeed;

    public float xdirection;
    public float alphaTime;

    public Transform deathWall1;
    public Transform deathWall2;

    public Collider shield1;
    public Collider shield2;
    public Material shieldAlpha;

    public Transform shieldtest;

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
        if (camPosition.position.y >= 55)
        {
            if (shieldAttackFinished == true)
            {
                wallAttackTimer += Time.deltaTime;
                if (wallAttackTimer >= 10)
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
                    shieldAttackFinished = false;
                    shieldAttackStarting = true;
                    Color shieldColor = shieldAlpha.color;
                    while (shieldAlpha.color.a < 1 && shieldAttackStarting == true)
                    {
                        shieldColor.a += alphaTime * Time.deltaTime;
                        shieldAlpha.color = shieldColor;
                        if (shieldAlpha.color.a == 1)
                        {
                            shieldAttackStarting = false;
                            shieldAttackEnding = true;
                        }
                    }
                    while (shieldAlpha.color.a > 0 && shieldAttackEnding == true)
                    {
                        shieldColor.a -= alphaTime * Time.deltaTime;
                        shieldAlpha.color = shieldColor;
                        if (shieldAlpha.color.a == 0)
                        {
                            shieldAttackTimer = 0;
                            wallAttackFinished = false;
                            shieldAttackFinished = true;
                        }
                    }
                    if (shieldAlpha.color.a > 0)
                    {
                        shield1.enabled = true;
                    }
                    else
                    {
                        shield1.enabled = false;
                    }    
                }
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
