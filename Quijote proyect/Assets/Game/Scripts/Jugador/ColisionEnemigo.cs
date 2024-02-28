using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionEnemigo : MonoBehaviour
{
    public float reboundForce = 10f; // Fuerza de rebote
    public Vector2 respawnPoint;
    public float respawnDelay = 1f; // Tiempo de espera antes de reaparecer
    public Animator animator;

    private void Start()
    {     
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Asegúrate de que el enemigo tenga la etiqueta "Enemy"
        {
            PlayerMovement.isDying = true;
            animator.SetTrigger("Die");

            // Calcula la dirección del rebote
            Vector2 reboundDirection = (transform.position - collision.transform.position).normalized;

            // Aplica la fuerza de rebote
            GetComponent<Rigidbody2D>().AddForce(reboundDirection * reboundForce, ForceMode2D.Impulse);

            // Comienza la corrutina de reaparición
            StartCoroutine(RespawnAfterDelay());
        }
    }

    IEnumerator RespawnAfterDelay()
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(respawnDelay);

        // Detiene el movimiento del personaje
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // "Muerte" del jugador y reaparición en el punto de control
        transform.position = respawnPoint;

        PlayerMovement.isDying = false;
        animator.Play("Quieto");
    }
}
