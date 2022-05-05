using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Text countdown;

    float timer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        countdown.text = "Entering The Final Battle In " + timer.ToString("F2");
        if (timer <= 0)
        {
            SceneManager.LoadScene(10);
        }
    }
}
