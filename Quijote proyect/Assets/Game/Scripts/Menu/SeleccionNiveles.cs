using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeleccionNiveles : MonoBehaviour
{

    [SerializeField] public Button btnNivel1;
    [SerializeField] public Button btnNivel2;
    [SerializeField] public Button btnNivel3;
    [SerializeField] public Button btnNivel4;

    void Start()
    {
        // Si el nivel 1 no está completado, deshabilita los botones de los niveles 3 y 4
        if (PlayerPrefs.GetInt("Nivel1") != 1)
        {
            btnNivel2.interactable = false;
            btnNivel3.interactable = false;
            btnNivel4.interactable = false;
        }
        // Si el nivel 2 no está completado, deshabilita los botones de los niveles 3 y 4
        else if (PlayerPrefs.GetInt("Nivel2") != 1)
        {
            btnNivel3.interactable = false;
            btnNivel4.interactable = false;
        }
        // Si el nivel 3 no está completado, deshabilita el botón del nivel 4
        else if (PlayerPrefs.GetInt("Nivel3") != 1)
        {
            btnNivel4.interactable = false;
        }



        if (PlayerPrefs.GetInt("Nivel1") == 1)
        {
            btnNivel1.GetComponent<Image>().color = Color.green;
        }
        if (PlayerPrefs.GetInt("Nivel2") == 1)
        {
            btnNivel2.GetComponent<Image>().color = Color.green;
        }
        if (PlayerPrefs.GetInt("Nivel3") == 1)
        {
            btnNivel3.GetComponent<Image>().color = Color.green;
        }
        if (PlayerPrefs.GetInt("Nivel4") == 1)
        {
            btnNivel4.GetComponent<Image>().color = Color.green;
        }
    }

    public void Nivel1()
    {
        FadeManager.Instance.FadeToScene("Tutorial");
    }

    public void Nivel2()
    {
        FadeManager.Instance.FadeToScene("Escena Antonio");
    }

    public void Nivel3()
    {
        FadeManager.Instance.FadeToScene("Escena Alex");
    }

    public void Nivel4()
    {
        FadeManager.Instance.FadeToScene("Nivel Final");
    }

    public void Menu()
    {
        FadeManager.Instance.FadeToScene("Menu");
    }
}
