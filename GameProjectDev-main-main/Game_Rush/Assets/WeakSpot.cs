using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class WeakSpot : MonoBehaviour
{
    [SerializeField]
    public int weakSpotDmg = 15; 

    // this will be whatever health scripts the enemies are sharing for testing it was tankhealth
    public EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // just replace tankHealth with the enemies script that they are sharing
    public void DamageToEnemy(int dmg)
    {
        dmg = weakSpotDmg;
        //tankHealth = gameObject.GetComponentInParent<TankHealth>();
        enemyHealth.TakeDamage(dmg);
        //Destroy(gameObject);
     
    }


}
