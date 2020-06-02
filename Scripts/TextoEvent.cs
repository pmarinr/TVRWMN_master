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

    

    void MostrarTexto(string txt)
    {

       
         
        
    }

    private string TextoInvertido(string txt)
    {
        string textoMod = "";
        for (int i = txt.Length - 1; i > 0; i--)
        {
            textoMod += txt[i];
        }

        return textoMod;
    }
}
