using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesAds : MonoBehaviour
{
    public void MostrarAnuncio()
    {
        AudioManager.instance.ReproducirBoton();
        AdsInitializer.instance.ShowAd();
    }
    public void OcultarPanel()
    {
        AudioManager.instance.ReproducirBoton();
        AdsInitializer.instance.OcultarPanelAnuncio();
    }
    public void MostrarPanel()
    {
        AudioManager.instance.ReproducirBoton();
        AdsInitializer.instance.MostrarPanelAnuncio();
    }
}
