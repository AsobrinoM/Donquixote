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

    public void onButtonJugar()
    {
        FadeManager.Instance.FadeToScene("Seleccion Niveles");
    }

    public void onButtonCreditos()
    {

    }

    public void onButtonSalir()
    {
        Application.Quit();
    }
}
