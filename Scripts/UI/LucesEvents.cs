using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LucesEvents : MonoBehaviour { 
    // Start is called before the first frame update
    Light luz;
   
    void Start()
    {
        GameEvents.current.onLightOff += Apagar;
        GameEvents.current.onLightOn += Encender;

        luz = GetComponent<Light>();
    }

    void Apagar()
    {
        luz.enabled = false;
      
    }

    void Encender(string nombre)
    {
        
       
        if (transform.CompareTag(nombre))
        {
            //GameEvents.current.ApagarLuces();
            luz.enabled = !luz.enabled;
           
        }
        else
        {
            Apagar();
            
        }
        
    }
}
