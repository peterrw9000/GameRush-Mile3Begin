using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("GameManager");
        gm = go.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToGame()
    {
        gm.ResetLives();
        SceneManager.LoadScene("Level");
    }
}
