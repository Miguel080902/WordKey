using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;   
using UnityEngine.SceneManagement;
public class IrNivel : MonoBehaviour
{
    public int indiceEscena; // Índice de la escena que deseas cargar
    public void Start()
    {
        TextMeshProUGUI textoHijo = GetComponentInChildren<TextMeshProUGUI>();
        if(textoHijo!=null)
        {
            textoHijo.text = (indiceEscena - 1).ToString();
        }
    }
    public void CambiarEscenaPorIndice()
    {
        AudioManager.instance.ReproducirBoton();
        CoinManager.instance.SumarScena();
        SceneManager.LoadScene(indiceEscena);
    }
}
