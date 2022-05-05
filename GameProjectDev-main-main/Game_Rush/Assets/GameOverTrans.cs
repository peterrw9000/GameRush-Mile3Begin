using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverTrans : MonoBehaviour
{
    [SerializeField]
    CanvasGroup uIGroup;

    private bool fadeToGO = true;

    public bool fadeIn = false;
    public bool fadeOut = true;
    public bool isGameOver = false;
    public bool isEnable = true;
   

    public AudioSource gameOverAudio;

    EnemyMovement enemyMovement;
    EnemyAttackMelee enemyattackmelee;
    EnemyAttackRanged enemyattackranged;
    PlayerHealth playerHealth;

    PlayerMover playerMover;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverAudio = GetComponent<AudioSource>();
        enemyMovement = GetComponent<EnemyMovement>();
        playerMover = GetComponent<PlayerMover>();
        playerHealth = GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        if(fadeOut)
            FadeOut();

        if (fadeIn)
            FadeIn();

       // StopAll();

        //UIFade();
        if (Input.GetKeyDown(KeyCode.S) && isGameOver)
        {
            isGameOver = false;
            SceneManager.LoadScene(8);
            Debug.Log("S was pressed");
            gameOverAudio.Stop();
            
        }
    }

    public void UIFade()
    {
        if (fadeToGO)
        {
           
                if (uIGroup.alpha < 1)
                {
                    uIGroup.alpha += Time.deltaTime;
                    if (uIGroup.alpha >= 1)
                    {

                        fadeToGO = false;
                    }
                }
           
        }
        else if (!fadeToGO)
        {
            if (uIGroup.alpha >= 0)
            {
                uIGroup.alpha -= Time.deltaTime;
                if (uIGroup.alpha == 0)
                {

                    fadeToGO = false;
                }
            }

        }
    }

    public void FadeIn()
    {
        if (uIGroup.alpha < 1)
        {
            uIGroup.alpha += Time.deltaTime;
            if (uIGroup.alpha >= 1)
            {
                fadeIn = false;
               
                StartCoroutine (SceneTrans());
                //SceneManager.LoadScene("GameOver");
                //fadeToGO = false;
            }
        }
    }

    public void FadeOut()
    {
        if (uIGroup.alpha >= 0)
        {
            uIGroup.alpha -= Time.deltaTime;
            if (uIGroup.alpha == 0)
            {
                fadeOut = false;
                //fadeToGO = false;
            }
        }
    }

    IEnumerator SceneTrans()
    {

        isGameOver = true;
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene(8);
        gameOverAudio.Play();

       

    }

    void StopAll()
    {
        if(enemyMovement != null)
            enemyMovement.enabled = false;

        if(playerMover != null)
            playerMover.enabled = false;

        if (enemyattackmelee != null)
            enemyattackmelee.enabled = false;

        if (enemyattackranged != null)
            enemyattackranged.enabled = false;

        if (playerHealth != null)
            playerHealth.enabled = false;
        
    }
  
}
