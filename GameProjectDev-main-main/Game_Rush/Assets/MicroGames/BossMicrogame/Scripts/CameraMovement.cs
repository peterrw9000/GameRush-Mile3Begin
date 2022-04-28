using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform camView;

    public Transform targetSpot;

    [SerializeField]
    float speed;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            if (camView.transform.position.y <= -104)
            {
                speed += 0.0011f;
            }
            camView.transform.position = Vector3.Lerp(camView.transform.position, targetSpot.position, speed * Time.deltaTime);
        }
    }
}
