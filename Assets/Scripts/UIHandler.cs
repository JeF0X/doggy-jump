using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] Text numOfCoinsText = null;
    [SerializeField] SpriteRenderer[] liveSprites = null;

    [Header("Death")]
    [SerializeField] Canvas deathCanvas = null;

    [Header("Game Over")]
    [SerializeField] Canvas gameOverCanvas = null;
    [SerializeField] Text gameOverScoreText = null;

    [Header("Game Finished")]
    [SerializeField] Canvas gameFinishedCanvas = null;
    [SerializeField] Text gameFinishedScoreText = null;


    Player player = null;
    GameSession gameSession = null;
    LevelLoader sceneLoader = null;

    void Start()
    {
        player = FindObjectOfType<Player>();
        gameSession = FindObjectOfType<GameSession>();
        gameOverCanvas.enabled = false;
        deathCanvas.enabled = false;
        gameFinishedCanvas.enabled = false;
        sceneLoader = FindObjectOfType<LevelLoader>();
        Time.timeScale = 1;
    }

    void Update()
    {
        UpdateScoreUI();
        UpdateLivesUI();
    }
    private void UpdateScoreUI()
    {
        numOfCoinsText.text = gameSession.GetScore().ToString();
    }

    private void UpdateLivesUI()
    {
        var livesLeft = gameSession.GetLives();

        if (livesLeft < 3) { liveSprites[2].enabled = false; }
        else { liveSprites[2].enabled = true; }

        if (livesLeft < 2) { liveSprites[1].enabled = false; }
        else { liveSprites[1].enabled = true; }

        if (livesLeft < 1) { liveSprites[0].enabled = false; }
        else { liveSprites[0].enabled = true; }
    }
    public void EnableGameOverCanvas()
    {
        gameOverCanvas.enabled = true;
        gameOverScoreText.text = "You found " + gameSession.GetScore() + " coins!";
        StartCoroutine(StopTime(3f));
    }

    public void EnableDeathCanvas()
    {
        deathCanvas.enabled = true;
        StartCoroutine(StopTime(3f));
    }

    public void ResetLevel()
    {
        GameSession.Instance.ResetScore();
        sceneLoader.ReloadLevel();
    }

    public void ResetGame()
    {
        GameSession.Instance.ResetGameStats();
        sceneLoader.LoadFirstLevel();
    }

    public void FinishGame()
    {
        player.BounceUp();
        gameFinishedCanvas.enabled = true;
        gameFinishedScoreText.text = "You found " + gameSession.GetScore().ToString() + " of " + gameSession.GetMaxCoins() + " coins!";
        StartCoroutine(StopTime(0.4f));
    }

    IEnumerator StopTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Time.timeScale = 0;
    }

    public void ToMainMenu()
    {
        GameSession.Instance.ResetGameStats();
        sceneLoader.LoadMainMenu();
    }
}
