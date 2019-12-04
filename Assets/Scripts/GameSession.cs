using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    int playerLives = 3;
    int score = 0;
    int scoreOnLevelLoad = 0;
    int coinsMissed = 0;
    int maxCoins = 0;

    private static GameSession instance = null;
    public static GameSession Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ReduceLives()
    {
        playerLives--;
    }

    public int GetLives()
    {
        return playerLives;
    }

    public void HandlePlayerDeath()
    {
        ReduceLives();
        if (playerLives > 0)
        {   
            FindObjectOfType<UIHandler>().EnableDeathCanvas();
        }
        else if (playerLives <= 0)
        {
            FindObjectOfType<UIHandler>().EnableGameOverCanvas();
        }
    }

    public void AddScore()
    {
        score++;
        AudioManager.instance.Play("CoinPickup");
    }

    public int GetScore()
    {
        return score;
    }
    
    public void SaveScore()
    {
        scoreOnLevelLoad = score;
    }

    public void ResetScore()
    {
        score = scoreOnLevelLoad;
    }

    public void ResetGameStats()
    {
        score = 0;
        scoreOnLevelLoad = 0;
        playerLives = 3;
    }

    public void CountLevelCoins()
    {
        var levelCoins = FindObjectsOfType<Coin>();
        coinsMissed += levelCoins.Length;
        maxCoins = score + coinsMissed;
    }

    public int GetMaxCoins()
    {
        return maxCoins;
    }
}
