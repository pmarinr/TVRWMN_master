﻿using System.Collections;
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


        texto.text = txt;
        
    }
}
