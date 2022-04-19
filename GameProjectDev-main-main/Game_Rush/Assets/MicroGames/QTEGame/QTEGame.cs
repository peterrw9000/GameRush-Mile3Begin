using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEGame : MonoBehaviour
{
    public Text inputNeeded;
    public Text timerInfo;
    public Text inputCount;
    int randomInput;
    int inputsConfirmed = 0;
    int inputsRequired = 0;
    float timer = 2000f;
    bool inputsFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.inputsRequired = 5;
        randomInput = Random.Range(1, 5);
        SetInput();
    }

    // Update is called once per frame
    void Update()
    {
        timerInfo.text = timer.ToString("F0") + " Parsecs";
        inputCount.text = inputsConfirmed + "/" + GameManager.instance.inputsRequired;
        if (inputsFinished != true)
        {
            timer -= Time.deltaTime * 100;
            if (Input.GetButtonDown("QTEInput" + randomInput))
            {
                inputsConfirmed += 1;
                if (inputsConfirmed == GameManager.instance.inputsRequired)
                {
                    inputsFinished = true;
                    inputNeeded.text = "DONE";
                }
                else
                {
                    randomInput = Random.Range(1, 5);
                    SetInput();
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                timer = 2000f;
                inputsConfirmed = 0;
                inputsRequired += 1;
                inputsFinished = false;
                randomInput = Random.Range(1, 5);
                SetInput();
            }
        }
    }

    void SetInput()
    {
        if (randomInput == 1)
        {
            inputNeeded.text = "W";
        }
        else if (randomInput == 2)
        {
            inputNeeded.text = "A";
        }
        else if (randomInput == 3)
        {
            inputNeeded.text = "S";
        }
        else if (randomInput == 4)
        {
            inputNeeded.text = "D";
        }
    }
}
