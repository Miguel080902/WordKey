using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IrSiguienteNivel : MonoBehaviour
{
    public void Siguiente()
    {
        AudioManager.instance.ReproducirBoton();
        CoinManager.instance.SumarScena();
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indiceEscenaActual+1);
    }
}
