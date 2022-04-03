using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //public Transform[] enemyStarts;
    //public Transform[] enemyEnds;

public class EnemySpawner : MonoBehaviour {
    public List<GameObject> enemiesList = new List<GameObject>();

    public GameObject[] enemyPrefabs;
    public Transform[] enemySpawns;
    public Transform[] enemyPositions;

    int[] enemyInts = {
            //1st Wave - 6
            0, 2, 3, 11,
            0, 6, 7, 17,
            0, 1, 1, 10,
            0, 7, 8, 10,
            0, 0, 1, 0,
            0, 8, 9, 0,
            //2nd Wave - 7
            0, 2, 13, 2,
            0, 6, 15, 8,
            0, 1, 11, 1,
            0, 7, 17, 9,
            1, 4, 5, 14,
            0, 0, 10, 0,
            0, 8, 10, 0,
            //3rd Wave - 9
            1, 4, 5, 14,
            1, 3, 4, 3,
            1, 5, 6, 7,
            0, 2, 3, 13,
            0, 6, 7, 15, 
            0, 1, 2, 18,
            0, 7, 8, 18, 
            0, 0, 1, 18,
            0, 8, 9, 18, 
            //4th Wave - 8
            2, 6, 8, 18,
            2, 2, 2, 18,
            1, 4, 5, 14,
            1, 3, 4, 12,
            1, 5, 6, 16,            
            1, 5, 6, 16,
            1, 3, 4, 12,
            1, 4, 5, 14,
            //5th Wave - 6
            4, 3, 12, 11,
            4, 5, 16, 17,
            3, 1, 11, 18,
            3, 7, 17, 18,
            0, 2, 2, 10,
            0, 6, 8, 10,
            //6th Wave - 3
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            //7th Wave - 4
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            //8th Wave - 5
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            //9th Wave - 6
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            //10 Wave - 7
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
            0, 1, 0, 1,
                       };
    public readonly int[] waveSizeArray = { 6, 7, 9, 8, 6, 3, 4, 5, 6, 7 };
    int spawnKey = 0;
    public int waveKey = 0;

    protected bool paused;
    void OnPauseGame() {
        paused = true;
        Debug.Log("Pause!");
    }

    void OnResumeGame() {
        paused = false;
        Debug.Log("Unpause!");
    }

    void SpawnEnemy(int type, int spawnPosition, int positionOne, int positionTwo) {
        GameObject newEnemy = Instantiate(
            enemyPrefabs[type],
            enemySpawns[spawnPosition]
            ) as GameObject;

        enemiesList.Add(newEnemy);

        newEnemy.GetComponent<EnemyMovement>().SetPoint(enemyPositions[positionOne]);
        newEnemy.GetComponent<EnemyMovement>().SetPoint(enemyPositions[positionTwo]);
    }

    public void WaveSpawn() {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn() {        
        int waveSize = waveSizeArray[waveKey];
        if (spawnKey >= enemyInts.Length) {
            yield break;
        }
        for (int i = 1; i <= waveSize; i++) {
            yield return new WaitWhile(() => paused);
                SpawnEnemy(enemyInts[spawnKey], enemyInts[spawnKey + 1], enemyInts[spawnKey + 2], enemyInts[spawnKey + 3]);
            spawnKey += 4;            
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        }
        waveKey++;
        //Debug.Log("Enemy Wave Size = " + enemiesList.Count);
    }

    void Update()
    {
/*        if (Input.GetKeyDown("i")) {
            SpawnEnemy();
        }
        if (Input.GetKeyDown("s")) {
            waveSpawn();
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
// Update is called once per frame


/*    void SpawnEnemy() {
            ///Debug.Log("SPAWN");

        GameObject newEnemy = Instantiate(
            enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],
            enemySpawns[Random.Range(0, enemySpawns.Length)].position, transform.rotation
            ) as GameObject;

        newEnemy.GetComponent<EnemyMovement>().SetPoint(enemyStarts[Random.Range(0, enemyStarts.Length)]);
        newEnemy.GetComponent<EnemyMovement>().SetPoint(enemyEnds[Random.Range(0, enemyEnds.Length)]);
    }*/

/*    public void waveSpawn() {
        int waveSize = waveSizeArray[waveKey];
        if (spawnKey >= enemyInts.Length) {
            return;
        }
        for (int i = 1; i <= waveSize; i++) {
            SpawnEnemy(enemyInts[spawnKey], enemyInts[spawnKey + 1], enemyInts[spawnKey + 2], enemyInts[spawnKey + 3]);
            spawnKey += 4;
        }
        waveKey++;
    }*/
