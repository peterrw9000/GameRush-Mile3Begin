using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour {

    public GameObject[] bossGuns;
    public Slider enemyHPBar;
    public BossCore[] bossCores;
    public GameObject explosion;
    public GameObject victory;
    public AudioManager audioManager;
    public AudioClip bossMusic;

    public int startingHealth = 10;
    public int currentHealth;
    public int activeCore;
    public float attackTimer;
    public float timeTillAttack;    

    SkinnedMeshRenderer[] skinnedMeshRenderers = new SkinnedMeshRenderer[3];
    Renderer[] renderers = new Renderer[3];
    int[] randomCores = new int[] { 0, 2 };
    float colorLerp;
    
    int[] damageToCores = new int[] { 0, 0, 0 };
    int hitCount = 0;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }


    void Start() {
        currentHealth = startingHealth;
        for (int i = 0; i < (bossCores.Length); i++) {
            skinnedMeshRenderers[i] = bossCores[i].GetComponent<SkinnedMeshRenderer>();
        }
        ChooseActiveCore();
        attackTimer = 0;
        timeTillAttack = 10;
        StartCoroutine (audioManager.ChangeBGM2(bossMusic));
        //audioManager.ChangeBGM(bossMusic);
    }

    void Update() {
        if (Input.GetKeyDown("x")) {
            Attack();
/*            foreach (GameObject bossGun in bossGuns) {
                var BA = bossGun.GetComponent<BossAttack>();
                BA.Shoot();
            }*/
        }

        for (int i = 0; i < 10; ++i) {
            if (Input.GetKeyDown("" + i)) {
                ActivateGivenCore(i);
            }
        }

        for (int i = 0; i < (bossCores.Length); i++) {
            if (activeCore == i) {
                skinnedMeshRenderers[i].material.color = Color.Lerp(Color.white, Color.red, colorLerp);
            }
        }
        colorLerp = Mathf.PingPong(Time.time, .3f) / .3f;

        attackTimer += Time.deltaTime;

        if (attackTimer > timeTillAttack){
            if (hitCount < 10) {
                Attack();
            }
            else if (activeCore == 1) {
                Attack();
            } else {
                ChooseActiveCore();
                attackTimer = 0;
                hitCount = 0;
            }
        }
    }

    void Attack() {
        if (activeCore == 2) {
            for (int i = 0; i <= 2; i++) {
                var BA = bossGuns[i].GetComponent<BossAttack>();
                BA.Shoot();
            }
        } else if (activeCore == 0) {
            for (int i = 3; i <= 5; i++) {
                var BA = bossGuns[i].GetComponent<BossAttack>();
                BA.Shoot();
            }
        } else {
            for (int i = 0; i <= 5; i++) {
                var BA = bossGuns[i].GetComponent<BossAttack>();
                BA.Shoot();
            }
        }
        attackTimer = 0;
        hitCount = 0;
        ChooseActiveCore();
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        enemyHPBar.value = (float)currentHealth / startingHealth;
        hitCount++;
        damageToCores[activeCore]++;
        Debug.Log(damageToCores[activeCore]);

        if (currentHealth <= 0) {
            Instantiate(victory);
            Death();
        }
    }

    public void Death() { 
        Explode();
        Destroy(gameObject, .2f);
    }



    void Explode() {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    void ActivateCenterCore() {
        ActivateGivenCore(1);
    }
    
    void ActivateGivenCore(int c) {
        activeCore = c;
        for (int i = 0; i < (renderers.Length); i++) {
            if (activeCore != i) {
                skinnedMeshRenderers[i].material.color = Color.red;
            }
        }
    }
    void ChooseActiveCore() {

        if (damageToCores[0] >= 20 && damageToCores[2] >= 20) {
            ActivateCenterCore();
            return;
        }

        var core = randomCores[Random.Range(0, randomCores.Length)];
        if (core == 0) {
            if (damageToCores[core] < 21) {
                ActivateGivenCore(core);
            }
            else {
                ActivateGivenCore(2);
            }
        }
        if (core == 2) {
            if (damageToCores[core] < 21) {
                ActivateGivenCore(core);
            }
            else {
                ActivateGivenCore(0);
            }
        }
    }
}