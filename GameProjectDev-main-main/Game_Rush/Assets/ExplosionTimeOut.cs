using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTimeOut : MonoBehaviour
{
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2.0) {
            Destroy(gameObject);
        }
    }
}
