using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoHollow : MonoBehaviour
{
    public float speed;
    public float circleRadius;
    private Rigidbody2D EnemyRB;
    public GameObject groundCheck;
    public GameObject wallCheckRight;
    public GameObject wallCheckLeft;
    public LayerMask groundLayer;

    public bool facingRight = true;
    public bool isGrounded;
    public bool wasGrounded;
    public bool isWallCollisionRight;
    public bool isWallCollisionLeft;
    public bool hasFlippedDueToWallCollision;

    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        EnemyRB.velocity = Vector2.right * speed * Time.fixedDeltaTime;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, circleRadius, groundLayer);

        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        isWallCollisionRight = Physics2D.OverlapCircle(wallCheckRight.transform.position, circleRadius, groundLayer);
        isWallCollisionLeft = Physics2D.OverlapCircle(wallCheckLeft.transform.position, circleRadius, groundLayer);

        if (wasGrounded && !isGrounded)
        {
            Flip();
        }
        else if ((isWallCollisionRight || isWallCollisionLeft) && !hasFlippedDueToWallCollision)
        {
            Flip();
            hasFlippedDueToWallCollision = true;
        }
        else if (!isWallCollisionRight && !isWallCollisionLeft)
        {
            hasFlippedDueToWallCollision = false;
        }

        wasGrounded = isGrounded;
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        speed = -speed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheckLeft.transform.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheckRight.transform.position, circleRadius);
    }
}