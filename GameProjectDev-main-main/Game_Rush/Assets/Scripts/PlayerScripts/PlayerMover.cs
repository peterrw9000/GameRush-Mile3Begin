using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public int enemiesDestroyed = 0;
    [SerializeField] int maxScore = 0;
    public EnemySpawner enemySpawner;
    Animator anim;
    [SerializeField] int enemies;
    [SerializeField] float timer = 1.0f;
    [SerializeField] bool timerStarted = true;
    public bool playerMoved = false;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemies = enemySpawner.enemiesList.Count;
        if (enemiesDestroyed > maxScore) {
            enemiesDestroyed = maxScore;
        }
        if (enemiesDestroyed == maxScore) {
            StartTimer();
        }

        if (Input.GetKeyDown("m")) {
            MovePlayer();
        }
        if (timerStarted == true) {
            timer -= Time.deltaTime;
        }
        if (timer <= 0) {
            if (!playerMoved) {
                MovePlayer();
                timerStarted = false;
            }
        }
    }

    void StartTimer() {
        timerStarted = true;
    }

    int CalcMaxScore() {
        maxScore += enemySpawner.waveSizeArray[enemySpawner.waveKey];
        return maxScore;
    }


    public void MovePlayer() {
        anim.SetTrigger("movePlayer");
        if (anim.speed == 0.0f) {
            anim.speed = 1f;
        }
        Debug.Log("Moving Player!");
        playerMoved = true;
        //Debug.Break();
    }

    public void PausePlayer(){
        anim.speed = 0.0f;
        timerStarted = false;
        timer = 1.0f;
        CalcMaxScore();
    }
}

/*public void () {
    StartCoroutine(XX());
}

IEnumerator XX() {*/
