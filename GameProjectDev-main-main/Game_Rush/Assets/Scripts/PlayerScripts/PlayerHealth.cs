using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public bool isDead;
    public int damageTaken;
    public MicroGameManager microGames;
    public int playerLives = 5;
    public Text damageTakenText;

    ///public Image playerHPBar; 
    public Slider playerHPBar; 

    public float timer;
    [SerializeField] bool timerStarted = true;

    public bool paused;
    void OnPauseGame() {
        paused = true;
    }

    void OnResumeGame() {
        paused = false;
    }

    public void StartTimer() {
        timerStarted = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        damageTaken =  (currentHealth - startingHealth) * - 1;
        if (!paused) {
            DisplayGameText();
        }
        else {
            DisplayMicroGameText();
        }

        if (timerStarted == true) {
            timer -= Time.deltaTime;
        }
        if (timer < 0) {
            timerStarted = false;
        }
    }

    void DisplayGameText() {
        if (GetComponentInChildren<Text>().gameObject.activeInHierarchy) {
            damageTakenText.text = damageTaken.ToString() + " Damage Taken";
        }
    }
    void DisplayMicroGameText() {
        if (GetComponentInChildren<Text>().gameObject.activeInHierarchy) {
            damageTakenText.text = "Press SPACE to drop PWRBLK ";
        }
    }

    public void TakeDamage(int d) {
        if (timer < 0) {
            currentHealth -= d;
            if (currentHealth <= 0 && isDead == false) {
                Death();
            }
            ///playerHPBar.fillAmount = (float)currentHealth / startingHealth;
            CalcHealthSlider();
        }
    }

    public void CalcHealthSlider(){
        playerHPBar.value = (float)currentHealth / startingHealth;
    }

    public void Death() {
        GameManager.instance.playerLives--;
        //isDead = true;
        if (GameManager.instance.playerLives > 0) {
            microGames.SetActiveGame(0);
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
