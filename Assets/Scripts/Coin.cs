using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    bool coinPicked = false;
    public static int sceneIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!coinPicked && collision.gameObject.GetComponentInParent<Player>() is Player)
        {
            coinPicked = true;
            GameSession.Instance.AddScore();
            Destroy(gameObject);
        }        
    }
}
