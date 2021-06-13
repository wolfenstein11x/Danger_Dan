using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    public float direction = 1f;

    private int moveScale = 1;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.localScale.x;
        Debug.Log(direction);

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
