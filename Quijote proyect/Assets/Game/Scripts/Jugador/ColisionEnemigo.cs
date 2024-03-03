using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisionEnemigo : MonoBehaviour
{
    public float reboundForce = 10f; // Fuerza de rebote
    public Vector2 respawnPoint;
    public float respawnDelay = 1f; // Tiempo de espera antes de reaparecer
    public Animator animator;
    public int vida = 10; // Vida del jugador


     // Necesario para trabajar con UI

    public Image image; // Referencia al componente Image
    public Sprite[] sprites; // Array de sprites
    public Sprite defaultSprite;

    private void Start()
    {
        animator = GetComponent<Animator>();
        image.sprite = defaultSprite;
    }



    private void Update()
    {
        if (vida >= 0 && vida < sprites.Length) // Asegúrate de que el índice esté dentro del rango del array
        {
            image.sprite = sprites[vida]; // Cambia el sprite basándote en el valor de vida
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Asegúrate de que el enemigo tenga la etiqueta "Enemy"
        {
            // Decrementa la vida
            vida--;

            // Calcula la dirección del rebote
            Vector2 reboundDirection = (transform.position - collision.transform.position).normalized;

            // Aplica la fuerza de rebote
            GetComponent<Rigidbody2D>().AddForce(reboundDirection * reboundForce, ForceMode2D.Impulse);

            // Si la vida es 0, el jugador muere
            if (vida <= 0)
            {
                PlayerMovement.isDying = true;
                animator.SetTrigger("Die");

                // Comienza la corrutina de reaparición
                StartCoroutine(RespawnAfterDelay());
            }
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

        // Restablece la vida a 10
        vida = 10;

        image.sprite = defaultSprite; // Establece el sprite por defecto al reaparecer
    }
}
