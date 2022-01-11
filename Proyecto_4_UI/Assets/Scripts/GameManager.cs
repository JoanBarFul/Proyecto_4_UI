using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    private float minX = -3.75f;
    private float minY = -3.75f;
    private float spaceSquares = 2.5f;
    private int numbersRows = 4;
    public bool gameOver;
    public float timeSpawnRate = 1f;
    private Vector3 ranSpawnPos;
    public List<Vector3> targetPositions;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public GameObject gameOverPanel;
    public TextMeshProUGUI liveText;
    public int live = 3;
    public int missTarget;
    public int totalmisses = 3;
    
    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnRandomTarget");
        score = 0;
        live = 3;
        gameOverPanel.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {score}";
        if (gameOver)
        { gameOverPanel.gameObject.SetActive(true); }
        liveText.text = $"Lives: X {live}";



    }
    public Vector3 RandomSpawnPosition()
    {
        int ranIntX = Random.Range(0, numbersRows);
        int ranIntY = Random.Range(0, numbersRows);
        float ranPosX = minX + ranIntX * spaceSquares;
        float ranPosY = minY + ranIntY * spaceSquares;

        return new Vector3(ranPosX, ranPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
       while (!gameOver)
        {
            yield return new WaitForSeconds(timeSpawnRate);
            int ranIndex = Random.Range(0, targetPrefabs.Length);
            ranSpawnPos = RandomSpawnPosition();
            while (targetPositions.Contains(ranSpawnPos))
            {ranSpawnPos = RandomSpawnPosition(); }
            Instantiate(targetPrefabs[ranIndex], ranSpawnPos, targetPrefabs[ranIndex].transform.rotation);
            targetPositions.Add(ranSpawnPos);
        }
    }
  
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
       
}// para llamar corutina "StartCoroutine"
