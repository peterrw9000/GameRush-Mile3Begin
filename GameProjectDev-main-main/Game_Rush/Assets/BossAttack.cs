using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    GameObject player;
    AudioManager audioManagement;
    AudioSource enemyLaserSound;
    LineRenderer shootLine;
    PlayerHealth playerHealth;
    
    float timeAttack;

    public Transform gunEnd;

    public int attackDamage = 10;
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
        player = GameObject.FindGameObjectWithTag("Player");        
        shootLine = GetComponent<LineRenderer>();
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyLaserSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeAttack >= 0) { timeAttack -= Time.deltaTime;}
        if (timeAttack <= 0) { StopShot();}
    }

    public void Shoot() {
        if (!paused) {
            enemyLaserSound.PlayOneShot(audioManagement.soundEffects[1]);
            shootLine.enabled = true;
            shootLine.SetPosition(0, gunEnd.position);
            shootLine.SetPosition(1, player.transform.position);
            playerHealth.TakeDamage(attackDamage);
            timeAttack = 1f;
            //shootingTimer = 0;
            //Debug.Break();
        }
    }

    void StopShot() {
        shootLine.enabled = false;
    }
}
