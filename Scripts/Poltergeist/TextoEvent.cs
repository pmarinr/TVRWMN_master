using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoEvent : MonoBehaviour { 
    // Start is called before the first frame update
    Text texto;
    int tipoMod = 0;

    void Start()
    {
       
        GameEvents.current.demonText += MostrarTexto;
        TextoIncompleto("Hola esto es un texto nuevo");
        texto = GetComponent<Text>();
    }

    

    public void MostrarTexto(string txt)
    {

        switch (tipoMod)
        {   
            case 0:
                texto.text = TextoInvertido(txt);
                break;
            case 1:
                texto.text = TextoIncompleto(txt);
                break;
            default:
                texto.text = TextoDesordenado(txt);
                break;
        }

        tipoMod = tipoMod > 2 ? 0 : tipoMod + 1;
        
    }

    private string TextoInvertido(string txt)
    {
        string textoMod = " ";
        for (int i = txt.Length - 1; i >= 0; i--)
        {
            textoMod += txt[i];
        }
        Debug.Log("Texto inverd"+textoMod);
        return textoMod;
    }

    private string TextoIncompleto(string txt)
    {
        string textoMod = " ";
        string caracteres = ",_`'|:¨";
        for (int i = 0;i < txt.Length ; i++)
        {
            int loteria = Random.Range(0, 3);
            if (loteria == 2 && txt[i]!=' ')
            {
                textoMod += caracteres[Random.Range(0,caracteres.Length)];
            }
            else { 
                textoMod += txt[i]; 
            }

            
        }
        Debug.Log("Texto inverd" + textoMod);
        return textoMod;
    }

    private string TextoDesordenado(string txt)
    {
        string textoMod = " ";

        string palabra;
        List<string> listaPalabras = new List<string>(txt.Split(' '));


        while (listaPalabras.Count > 0)
        {
            palabra = listaPalabras[Random.Range(0, listaPalabras.Count)];
            textoMod += palabra + " ";
            listaPalabras.Remove(palabra);
        }

        Debug.Log("Texto desordenado: " + textoMod);
        return textoMod;

       
    }
}
