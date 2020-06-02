﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vela : MonoBehaviour
{    
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.activeOuija += Activar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activar(bool active)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }
}
