using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuitarVolumen : MonoBehaviour
{
    public Image boton;
    public AudioSource audioMusica;
    float volumenInicial;
    bool TieneMusica = true;
    private void Start()
    {
        audioMusica = GameObject.Find("MusicaFondo").GetComponent<AudioSource>();
        volumenInicial = 0.26f;
    }
    public void QuitarMusica()
    {

        audioMusica.volume = 0;
        boton.color = Color.red;
    }
    public void PonerMusica()
    {
        audioMusica.volume = volumenInicial;
        boton.color = Color.white;
    }

    public void ControlarMusica()
    {
        AudioManager.instance.ReproducirBoton();
        if (TieneMusica)
        {
            QuitarMusica();
        }
        else
        {
            PonerMusica();
        }
        TieneMusica = !TieneMusica;
    }
}
