using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnviarInput : MonoBehaviour
{
    private TextMeshProUGUI texto;
    private void Start()
    {
        texto = gameObject.GetComponent<TextMeshProUGUI>();
    }
    public void SumarLetra(string letra)
    {
        AudioManager.instance.ReproducirTecla();
        texto.text += letra;
    }
    public void BorrarUltimaLetra()
    {
        AudioManager.instance.ReproducirBoton();
        if (texto.text.Length>0)
        texto.text = texto.text.Substring(0, texto.text.Length - 1);
    }
    public void BorrarTodo()
    {
        AudioManager.instance.ReproducirBoton();
        texto.text = "";
    }
}
