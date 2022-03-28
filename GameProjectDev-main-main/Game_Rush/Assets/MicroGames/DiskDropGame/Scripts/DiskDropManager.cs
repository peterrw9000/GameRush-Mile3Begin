using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskDropManager : MonoBehaviour
{
    public GameObject[] disksArray;
    public int diskNum = 0;
    int diskArrayLength;
    public Transform[] targets;
    int targetIndex = 0;
    Transform currentTarget;
    float speed = 5;
    float dist = 1;
    MicroGameManager microGameManager;
    AudioManager audioManagement;
    AudioSource discDroppedSound;
    float positionA;
    float positionB;
    bool movingR;
    float force = 2.0f;

    private void Awake()
    {
        audioManagement = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        positionA = transform.position.x;
    }

    void Start() {
        updateTarget();
        diskArrayLength = disksArray.Length;
        GameObject go = GameObject.Find("MicroGameContainer");
        microGameManager = go.GetComponent<MicroGameManager>();
        discDroppedSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentTarget.position, 
            (speed * Time.deltaTime)/Vector3.Distance(transform.position, currentTarget.position)
            );

        if (Vector3.Distance(transform.position, currentTarget.position) < dist) {
            targetIndex++;
            if (targetIndex >= targets.Length) {
                targetIndex = 0;
            }
            updateTarget();
        }

        if (Input.GetKeyDown("space") && diskNum < 4) {
            SpawnDisk();
            diskNum++;
            discDroppedSound.PlayOneShot(audioManagement.soundEffects[3]);
            if (diskNum >= diskArrayLength) {
                StartCoroutine(CountDown());
            }
        }        
    }

    void LateUpdate() {
        positionB = transform.position.x;
        if (positionB > positionA) {
            movingR = true;
        }
        else {
            movingR = false;
        }
        positionA = transform.position.x;
    }

    void SpawnDisk() {

        Rigidbody rb;

        GameObject newDisk = Instantiate(disksArray[diskNum], transform.position, transform.rotation)
        as GameObject;
        rb = newDisk.GetComponent<Rigidbody>();
        if (movingR) {
            rb.AddForce(0, 0, force, ForceMode.Impulse);
        }
        else {
            rb.AddForce(0, 0, -force, ForceMode.Impulse);
        }
    }


    IEnumerator CountDown() {
        yield return new WaitForSeconds(2f);
        microGameManager.SetActiveGame(0);
        diskNum = 0;
    }

    void updateTarget() {
        currentTarget = targets[targetIndex];
    }
}
