using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public int enemiesDestroyed = 0;
    public EnemySpawner enemySpawner;
    Animator anim;
    [SerializeField] int enemies;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemies = enemySpawner.enemiesList.Count;

        if (enemiesDestroyed >= enemySpawner.enemiesList.Count) {
            MovePlayer();
        }

        if (Input.GetKeyDown("m")) {
            MovePlayer();
        }
    }

    public void MovePlayer() {
        anim.SetTrigger("movePlayer");
        if (anim.speed == 0.0f) {
            anim.speed = 1f;
        }
    }

    public void PausePlayer(){
        anim.speed = 0.0f;
    }
}
