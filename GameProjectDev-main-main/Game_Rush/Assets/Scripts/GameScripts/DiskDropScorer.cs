using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskDropScorer : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;
    PlayerHealth playerHealth;
    //public int timesActive;
    public int score;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Cylinder") {
            playerHealth.currentHealth += 25;
            playerHealth.CalcHealthSlider();
            score++;
        }
        if (score % 4 == 0) {
            playerHealth.timer = 4;
            playerHealth.StartTimer();
        }
    }
}
