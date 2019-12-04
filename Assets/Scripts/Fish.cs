using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Player player = null;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInParent<Player>() is Player)
        {
            player.Die();
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
