using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRanged : MonoBehaviour
{
    Renderer renderer;
    float colorLerp;
    float timeSinceAwake = 0;
    public int timeTillAttack = 3;
    public float timeAttack = 0;
    public int attackDamage = 10;
    LineRenderer shootLine;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    Transform weakPoint;
    public float shootingDelay = 1f;
    float shootingTimer = 0f;
    AudioManager audioManagement;
    AudioSource enemyLaserSound;

    public bool paused;
    void OnPauseGame() {
        paused = true;
    }

    void OnResumeGame() {
        paused = false;
    }

    private void Awake()
    {
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
        enemyHealth = GetComponent<EnemyHealth>();
        enemyLaserSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (!paused)
        {
            timeAttack += Time.deltaTime;
            if (enemyHealth.grounded == true && timeAttack >= 3)
            {
                shootingTimer += Time.deltaTime;
                if (shootingTimer >= shootingDelay && Time.timeScale != 0)
                {
                    //colorLerp = Mathf.PingPong(Time.time, .3f) / .3f;
                    Shoot();
                }
            }
            //renderer.material.color = Color.Lerp(Color.white, Color.red, colorLerp);
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
            //Debug.Break();
        }
    }
}
