using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ModifyText : MonoBehaviour
{
    public List<string> Palabras;
    public List<GameObject> textos;
    private int cont = 0;
    void Start()
    {

        for (int i=0;i<6; i++)
        {
            Palabras[i] = Palabras[i].ToUpper();
        }
        GameObject[] objetosEncontradosArray = GameObject.FindGameObjectsWithTag("Palabra");
        textos = new List<GameObject>(objetosEncontradosArray);
        foreach(GameObject texto in textos)
        {
            TextMeshProUGUI tmp = texto.GetComponent<TextMeshProUGUI>();
            string palabraAsignada="";
            foreach(char punto in Palabras[cont])
            {
                if (punto != ' ')
                    palabraAsignada += "_";
                else
                    palabraAsignada += " ";
            }
            tmp.text = palabraAsignada;
            tmp.characterSpacing = 15f;
            cont++;
        }
    }
}
