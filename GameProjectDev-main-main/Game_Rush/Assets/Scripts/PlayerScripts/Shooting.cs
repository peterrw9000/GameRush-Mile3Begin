using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    int laserDPS = 1;

    [SerializeField]
    int weakSpotHit;

    [SerializeField]
    float range = 100;

    [SerializeField]
    float fireRate = 0.5f;

    public Camera playerCam;
    public Transform laserOrigin;
    public Image aimer;

    [SerializeField]
    Image overHeat;

    bool overheated = false;
    float temperature = 0;
    
    float timer;

    LineRenderer laserFire;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    EnemyHealth enemyHealth;

    float effectdisplay = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        laserFire = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (Input.GetButton("Fire1") && (timer >= fireRate) && Time.timeScale != 0 && overheated == false)
        {
            Shoot();

            //work in progress
            OverHeat();
        }
        if (timer >= laserDPS * effectdisplay)
        {
            laserFire.enabled = false;
        }
        if (overheated == true)
        {
            temperature -= 1;
            if (temperature <= 0)
            {
                overheated = false;
            }
        }
    }

    public void Shoot()
    {
        timer = 0f;
        laserFire.SetPosition(0, laserOrigin.position);
        laserFire.enabled = true;
        Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0));

        if (Physics.Raycast(rayOrigin, aimer.transform.position, out shootHit, range))
        {

            //enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();

            //aimer.transform.position
            laserFire.SetPosition(1, shootHit.point);
/*            EnemyWeakspot weakspot = shootHit.collider.GetComponent<EnemyWeakspot>();
            if(weakspot != null)
            {
                weakspot.DamageToEnemy(laserDPS);
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(laserDPS);
                }
            }
            laserFire.SetPosition(1, shootHit.point);
        }
        else
        {*/
            laserFire.SetPosition(1, rayOrigin + (playerCam.transform.forward * range));
        }
    }

    public void OverHeat()
    {
        temperature = temperature + fireRate + 1;
        //overHeat.fillAmount = fireRate + 1;
        if (temperature >= 100)
        {
            overheated = true;
        }
    }
}

