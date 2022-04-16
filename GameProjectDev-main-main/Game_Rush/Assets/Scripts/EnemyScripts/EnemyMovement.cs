using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    int targetIndex = 0;
    Transform currentTarget;
    public float speed = 5;
    float dist = 1;
    [SerializeField]
    float moveTimer = 0f;
    public float timeTillAttack = 10f;
    Transform player;

    public bool paused;
    bool attackPlayer;
    bool bossHover;

    void OnPauseGame() {
        paused = true;
    }

    void OnResumeGame() {
        paused = false;
    }

    // Start is called before the first frame update
    void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        updateTarget();
    }

    public void SetPoint(Transform t) {
        targets.Add(t);
    }


    // Update is called once per frame
    void Update() {
        if (!paused){ 
            Move();         
            moveTimer += Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        if (moveTimer >= timeTillAttack) {
            updateTarget();
        }
    }

    

    void Move() {
        transform.position = Vector3.Lerp(transform.position, currentTarget.position,
        (speed * Time.deltaTime) / Vector3.Distance(transform.position, currentTarget.position)
        );

        if (Vector3.Distance(transform.position, currentTarget.position) < dist) {
            targetIndex++;
            if (targetIndex >= targets.Count) {
                if (TryGetComponent(out EnemyAttackRanged eAR) || TryGetComponent(out KnightAttack ka)) {
                    targetIndex = 0;
                } else if (TryGetComponent(out BossHealth bH)) {
                    bossHover = true;
                    //Debug.Log("Fighting Boss");
                } else {
                    attackPlayer = true;
                }
            }
            updateTarget();
        }
    }

    void updateTarget() {
        if (
            //moveTimer <= timeTillAttack
            !attackPlayer && !bossHover) {
            currentTarget = targets[targetIndex];
        }
        else if (bossHover) {
            currentTarget = targets[1];
        }
        else {
            currentTarget = player;
        }
    }
}
