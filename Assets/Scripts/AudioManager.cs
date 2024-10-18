using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audio;
    public AudioClip Boton;
    public AudioClip Palabra;
    public AudioClip Moneda;
    public AudioClip Tecla;
    public AudioClip Pop;
    public AudioClip Victoria;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        audio = gameObject.GetComponent<AudioSource>();
    }
    public void ReproducirBoton()
    {
        audio.PlayOneShot(Boton);
    }

    public void ReproducirPalabra()
    {
        audio.PlayOneShot(Palabra);
    }
    public void ReproducirMoneda()
    {
        audio.PlayOneShot(Moneda,0.35f);
    }
    public void ReproducirTecla()
    {
        audio.PlayOneShot(Tecla, 1f);
    }
    public void ReproducirPop()
    {
        audio.PlayOneShot(Pop, 1f);
    }
    public void ReproducirVictoria()
    {
        audio.PlayOneShot(Victoria, 0.3f);
    }
}
