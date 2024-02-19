using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicionFin;
    public Vector3 posicionInicio;
    private bool moviendoAFin;

    void Start()
    {
        transform.position = posicionInicio;
        moviendoAFin = true;
    }

    // Update is called once per frame
    void Update()
    {
        moverEnemigo();
    }

    private void moverEnemigo()
    {
        Vector3 direccion;

        if (moviendoAFin)
        {
            direccion = posicionFin - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, posicionFin, velocidad * Time.deltaTime);
            if (transform.position == posicionFin)
            {
                moviendoAFin = false;
            }
        }
        else
        {
            direccion = posicionInicio - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, posicionInicio, velocidad * Time.deltaTime);
            if (transform.position == posicionInicio)
            {
                moviendoAFin = true;
            }
        }

        if (direccion.x > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (direccion.x < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}