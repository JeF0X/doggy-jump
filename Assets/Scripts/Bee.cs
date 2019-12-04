using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float detectionRadius = 5f;
    [SerializeField] float deathDelay = 2f;

    Animator myAnimator = null;
    Player player = null;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        if (Vector2.Distance(gameObject.transform.position, player.transform.position) < 5f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, detectionRadius);
    }

    IEnumerator Die()
    {
        speed = 0f;
        myAnimator.SetTrigger("death");
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
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
