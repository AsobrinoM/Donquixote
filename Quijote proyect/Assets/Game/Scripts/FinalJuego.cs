using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalJuego : MonoBehaviour
{
    [SerializeField] public GameObject EndGamePanel;
    [SerializeField] public GameObject panelNegro;
    //Start
    void Start()
    {
        EndGame();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuGame()
    {
        Time.timeScale = 1;
        FadeManager.Instance.FadeToScene("Seleccion Niveles");
    }

    public void EndGame()
    {
        StartCoroutine(ActivateGameOverPanel());
    }

    IEnumerator ActivateGameOverPanel()
    {
        yield return new WaitForSeconds(20);
        panelNegro.SetActive(true);
        Time.timeScale = 0;
        EndGamePanel.SetActive(true);
        yield return StartCoroutine(ShowGameOverPanel());
    }

    IEnumerator ShowGameOverPanel()
    {
        EndGamePanel.transform.localScale = Vector3.zero;
        float timer = 0;
        while (timer < 1)
        {
            timer += Time.unscaledDeltaTime * 1; // 2 es la velocidad de la animación
            EndGamePanel.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, timer);
            yield return null;
        }
    }
}