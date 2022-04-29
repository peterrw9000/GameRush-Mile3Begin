using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int inputsRequired = 0;
    public int playerLives = 5;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

     public void ResetLives() {
        playerLives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z")) {
            Debug.Break();
        }
    }
}
