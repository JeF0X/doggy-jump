using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{

    bool hasExited = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasExited)
        {
            GameSession.Instance.SaveScore();
            GameSession.Instance.CountLevelCoins();
            FindObjectOfType<LevelLoader>().LoadNextLevel();
        }
        
    }
}
