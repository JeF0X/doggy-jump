using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void ReloadLevel()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadNextLevel()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
