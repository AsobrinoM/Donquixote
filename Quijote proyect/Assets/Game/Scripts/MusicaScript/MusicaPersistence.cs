using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaPersistente : MonoBehaviour
{
    private static MusicaPersistente instancia;

    void Awake()
    {
        if (instancia == null)
        {
            // Si no hay instancia, establece esta como la instancia
            instancia = this;
            // Hacer que este objeto persista entre las escenas
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya hay una instancia, destruir este objeto
            Destroy(gameObject);
        }
    }
  
}
