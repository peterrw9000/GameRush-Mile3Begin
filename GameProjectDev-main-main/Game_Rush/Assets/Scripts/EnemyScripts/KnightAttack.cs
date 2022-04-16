using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    Renderer renderer;
    float colorLerp;
    float timeSinceAwake = 0;
    public float timeTillAttack = 1;
    public float timeAttack = 0;
    public int attackDamage = 10;
    LineRenderer shootLine;
    GameObject player;
    PlayerHealth playerHealth;
    Transform weakPoint;
    float shootingDelay = .75f;
    float shootingTimer = 0f;
    AudioManager audioManagement;
    AudioSource enemyLaserSound;
    Animator knightAnimator;


    public bool paused;
    void OnPauseGame() {
        paused = true;
    }

    void OnResumeGame() {
        paused = false;
    }

    private void Awake() {
        audioManagement = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject soldierBody = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        renderer = soldierBody.GetComponent<Renderer>();
        weakPoint = this.gameObject.transform.GetChild(0).GetChild(1);
        shootLine = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyLaserSound = GetComponent<AudioSource>();
        knightAnimator = GetComponentInChildren<Animator>();

        timeTillAttack = 1;
        timeAttack = 0;
}



    // Update is called once per frame
    void Update() {
        if (knightAnimator.GetCurrentAnimatorStateInfo(0).IsName("shield_OPEN02")) {
            Debug.Log("Opening Shield");
            timeAttack += Time.deltaTime;
        }

        if (!paused) {
            if (timeAttack > timeTillAttack) {
                Shoot();
            }
            if (Input.GetKeyDown("k")) {
                Shoot();
            }
        }
        if (shootingTimer > .5f) {
            shootLine.enabled = false;
        }
        if (shootingTimer < 1f) { 
            shootingTimer += Time.deltaTime;
        }
    }

    void Shoot() {
        if (!paused) {
            enemyLaserSound.PlayOneShot(audioManagement.soundEffects[1]);
            shootLine.enabled = true;
            shootLine.SetPosition(0, weakPoint.position);
            shootLine.SetPosition(1, player.transform.position);
            playerHealth.TakeDamage(attackDamage);
            shootingTimer = 0;
            timeAttack = 0;
            //Debug.Break();
        }
    }

}
