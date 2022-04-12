using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
    public GameObject[] bossGuns;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("x")) {
            foreach (GameObject bossGun in bossGuns) {
                var BA = bossGun.GetComponent<BossAttack>();
                BA.Shoot();
            }
        }
    }
}
