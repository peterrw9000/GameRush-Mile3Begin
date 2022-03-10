using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelCollider : MonoBehaviour {

    public EnemySpawner enemySpawner;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "FightZone") {
            Debug.Log("Triggered Fight!");
            enemySpawner.WaveSpawn();            
        }
    }
}
