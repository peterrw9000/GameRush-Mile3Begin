using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

    RaycastHit hit;
    Ray ray;

    int layerMask = 1 << 7;

    private void Start() {
        layerMask = ~layerMask;
    }

    void Update() {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask)) {

            transform.LookAt(hit.point);
        }

        float rotationX = transform.rotation.eulerAngles.x;

        if (rotationX < 330f && rotationX > 320f) {
            transform.rotation = Quaternion.Euler(330f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else if (rotationX > 10f && rotationX < 30f) {
            transform.rotation = Quaternion.Euler(10f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
