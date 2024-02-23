using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public bool isWallCollisionRight;
    public bool isWallCollisionLeft;

    public GameObject obstacleRayObject;

    [SerializeField] float rayDistance = 1f;

    [SerializeField] LayerMask playerLayer;

    public GameObject player;


    void Start()
    {
         EnemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hitPlayer = Physics2D.Raycast(obstacleRayObject.transform.position, Vector2.right, rayDistance, playerLayer);

        Debug.Log(hitPlayer.collider);

        if (hitPlayer.collider != null)
        {
            Debug.DrawRay(obstacleRayObject.transform.position, Vector2.right * rayDistance, Color.red);
        }
        else
        {
            Debug.DrawRay(obstacleRayObject.transform.position, Vector2.right * rayDistance, Color.green);
        }

        EnemyRB.velocity = Vector2.right * speed * Time.deltaTime;
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadius, groundLayer);
        isWallCollisionRight = Physics2D.OverlapCircle(wallCheckRight.transform.position, circleRadius, groundLayer);
        isWallCollisionLeft = Physics2D.OverlapCircle(wallCheckLeft.transform.position, circleRadius, groundLayer);

        if (!isGrounded && facingRight)
        {
            Flip();
        }
        else if (!isGrounded && !facingRight)
        {
            Flip();
        }
        else if (isWallCollisionRight || isWallCollisionLeft)
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
        Gizmos.DrawWireSphere(wallCheckLeft.transform.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheckRight.transform.position, circleRadius);
    }
}
