using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour
{

    [SerializeField] public GameObject btnJugar;
    [SerializeField] public GameObject btnCreditos;
    [SerializeField] public GameObject btnSalir;

    [SerializeField] public GameObject PanelNegro;
    [SerializeField] public GameObject PanelHighScore;
    [SerializeField] public GameObject btnHighScore;

    public void onButtonJugar()
    {
        FadeManager.Instance.FadeToScene("Seleccion Niveles");
    }

    public void onButtonCreditos()
    {
        FadeManager.Instance.FadeToScene("Creditos");
    }

    public void onButtonSalir()
    {
        Application.Quit();
    }
    public void onButtonVolver()
    {
        FadeManager.Instance.FadeToScene("Menu");
    }
    public void onButtonHighScore()
    {
        btnHighScore.SetActive(false);
        PanelNegro.SetActive(true);
        PanelHighScore.SetActive(true);
    }
    public void onButtonCerrarHighScore()
    {
        btnHighScore.SetActive(true);
        PanelNegro.SetActive(false);
        PanelHighScore.SetActive(false);
    }


}
