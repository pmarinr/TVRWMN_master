using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Necesitamos crear variables estaticas para poder hacer referencias a objetos entre escenas
 * 
 * 
 * */
public class GameController : MonoBehaviour
{
    public static Transform Player;
    public static Transform LeftHand;
    public static Transform RightHand;


    public Transform Player2;
    public Transform LeftHand2;
    public Transform RightHand2;

    public static void  UpdatePlayer()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    public static void UpdateLeftHand()
    {
        Player = GameObject.FindWithTag("PlayerManoIzq").transform;
    }

    public static void UpdateRightHand()
    {
        Player = GameObject.FindWithTag("PlayerManoDch").transform;
    }

    private void Update()
    {
        Player2 = Player;
        LeftHand2 = LeftHand;
        RightHand2 = RightHand;
    }


}
