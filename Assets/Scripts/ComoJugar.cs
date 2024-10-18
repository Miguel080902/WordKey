using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComoJugar : MonoBehaviour
{
    public GameObject panelComoJugar;
    public void MostrarPanel()
    {
        AudioManager.instance.ReproducirBoton();
        panelComoJugar.SetActive(true);

    }
    public void OcultarPanel()
    {
        AudioManager.instance.ReproducirBoton();
        panelComoJugar.SetActive(false);
    }
}
