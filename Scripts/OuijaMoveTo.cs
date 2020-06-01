using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using UnityEngine;

public class OuijaMoveTo : MonoBehaviour
{
  
    AudioSource audioSource;
    bool activa = false;
    private Vector3 destino;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameEvents.current.moveToOuija += MoveTo;
        GameEvents.current.activaOuija += setActive;
    }

    // Update is called once per frame
   

    public void MoveTo(Vector3 pos)
    {
        if (activa) { 
        transform.DOLookAt(pos, .5f);
        transform.DOMove(pos, 2f);
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.Play();
        }
    }

    public void setActive(bool active)
    {
        Debug.Log("SetActive "+active);
        activa = active;
    }

}
