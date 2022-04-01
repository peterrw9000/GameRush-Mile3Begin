using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitFlash : MonoBehaviour
{
    public SkinnedMeshRenderer[] enemyParts;
    //EnemyHealth eHealth;

    // Start is called before the first frame update
    void Start()
    {
        //eHealth = GetComponentInParent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnMeshOff()
    {
        foreach (var f in enemyParts)
        {
            f.enabled = false;
        }
    }
    public void TurnMeshOn()
    {
        foreach (var o in enemyParts)
        {
            o.enabled = true;
        }
    }
}
