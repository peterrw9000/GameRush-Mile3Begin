using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public int verticalOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        Vector3 mousePosition = Input.mousePosition;
        //transform.position = mousePosition;
        transform.position = new Vector3(mousePosition.x, mousePosition.y+ verticalOffset, mousePosition.z);
    }
}
