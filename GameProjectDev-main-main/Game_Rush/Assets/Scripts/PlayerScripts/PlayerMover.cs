using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public int enemiesDestroyed = 0;
    public EnemySpawner enemySpawner;
    Animator anim;
    [SerializeField] int enemies;
    [SerializeField] float timer = 1.0f;
    [SerializeField] bool timerStarted = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemies = enemySpawner.enemiesList.Count;
        if (enemiesDestroyed >= enemies) {
            StartTimer();
        }

        if (Input.GetKeyDown("m")) {
            MovePlayer();
        }
        if (timerStarted == true) {
            timer -= Time.deltaTime;
        }
        if (timer <= 0) {
            MovePlayer();
        }
    }

    void StartTimer() {
        timerStarted = true;
    }


    public void MovePlayer() {
        anim.SetTrigger("movePlayer");
        if (anim.speed == 0.0f) {
            anim.speed = 1f;
        }
    }

    public void PausePlayer(){
        anim.speed = 0.0f;
        timerStarted = false;
        timer = 1.0f;
    }
}

/*public void () {
    StartCoroutine(XX());
}

IEnumerator XX() {*/
