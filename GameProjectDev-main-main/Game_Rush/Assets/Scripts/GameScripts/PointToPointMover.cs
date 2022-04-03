using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPointMover : MonoBehaviour {
    public Transform[] targets;
    int targetIndex = 0;
    Transform currentTarget;
    public float speed = 5;
    [SerializeField]
    float dist = 1;

    // Start is called before the first frame update
    void Start()
    {
        updateTarget();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        transform.position = Vector3.Lerp(transform.position, currentTarget.position,
(speed * Time.deltaTime) / Vector3.Distance(transform.position, currentTarget.position)
);

        if (Vector3.Distance(transform.position, currentTarget.position) < dist) {
            targetIndex++;
            if (targetIndex >= targets.Length) {
                targetIndex = 0;
            }
            updateTarget();
        }
    }

    void updateTarget() {
            currentTarget = targets[targetIndex];       
    }
}
