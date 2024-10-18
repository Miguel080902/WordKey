using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoFondo : MonoBehaviour
{
    public static SonidoFondo instance;
    private void Awake()
    {
        // Verificar si ya existe una instancia
        if (instance == null)
        {
            // Si no existe, asignar esta instancia al campo estático
            instance = this;
        }
        else
        {
            // Si ya existe una instancia, destruir este objeto para evitar duplicados
            Destroy(gameObject);
        }
    }
}
