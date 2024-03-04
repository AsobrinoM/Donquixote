using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] public GameObject PauseMenuPanel;
    [SerializeField] public GameObject GameOverPanel;
    [SerializeField] public GameObject PauseButton;
    [SerializeField] public GameObject FinalMenuPanel;
    [SerializeField] private TMP_Text timerText;
   


    private float gameTimer = 0.0f;
    private bool isPaused = false;

    void Update()
    {
        if (!isPaused)
        {
            gameTimer += Time.deltaTime;
            timerText.text = gameTimer.ToString("0.00");
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        PauseButton.SetActive(false);
        PauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        PauseButton.SetActive(true);
        PauseMenuPanel.SetActive(false);
    }

    public float GetGameTime()
    {
        return gameTimer;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        PauseButton.SetActive(true);
        PauseMenuPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuGame()
    {
        Time.timeScale = 1;
        FadeManager.Instance.FadeToScene("Seleccion Niveles");
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        FadeManager.Instance.FadeToScene("Escena Antonio");
    }
    public void NextLevel2()
    {
        Time.timeScale = 1;
        FadeManager.Instance.FadeToScene("Escena Alex");
    }
    public void pauseTimer()
    {
        isPaused = true;
    }

    public string GetTimerText()
    {
        return timerText.text;
    }

    public void sum10Seconds()
    {
        gameTimer += 10;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        isPaused = true;
        StartCoroutine(ActivateGameOverPanel());
    }

    IEnumerator ActivateGameOverPanel()
    {
        yield return new WaitForSeconds(2);
        GameOverPanel.SetActive(true);
        StartCoroutine(ShowGameOverPanel());
    }

    IEnumerator ShowGameOverPanel()
    {
        GameOverPanel.transform.localScale = Vector3.zero;
        float timer = 0;
        while (timer < 1)
        {
            timer += Time.deltaTime * 2; // 2 es la velocidad de la animación
            GameOverPanel.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, timer);
            yield return null;
        }
    }
}
