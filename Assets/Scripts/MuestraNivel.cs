using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MuestraNivel : MonoBehaviour
{
    public GameObject[] niveles;
    public Button sig;
    public Button ant;
    int cont = 0;
    private void Start()
    {
        MostrarNivel();
    }
    public void Siguiente()
    {
        AudioManager.instance.ReproducirBoton();
        if (cont < 5)
            cont++;
        MostrarNivel();
    }
    public void Anterior()
    {
        AudioManager.instance.ReproducirBoton();
        if (cont>0)
        cont--;
        MostrarNivel();
    }
    public void MostrarNivel()
    {
        int iteracion = 0;
        foreach(GameObject nivel in niveles)
        {
            if(iteracion==cont)
            {
                nivel.SetActive(true);
            }else
            {
                nivel.SetActive(false);
            }
            iteracion++;
        }
        if(cont==0)
        {
            ant.interactable = false;
        }else
        {
            ant.interactable = true;
        }
        if (cont == 5)
        {
            sig.interactable = false;
        }
        else
        {
            sig.interactable = true;
        }
    }
}
