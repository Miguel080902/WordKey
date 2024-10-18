using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IrSeleccion : MonoBehaviour
{
    public void IrEscenaSeleccion()
    {
        AudioManager.instance.ReproducirBoton();
        SceneManager.LoadScene("SeleccionNivel");
    }
}
