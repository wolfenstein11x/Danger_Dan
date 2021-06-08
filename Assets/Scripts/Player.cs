using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 1.0f;
    [SerializeField] float jumpSpeed = 28f;
    [SerializeField] float climbSpeed = 1.0f;

    Rigidbody2D rigidBody;
    Animator animator;
    CapsuleCollider2D playerCollider;
    BoxCollider2D feetCollider;
    float gravityScaleInitial;

    float epsilon = 0.0001f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        gravityScaleInitial = rigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        Shoot();
        Climb();
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");   // -1 to +1

        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, rigidBody.velocity.y);

        rigidBody.velocity = playerVelocity;

        bool movingHorizontal = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon 
                                && Mathf.Abs(rigidBody.velocity.y) < epsilon;
        
        animator.SetBool("running", movingHorizontal);

    }

    private void Climb()
    {
        if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
        {
            animator.SetBool("climbing", false);
            rigidBody.gravityScale = gravityScaleInitial;
            return; 
        }

        rigidBody.gravityScale = 0f;

        float controlThrow = Input.GetAxis("Vertical");

        Vector2 climbVelocity = new Vector2(rigidBody.velocity.x, controlThrow * climbSpeed);

        rigidBody.velocity = climbVelocity;

        bool movingVertical = Mathf.Abs(rigidBody.velocity.y) > Mathf.Epsilon;

        animator.SetBool("climbing", movingVertical);
                             




    }

    private void Jump()
    {
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            animator.SetBool("jumping", false);
            return;
        }

        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            rigidBody.velocity += jumpVelocityToAdd;
        }

        bool jumping = Mathf.Abs(rigidBody.velocity.y) > epsilon;
        animator.SetBool("jumping", jumping);
        
    }

    private void Shoot()
    {
        if (!(rigidBody.velocity.x < epsilon && rigidBody.velocity.y < epsilon)) { return; }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("shooting");
        }
    }

    private void FlipSprite()
    {
        bool movingHorizontal = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;

        if (movingHorizontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
        }
    }
}
