using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 10f;

    Player player = null;
    Rigidbody2D myRigidbody = null;
    Animator myAnimator = null;

    void Start()
    {
        player = GetComponent<Player>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        Falling();
    }

    private void Run()
    {
        float hAxis = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(hAxis * speed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool isRunning = Mathf.Abs(myRigidbody.velocity.x) > 0.01f;
        myAnimator.SetBool("isRunning", isRunning);
    }

    private void FlipSprite()
    {
        bool facingRight = Mathf.Abs(myRigidbody.velocity.x) > 0.01f;
        if (facingRight)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && CheckGrounded())
        {
            Vector2 jumpVector = new Vector2(0f, jumpForce);
            myRigidbody.velocity = jumpVector;
            AudioManager.instance.Play("Jump");
            myAnimator.SetBool("isJumping", true);
        }

        if (myRigidbody.velocity.y < 0f)
        {
            myAnimator.SetBool("isJumping", false);
        }

    }

    private void Falling()
    {
        if (myRigidbody.velocity.y < -0.2f)
        {
            myAnimator.SetBool("isFalling", true);
        }
        else
        {
            myAnimator.SetBool("isFalling", false);
        }
    }

    private bool CheckGrounded()
    {
        bool isTouching = player.feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        return isTouching;
    }
}
