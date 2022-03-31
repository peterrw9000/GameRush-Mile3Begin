using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelCollider : MonoBehaviour {

    public EnemySpawner enemySpawner;
    public PlayerMover playerMover;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "FightZone") {
            Debug.Log("Triggered Fight!");
            enemySpawner.WaveSpawn();
            Invoke("SetPlayerMoved", 1.0f);
        }
    }

    void SetPlayerMoved() {
        playerMover.playerMoved = false;
    } 
}
