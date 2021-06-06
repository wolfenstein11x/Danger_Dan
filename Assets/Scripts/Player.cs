using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 1.0f;
    [SerializeField] float jumpSpeed = 28f;

    Rigidbody2D rigidBody;
    Animator animator;
    Collider2D playerCollider;

    float epsilon = 0.0001f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        Shoot();
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

    private void Jump()
    {
        if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

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
