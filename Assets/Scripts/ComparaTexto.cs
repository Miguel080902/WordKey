using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ComparaTexto : MonoBehaviour
{
    public GameObject Win;
    public ModifyText Contenedor;
    public string textoIngresado;
    public TextMeshProUGUI input;
    public Button btnItem;
    private int palabrasAdivinadas = 0;
    private void Start()
    {
        palabrasAdivinadas = 0;
        Win.SetActive(false);
        CoinManager.instance.BuscarTexto();

    }
    public void AsignarTexto()
    {
        textoIngresado = input.text;
        AudioManager.instance.ReproducirTecla();
        Comparar();
        input.text = string.Empty;
    }
    public void Comparar()
    {
        int iteracion = 0;
        foreach (string palabra in Contenedor.Palabras)
        {
            if (textoIngresado.ToUpper() == palabra.ToUpper())
            {
                string palabraComparada = Contenedor.textos[iteracion].GetComponent<TextMeshProUGUI>().text;
                if (palabraComparada.Contains('_'))
                {
                    
                    Contenedor.textos[iteracion].GetComponent<TextMeshProUGUI>().text= textoIngresado.ToUpper();
                    Contenedor.textos[iteracion].GetComponent<TextMeshProUGUI>().characterSpacing = 8f;
                    palabrasAdivinadas++;
                    AudioManager.instance.ReproducirPalabra();
                    bool palabraEncontrada = false;
                    if (palabrasAdivinadas==6)
                    {
                        palabraEncontrada = true;
                    }
                    
                    if(palabrasAdivinadas<6)
                    {
                        bool palabraIncompleta = false;
                        foreach(GameObject palabraIterada in Contenedor.textos)
                        {
                            int contVacio = 0;
                            foreach (char letraIterada in palabraIterada.GetComponent<TextMeshProUGUI>().text)
                            {
                                if (letraIterada == '_')
                                {
                                    contVacio++;
                                }
                                if(contVacio>2)
                                {
                                    palabraIncompleta = true;
                                }
                            }
                        }
                        while (!palabraEncontrada&&palabraIncompleta)
                        {
                            int ran = ObtenerNumeroAleatorio();
                            if (ran != iteracion)
                            {
                                int contVacio = 0;
                                string palabraRellenar = Contenedor.textos[ran].GetComponent<TextMeshProUGUI>().text;
                                foreach (char letra in palabraRellenar)
                                {
                                    if (letra == '_')
                                    {
                                        contVacio++;
                                    }
                                }
                                if (contVacio > 2)
                                {
                                    for(int te=0;te<=1;te++)
                                    {
                                        List<int> posiciones = new List<int>();
                                        for (int i = 0; i < palabraRellenar.Length; i++)
                                        {
                                            if (palabraRellenar[i] == '_')
                                            {
                                                posiciones.Add(i);
                                            }
                                        }
                                        char[] arregloPalabra = palabraRellenar.ToCharArray(); // Convertir la palabra en un arreglo de caracteres
                                        int cantPos = 0;
                                        foreach (int posicion in posiciones)
                                        {
                                            cantPos++;
                                        }
                                        int pos = Random.Range(0, cantPos);
                                        arregloPalabra[posiciones[pos]] = Contenedor.Palabras[ran][posiciones[pos]]; // Modificar el carácter en el índice especificado

                                        palabraRellenar = new string(arregloPalabra);
                                        Contenedor.textos[ran].GetComponent<TextMeshProUGUI>().text = palabraRellenar;
                                    }                                   
                                    palabraEncontrada = true;
                                }
                            }
                        }
                    }
                    if(palabrasAdivinadas>5)
                    Victoria();
                }              
            }
            iteracion++;
        }
    }
    public void Victoria()
    {
        AudioManager.instance.ReproducirVictoria();
        int indexNivelActual = SceneManager.GetActiveScene().buildIndex;
        ControladorNiveles.instancia.desbloquearNiveles = indexNivelActual;
        ControladorNiveles.instancia.AumentarNiveles();
        Win.SetActive(true);
        CoinManager.instance.AddCoins(5);
    }
    int ObtenerNumeroAleatorio()
    {
        return Random.Range(0, 6);
    }

    public void CompraItem()
    {
        CoinManager.instance.RestarCoins(5);
        AudioManager.instance.ReproducirPalabra();
        bool palabraDescubierta = false;
        while(!palabraDescubierta)
        {
            int posicion = ObtenerNumeroAleatorio();
            string palabraComparada = Contenedor.textos[posicion].GetComponent<TextMeshProUGUI>().text;
            if (palabraComparada.Contains('_'))
            {
                Contenedor.textos[posicion].GetComponent<TextMeshProUGUI>().text = Contenedor.Palabras[posicion];
                palabrasAdivinadas++;
                palabraDescubierta = true;
            }
        }
       
        if (palabrasAdivinadas > 5)
            Victoria();
    }
    private void Update()
    {
        if (CoinManager.instance.GetCoins() < 5)
        {
            btnItem.interactable = false;
        }else
        {
            btnItem.interactable = true;
        }
    }
}
