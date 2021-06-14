using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    public float direction = 1f;

    private int moveScale = 1;
    private CapsuleCollider2D enemyCollider;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Die();

        direction = transform.localScale.x;

        if (IsFacingNormally())
        {
            rigidBody.velocity = new Vector2(-moveSpeed * moveScale, 0f);
        }

        else
        {
            rigidBody.velocity = new Vector2(moveSpeed * moveScale, 0f);
        }
        
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
    }

    private void Die()
    {
        if (enemyCollider.IsTouchingLayers(LayerMask.GetMask("Projectile")))
        {
            Destroy(gameObject);
        }
    }

    private bool IsFacingNormally()
    {
        return transform.localScale.x > 0;
    }

    public void HaltMotion()
    {
        moveScale = 0;
    }

    public void ResumeMotion()
    {
        moveScale = 1;
    }
}
