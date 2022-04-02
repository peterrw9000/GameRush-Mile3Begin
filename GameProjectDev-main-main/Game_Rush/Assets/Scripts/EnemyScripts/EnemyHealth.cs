using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 10;
    public int currentHealth;

    bool isDead = false;
    public bool grounded = false;

    public PlayerMover playerMover;
    public GameObject explosion;
    public Slider enemyHPBar;

    AudioManager audioManagement;
    AudioSource enemyDeathSounds;
    EnemyHitFlash hitFlash;

    public Transform groundCheck;
    public LayerMask whatGround;
    RaycastHit hit;
    public float range = 0.5f;

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
        hitFlash = GetComponent<EnemyHitFlash>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(groundCheck.position, Vector3.down, range, whatGround))
        {
            grounded = true;
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint) {
        currentHealth -= amount;

        if (currentHealth <= 0) {
            Death();
        }
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        hitFlash.TurnMeshOff();
        hitFlash.Invoke("TurnMeshOn", 0.1f);
        if (currentHealth <= 0 && !isDead) {
            playerMover.enemiesDestroyed++;
            Death();            
            isDead = true;
        }
        enemyHPBar.value = (float)currentHealth / startingHealth;
    }

    public void Death() {
        if(gameObject.GetComponent<EnemyAttackRanged>() != null)
        {
            enemyDeathSounds.PlayOneShot(audioManagement.soundEffects[7]);
        }
        else
        {
            enemyDeathSounds.PlayOneShot(audioManagement.soundEffects[6]);
        }        
        Explode();
        Destroy(gameObject, .2f);
    }

    void Explode() {
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
