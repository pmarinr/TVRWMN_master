using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManoDch : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameController.RightHand = this.transform;
    }

  
}
