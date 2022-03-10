using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 10;
    public int currentHealth;

    bool isDead = false;

    public PlayerMover playerMover;

    AudioManager audioManagement;
    AudioSource enemyDeathSounds;

    private void Awake()
    {
        audioManagement = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        playerMover = FindObjectOfType<PlayerMover>();
        enemyDeathSounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount, Vector3 hitPoint) {
        currentHealth -= amount;

        if (currentHealth <= 0) {
            Death();
        }
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead) {
            Death();
            isDead = true;
        }
    }

    void Death() {
        if(gameObject.GetComponent<EnemyAttackRanged>() != null)
        {
            enemyDeathSounds.PlayOneShot(audioManagement.soundEffects[7]);
        }
        else
        {
            enemyDeathSounds.PlayOneShot(audioManagement.soundEffects[6]);
        }
        playerMover.enemiesDestroyed++;
        Destroy(gameObject, .2f);        
    }
}