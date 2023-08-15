using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private bool doubleJump;
    private bool isDoubleJump;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling, doubleJumping }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // With Coyote
    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            dirX = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (rb.velocity.y < -.1f)
            {
                isDoubleJump = false;
            }

            if (isGrounded())
            {
                doubleJump = true;
                coyoteTimeCounter = coyoteTime;
            }
            else
            {
                coyoteTimeCounter -= Time.deltaTime;
            }


            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded() || coyoteTimeCounter > 0f)
                {
                    jumpSoundEffect.Play();
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
                else if (doubleJump)
                {
                    jumpSoundEffect.Play();
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    doubleJump = false;
                    isDoubleJump = true;
                }
            }


            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0.1f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                coyoteTimeCounter = 0f;
            }

            updateAnimationState();
        }
        
    }

    /*private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (rb.velocity.y < -.1f)
        {
            isDoubleJump = false;
        }

        if (isGrounded())
        {
            doubleJump = true;
        } 

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded())
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (doubleJump)
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = false;
                isDoubleJump = true;
            }
        }


        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0.1f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        updateAnimationState();
    }*/

    private void updateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (isDoubleJump)
        {
            state = MovementState.doubleJumping;
        }
        else if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
    //hi -ua here

}
