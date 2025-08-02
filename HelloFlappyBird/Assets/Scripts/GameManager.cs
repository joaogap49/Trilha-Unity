using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    [FormerlySerializedAs("prefabs")]
    public List<GameObject> obstaclePrefabs;

    public float obstacleInterval = 2;
    public float obstacleSpeed = 5;
    public float obstacleOffsetX = 15;

    public Vector2 obstacleOffsetY = new Vector2(0, 0);

    [HideInInspector]
    public int score;

    private bool isGameOver = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
       
    }

    public bool IsGameActive()
    {
        return !isGameOver;
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public void EndGame()
    {
        isGameOver = true;
        Debug.Log("Game Over! Final Score: " + score);

        StartCoroutine(ReloadScene(2f));
    }

    private IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);

    }

}
