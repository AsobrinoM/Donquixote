using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    private PauseMenu pauseMenu;
    [SerializeField] public GameObject FinalMenuPanel;
    [SerializeField] public GameObject panelNegro;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private TextMeshProUGUI scoreText; // Si est�s usando TextMesh Pro

    void Start()
    {
        pauseMenu = gameManager.GetComponent<PauseMenu>(); // Agrega esta l�nea
    }


private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.tag == "Player")
    {
        pauseMenu.pauseTimer(); // Cambia gameManager a pauseMenu
        playerMovement.forceRight();
        StartCoroutine(ActivatePanel());
    }
}

IEnumerator ActivatePanel()
    {
        yield return new WaitForSeconds(2);
        panelNegro.SetActive(true);
        StartCoroutine(ShowFinalMenuPanel());
    }

    IEnumerator ShowFinalMenuPanel()
    {
        FinalMenuPanel.SetActive(true);
        StartCoroutine(UpdateScore());
        FinalMenuPanel.transform.localScale = Vector3.zero;
        float timer = 0;
        while (timer < 1)
        {
            timer += Time.deltaTime * 2; // 2 es la velocidad de la animaci�n
            FinalMenuPanel.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, timer);
            yield return null;
        }
    }

    IEnumerator UpdateScore()
    {
        float finalTime = pauseMenu.GetGameTime();
        int finalScore = (int)(10000 / finalTime); // Aumenta el numerador para obtener una puntuaci�n m�s alta
        int currentScore = 0;
        while (currentScore < finalScore)
        {
            currentScore += (int)(Time.deltaTime * 500); // Aumenta el factor de incremento para que la puntuaci�n se incremente m�s r�pido
            scoreText.text = currentScore.ToString() + "\nPoints"; // Agrega " Points" al final del texto de la puntuaci�n
            yield return null;
        }
        // Aseg�rate de que la puntuaci�n final sea exactamente igual a finalScore
        scoreText.text = finalScore.ToString() + "\nPoints"; // Agrega " Points" al final del texto de la puntuaci�n
    }
}
