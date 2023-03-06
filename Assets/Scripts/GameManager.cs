using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    public bool isGameOver;
    
    public List<Vector3> targetPositionsInScene;
   
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel;
    public GameObject startGamePanel;
    public bool hasPowerUpShield;



    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenSquares = 2.5f;
    private int score;
    private Vector3 randomPos;
    private float spawnRate = 1f;
    private int lives = 3;




    private void Start()
    {
        startGamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void UpdateScore(int newPoints)
    {
        score += newPoints;
        scoreText.text = $"Score: {score}";
    }
    private Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minX + Random.Range(0, 4) * distanceBetweenSquares;
        float spawnPosY = minY + Random.Range(0, 4) * distanceBetweenSquares;
        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, targetPrefabs.Length);
            randomPos = RandomSpawnPosition();
            while (targetPositionsInScene.Contains(randomPos))
            {
                randomPos = RandomSpawnPosition();
            }
            Instantiate(targetPrefabs[randomIndex], randomPos, targetPrefabs[randomIndex].transform.rotation);
            targetPositionsInScene.Add(randomPos);
        }
    }

    

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameOver = false;
        score = 0;
        UpdateScore(0);
        livesText.text = $"Lives: {lives}";
        spawnRate /= difficulty;
        StartCoroutine(SpawnRandomTarget());
        startGamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void minusLive()
    {
        lives--;
        livesText.text = $"Lives: {lives}";
        if(lives <= 0)
        {
            GameOver();
        }
    }

  
}
