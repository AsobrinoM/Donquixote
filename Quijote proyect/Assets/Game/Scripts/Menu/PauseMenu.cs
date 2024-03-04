using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] public GameObject PauseMenuPanel;
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
}
