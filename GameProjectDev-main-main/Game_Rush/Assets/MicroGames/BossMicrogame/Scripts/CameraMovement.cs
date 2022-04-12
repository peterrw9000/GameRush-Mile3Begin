using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform camView;

    public Transform targetSpot;

    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camView.transform.position = Vector3.Lerp(camView.transform.position, targetSpot.position, speed * Time.deltaTime);
    }
}
