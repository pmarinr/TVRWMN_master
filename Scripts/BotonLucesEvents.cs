using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonLucesEvents : MonoBehaviour { 
    // Start is called before the first frame update
    Light luz;
    public Sprite icono_on, icono_off;
    public Color color_on, color_off;
    Image boton;
    void Start()
    {
        GameEvents.current.onLightOff += Apagar;
        GameEvents.current.onLightOn += Encender;

        boton = GetComponent<Image>();
    }

    void Apagar()
    {
        boton.sprite = icono_off;
        boton.color = color_off;
    }

    void Encender(string nombre)
    {
        if (transform.CompareTag(nombre))
        {
           
            boton.sprite = icono_on;
            boton.color = color_on;
        }
        else
        {
            Apagar();
            
        }
        
    }
}
