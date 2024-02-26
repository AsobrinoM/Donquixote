using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    void Start()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        DontDestroyOnLoad(gameManager);
    }

    void Update()
    {

    }

    public void onButtonJugar()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void onButtonCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void onButtonSalir()
    {
        Application.Quit();
    }

    public void onButtonVolver()
    {
        SceneManager.LoadScene("Menu");
    }


}
