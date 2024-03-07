using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaPersistente : MonoBehaviour
{
    // Declara una variable para almacenar la instancia
    private static MusicaPersistente instancia;

    // Declara una variable para el audio source
    private AudioSource audioSource;

    [SerializeField] private AudioClip musicaMenu;
    [SerializeField] private AudioClip musicaTutorial;
    private AudioClip ultimoClipReproducido;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
        }
        else
        {
     
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ultimoClipReproducido=audioSource.clip;
        SceneManager.sceneLoaded += CambiarMusicaSegunEscena;
    }

    void CambiarMusicaSegunEscena(Scene escena, LoadSceneMode modo)
    {
        AudioClip nuevoClip = null;
        switch (escena.name)
        {
            case "Menu":
                nuevoClip = musicaMenu;
                break;
            case "Tutorial":
                nuevoClip = musicaTutorial;
                break;
               
        }
        if (nuevoClip != null && nuevoClip != ultimoClipReproducido)
        {
            audioSource.clip = nuevoClip;
            audioSource.Play();
            ultimoClipReproducido = nuevoClip;
        }
       
    }

       
    }
