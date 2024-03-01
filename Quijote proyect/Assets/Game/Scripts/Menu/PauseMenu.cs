using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] public GameObject PauseMenuPanel;
    [SerializeField] public GameObject PauseButton;


    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        PauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseButton.SetActive(true);
        PauseMenuPanel.SetActive(false);
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
        PauseButton.SetActive(true);
        PauseMenuPanel.SetActive(false);
    }
}
