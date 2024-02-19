using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoHollow : MonoBehaviour
{
    public float speed;
    public float circleRadius;
    private Rigidbody2D EnemyRB;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public bool facingRight = true;
    public bool isGrounded;


    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyRB.velocity = Vector2.right * speed * Time.deltaTime;
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadius, groundLayer);

        if (!isGrounded && facingRight)
        {
            Flip();
        }
        else if (!isGrounded && !facingRight)
        {
            Flip();
        }

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
    }
}
