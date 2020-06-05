using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCabeza : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameController.Player = this.transform;
    }

   
}
