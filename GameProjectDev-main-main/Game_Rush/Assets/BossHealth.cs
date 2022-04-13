using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

    public GameObject[] bossGuns;
    public Slider enemyHPBar;
    public BossCore[] bossCores;

    public int startingHealth = 10;
    public int currentHealth;
    public int activeCore;

    Renderer[] renderers = new Renderer[3];
    int[] randomCores = new int[] { 0, 2 };
    float colorLerp;


    // Start is called before the first frame update
    void Start() {
        currentHealth = startingHealth;


        for (int i = 0; i < (bossCores.Length); i++) {
            renderers[i] = bossCores[i].GetComponent<Renderer>();
        }
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
                ActivateGivenCore(i);
            }
        }

        for (int i = 0; i < (bossCores.Length); i++) {
            if (activeCore == i) {
                renderers[i].material.color = Color.Lerp(Color.white, Color.red, colorLerp);
            }
        }
        colorLerp = Mathf.PingPong(Time.time, .3f) / .3f;
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        enemyHPBar.value = (float)currentHealth / startingHealth;
    }

    void ActivateCenterCore() {
        activeCore = 1;
    }
    
    void ActivateGivenCore(int c) {
        activeCore = c;
        for (int i = 0; i < (renderers.Length); i++) {
            if (activeCore != i) {
                renderers[i].material.color = Color.red;
            }
        }
    }
    void ChooseActiveCore() {
        ActivateGivenCore(randomCores[Random.Range(0, randomCores.Length)]);
    }
}

//colorLerp = Mathf.PingPong(Time.time, .3f) / .3f;
//renderers.material.color = Color.Lerp(Color.white, Color.red, colorLerp);