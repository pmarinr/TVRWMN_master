using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoEvent : MonoBehaviour { 
    // Start is called before the first frame update
    Text texto;
   
    void Start()
    {
       
        GameEvents.current.demonText += MostrarTexto;

        texto = GetComponent<Text>();
    }

    

    public void MostrarTexto(string txt)
    {

        texto.text = TextoInvertido(txt);
    }

    private string TextoInvertido(string txt)
    {
        string textoMod = "";
        for (int i = txt.Length - 1; i >= 0; i--)
        {
            textoMod += txt[i];
        }
        Debug.Log("Texto"+textoMod);
        return textoMod;
    }
}
