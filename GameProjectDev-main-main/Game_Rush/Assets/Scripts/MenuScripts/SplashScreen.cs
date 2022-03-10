using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField]
    public static int sceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (sceneNumber == 0)
        {
            StartCoroutine(ToMainMenu());
        }
    }

    // Update is called once per frame
    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(2.5f);
        sceneNumber = 0;
        SceneManager.LoadScene("Main Menu");
    }




}
