using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManoIzq : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameController.LeftHand = this.transform;
    }


}
