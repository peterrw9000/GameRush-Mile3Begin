using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

    public GameObject[] bossGuns;
    public Slider enemyHPBar;

    public int startingHealth = 10;
    public int currentHealth;
    public int activeCore;


    // Start is called before the first frame update
    void Start() {
        currentHealth = startingHealth;
    }


    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("x")) {
            foreach (GameObject bossGun in bossGuns) {
                var BA = bossGun.GetComponent<BossAttack>();
                BA.Shoot();
            }
        }

        for (int i = 0; i < 10; ++i) {
            if (Input.GetKeyDown("" + i)) {
                activeCore = i;
            }
        }
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        enemyHPBar.value = (float)currentHealth / startingHealth;
    }

}
