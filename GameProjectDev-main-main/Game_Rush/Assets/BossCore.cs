using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCore : MonoBehaviour
{
    public BossHealth bossHealth;
    public int coreNum;
    PlayerShooting playerShooting;

    public void TryDamage(int damage) {
        if (bossHealth.activeCore == coreNum) {
            bossHealth.TakeDamage(damage);
            playerShooting.DisplayDamageText(playerShooting.laserDPS);
        }
    }

    private void Awake() {
        playerShooting = FindObjectOfType<PlayerShooting>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
