using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animator))]
public class Ghost : MonoBehaviour
{
    Animator anim;
    BoxCollider boxcol;
    public float restart = 20;
            
            
// Start is called before the first frame update
void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        boxcol = gameObject.GetComponent<BoxCollider>();
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ocultar()
    {
        boxcol.enabled = false;
        anim.SetTrigger("Activar");
        Invoke("Mostrar", restart);
    }

    public void Mostrar()
    {
        anim.SetTrigger("Reiniciar");
        boxcol.enabled = true;
    }
}
