using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionEnemigo : MonoBehaviour
{
    public float reboundForce = 10f; // Fuerza de rebote
    public Vector2 respawnPoint;
    public float respawnDelay = 1f; // Tiempo de espera antes de reaparecer

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Aseg�rate de que el enemigo tenga la etiqueta "Enemy"
        {
            // Calcula la direcci�n del rebote
            Vector2 reboundDirection = (transform.position - collision.transform.position).normalized;

            // Aplica la fuerza de rebote
            GetComponent<Rigidbody2D>().AddForce(reboundDirection * reboundForce, ForceMode2D.Impulse);

            // Comienza la corrutina de reaparici�n
            StartCoroutine(RespawnAfterDelay());
        }
    }

    IEnumerator RespawnAfterDelay()
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(respawnDelay);

        // "Muerte" del jugador y reaparici�n en el punto de control
        transform.position = respawnPoint;
    }
}
