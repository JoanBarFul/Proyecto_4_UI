using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    private float minX = -3.75f;
    private float minY = -3.75f;
    private float spaceSquares = 2.5f;
    private int numbersRows = 4;
    public bool gameOver;
    private float timeSpawnRate = 2f;
    public Vector3 ranSpawnPos;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnRandomTarget");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 RandomSpawnPosition()
    {
        int ranInt = Random.Range(0, numbersRows);
        float ranPosX = minX + ranInt * spaceSquares;
        float ranPosY = minY + ranInt * spaceSquares;

        return new Vector3(ranPosX, ranPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        yield return new WaitForSeconds(timeSpawnRate);
        int ranIndex = Random.Range(0, targetPrefabs.Length);
        ranSpawnPos = RandomSpawnPosition();
        Instantiate(targetPrefabs[ranIndex], ranSpawnPos, targetPrefabs[ranIndex].transform.rotation);
    }
}// para llamar corutina "StartCoroutine"
