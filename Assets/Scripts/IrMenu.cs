using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IrMenu : MonoBehaviour
{
    public void IrEscenaMenu()
    {
        AudioManager.instance.ReproducirBoton();
        SceneManager.LoadScene("MenuPrincipal");
    }
}
