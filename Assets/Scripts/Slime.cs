using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Slime : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject edgeDetector =null;
    [SerializeField] float deathDelay = 0.5f;

    Rigidbody2D myRigidbody = null;
    Animator myAnimator = null;
    Player player = null;
    Vector2 direction = Vector2.left;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        Move();
        EdgeDetection();
    }

    private void Move()
    {
        myRigidbody.velocity = direction * speed;
        //myRigidbody.velocity = new Vector2(transform.localScale.x  * -speed * Time.deltaTime, 0f);
    }

    private void EdgeDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(edgeDetector.transform.position, Vector2.down, 1f);
        if (hit.collider == null)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, 1f);
            direction = -direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<Player>() is Player)
        {
            player.BounceUp();
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        speed = 0f;
        myAnimator.SetTrigger("death");
        myRigidbody.isKinematic = true;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(deathDelay);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInParent<Player>() is Player)
        {
            player.Die();
        }
    }

}
