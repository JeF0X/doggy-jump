using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas creditsCanvas = null;

    private void Start()
    {
        HideCredits();
    }
    public void LoadLevel()
    {
        FindObjectOfType<LevelLoader>().LoadFirstLevel();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        creditsCanvas.enabled = true;
    }

    public void HideCredits()
    {
        creditsCanvas.enabled = false;
    }
}
