using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float bounceForceFromEnemy = 10f;
    public Collider2D bodyCollider = null;
    public Collider2D feetCollider = null;

    Rigidbody2D myRigidbody = null;
    Animator myAnimator = null;
    GameSession gameSession = null;
    bool isDead = false;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        gameSession = FindObjectOfType<GameSession>();
        
    }

    private void DisableColliders()
    {
        feetCollider.enabled = false;
        bodyCollider.enabled = false;
    }

    public void BounceUp()
    {
        Vector2 jumpVector = new Vector2(0f, bounceForceFromEnemy);
        myRigidbody.velocity = jumpVector;
        AudioManager.instance.Play("Bounce");
        myAnimator.SetBool("isJumping", true);
    }

    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            DisableColliders();
            BounceUp();
            myAnimator.SetTrigger("death");
            AudioManager.instance.Play("GameOver");
            gameSession.HandlePlayerDeath();
        }    
    } 
}
